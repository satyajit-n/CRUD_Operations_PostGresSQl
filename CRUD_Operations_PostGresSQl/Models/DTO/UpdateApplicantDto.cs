namespace CRUD_Operations_PostGresSQl.Models.DTO
{
    public class UpdateApplicantDto
    {
        public string AplicantBranch { get; set; }
        public string ApplicantFirstName { get; set; }
        public string ApplicantMiddleName { get; set; }
        public string ApplicantLastName { get; set; }
        public string ApplicantApplicationType { get; set; }
        public string ApplicantProductType { get; set; }
        public string ApplicantCategory { get; set; }
        public string ApplicantPanCard { get; set; }
        public string ApplicantStatus { get; set; }
        public string? ApplicantLevel { get; set; }
        public string? ApplicantUpdateBy { get; set; }
        public DateTime? ApplicantUpdateDate { get; set; }
        public Boolean ApplicantMarkedForReview { get; set; }
    }
}
