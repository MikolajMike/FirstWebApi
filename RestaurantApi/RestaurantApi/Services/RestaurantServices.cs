using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using RestaurantApi.Entities;
using RestaurantApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace RestaurantApi.Services
{
    public interface IRestaurantServices
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
        bool Delete(int id);
        bool Modify(int id, ModifyRestaurantDto dto);
    }

    public class RestaurantServices : IRestaurantServices
    {
        
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantServices> _logger;

        public RestaurantServices(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantServices> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Modify(int id, ModifyRestaurantDto dto)
        {
            var restaurant = _dbContext
                 .Restaurants
                 .FirstOrDefault(e => e.Id == id);

            if (restaurant is null) return false;
            
            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.HasDevilery = dto.HasDevilery;

            _dbContext.Update(restaurant);
            _dbContext.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {

            _logger.LogError($"Restaurant with id: {id} Delete action invoked");

            var restaurant = _dbContext
                 .Restaurants
                 .FirstOrDefault(e => e.Id == id);

            if (restaurant is null) return false;

            _dbContext.Restaurants.Remove(restaurant);
            _dbContext.SaveChanges();

            return true;

        }

        public RestaurantDto GetById(int id)
        {

            var restaurant = _dbContext
                .Restaurants
                .Include(r => r.Dishes)
                .Include(r => r.Addres)
                .FirstOrDefault(e => e.Id == id);

            if (restaurant is null) return null;

            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;

        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
            .Restaurants
            .Include(r => r.Dishes)
            .Include(r => r.Addres)
            .ToList();

            var restaurantDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

            return restaurantDtos;
        }

        public int Create(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();

            return restaurant.Id;
        }

    }
}
