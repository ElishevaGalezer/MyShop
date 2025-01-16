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
    public class OrderController : ControllerBase
    {

        IOrderService _orderService;
        IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<OrderDTO> GetByID(int id)
        {
            Order order =await _orderService.GetByID(id);
            OrderDTO orderDTO = _mapper.Map<Order,OrderDTO>(order);
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
