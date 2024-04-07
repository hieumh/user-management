using System.Diagnostics;
using UserManagement.Domains.Interfaces;
using UserManagement.Domains.Models;

namespace UserManagement.Infrastructures.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}