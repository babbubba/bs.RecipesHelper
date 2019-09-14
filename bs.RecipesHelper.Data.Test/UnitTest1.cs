using bs.Data;
using bs.Data.Interfaces;
using bs.RecipesHelper.Models.Entities;
using bs.RecipesHelper.Models.Repositories;
using bs.RecipesHelper.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bs.RecipesHelper.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        private static IUnitOfWork CreateUnitOfWork_Sqlite()
        {
            var dbContext = new DbContext
            {
                ConnectionString = "Data Source=.\\bs.Data.Test.db;Version=3;BinaryGuid=False;",
                DatabaseEngineType = "sqlite",
                Create = true,
                Update = true,
                LookForEntitiesDllInCurrentDirectoryToo = true,
                UseExecutingAssemblyToo = true
            };
            var uOW = new UnitOfWork(dbContext);
            return uOW;
        }

        [TestMethod]
        public void TestEntity()
        {
            var uow = CreateUnitOfWork_Sqlite();
            var ingredientRepo = new IngredientRepository(uow);
            uow.BeginTransaction();
            var ingr = new Ingredient
            {
                Name = "Ingrediente di prova",
                Description = "Descrizione dell'ingrediente di prova",
                IsEnabled = true
            };


            ingredientRepo.CreateNewIngredient(ingr);

            uow.Commit();


        }

        [TestMethod]
        public void TestRecipeService()
        {
            var uow = CreateUnitOfWork_Sqlite();
            var ingredientRepo = new IngredientRepository(uow);
            var recipeService = new RecipeService(uow, ingredientRepo);
            var result = recipeService.GetIngredientsInfo(null, true);

        }

        [TestMethod]
        public void CreateIngredientTest()
        {
            var uow = CreateUnitOfWork_Sqlite();
            var ingredientRepo = new IngredientRepository(uow);
            //uow.BeginTransaction();

            var recipeService = new RecipeService(uow, ingredientRepo);
            recipeService.CreateIngredient("Cipolla", "Descrizione per cipolla", true);
            //uow.Commit();
        }
    }
}
