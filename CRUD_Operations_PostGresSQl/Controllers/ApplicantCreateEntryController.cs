using CRUD_Operations_PostGresSQl.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operations_PostGresSQl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantCreateEntryController : ControllerBase
    {
        private readonly CrudDbContext crudDbContext;

        public class Column
        {
            public string Title { get; set; }
            public string Field { get; set; }
        }

        public ApplicantCreateEntryController(CrudDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }
    }
}
