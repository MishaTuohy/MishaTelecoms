using AutoMapper;
using MishaTelecoms.API.Models;
using MishaTelecoms.API.Models.Requests;
using MishaTelecoms.API.Models.Responses;
using MishaTelecoms.Application.Dtos;

namespace MishaTelecoms.API.Mappings
{
    /// <summary>
    /// Stores Mapping profiles for data transfer between layers
    /// </summary>
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Used for passing objects between application layer and external services
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<CDRDataDto, CDRDataModel>().ReverseMap();
            CreateMap<CDRDataDto, CDRDataResponse>().ReverseMap();
            CreateMap<CDRDataDto, CDRDataRequest>().ReverseMap();
        }
    }
}
