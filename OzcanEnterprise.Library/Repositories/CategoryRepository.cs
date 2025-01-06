using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzcanEnterprise.Library.AppDbContexts;
using OzcanEnterprise.Library.Dtos;
﻿using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

namespace OzcanEnterprise.Library.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(MainDbContext mainDbContext, IMapper mapper)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetCategoryByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
