using UserManagement.Domains.Interfaces;

namespace UserManagement.Infrastructures.Repositories
{
    public class RepositoryWrapper(RepositoryContext repositoryContext) : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext = repositoryContext;
        private IUserRepository? _userRepository;

        public IUserRepository? User
        {
            get
            {
                if (_userRepository is not null)
                {
                    _userRepository = new UserRepository(_repositoryContext);
                }

                return _userRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}