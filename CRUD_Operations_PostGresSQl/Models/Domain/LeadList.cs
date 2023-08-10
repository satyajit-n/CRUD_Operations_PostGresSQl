using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_PostGresSQl.Models.Domain
{
    public class LeadList
    {
        [Key]
        public Guid LeadId { get; set; }
        public string LeadLastName { get; set; }
        public string LeadFirstName { get; set; }
        public string LeadMiddleName { get; set; }
        public string LeadContactNumber { get; set; }
        public string LeadEmail { get; set; }
        public string LeadLoanType { get; set; }
        public string LeadProductType { get; set; }
        public string LeadAssignedTo { get; set; }
        public string? LeadCreatedBy { get; set; }
        public DateTime? LeadCreatedDate { get; set; }
        public string? LeadUpdatedBy { get; set; }
        public DateTime? LeadUpdatedDate { get; set; }
        public string LeadStatus { get; set; }
        public Boolean LeadMarkedForReview { get; set; }
    }
}
