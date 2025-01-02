using Entities;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepositories : IOrderRepositories
    {
        MyShopUsersContext context;
        public OrderRepositories(MyShopUsersContext myShopUsersContext)
        {
            context = myShopUsersContext;
        }
        public async Task<Order> GetByID(int id)
        {
            return await context.Orders.Include(o=> o.User).FirstOrDefaultAsync(order => order.OrderId == id);
        }

        public async Task<Order> Post(Order order)
        {
            context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }
    }
}
