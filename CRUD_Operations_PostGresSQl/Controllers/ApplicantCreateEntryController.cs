using AutoMapper;
using CRUD_Operations_PostGresSQl.CustomActionFilter;
using CRUD_Operations_PostGresSQl.Data;
using CRUD_Operations_PostGresSQl.Models.Domain;
using CRUD_Operations_PostGresSQl.Models.DTO;
using CRUD_Operations_PostGresSQl.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch.Operations;
namespace CRUD_Operations_PostGresSQl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantCreateEntryController : ControllerBase
    {
        public class Column
        {
            public string Title { get; set; }
            public string Field { get; set; }
        }

        private readonly CrudDbContext crudDbContext;
        private readonly IMapper mapper;
        private readonly IApplicantRepository applicantRepository;
        public ApplicantCreateEntryController(
            CrudDbContext crudDbContext,
            IMapper mapper,
            IApplicantRepository applicantRepository)
        {
            this.crudDbContext = crudDbContext;
            this.mapper = mapper;
            this.applicantRepository = applicantRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateApplicant([FromBody] AddApplicantDto addApplicantDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                addApplicantDto.ApplicantCreateBy = userIdClaim.Value;
            }
            addApplicantDto.ApplicantCreateDate = DateTime.UtcNow;
            try
            {
                var ApplicantDomain = mapper.Map<ApplicantsCreateEntry>(addApplicantDto);
                ApplicantDomain = await applicantRepository.CreateAsync(ApplicantDomain);

                return Ok(mapper.Map<AddApplicantDto>(ApplicantDomain));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetApplicant(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] bool? isAscending,
            [FromQuery] string sortBy = "ApplicantFirstName",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var AllApplicantDomain = await applicantRepository.GetAllApplicantsAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

                var ApplicantsDto = mapper.Map<List<ApplicantsDto>>(AllApplicantDomain);

                var columnNames = crudDbContext.Model.FindEntityType(typeof(ApplicantsCreateEntry))
                .GetProperties()
                .Select(p => p.GetColumnName())
                .ToList();

                columnNames.Remove("ApplicantMarkedForReview");

                List<Column> columnList = columnNames.Select(columnNames => new Column
                {
                    Title = FormatTitle(columnNames),
                    Field = char.ToLower(columnNames[0]) + columnNames[1..],
                }).ToList();

                var action = new List<string> { "Edit", "Delete", "Marked for review" };
                var response = new
                {
                    total = ApplicantsDto.Count,
                    limit = 10,
                    skip = 10,
                    action,
                    data = new
                    {
                        columns = columnList,
                        rows = ApplicantsDto
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchApplicant([FromRoute] Guid id, JsonPatchDocument updateApplicationDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;

            var operation1 = new Operation<UpdateApplicantDto>(
                            "replace", "/ApplicantUpdateBy", from: null, value: userId);

            var operation2 = new Operation<UpdateApplicantDto>(
                            "replace", "/ApplicantUpdateDate", from: null, value: DateTime.UtcNow);

            updateApplicationDto.Operations.Add(operation1);
            updateApplicationDto.Operations.Add(operation2);

            var ApplicantDomain = await applicantRepository.PatchApplicantAsync(id, updateApplicationDto);

            if (ApplicantDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UpdateApplicantDto>(ApplicantDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteApplicant([FromRoute] Guid id)
        {
            var ApplicantDomain = await applicantRepository.DeleteApplicantAsync(id);
            if (ApplicantDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ApplicantsDto>(ApplicantDomain));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateApplicant([FromRoute] Guid id, [FromBody]UpdateApplicantDto updateApplicantDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                updateApplicantDto.ApplicantUpdateBy = userIdClaim.Value;
            }
            updateApplicantDto.ApplicantUpdateDate = DateTime.UtcNow;

            var ApplicantDomain = mapper.Map<ApplicantsCreateEntry>(updateApplicantDto);
            ApplicantDomain = await applicantRepository.UpdateApplicantAsync(id, ApplicantDomain);
            if (ApplicantDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ApplicantsCreateEntry>(ApplicantDomain));

        }

        private static string FormatTitle(string columnName)
        {
            // Remove "Lead" from the Title field
            columnName = columnName.Replace("Applicant", "");

            // Add a space before the second capital word
            var regex = new Regex(@"\B[A-Z]");
            columnName = regex.Replace(columnName, " $&");

            return columnName;
        }
    }
}
