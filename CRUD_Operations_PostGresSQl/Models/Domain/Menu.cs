using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_PostGresSQl.Models.Domain
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string MenuName { get; set; }
    }
}
