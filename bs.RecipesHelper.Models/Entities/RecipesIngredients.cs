using bs.Data.Interfaces.BaseEntities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace bs.RecipesHelper.Models.Entities
{
    public class RecipesIngredients : BaseEntity
    {
        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual IngredientVariant PossibleVariants { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual MeasureUnit Um { get; set; }
        public virtual bool IsOptional { get; set; }
    }

    class RecipesIngredientsMap : SubclassMap<RecipesIngredients>
    {
        public RecipesIngredientsMap()
        {
            Abstract();
            Table("RecipesIngredients");
            References(x=>x.Recipe).Not.Nullable();
            References(x=>x.Ingredient).Not.Nullable();
            Map(x => x.Quantity);
            Map(x => x.Um);
            Map(x => x.IsOptional);
        }
    }
}
