using bs.Data.Interfaces.BaseEntities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace bs.RecipesHelper.Models.Entities
{
    public class Recipe : BaseEntity
    {
        public virtual int Complexity { get; set; }
        public virtual string Instruction { get; set; }
        public virtual int NeededMinutes { get; set; }
        public virtual IList<RecipesIngredients> RecipesIngredients { get; set; }
        public virtual IList<Recipe> RelatedRecipes { get; set; }

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
        }
    }
}
