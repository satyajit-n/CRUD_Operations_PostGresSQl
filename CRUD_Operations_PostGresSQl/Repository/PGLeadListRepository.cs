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
    public class PGLeadListRepository : ILeadListRepository
    {
        private readonly CrudDbContext crudDbContext;

        public PGLeadListRepository(CrudDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }
        public async Task<LeadList> CreateAsync(LeadList leadList)
        {
            await crudDbContext.AddAsync(leadList);
            await crudDbContext.SaveChangesAsync();
            return leadList;
        }

        public async Task<List<LeadList>> GetAllLeadsAsync(
            string? filterOn = null, string? filterQuery = null,
            string sortBy = "LeadFullName", bool isAscending = true,
            int pageNumber = 1, int pageSize = 10)
        {
            var leadLists = new List<LeadList>();
            var skipResults = (pageNumber - 1) * pageSize;

            if (string.IsNullOrWhiteSpace(filterOn) == false &&
                string.IsNullOrWhiteSpace(filterQuery) == false &&
                string.IsNullOrWhiteSpace(sortBy) == false)
            {
                filterOn = filterOn.ToLower();

                var parameter = Expression.Parameter(typeof(LeadList), "x");

                var property = typeof(LeadList).GetProperty(filterOn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                {
                    //Filtering -  creating neccessary elements to build lambda expression
                    var propertyAccess = Expression.Property(parameter, property); // x.LeadFirstName

                    var constantQuery = Expression.Constant(filterQuery, typeof(string)); // extracting filterquery

                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) }); // get contains method

                    var containsExpression = Expression.Call(propertyAccess, containsMethod, constantQuery);//x.LeadFirstName.Contains("c")

                    //compile all expresion
                    var predicate = Expression.Lambda<Func<LeadList, bool>>(containsExpression, parameter);//x => x.LeadFirstName.Contains("c")

                    //Sorting - creating neccessary elements to build lambda expression
                    sortBy = sortBy.ToLower();
                    string sortOrder = isAscending ? "ascending" : "descending";

                    string sortExpression = $"{sortBy} {sortOrder}"; //building sorting string

                    try
                    {
                        leadLists = crudDbContext.Leads.AsQueryable()
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
                    leadLists = await crudDbContext.Leads.AsQueryable()
                        .OrderBy(sortExpression)
                        .Skip(skipResults).Take(pageSize).ToListAsync();
                }
                catch (ParseException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        Final:
            return leadLists;
        }

        public async Task<LeadList?> PatchLeadsAsync(Guid id, JsonPatchDocument leadList)
        {
            var existingLead = await crudDbContext.Leads.FirstOrDefaultAsync(x => x.LeadId == id);

            if (existingLead == null)
            {
                return null;
            }
            leadList.ApplyTo(existingLead);
            await crudDbContext.SaveChangesAsync();
            return existingLead;
        }

        public async Task<LeadList?> DeleteLeadsAsync(Guid id)
        {
            var existingLead = await crudDbContext.Leads.FirstOrDefaultAsync(x => x.LeadId == id);

            if (existingLead == null)
            {
                return null;
            }
            crudDbContext.Leads.Remove(existingLead);
            await crudDbContext.SaveChangesAsync();
            return existingLead;
        }

        public async Task<LeadList?> UpdateLeadsAsync(Guid id, LeadList leadList)
        {
            var exsistingLead = await crudDbContext.Leads.FirstOrDefaultAsync(x => x.LeadId == id);

            if (exsistingLead == null)
            {
                return null;
            }

            exsistingLead.LeadFirstName = leadList.LeadFirstName;
            exsistingLead.LeadLastName = leadList.LeadLastName;
            exsistingLead.LeadMiddleName = leadList.LeadMiddleName;
            exsistingLead.LeadContactNumber = leadList.LeadContactNumber;
            exsistingLead.LeadEmail = leadList.LeadEmail;
            exsistingLead.LeadLoanType = leadList.LeadLoanType;
            exsistingLead.LeadProductType = leadList.LeadProductType;
            exsistingLead.LeadAssignedTo = leadList.LeadAssignedTo;
            exsistingLead.LeadUpdatedDate = leadList.LeadUpdatedDate;
            exsistingLead.LeadUpdatedBy = leadList.LeadUpdatedBy;
            exsistingLead.LeadStatus = leadList.LeadStatus;
            exsistingLead.LeadMarkedForReview = leadList.LeadMarkedForReview;

            await crudDbContext.SaveChangesAsync();
            return exsistingLead;

        }
    }
}
