using Entities;

namespace Repositories
{
    public interface ICategoryRepositories
    {
        Task<List<Category>> Get();
    }
}