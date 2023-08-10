using CRUD_Operations_PostGresSQl.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations_PostGresSQl.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LeadList> Leads { get; set; }
        public virtual DbSet<ApplicantsCreateEntry> ApplicantsCreateEntries { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<EntitlementTable> EntitlementTables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            var Menus = new List<Menu>()
            {
                new Menu()
                {
                    Id = 100,
                    MenuName = "Leads",
                },
                new Menu()
                {
                    Id = 101,
                    MenuName = "Applicants",
                },
                new Menu()
                {
                    Id = 102,
                    MenuName = "Legal Verification",
                },
                new Menu()
                {
                    Id = 103,
                    MenuName = "Setting",
                },
            };
            modelBuilder.Entity<Menu>().HasData(Menus);

            var Roles = new List<Roles>()
            {
                new Roles()
                {
                    Id = 200,
                    Role = "Admin"
                },
                new Roles()
                {
                    Id = 201,
                    Role = "Manager"
                },
            };
            modelBuilder.Entity<Roles>().HasData(Roles);

            var ActionValues = new List<ActionTable>()
            {
                new ActionTable()
                {
                    Id = 400,
                    ActionName = "View",
                },
                new ActionTable()
                {
                    Id = 401,
                    ActionName = "Add",
                },
                new ActionTable()
                {
                    Id = 402,
                    ActionName = "Update",
                },
                new ActionTable()
                {
                    Id = 403,
                    ActionName = "Delete",
                },
                new ActionTable()
                {
                    Id = 404,
                    ActionName = "Review",
                },
            };
            modelBuilder.Entity<ActionTable>().HasData(ActionValues);

            var Entitlement = new List<EntitlementTable>()
            {
                //Lead table for admin with action entitlement
                new EntitlementTable()
                {
                    Id = 301,
                    MenuRefId = 100,
                    RoleRefId = 200,
                    ActionId = 400,
                },
                new EntitlementTable()
                {
                    Id = 302,
                    MenuRefId = 100,
                    RoleRefId = 200,
                    ActionId = 401,
                },
                new EntitlementTable()
                {
                    Id = 303,
                    MenuRefId = 100,
                    RoleRefId = 200,
                    ActionId = 402,
                },
                new EntitlementTable()
                {
                    Id = 304,
                    MenuRefId = 100,
                    RoleRefId = 200,
                    ActionId = 403,
                },
                new EntitlementTable()
                {
                    Id = 305,
                    MenuRefId = 100,
                    RoleRefId = 200,
                    ActionId = 404,
                },
                // Applicants menu admin Action entitlement
                new EntitlementTable()
                {
                    Id = 306,
                    MenuRefId = 101,
                    RoleRefId = 200,
                    ActionId = 400,
                },
                new EntitlementTable()
                {
                    Id = 307,
                    MenuRefId = 101,
                    RoleRefId = 200,
                    ActionId = 401,
                },
                new EntitlementTable()
                {
                    Id = 308,
                    MenuRefId = 101,
                    RoleRefId = 200,
                    ActionId = 402,
                },
                new EntitlementTable()
                {
                    Id = 309,
                    MenuRefId = 101,
                    RoleRefId = 200,
                    ActionId = 403,
                },
                new EntitlementTable()
                {
                    Id = 310,
                    MenuRefId = 101,
                    RoleRefId = 200,
                    ActionId = 404,
                },
                // Legal verification admin entitlement
                new EntitlementTable()
                {
                    Id = 311,
                    MenuRefId = 102,
                    RoleRefId = 200,
                    ActionId = 400,
                },
                new EntitlementTable()
                {
                    Id = 312,
                    MenuRefId = 102,
                    RoleRefId = 200,
                    ActionId = 401,
                },
                new EntitlementTable()
                {
                    Id = 313,
                    MenuRefId = 102,
                    RoleRefId = 200,
                    ActionId = 404,
                },
                //setting menu
                new EntitlementTable()
                {
                    Id = 314,
                    MenuRefId = 103,
                    RoleRefId = 200,
                    ActionId = 400
                },
                new EntitlementTable()
                {
                    Id = 315,
                    MenuRefId = 103,
                    RoleRefId = 201,
                    ActionId = 400
                },
            };
            modelBuilder.Entity<EntitlementTable>().HasData(Entitlement);
        }
    }
}
