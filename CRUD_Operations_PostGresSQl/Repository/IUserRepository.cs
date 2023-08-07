using CRUD_Operations_PostGresSQl.Models.Domain;

namespace CRUD_Operations_PostGresSQl.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<List<User>> GetAllUserAsync(
            string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);
        Task<User?> FindByIdAsync(Guid id);
        Task<User?> UpdateUserAsync(Guid id, User user);
        Task<User?> DeleteUserAsync(Guid id);
    }
}
