using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamsSoup.Auth;
using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Soup> Soups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "Clear Soups", CategoryDescription = "Clear Soups based on broths" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, CategoryName = "Cream Soups", CategoryDescription = "Soups made with cream" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, CategoryName = "Chicken Soups", CategoryDescription = "Soups made with chicken" });

            //seed Soups
            modelBuilder.Entity<Soup>().HasData
                (
                new Soup
                {
                    Id = 1,
                    SoupName = "Vegetable Clear Soup",
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.",
                    Price = 10m,
                    CategoryId = 1,
                    IsSoupOfTheWeek = false
                });
            modelBuilder.Entity<Soup>().HasData
                (new Soup
                {
                    Id = 2,
                    SoupName = "Mushroom Soup",
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.",
                    Price = 15m,
                    CategoryId = 2,
                    IsSoupOfTheWeek = false
                });
            modelBuilder.Entity<Soup>().HasData
                (new Soup
                {
                    Id = 3,
                    SoupName = "Chicken and Chard Pasta Fagioli",
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.",
                    Price=12m,
                    CategoryId = 3,
                    IsSoupOfTheWeek = false
                });
            modelBuilder.Entity<Soup>().HasData
                (new Soup
                {
                    Id = 4,
                    SoupName = "Japanese Soup",
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.",
                    Price = 12m,
                    CategoryId = 1,
                    IsSoupOfTheWeek = true
                });

        }
    }
}
