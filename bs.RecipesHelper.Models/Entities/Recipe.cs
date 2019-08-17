using bs.Data.Interfaces.BaseEntities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace bs.RecipesHelper.Models.Entities
{
    public class Recipe : BaseAuditableEntity, IEnableableEntity, ILogicallyDeletableEntity
    {
        public virtual int Complexity { get; set; }
        public virtual string Instruction { get; set; }
        public virtual int NeededMinutes { get; set; }
        public virtual IList<RecipesIngredients> RecipesIngredients { get; set; }
        public virtual IList<Recipe> RelatedRecipes { get; set; }

        public virtual bool IsEnabled { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionDate { get; set; }

    }

    class RecipeMap : SubclassMap<Recipe>
    {
        public RecipeMap()
        {
            Abstract();
            Table("Recipes");
            Map(x => x.Complexity);
            Map(x => x.Instruction).Not.Nullable();
            Map(x => x.NeededMinutes).Not.Nullable();
            HasMany(x => x.RecipesIngredients);
            HasMany(x => x.RelatedRecipes);

            Map(x => x.IsEnabled);
            Map(x => x.IsDeleted);
            Map(x => x.DeletionDate);

        }
    }
}
