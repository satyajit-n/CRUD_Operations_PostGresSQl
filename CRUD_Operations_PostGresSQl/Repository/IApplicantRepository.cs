using CRUD_Operations_PostGresSQl.Models.Domain;
using Microsoft.AspNetCore.JsonPatch;

namespace CRUD_Operations_PostGresSQl.Repository
{
    public interface IApplicantRepository
    {
        Task<ApplicantsCreateEntry> CreateAsync(ApplicantsCreateEntry applicantsCreateEntry);
        Task<List<ApplicantsCreateEntry>> GetAllApplicantsAsync(
            string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);
        Task<ApplicantsCreateEntry?> PatchApplicantAsync(Guid id, JsonPatchDocument applicantList);
        Task<ApplicantsCreateEntry?> DeleteApplicantAsync(Guid id);
        Task<ApplicantsCreateEntry?> UpdateApplicantAsync(Guid id, ApplicantsCreateEntry applicantsCreateEntry);
    }
}
