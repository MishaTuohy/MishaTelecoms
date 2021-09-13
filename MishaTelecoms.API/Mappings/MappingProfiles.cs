using AutoMapper;
using MishaTelecoms.API.Models;
using MishaTelecoms.API.Models.Requests;
using MishaTelecoms.API.Models.Responses;
using MishaTelecoms.Application.Dtos;

namespace MishaTelecoms.API.Mappings
{
    /// <summary>
    /// Used for passing objects between application layer and api
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CDRDataDto, CDRDataResponse>().ReverseMap();
            CreateMap<CDRDataDto, CDRDataRequest>().ReverseMap();
        }
    }
}
