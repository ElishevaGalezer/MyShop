using AutoMapper;
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
    public class OrderController : ControllerBase
    {

        IOrderService _orderService;
        IMapper _mapper;
        IMemoryCache _cache;
        public OrderController(IOrderService orderService, IMapper mapper,IMemoryCache cache)
        {
            _orderService = orderService;
            _mapper = mapper;
            _cache = cache;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<OrderDTO> GetByID(int id)
        {
            if (!_cache.TryGetValue($"Order_{id}", out OrderDTO orderDTO))
            {
                Order order = await _orderService.GetByID(id);
                orderDTO = _mapper.Map<Order, OrderDTO>(order);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                _cache.Set($"Order_{id}", orderDTO, cacheOptions);
            }
            return orderDTO;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<OrderDTO> Post([FromBody]PostOrderDTO  order)
        {
            Order ordr = await _orderService.Post(_mapper.Map<PostOrderDTO,Order>(order));
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(ordr);
            return orderDTO;

           
        }
    }
}
