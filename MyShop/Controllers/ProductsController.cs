using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PresidentsApp.Middlewares;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase{
         IProductService _productService;
        IMapper _mapper;
        ILogger<ProductsController> _logger;
        IMemoryCache _cache;
        public ProductsController(IProductService productService,IMapper mapper,ILogger<ProductsController> logger,IMemoryCache cache)
    {
        _productService = productService;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("someone enter to the aplication");
            _cache = cache; 
        }
    
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get([FromQuery]string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            string cacheKey = $"products_{desc}_{minPrice}_{maxPrice}_{string.Join(",", categoryIds)}";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<ProductDTO> productDTOs))
            {
                IEnumerable<Product> products = await _productService.Get(desc, minPrice, maxPrice, categoryIds);
                productDTOs = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));

                _cache.Set(cacheKey, productDTOs, cacheEntryOptions);
            }

            return productDTOs;
        }
    }
}
