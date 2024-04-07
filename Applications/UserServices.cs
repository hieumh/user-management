using UserManagement.Domains.Interfaces;
using UserManagement.Domains.Models;

namespace UserManagement.Applications
{
    public class UserServices
    {
        private IRepositoryWrapper? _repositoryWrapper;
        public UserServices(IRepositoryWrapper? repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var results = new List<User>();
            if (_repositoryWrapper is not null && _repositoryWrapper.User is not null)
            {
                var temp = await _repositoryWrapper.User.FindAllAsync();
                results = temp.ToList();
            }

            return results;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            User? result = null;
            if (_repositoryWrapper?.User is not null)
            {
                result = (User?)await _repositoryWrapper.User.CreateAsync(user);
                await _repositoryWrapper.SaveAsync();
            }

            return result;
        }
    }
}