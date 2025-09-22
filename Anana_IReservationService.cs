using MongoDB.Bson;
using Anana_Restaurant.Models;

namespace Anana_Restaurant.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(ObjectId id);
        void AddReservation(Reservation newReservation);
        void EditReservation(Reservation updatedReservation);
        void DeleteReservation(Reservation reservationToDelete);
    }
}