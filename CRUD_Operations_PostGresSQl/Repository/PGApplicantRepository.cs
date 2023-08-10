using CRUD_Operations_PostGresSQl.Data;
using CRUD_Operations_PostGresSQl.Models.Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Expressions;
using System.Reflection;

namespace CRUD_Operations_PostGresSQl.Repository
{
    public class PGApplicantRepository : IApplicantRepository
    {
        private readonly CrudDbContext crudDbContext;

        public PGApplicantRepository(CrudDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }
        public async Task<ApplicantsCreateEntry> CreateAsync(ApplicantsCreateEntry applicantsCreateEntry)
        {
            await crudDbContext.AddAsync(applicantsCreateEntry);
            await crudDbContext.SaveChangesAsync();
            return applicantsCreateEntry;
        }

        public async Task<List<ApplicantsCreateEntry>> GetAllApplicantsAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var ApplicantList = new List<ApplicantsCreateEntry>();
            var skipResults = (pageNumber - 1) * pageSize;

            if (string.IsNullOrWhiteSpace(filterOn) == false &&
                string.IsNullOrWhiteSpace(filterQuery) == false &&
                string.IsNullOrWhiteSpace(sortBy) == false)
            {
                filterOn = filterOn.ToLower();

                var parameter = Expression.Parameter(typeof(ApplicantsCreateEntry), "x");

                var property = typeof(ApplicantsCreateEntry).GetProperty(filterOn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                {
                    //Filtering -  creating neccessary elements to build lambda expression
                    var propertyAccess = Expression.Property(parameter, property); // x.ApplicantFirstName

                    var constantQuery = Expression.Constant(filterQuery, typeof(string)); // extracting filterquery

                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) }); // get contains method

                    var containsExpression = Expression.Call(propertyAccess, containsMethod, constantQuery);//x.LeadFirstName.Contains("c")

                    //compile all expresion
                    var predicate = Expression.Lambda<Func<ApplicantsCreateEntry, bool>>(containsExpression, parameter);//x => x.LeadFirstName.Contains("c")

                    //Sorting - creating neccessary elements to build lambda expression
                    sortBy = sortBy.ToLower();
                    string sortOrder = isAscending ? "ascending" : "descending";

                    string sortExpression = $"{sortBy} {sortOrder}"; //building sorting string

                    try
                    {
                        ApplicantList = crudDbContext.ApplicantsCreateEntries.AsQueryable()
                            .OrderBy(sortExpression)
                            .Where(predicate.Compile()) //x => x.Name.Contains(filterQuery)
                            .Skip(skipResults).Take(pageSize).ToList();
                        goto Final;
                    }
                    catch (ParseException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = sortBy.ToLower();
                string sortOrder = isAscending ? "ascending" : "descending";

                string sortExpression = $"{sortBy} {sortOrder}";
                try
                {
                    ApplicantList = await crudDbContext.ApplicantsCreateEntries.AsQueryable()
                        .OrderBy(sortExpression)
                        .Skip(skipResults).Take(pageSize).ToListAsync();
                }
                catch (ParseException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        Final:
            return ApplicantList;
        }

        public async Task<ApplicantsCreateEntry?> PatchApplicantAsync(Guid id, JsonPatchDocument applicantList)
        {
            var existingApplicant = await crudDbContext.ApplicantsCreateEntries.FirstOrDefaultAsync(x => x.ApplicantId == id);
            if (existingApplicant == null)
            {
                return null;
            }
            applicantList.ApplyTo(existingApplicant);
            await crudDbContext.SaveChangesAsync();
            return existingApplicant;
        }

        public async Task<ApplicantsCreateEntry?> DeleteApplicantAsync(Guid id)
        {
            var existingApplicant = await crudDbContext.ApplicantsCreateEntries.FirstOrDefaultAsync(x => x.ApplicantId == id);

            if (existingApplicant == null)
            {
                return null;
            }
            crudDbContext.ApplicantsCreateEntries.Remove(existingApplicant);
            await crudDbContext.SaveChangesAsync();
            return existingApplicant;
        }

        public async Task<ApplicantsCreateEntry?> UpdateApplicantAsync(Guid id, ApplicantsCreateEntry applicantsCreateEntry)
        {
            var exsistingApplicant = await crudDbContext.ApplicantsCreateEntries.FirstOrDefaultAsync(x => x.ApplicantId == id);

            if (exsistingApplicant == null)
            {
                return null;
            }

            exsistingApplicant.ApplicantFirstName = applicantsCreateEntry.ApplicantFirstName;
            exsistingApplicant.ApplicantMiddleName = applicantsCreateEntry.ApplicantMiddleName;
            exsistingApplicant.ApplicantLastName = applicantsCreateEntry.ApplicantLastName;
            exsistingApplicant.AplicantBranch = applicantsCreateEntry.AplicantBranch;
            exsistingApplicant.ApplicantUpdateBy = applicantsCreateEntry.ApplicantUpdateBy;
            exsistingApplicant.ApplicantApplicationType = applicantsCreateEntry.ApplicantApplicationType;
            exsistingApplicant.ApplicantProductType = applicantsCreateEntry.ApplicantProductType;
            exsistingApplicant.ApplicantCategory = applicantsCreateEntry.ApplicantCategory;
            exsistingApplicant.ApplicantPanCard = applicantsCreateEntry.ApplicantPanCard;
            exsistingApplicant.ApplicantStatus = applicantsCreateEntry.ApplicantStatus;
            exsistingApplicant.ApplicantLevel = applicantsCreateEntry.ApplicantLevel;
            exsistingApplicant.ApplicantMarkedForReview = applicantsCreateEntry.ApplicantMarkedForReview;
            exsistingApplicant.ApplicantUpdateDate = applicantsCreateEntry.ApplicantUpdateDate;

            await crudDbContext.SaveChangesAsync();
            return exsistingApplicant;
        }
    }
}
