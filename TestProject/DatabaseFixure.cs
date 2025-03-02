using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Tests
{
    public class DatabaseFixure
    {
        public MyShopUsersContext Context { get; private set; }
        public DatabaseFixure()
        {
            var options = new DbContextOptionsBuilder<MyShopUsersContext>()
                .UseSqlServer("Server = SRV2\\PUPILS; Database=MyShopUsers1_test; Trusted_Connection=True; TrustServerCertificate=True" )
                .Options;
            Context = new MyShopUsersContext(options);
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Database.EnsureCreated();
            Context.Dispose();
        }
    }
}
