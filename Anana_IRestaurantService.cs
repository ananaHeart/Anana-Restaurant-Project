using MongoDB.Bson;
using Anana_Restaurant.Models;

namespace Anana_Restaurant.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant>GetAllRestaurants();
        Restaurant? GetRestaurantById(ObjectId id);

        void AddRestaurant(Restaurant newRestaurant);
        void EditRestaurant(Restaurant updatedRestaurant);
        void DeleteRestaurant(Restaurant restaurantToDelete);
        // ...
    }

}