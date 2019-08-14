using bs.Data.Interfaces.BaseEntities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace bs.RecipesHelper.Models.Entities
{
    public class IngredientCategory : BaseEntity, IEnableableEntity, ILogicallyDeletableEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsEnabled { get; set; }

        public virtual IList<Ingredient> Ingredients { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionDate { get; set; }
    }

    class IngredientCategoryMap : SubclassMap<IngredientCategory>
    {
        public IngredientCategoryMap()
        {
            Abstract();
            Table("IngredientCategories");

            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.IsEnabled);
            HasMany(x => x.Ingredients).Cascade.All().Inverse();
            Map(x => x.IsDeleted);
            Map(x => x.DeletionDate);

        }
    }
}
