using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Anana_Restaurant.Models;
using Anana_Restaurant.Services;
using Anana_Restaurant.ViewModels;

namespace Anana_Restaurant.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _RestaurantService;

        public RestaurantController(IRestaurantService RestaurantService)
        {
            _RestaurantService = RestaurantService;
        }

        public IActionResult Index()
        {
            RestaurantListViewModel viewModel = new()
            {
                Restaurants = _RestaurantService.GetAllRestaurants(),
            };

            return View(viewModel);
        }
    }
}