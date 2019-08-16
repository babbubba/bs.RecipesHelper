using bs.Data.Interfaces.BaseEntities;
using FluentNHibernate.Mapping;
using System;

namespace bs.RecipesHelper.Models.Entities
{
    public class IngredientVariant : BaseAuditableEntity, IEnableableEntity, ILogicallyDeletableEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual bool IsEnabled { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionDate { get; set; }
    }

    class IngredientVariantMap : SubclassMap<IngredientVariant>
    {
        public IngredientVariantMap()
        {
            Abstract();
            Table("IngredientVariants");

            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.IsEnabled);

            Map(x => x.IsDeleted);
            Map(x => x.DeletionDate);
        }
    }
}
