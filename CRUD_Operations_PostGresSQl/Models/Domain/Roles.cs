using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_PostGresSQl.Models.Domain
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
