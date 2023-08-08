using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_PostGresSQl.Models.Domain
{
    public class ActionTable
    {
        [Key]
        public int Id { get; set; }
        public string ActionName { get; set; }
    }
}
