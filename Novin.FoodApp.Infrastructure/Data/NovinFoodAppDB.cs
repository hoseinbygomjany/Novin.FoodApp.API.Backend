using Microsoft.EntityFrameworkCore;
using Novin.FoodApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Infrastructure.Data
{
    public class NovinFoodAppDB :DbContext  
    {
        public DbSet <ApplicationUser> ApplicationUsers { get; set; }
        
        public DbSet<Restaurant> Restaurants { get; set; }


        public NovinFoodAppDB(DbContextOptions<NovinFoodAppDB> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<ApplicationUser>()
                .HasKey(p => p.Username);
                
        }
    }
}
