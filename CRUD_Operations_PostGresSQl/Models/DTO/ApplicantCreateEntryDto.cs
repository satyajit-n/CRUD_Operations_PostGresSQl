﻿namespace CRUD_Operations_PostGresSQl.Models.DTO
{
    public class ApplicantCreateEntryDto
    {
        public string ApplicantNumber { get; set; }
        public DateOnly ApplicantDate { get; set; }
        public string ApllicantBranch { get; set; }
        public string? ApplicantCustomerName { get; set; }
        public string ApplicantApplicationType { get; set; }
        public string ApplicantProductType { get; set; }
        public string ApplicantCategory { get; set; }
        public string ApplicantPanCard { get; set; }
        public string ApplicantStatus { get; set; }
        public string? ApplicantLevel { get; set; }
        public Boolean ApplicantMarkedForReview { get; set; }
    }
}
