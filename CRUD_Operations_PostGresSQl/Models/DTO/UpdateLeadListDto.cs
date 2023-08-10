namespace CRUD_Operations_PostGresSQl.Models.DTO
{
    public class UpdateLeadListDto
    {
        public string? LeadLastName { get; set; }
        public string? LeadFirstName { get; set; }
        public string? LeadMiddleName { get; set; }
        public string? LeadContactNumber { get; set; }
        public string? LeadEmail { get; set; }
        public string? LeadLoanType { get; set; }
        public string? LeadProductType { get; set; }
        public string? LeadAssignedTo { get; set; }
        public string? LeadUpdatedBy { get; set; }
        public DateTime? LeadUpdatedDate { get; set; }
        public string? LeadStatus { get; set; }
        public Boolean? LeadMarkedForReview { get; set; }
    }
}
