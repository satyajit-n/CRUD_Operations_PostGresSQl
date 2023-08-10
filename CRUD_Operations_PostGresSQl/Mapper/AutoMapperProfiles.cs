using AutoMapper;
using CRUD_Operations_PostGresSQl.Models.Domain;
using CRUD_Operations_PostGresSQl.Models.DTO;

namespace CRUD_Operations_PostGresSQl.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //User Mapper
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();

            //LeadList Mapper
            CreateMap<LeadList, LeadListDto>().ReverseMap();
            CreateMap<AddLeadListDto, LeadList>().ReverseMap();
            CreateMap<UpdateLeadListDto, LeadList>().ReverseMap();

            //Applicants Create Mapper
            CreateMap<ApplicantsCreateEntry,ApplicantsDto>().ReverseMap();
            CreateMap<AddApplicantDto,ApplicantsCreateEntry>().ReverseMap();
            CreateMap<UpdateApplicantDto, ApplicantsCreateEntry>().ReverseMap();
        }
    }
}
