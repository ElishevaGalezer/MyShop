using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class UserRepositories : IUserRepositories
    {
        MyShopUsersContext context;
        public UserRepositories(MyShopUsersContext myShopUsersContext)
        {
            context = myShopUsersContext;
        }
        public IEnumerable<string> Get()
        {
             return  new string[] { "value1", "value2" };
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
            context.Users.AddAsync(user);
            await  context.SaveChangesAsync();
            return user;
        }

        public async Task Put(int id, User userToUpdate)
        {
            context.Users.Update(userToUpdate);
            await context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
        }
    }
}
