using Anana_Restaurant.Models;

namespace Anana_Restaurant.ViewModels
{
    public class ReservationListViewModel
    {
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}