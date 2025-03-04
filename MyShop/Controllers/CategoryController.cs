﻿using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        private readonly IMemoryCache _cache;   
        public CategoryController(ICategoryService categoryService,IMapper mapper,IMemoryCache cache)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _cache = cache;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {

            const string cacheKey = "Categories_Cache";

            if (!_cache.TryGetValue(cacheKey, out List<CategoryDTO> categoriesDTO))
            {
                List<Category> categories = await _categoryService.Get();
                categoriesDTO = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, categoriesDTO, cacheOptions);
            }

            return categoriesDTO;
        }
    }
}
