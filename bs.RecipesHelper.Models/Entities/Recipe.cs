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
        public virtual IList<RecipesIngredients> RecipesIngredients { get; set; }

    }

    class RecipeMap : SubclassMap<Recipe>
    {
        public RecipeMap()
        {
            Abstract();
            Table("Recipes");
            Map(x => x.Complexity);
            Map(x => x.Instruction);
            HasMany(x => x.RecipesIngredients);
        }
    }
}
