using Entities;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;

namespace TestProject
{
    public class OrderServiceIntegrationTest
    {


        private readonly MyShopUsersContext _context;
        private readonly OrderService _repository;

        public OrderServiceIntegrationTest(DatabaseFixure fixture)
        {
            _context = fixture.Context;
            _repository = new OrderService(new OrderRepositories(_context), new ProductsRepositories(_context));
        }



        [Fact]
        public async Task Post_ShouldSaveOrder_WithCorrectTotalAmount()
        {
            // Arrange
            var product1 = new Product { ProductId = 1, Price = 10.5m };
            var product2 = new Product { ProductId = 2, Price = 20.0m };
            var product3 = new Product { ProductId = 3, Price = 15.75m };

            _context.Products.AddRange(product1, product2, product3);
            await _context.SaveChangesAsync();

            var order = new Order
            {
                OrderItems = new List<OrderItem>
        {
            new OrderItem { ProductId = 1 },
            new OrderItem { ProductId = 2 },
            new OrderItem { ProductId = 3 }
        }
            };

            // Act
            var savedOrder = await _repository.Post(order);

            // Assert
            Assert.NotNull(savedOrder);
            Assert.Equal(46.25m, savedOrder.OrderSum); // 10.5 + 20.0 + 15.75
        }
    }
}
