using CRUD_Operations_PostGresSQl.Models.Domain;
using Microsoft.AspNetCore.JsonPatch;

namespace CRUD_Operations_PostGresSQl.Repository
{
    public interface ILeadListRepository
    {
        Task<LeadList> CreateAsync(LeadList leadList);
        Task<List<LeadList>> GetAllLeadsAsync(
            string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);
        Task<LeadList?> PatchLeadsAsync(Guid id, JsonPatchDocument leadList);
        Task<LeadList?> DeleteLeadsAsync(Guid id);
        Task<LeadList?> UpdateLeadsAsync(Guid id, LeadList leadList);
    }
}
