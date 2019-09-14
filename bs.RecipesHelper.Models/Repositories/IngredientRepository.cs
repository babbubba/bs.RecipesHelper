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
        /// Updates the ingredient.
        /// </summary>
        /// <param name="ingredient">The ingredient.</param>
        /// <exception cref="ArgumentNullException">newIngredient - Mandatory paramerter.</exception>
        public void UpdateIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
                throw new ArgumentNullException("newIngredient", "Mandatory paramerter.");

            Update(ingredient);
        }
        /// <summary>
        /// Gets the active ingredients.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ingredient> GetIngredients(string ingredientNamePattern, bool enabledOnly)
        {
            var query = GetAll<Ingredient>().Where(x => !x.IsDeleted);

            if(enabledOnly) query = query.Where(x => x.IsEnabled);

            if(!string.IsNullOrWhiteSpace(ingredientNamePattern)) query = query.Where(x => x.Name.Contains(ingredientNamePattern));

            return query;
        }
     

        /// <summary>
        /// Gets the ingredient by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Ingredient GetIngredientById(Guid id)
        {
            return GetById<Ingredient>(id);
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
        public void UpdateIngredient(IngredientCategory ingredientCategory)
        {
            if (ingredientCategory == null)
                throw new ArgumentNullException("newIngredient", "Mandatory paramerter.");

            Update(ingredientCategory);
        }
        /// <summary>
        /// Gets the active ingredient categories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IngredientCategory> GetActiveIngredientCategories()
        {
            return GetAll<IngredientCategory>()
                .Where(x => x.IsEnabled && !x.IsDeleted);
        }
        /// <summary>
        /// Gets the ingredient category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IngredientCategory GetIngredientCategoryById(Guid id)
        {
            return GetById<IngredientCategory>(id);
        }
     
    }
}
