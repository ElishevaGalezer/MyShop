using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productService,IMapper mapper,ILogger<ProductsController> _logger)
    {
        _productService = productService;
            _mapper = mapper;
            _logger.LogInformation("someone enter to the aplication");
        }
    
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get([FromQuery]string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> products=await _productService.Get( desc,  minPrice,  maxPrice,  categoryIds);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productsDTO;
        }
    }
}
