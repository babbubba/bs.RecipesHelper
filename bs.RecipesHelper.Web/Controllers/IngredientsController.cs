using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bs.RecipesHelper.Models.ViewModel.Ingredients;
using bs.RecipesHelper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;

namespace bs.RecipesHelper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : JsonController//ControllerBase
    {
        private readonly RecipeService recipeService;

        public IngredientsController(RecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet("[action]")]
        public IActionResult GetIngredientsDetail()
        {
            IEnumerable<IngredientDetail> result;
            result =  recipeService.GetIngredientsDetail(null,true);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetIngredientsInfo([FromQuery]GetIngredientsInfoViewModel parameter)
        {
            return ReturnOkOrError<GetIngredientsInfoViewModel, IEnumerable<IngredientInfo>>(recipeService.GetIngredientsInfo, parameter, "Error getting ingredients");

        }

        [HttpGet("[action]")]
        public IActionResult GetIngredientDetail(string id)
        {
            return ReturnOkOrError<string,IngredientDetail>(recipeService.GetIngredientDetail, id, "Error getting ingredient");
        }

        [HttpPost("[action]")]
        public IActionResult CreateIngredient([FromBody]IngredientInfo newIngredient)
        {
            return ReturnCreateOrError<IngredientInfo>(recipeService.CreateIngredient, newIngredient,"GetIngredientDetail","Ingredients","Error getting ingredient");
        }

    }

    public class NullableParamFromQueryAttribute : FromQueryAttribute
    {
        public NullableParamFromQueryAttribute()
        {

        }
    }
}