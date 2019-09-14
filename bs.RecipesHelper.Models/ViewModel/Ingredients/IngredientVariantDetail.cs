using bs.RecipesHelper.Models.ViewModel.Base;

namespace bs.RecipesHelper.Models.ViewModel.Ingredients
{
        public class IngredientVariantDetail : IIdentityViewModel
    {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsEnabled { get; set; }

        }
}
