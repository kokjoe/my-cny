using AutoMapper;
using my_cny.API.Model;
using my_cny.API.Resource;

namespace my_cny.API.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // model to API
            CreateMap<Patient, PatientResource>()
            .ForMember(p => p.EmergencyContactsResource, opt => opt
                .MapFrom(a => a.EmergencyContacts))
            .ForMember(p => p.IdentificationResource, opt => opt
                .MapFrom(a => a.Identification)).ReverseMap();

            CreateMap<EmergencyContact, EmergencyContactResource>()
                .ForMember(p => p.RelationshipResource, opt => opt
                    .MapFrom(a => a.Relationship)).ReverseMap();

            CreateMap<Relationship, RelationshipResource>().ReverseMap();
            CreateMap<Identification, IdentificationResource>().ReverseMap();
            CreateMap<CurrentMRN, CurrentMRNResource>().ReverseMap();

            //API to model
        }
    }
}