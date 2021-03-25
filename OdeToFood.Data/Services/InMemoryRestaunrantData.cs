using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaunrantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaunrantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "aby's Pizza", Cuisine = CuisineType.French},
                new Restaurant {Id = 2, Name = "Tersiguels", Cuisine = CuisineType.Chineese},
                new Restaurant {Id = 3, Name = "Mango Groove", Cuisine = CuisineType.Italaian}
            };
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
