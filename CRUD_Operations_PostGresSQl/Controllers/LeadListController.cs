using AutoMapper;
using CRUD_Operations_PostGresSQl.CustomActionFilter;
using CRUD_Operations_PostGresSQl.Data;
using CRUD_Operations_PostGresSQl.Models.Domain;
using CRUD_Operations_PostGresSQl.Models.DTO;
using CRUD_Operations_PostGresSQl.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace CRUD_Operations_PostGresSQl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadListController : ControllerBase
    {
        public class Column
        {
            public string Title { get; set; }
            public string Field { get; set; }
        }
        private readonly CrudDbContext crudDbContext;
        private readonly IMapper mapper;
        private readonly ILeadListRepository leadList;
        private readonly UserManager<IdentityUser> userManager;

        public LeadListController(
            CrudDbContext crudDbContext,
            IMapper mapper,
            ILeadListRepository leadList,
            UserManager<IdentityUser> userManager)
        {
            this.crudDbContext = crudDbContext;
            this.mapper = mapper;
            this.leadList = leadList;
            this.userManager = userManager;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ValidateModel]
        public async Task<IActionResult> CreateLead([FromBody] AddLeadListDto addLeadListDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                addLeadListDto.LeadCreatedBy = userIdClaim.Value;
            }
            addLeadListDto.LeadCreatedDate = DateTime.UtcNow;
            try
            {
                var LeadListDomain = mapper.Map<LeadList>(addLeadListDto);
                LeadListDomain = await leadList.CreateAsync(LeadListDomain);

                return Ok(mapper.Map<LeadListDto>(LeadListDomain));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetAllLeadList(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] bool? isAscending,
            [FromQuery] string sortBy = "LeadFirstName",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var AllLeadListDomain = await leadList.GetAllLeadsAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

                var LeadListDto = mapper.Map<List<LeadListDto>>(AllLeadListDomain);

                var columnNames = crudDbContext.Model.FindEntityType(typeof(LeadList))
                .GetProperties()
                .Select(p => p.GetColumnName())
                .ToList();

                columnNames.Remove("LeadMarkedForReview");

                List<Column> columnList = columnNames.Select(columnNames => new Column
                {
                    Title = FormatTitle(columnNames),
                    Field = char.ToLower(columnNames[0]) + columnNames[1..],
                }).ToList();

                var action = new List<string> { "Edit", "Delete", "Marked for review" };
                var response = new
                {
                    total = LeadListDto.Count,
                    limit = 10,
                    skip = 10,
                    action,
                    data = new
                    {
                        columns = columnList,
                        rows = LeadListDto
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        [ValidateModel]
        public async Task<IActionResult> PatchLeads([FromRoute] Guid id, JsonPatchDocument updateLeadListDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;

            var operation1 = new Operation<UpdateLeadListDto>(
                            "replace", "/LeadUpdatedBy", from: null, value: userId);

            var operation2 = new Operation<UpdateLeadListDto>(
                            "replace", "/LeadUpdatedDate", from: null, value: DateTime.UtcNow);

            updateLeadListDto.Operations.Add(operation1);
            updateLeadListDto.Operations.Add(operation2);
            var LeadDomain = await leadList.PatchLeadsAsync(id, updateLeadListDto);

            if (LeadDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<LeadListDto>(LeadDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLeads([FromRoute] Guid id)
        {
            var LeadDomainmodel = await leadList.DeleteLeadsAsync(id);
            if (LeadDomainmodel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LeadListDto>(LeadDomainmodel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        [ValidateModel]
        public async Task<IActionResult> UpdateLeads([FromRoute] Guid id, UpdateLeadListDto updateLeadListDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                updateLeadListDto.LeadUpdatedBy = userIdClaim.Value;
            }
            updateLeadListDto.LeadUpdatedDate = DateTime.UtcNow;

            var leadDomain = mapper.Map<LeadList>(updateLeadListDto);
            leadDomain = await leadList.UpdateLeadsAsync(id, leadDomain);
            if (leadDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LeadListDto>(leadDomain));

        }

        //Custom function to manipulate Title property
        private static string FormatTitle(string columnName)
        {
            // Remove "Lead" from the Title field
            columnName = columnName.Replace("Lead", "");

            // Add a space before the second capital word
            var regex = new Regex(@"\B[A-Z]");
            columnName = regex.Replace(columnName, " $&");

            return columnName;
        }
    }
}
