﻿using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_PostGresSQl.Models.DTO
{
    public class AddLeadListDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 characters")]
        public string LeadLastName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 characters")]
        public string LeadFirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 characters")]
        public string LeadMiddleName { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile no not valid")]
        public string LeadContactNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string LeadEmail { get; set; }
        [Required]
        public string LeadLoanType { get; set; }
        [Required]
        public string LeadProductType { get; set; }
        [Required]
        public string LeadAssignedTo { get; set; }
        public string? LeadCreatedBy { get; set; }
        public DateTime? LeadCreatedDate { get; set; }
        [Required]
        public string LeadStatus { get; set; }
        [Required]
        public Boolean LeadMarkedForReview { get; set; }
    }
}
