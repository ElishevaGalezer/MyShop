using Entities;

namespace Repositories
{
    public interface IProductRepositories
    {
        Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);

    }
}