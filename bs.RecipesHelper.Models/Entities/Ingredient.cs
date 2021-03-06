﻿using bs.Data.Interfaces.BaseEntities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace bs.RecipesHelper.Models.Entities
{
    public class Ingredient : BaseAuditableEntity, IEnableableEntity, ILogicallyDeletableEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<IngredientCategory> Categories { get; set; }
        public virtual IList<IngredientVariant> Variants { get; set; }

        public virtual bool IsEnabled { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionDate { get; set; }
    }

    class IngredientMap : SubclassMap<Ingredient>
    {
        public IngredientMap()
        {
            Abstract();
            Table("Ingredients");

            Map(x => x.Name);
            Map(x => x.Description);
            HasMany(x => x.Categories).Cascade.None();
            HasMany(x => x.Variants).Cascade.All();

            Map(x => x.IsEnabled);
            Map(x => x.IsDeleted);
            Map(x => x.DeletionDate);
        }
    }
}
