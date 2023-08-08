using CRUD_Operations_PostGresSQl.Data;
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
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            var menuData = await crudDbContext.EntitlementTables
                .Include("Menu")
                .Include("Roles")
                .Include("ActionTable")
                .Where(e => roles.Contains(e.Roles.Role))
                .ToListAsync();

            var menuActionNames = menuData
                .Select(e => new
                {
                    e.Menu.MenuName,
                    e.ActionTable.ActionName
                })
                .ToList();
            var memuActionList = new List<string>();
            for (var i = 0; i < menuActionNames.Count; i++)
            {
                memuActionList.Add(menuActionNames[i].MenuName + "_" + menuActionNames[i].ActionName);
            }
            return Ok(memuActionList);
        }
    }
}
