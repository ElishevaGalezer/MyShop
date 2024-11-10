using Entities;
using System.Text.Json;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class UserService:IUserService


    {
        IUserRepositories _userRepository;
        public UserService(IUserRepositories userRepository)
        {
            _userRepository = userRepository;
        }

            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }
            public string Get(int id)
            {
                return "value";
            }
            public User Login(string UserName, string Password)
            {
                return _userRepository.Login(UserName, Password);
            }
            public User Post(User user)
            {
                
                return _userRepository.Post(user);

            }
        public int Password(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password).Score;
            
            return result;
        }
            public User Put(int id, User userToUpdate)
            {
            return _userRepository.Put(id, userToUpdate);
            }

            public void Delete(int id)
            {
            _userRepository.Delete(id);
        }
        }
    }

 
