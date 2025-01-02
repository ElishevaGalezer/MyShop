using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepositories _categoryRepository;
        public CategoryService(ICategoryRepositories categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Get()
        {
            return await _categoryRepository.Get();
        }

    }
}
