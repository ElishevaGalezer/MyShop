using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
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
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            try { 
            IEnumerable<Category> categorioes = await _categoryService.Get();
            IEnumerable<CategoryDTO> categorioesDTO = _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDTO>>(categorioes);
            return categorioesDTO;
            }catch(Exception ex)
            {
                throw new Exception("cant get" + ex);
            }
        }
    }
}
