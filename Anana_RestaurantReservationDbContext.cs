using Microsoft.EntityFrameworkCore;
using Anana_Restaurant.Models;

namespace Anana_Restaurant.Services
{
    public class Anana_RestaurantReservationDbContext : DbContext
    {
        // Properties
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        // Constructor - MUST be inside the class
        public Anana_RestaurantReservationDbContext(DbContextOptions options)
        {
        }

        // OnModelCreating method - MUST be inside the class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>();
            modelBuilder.Entity<Reservation>();
        }
    } // <-- FIX: The closing brace for the class goes here.
}


    
