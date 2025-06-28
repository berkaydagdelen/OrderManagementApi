using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Core.Repository;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;

namespace OrderManagementApi.DataAccess.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
