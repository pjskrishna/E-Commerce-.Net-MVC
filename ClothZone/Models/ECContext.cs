using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClothZone.Models
{
    public class ECContext : IdentityDbContext
    {
        public ECContext(DbContextOptions<ECContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LoginViewModel> loginviewmodels { get; set; }
        public DbSet<Uco> Ucos { get; set; }



    }
}