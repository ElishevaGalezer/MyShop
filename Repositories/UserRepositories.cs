using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;


namespace Repositories
{
    public class UserRepositories : IUserRepositories
    {
        MyShopUsersContext context;
        public UserRepositories(MyShopUsersContext myShopUsersContext)
        {
            context = myShopUsersContext;
        }
        public string Get(int id)
        {
            return "value";
        }
        public async Task<User> Login(string UserName, string Password)
        {
           User user=await context.Users.FirstOrDefaultAsync(user => user.Password == Password && user.UserName== UserName);
            return user;
        }
        public async Task <User> Post(User user)
        {
            var item=context.Users.ToList().Find(item => item.UserName.Trim() ==user.UserName);
            if (item == null) { 
            context.Users.AddAsync(user);
            await  context.SaveChangesAsync();
            return user;
            }
            return null;
        }

        public async Task Put(int id, User userToUpdate)
        {
            userToUpdate.Id = id;
            context.Users.Update(userToUpdate);
            await context.SaveChangesAsync();
        }
    }
}
