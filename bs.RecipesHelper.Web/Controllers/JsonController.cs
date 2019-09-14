using bs.RecipesHelper.Models.ViewModel.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bs.RecipesHelper.Web.Controllers
{
    public abstract class JsonController : ControllerBase
    {
        protected virtual IActionResult ReturnOkOrError<TIn, TOut>(Func<TIn, TOut> expression, TIn parameter, string errorMessage = null)
        {
            TOut result = default(TOut);

            if (ModelState.IsValid)
            {
                try
                {
                    result = expression.Invoke(parameter);
                }
                catch (Exception ex)
                {
                    var message = errorMessage ?? "Error";
                    return BadRequest(message + ":\n" + ex.Message);
                }
                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        protected virtual IActionResult ReturnCreateOrError<TIn>(Action<TIn> expression, TIn parameter, string actionName, string controllerName, string errorMessage = null) where TIn : IIdentityViewModel
        {
            if (ModelState.IsValid)
            {
                try
                {
                    expression.Invoke(parameter);
                }
                catch (Exception ex)
                {
                    var message = errorMessage ?? "Error";
                    return BadRequest(message + ":\n" + ex.Message);
                }
                return CreatedAtAction(actionName,controllerName, new { id = parameter.Id }, parameter);
            }

            return BadRequest(ModelState);
        }
    }
}
