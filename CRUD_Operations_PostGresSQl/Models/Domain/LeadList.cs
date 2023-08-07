using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_PostGresSQl.Models.Domain
{
    public class LeadList
    {
        [Key]
        public Guid LeadId { get; set; }
        public string LeadFullName { get; set; }
        public string LeadContactNumber { get; set; }
        public string LeadEmail { get; set; }
        public string LeadLoanType { get; set; }
        public string LeadProductType { get; set; }
        public string LeadAssignedTo { get; set; }
        public string LeadCreatedBy { get; set; }
        public DateOnly LeadCreatedDate { get; set; }
        public string LeadStatus { get; set; }
        public Boolean LeadMarkedForReview { get; set; }
    }
}
