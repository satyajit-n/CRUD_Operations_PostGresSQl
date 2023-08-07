using CRUD_Operations_PostGresSQl.Data;
using CRUD_Operations_PostGresSQl.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CRUD_Operations_PostGresSQl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly CrudDbContext crudDbContext;
        public MenuController(
            CrudDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }
        // route : /api/Menu
        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            // Get the authenticated user's username
            // Get other roles associated with the user
            String userName = User.Identity.Name;
            var menuData = crudDbContext.EntitlementTables.Include("Menu").Include("Roles").AsQueryable();

            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

            var menuNames = menuData
            .Where(e => roles.Contains(e.Roles.Role)) // Filter by roles
            .Select(e => e.Menu.MenuName) // Select only the MenuName property
            .ToList();

            return Ok(menuNames);
        }
    }
}
