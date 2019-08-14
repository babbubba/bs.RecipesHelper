using bs.Data;
using bs.Data.Interfaces;
using bs.RecipesHelper.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bs.RecipesHelper.Models.Repositories
{
    public class IngredientRepository : Repository
    {
        public IngredientRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public void CreateNewIngredient(Ingredient newIngredient)
        {
            if (newIngredient == null)
                throw new ArgumentNullException("newIngredient", "Mandatory paramerter.");

            Create(newIngredient);
        }

        public IEnumerable<Ingredient> GetActiveIngredients()
        {
            return GetAll<Ingredient>()
                .Where(x=> x.IsEnabled && !x.IsDeleted);
        }
    }
}
