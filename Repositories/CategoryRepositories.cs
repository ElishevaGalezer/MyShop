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
    public class CategoryRepositories : ICategoryRepositories
    {
        MyShopUsersContext context;
        public CategoryRepositories(MyShopUsersContext myShopUsersContext)
        {
            context = myShopUsersContext;
        }

        public async Task<List<Category>> Get()
        {
            return await context.Categories.ToListAsync();
        }
    }
}
//hi elisheva 
