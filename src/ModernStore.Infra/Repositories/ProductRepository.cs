using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using ModernStore.Shared;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context
                .Products
                .AsNoTracking()
                .FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<GetProductListCommandResult> Get()
        {
            var query = "SELECT [Id], [Title], [Price], [Image] FROM [Product]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<GetProductListCommandResult>(query);
            }
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public bool ProductExists(string productTitle)
        {   
            return _context.Products.Any(x => x.Title == productTitle);
        }
    }
}
