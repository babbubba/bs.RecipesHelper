using bs.RecipesHelper.Models.ViewModel.Base;
using System.Collections.Generic;

namespace bs.RecipesHelper.Models.ViewModel.Ingredients
{
    public class IngredientDetail : IIdentityViewModel
    {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public IEnumerable<IngredientCategoryDetail> Categories { get; set; }
            public IEnumerable<IngredientVariantDetail> Variants { get; set; }
            public bool IsEnabled { get; set; }

        }
}
