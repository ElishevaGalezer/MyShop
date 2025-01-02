using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepositories _orderRepository;
        public OrderService(IOrderRepositories orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetByID(int id)
        {
            return await _orderRepository.GetByID(id);
        }

        public async Task<Order> Post(Order order)
        {
            return await _orderRepository.Post(order);
        }
    }
}
