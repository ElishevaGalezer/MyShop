using System.Text.Json;
using Entities;
namespace Repositories
{
    public class UserRepositories
    {
        public UserRepositories()
        {

        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        } 
        public string Get(int id)
        {
            return "value1";
        }
        public User Login( string UserName,  string Password)
        {
            using (StreamReader reader = System.IO.File.OpenText("M:\\web api\\MyShop\\MyShop\\UserList.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == UserName && user.Password == Password)
                        return user;
                }
            }
            return null;
        }
        public User Post(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines("M:\\web api\\MyShop\\MyShop\\UserList.txt").Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("M:\\web api\\MyShop\\MyShop\\UserList.txt", userJson + Environment.NewLine);
            return user;
        }

        public User Put(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            userToUpdate.userId = id;
            using (StreamReader reader = System.IO.File.OpenText("M:\\web api\\MyShop\\MyShop\\UserList.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("M:\\web api\\MyShop\\MyShop\\UserList.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText("M:\\web api\\MyShop\\MyShop\\UserList.txt", text);
                return userToUpdate;
            }
            return null;
        }

        public void Delete(int id)
        {
        }
    }
}
