using CRUD_Operations_PostGresSQl.Models.Domain;
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
                    Id = 200,
                    MenuName = "Applicants",
                },
                new Menu()
                {
                    Id = 300,
                    MenuName = "Legal Verification",
                },
                new Menu()
                {
                    Id = 400,
                    MenuName = "Setting",
                },
            };
            modelBuilder.Entity<Menu>().HasData(Menus);

            var Roles = new List<Roles>()
            {
                new Roles()
                {
                    Id = 1,
                    Role = "Admin"
                },
                new Roles()
                {
                    Id = 2,
                    Role = "Manager"
                },
            };
            modelBuilder.Entity<Roles>().HasData(Roles);

            var Entitlement = new List<EntitlementTable>()
            {
                new EntitlementTable()
                {
                    Id = 101,
                    MenuRefId = 100,
                    RoleRefId = 1,
                },
                new EntitlementTable()
                {
                    Id = 102,
                    MenuRefId = 200,
                    RoleRefId = 1,
                },
                new EntitlementTable()
                {
                    Id = 103,
                    MenuRefId = 300,
                    RoleRefId = 1,
                },
                new EntitlementTable()
                {
                    Id = 104,
                    MenuRefId = 400,
                    RoleRefId = 1,
                },
                new EntitlementTable()
                {
                    Id = 105,
                    MenuRefId = 300,
                    RoleRefId = 2,
                },
                new EntitlementTable()
                {
                    Id = 106,
                    MenuRefId = 400,
                    RoleRefId = 2,
                },
            };
            modelBuilder.Entity<EntitlementTable>().HasData(Entitlement);
        }
    }
}
