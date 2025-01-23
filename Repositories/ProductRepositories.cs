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
    public class ProductsRepositories : IProductRepositories
    {
        MyShopUsersContext context;
        public ProductsRepositories(MyShopUsersContext myShopUsersContext)
        {
            context = myShopUsersContext;
        }

        public async Task<List<Product>> Get(string? desc,int? minPrice, int? maxPrice, int?[] categoryIds)
        {     
         var query = context.Products.Where(Product =>
         (desc==null?(true):(Product.Description.Contains(desc)))
         &&(minPrice == null ? (true) : (Product.Price >= minPrice))
        && ((maxPrice == null) ? (true) : (Product.Price <= maxPrice))
        && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(Product.CategoryId))))
        .OrderBy(Product => Product.Price);
        Console.WriteLine(query.ToQueryString());//
            List<Product> products = await query.Include(p=>p.Category).ToListAsync();
            return products;
           
        }



  




    }
}
