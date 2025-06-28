using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Core.Repository;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;

namespace OrderManagementApi.DataAccess.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
