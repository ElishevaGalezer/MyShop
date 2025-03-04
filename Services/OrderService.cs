using Entities;
using Microsoft.Extensions.Logging;
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
        IProductRepositories _productRepository;
        ILogger<OrderService> _logger;
        public OrderService(IOrderRepositories orderRepository, IProductRepositories productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Order> GetByID(int id)
        {
            return await _orderRepository.GetByID(id);
        }

        public async Task<Order> Post(Order order)
        {
            decimal amount = await CheckSum(order);
            if (amount != order.OrderSum)
            {
                _logger.LogCritical($"{order.UserId} tried to change the order price!!!!!!!!!!!");
            }
            order.OrderSum = amount;
            return await _orderRepository.Post(order);
        }

        private async Task<decimal> CheckSum(Order order)

        {
            List<Product> products = await _productRepository.Get(null, null, null, []);

            decimal amount = 0;
            foreach (var item in order.OrderItems)
            {

                var product = products.Find(p => p.ProductId == item.ProductId);
                if (product != null)
                {
                    amount += product.Price;
                }

            }
            return amount;
        }
    }
}
