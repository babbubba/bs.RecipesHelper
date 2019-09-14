using bs.RecipesHelper.Models.ViewModel.Base;

namespace bs.RecipesHelper.Models.ViewModel.Ingredients
{
    public class IngredientInfo : IIdentityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
