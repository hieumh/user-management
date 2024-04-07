namespace UserManagement.Domains.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository? User { get; }
        Task SaveAsync();
    }
}