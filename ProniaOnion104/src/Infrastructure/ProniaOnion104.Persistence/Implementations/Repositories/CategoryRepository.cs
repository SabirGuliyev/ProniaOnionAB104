using ProniaOnion104.Application.Abstractions.Repositories;
using ProniaOnion104.Domain.Entities;
using ProniaOnion104.Persistence.Contexts;
using ProniaOnion104.Persistence.Implementations.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion104.Persistence.Implementations.Repositories
{
    internal class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context)
        {

        }
    }
}
