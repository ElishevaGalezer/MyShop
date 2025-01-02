using Entities;

namespace Repositories
{
    public interface IOrderRepositories
    {
        Task<Order> GetByID(int id);
        Task<Order> Post(Order order);
    }
}