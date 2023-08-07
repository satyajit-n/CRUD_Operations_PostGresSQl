using AutoMapper;
using CRUD_Operations_PostGresSQl.Data;
using CRUD_Operations_PostGresSQl.Models.Domain;
using CRUD_Operations_PostGresSQl.Models.DTO;
using CRUD_Operations_PostGresSQl.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CRUD_Operations_PostGresSQl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public class Column
        {
            public string Title { get; set; }
            public string Field { get; set; }
        }

        private readonly CrudDbContext crudDbContext;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserController(
            CrudDbContext crudDbContext,
            IMapper mapper,
            IUserRepository userRepository)
        {
            this.crudDbContext = crudDbContext;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
        {
            try
            {
                var UserModel = mapper.Map<User>(addUserRequestDto);

                var UserDomainModel = await userRepository.CreateAsync(UserModel);

                return Ok(mapper.Map<UserDto>(UserDomainModel));
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] bool? isAscending,
            [FromQuery] string sortBy = "Name",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var AllUserDomain = await userRepository.GetAllUserAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

                var UsersDto = mapper.Map<List<UserDto>>(AllUserDomain);

                var columnNames = crudDbContext.Model.FindEntityType(typeof(User))
                    .GetProperties()
                    .Select(p => p.GetColumnName())
                    .ToList();

                Column[] columnList = new Column[columnNames.Count];

                for (var i = 0; i < columnList.Length; i++)
                {
                    Column obj = new()
                    {
                        Title = columnNames.Find(column => column == columnNames[i]),
                        Field = columnNames[i].ToLower()
                    };
                    columnList[i] = obj;
                }

                // columnNames.FirstOrDefault(column => column == "Name");
                var response = new
                {
                    total = UsersDto.Count,
                    limit = pageSize,
                    skip = (pageNumber - 1) * pageSize,
                    data = new
                    {
                        columns = columnList,
                        rows = UsersDto
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

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var UserDomain = await userRepository.FindByIdAsync(id);

            if (UserDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(UserDomain));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, AddUserRequestDto addUserRequestDto)
        {
            var UserDomain = mapper.Map<User>(addUserRequestDto);

            UserDomain = await userRepository.UpdateUserAsync(id, UserDomain);

            if (UserDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(UserDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var UserDomain = await userRepository.DeleteUserAsync(id);

            if (UserDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(UserDomain));
        }
    }
}
