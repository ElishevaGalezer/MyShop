using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepositories _productRepository;
        public ProductService(IProductRepositories productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _productRepository.Get( desc,  minPrice,  maxPrice,  categoryIds);
        }
    }
}
