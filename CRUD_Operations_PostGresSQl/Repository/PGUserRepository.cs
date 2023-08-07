using CRUD_Operations_PostGresSQl.Data;
using CRUD_Operations_PostGresSQl.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Expressions;
using System.Reflection;

namespace CRUD_Operations_PostGresSQl.Repository
{
    public class PGUserRepository : IUserRepository
    {
        private readonly CrudDbContext crudDbContext;

        public PGUserRepository(CrudDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await crudDbContext.AddAsync(user);
            await crudDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUserAsync(
            string? filterOn = null, string? filterQuery = null,
            string sortBy = "LeadFullName", bool isAscending = true,
            int pageNumber = 1, int pageSize = 10)
        {
            //Necessary variable initialization
            var users = new List<User>();
            var skipResults = (pageNumber - 1) * pageSize;
            //var users = await crudDbContext.Users.ToListAsync();

            //filtering & sorting both
            if (
                string.IsNullOrWhiteSpace(filterOn) == false &&
                string.IsNullOrWhiteSpace(filterQuery) == false &&
                string.IsNullOrWhiteSpace(sortBy) == false)
            {
                filterOn = filterOn.ToLower();

                var parameter = Expression.Parameter(typeof(User), "x");

                var property = typeof(User).GetProperty(filterOn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                {
                    //Filtering -  creating neccessary elements to build lambda expression
                    var propertyAccess = Expression.Property(parameter, property); // x.Name

                    var constantQuery = Expression.Constant(filterQuery, typeof(string)); // extracting filterquery

                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) }); // get contains method

                    var containsExpression = Expression.Call(propertyAccess, containsMethod, constantQuery);

                    //compile all expresion using the AndAlso method and logical AND
                    var predicate = Expression.Lambda<Func<User, bool>>(containsExpression, parameter);

                    //Sorting - creating neccessary elements to build lambda expression
                    sortBy = sortBy.ToLower();
                    string sortOrder = isAscending ? "ascending" : "descending";

                    string sortExpression = $"{sortBy} {sortOrder}"; //building sorting string

                    //users = users.AsQueryable().Where(predicate.Compile()).Skip(skipResults).Take(pageSize).ToList();

                    try
                    {
                        users = crudDbContext.Users.AsQueryable()
                            .OrderBy(sortExpression)
                            .Where(predicate.Compile())
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
                    //users = users.AsQueryable().OrderBy(sortExpression).ToList();
                    users = await crudDbContext.Users.AsQueryable()
                        .OrderBy(sortExpression)
                        .Skip(skipResults).Take(pageSize).ToListAsync();
                }
                catch (ParseException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        Final:
            return users;
        }

        public async Task<User?> FindByIdAsync(Guid id)
        {
            return await crudDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> UpdateUserAsync(Guid id, User user)
        {
            var existingUser = await crudDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Address = user.Address;
            existingUser.City = user.City;

            await crudDbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> DeleteUserAsync(Guid id)
        {
            var existingUser = await crudDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }
            crudDbContext.Users.Remove(existingUser);
            await crudDbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
