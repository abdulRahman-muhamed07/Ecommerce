using Ecommerce.Application.Abstractions.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {


        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }



    }
}
