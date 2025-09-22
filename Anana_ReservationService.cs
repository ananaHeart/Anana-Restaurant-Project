using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Anana_Restaurant.Models;

namespace Anana_Restaurant.Services
{
    public class ReservationService : IReservationService
    {
        private readonly Anana_RestaurantReservationDbContext _restaurantDbContext;

        public ReservationService(Anana_RestaurantReservationDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
        }

        public void AddReservation(Reservation newReservation)
        {
            var bookedRestaurant = _restaurantDbContext.Restaurants.FirstOrDefault(c => c.Id == newReservation.RestaurantId);
            if (bookedRestaurant == null)
            {
                throw new ArgumentException("The restaurant to be reserved cannot be found.");
            }
            newReservation.RestaurantName = bookedRestaurant.name;
            _restaurantDbContext.Reservations.Add(newReservation);
            _restaurantDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);
            _restaurantDbContext.SaveChanges();
        }

        public void DeleteReservation(Reservation reservation)
        {
            var reservationToDelete = _restaurantDbContext.Reservations.FirstOrDefault(b => b.Id == reservation.Id);
            if (reservationToDelete != null)
            {
                _restaurantDbContext.Reservations.Remove(reservationToDelete);
                _restaurantDbContext.ChangeTracker.DetectChanges();
                Console.WriteLine(_restaurantDbContext.ChangeTracker.DebugView.LongView);
                _restaurantDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The reservation to delete cannot be found.");
            }
        }

        // FIX: Added a body and closing brace for this method.
        public void EditReservation(Reservation updatedReservation)
        {
            // You still need to write the code for this method.
            throw new NotImplementedException();
        }

        // FIX: This method is now correctly defined *after* EditReservation.
        public IEnumerable<Reservation> GetAllReservations()
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationById(ObjectId id)
        {
            throw new NotImplementedException();
        }
    }
}