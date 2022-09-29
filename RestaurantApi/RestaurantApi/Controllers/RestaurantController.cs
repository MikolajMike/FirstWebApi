﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Entities;
using RestaurantApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApi.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantController(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurant = _dbContext
                .Restaurants
                .Include(r => r.Dishes)
                .Include(r => r.Addres)
                .ToList();

            var restaurantDto = _mapper.Map<List<RestaurantDto>>(restaurant);

            return Ok(restaurantDto);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _dbContext
                .Restaurants
                .Include(r => r.Dishes)
                .Include(r => r.Addres)
                .FirstOrDefault(e => e.Id == id);

            if(restaurant is null) return NotFound();

            var restaurantDto = _mapper.Map<List<RestaurantDto>>(restaurant);

            return Ok(restaurantDto);
        }
    }
}
