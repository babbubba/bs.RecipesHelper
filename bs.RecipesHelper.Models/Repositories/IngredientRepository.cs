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

        /// <summary>
        /// Creates the new ingredient.
        /// </summary>
        /// <param name="newIngredient">The new ingredient.</param>
        /// <exception cref="ArgumentNullException">newIngredient - Mandatory paramerter.</exception>
        public void CreateNewIngredient(Ingredient newIngredient)
        {
            if (newIngredient == null)
                throw new ArgumentNullException("newIngredient", "Mandatory paramerter.");

            Create(newIngredient);
        }

        /// <summary>
        /// Creates the new ingredient category.
        /// </summary>
        /// <param name="newIngredientCategory">The new ingredient category.</param>
        /// <exception cref="ArgumentNullException">newIngredientCategory - Mandatory paramerter.</exception>
        public void CreateNewIngredientCategory(IngredientCategory newIngredientCategory)
        {
            if (newIngredientCategory == null)
                throw new ArgumentNullException("newIngredientCategory", "Mandatory paramerter.");

            Create(newIngredientCategory);
        }

        /// <summary>
        /// Gets the active ingredients.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ingredient> GetActiveIngredients()
        {
            return GetAll<Ingredient>()
                .Where(x=> x.IsEnabled && !x.IsDeleted);
        }
    }
}
