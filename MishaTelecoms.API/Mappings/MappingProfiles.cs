using AutoMapper;
using MishaTelecoms.API.Models;
using MishaTelecoms.API.Models.Requests;
using MishaTelecoms.API.Models.Responses;
using MishaTelecoms.Application.Dtos;

namespace MishaTelecoms.API.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<CDRDataDto, CDRDataModel>().ReverseMap();
            CreateMap<CDRDataDto, CDRDataResponse>().ReverseMap();
            CreateMap<CDRDataDto, CDRDataRequest>().ReverseMap();
        }
    }
}
