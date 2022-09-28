using RestaurantApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApi
{
    public class RestaurantSeeder
    {
        public readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast food",
                    Description =
                        "KFC (short for kentucky fried chicken) is an american fast food restaurant",
                    Contactemail = "contact@kfc.com",
                    HasDevilery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30m,
                        },
                    },
                    Addres = new Address()
                    {
                        City = "Krakow",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },

                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description =
                        "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises",
                    Contactemail = "contact@mcdonald.com",
                    HasDevilery = true,
                    Addres = new Address()
                    {
                        City = "Kraków",
                        Street = "Szewska 2",
                        PostalCode = "30-001",
                    }
                }
            };
            return restaurants;
        }

    }
}
