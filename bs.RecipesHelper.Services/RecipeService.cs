using bs.Data;
using bs.Data.Interfaces;
using bs.RecipesHelper.Models.Entities;
using bs.RecipesHelper.Models.Repositories;
using bs.RecipesHelper.Models.ViewModel.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bs.RecipesHelper.Services
{
    public class RecipeService
    {
        private readonly IUnitOfWork uow;
        private readonly IngredientRepository ingerdientRepo;

        public RecipeService(IUnitOfWork uow, IngredientRepository ingerdientRepo)
        {
            this.uow = uow;
            this.ingerdientRepo = ingerdientRepo;
        }
        public IEnumerable<IngredientDetail> GetIngredientsDetail(string ingredientNamePattern, bool enabledOnly)
        {

            var ingredients = ingerdientRepo.GetIngredients(ingredientNamePattern, enabledOnly);
            return ingredients.Select(i => new IngredientDetail
            {
                Id = i.Id.ToString(),
                Name = i.Name,
                Description = i.Description,
                IsEnabled = i.IsEnabled,
                Categories = i.Categories.Select(c => new IngredientCategoryDetail
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Description = c.Description,
                    IsEnabled = c.IsEnabled
                }),
                Variants = i.Variants.Select(v => new IngredientVariantDetail
                {
                    Id = v.Id.ToString(),
                    Name = v.Name,
                    Description = v.Description,
                    IsEnabled = v.IsEnabled
                })
            }); ;
        }

        public IngredientDetail GetIngredientDetail(string id)
        {
            var i = ingerdientRepo.GetIngredientById(Guid.Parse(id));

            if (i == null) throw new ApplicationException($"Cannot find any ingredient with id: {id??"null"}");
            //TODO: Must implements automapping!!

            return new IngredientDetail
            {
                Id = i.Id.ToString(),
                Name = i.Name,
                Description = i.Description,
                IsEnabled = i.IsEnabled,
                Categories = i.Categories.Select(c => new IngredientCategoryDetail
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Description = c.Description,
                    IsEnabled = c.IsEnabled
                }),
                Variants = i.Variants.Select(v => new IngredientVariantDetail
                {
                    Id = v.Id.ToString(),
                    Name = v.Name,
                    Description = v.Description,
                    IsEnabled = v.IsEnabled
                })
            }; ;
        }
        public IEnumerable<IngredientInfo> GetIngredientsInfo(GetIngredientsInfoViewModel parameter)
        {
            //TODO: Must implements automapping!!
            IEnumerable<Ingredient> ingredients;

            try
            {
                ingredients = ingerdientRepo.GetIngredients(/*(parameter.IngredientNamePattern=="null")?null:*/ parameter.IngredientNamePattern, parameter.EnabledOnly);
            }
            catch (Exception)
            {
                throw;
            }
            return ingredients.Select(i => new IngredientInfo
            {
                Id = i.Id.ToString(),
                Name = i.Name,
                IsEnabled = i.IsEnabled,
                
            });
        }

        public void CreateIngredient(IngredientInfo newIngredient)
        {
            //TODO: Must implements automapping!!
            uow.BeginTransaction();
            var ingredient = new Ingredient {
                 Name = newIngredient.Name,
                 IsEnabled = newIngredient.IsEnabled
            };
            ingerdientRepo.CreateNewIngredient(ingredient);
            newIngredient.Id = ingredient.Id.ToString();
            uow.Commit();
        }
    }
}
