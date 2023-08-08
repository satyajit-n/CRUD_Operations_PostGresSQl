using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operations_PostGresSQl.Models.Domain
{
    public class EntitlementTable
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Menu")]
        public int MenuRefId { get; set; }
        public Menu Menu { get; set; }

        [ForeignKey("Roles")]
        public int RoleRefId { get; set; }
        public Roles Roles { get; set; }

        [ForeignKey("ActionTable")]
        public int ActionId { get; set; }
        public ActionTable ActionTable { get; set; }
    }
}
