﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uchebkaNyamNyamMukachev.BD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NyamNyam_Session2_mukachevEntities : DbContext
    {
        public NyamNyam_Session2_mukachevEntities()
            : base("name=NyamNyam_Session2_mukachevEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<CookingStage> CookingStage { get; set; }
        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientOfStage> IngredientOfStage { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderedDish> OrderedDish { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
    }
}
