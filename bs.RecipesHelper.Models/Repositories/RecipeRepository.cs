using bs.Data;
using bs.Data.Interfaces;
using bs.RecipesHelper.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bs.RecipesHelper.Models.Repositories
{
    public class RecipeRepository : Repository
    {
        public RecipeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void CreateNewRecipe(Recipe newRecipe)
        {
            if (newRecipe == null)
                throw new ArgumentNullException("newRecipe", "Mandatory paramerter.");

            Create(newRecipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException("recipe", "Mandatory paramerter.");

            Update(recipe);
        }

        public IEnumerable<Recipe> GetActiveRecipes()
        {
            return GetAll<Recipe>()
                .Where(x => x.IsEnabled && !x.IsDeleted);
        }

        public void AddIngredientToRecipe(Recipe recipe, Ingredient ingredient, decimal quantity, MeasureUnit um, bool isOptional = false, IEnumerable<IngredientVariant> possibleVariants = null)
        {
            if (recipe == null)
                throw new ArgumentNullException("recipe", "Mandatory paramerter.");
            if (ingredient == null)
                throw new ArgumentNullException("ingredient", "Mandatory paramerter.");
            if (recipe.RecipesIngredients.Any(r => r.Ingredient.Id == ingredient.Id))
                throw new ApplicationException("Recipe already contains ingredient.");
      

            var recipeIngredient = new RecipesIngredients
            {
                Ingredient = ingredient,
                Recipe = recipe,
                Quantity = quantity,
                Um = um,
                IsOptional = isOptional,
                PossibleVariants = possibleVariants.ToList()
            };

            recipe.RecipesIngredients.Add(recipeIngredient);
        }
    }
}
