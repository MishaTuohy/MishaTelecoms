using AutoMapper;
using MishaTelecoms.API.Models.Requests;
using MishaTelecoms.API.Models.Responses;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Features.CDRData.Commands.CreateCDR;

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
            CreateMap<CDRDataDto, CreateCDRRequest>().ReverseMap();
            CreateMap<CDRDataDto, CreateCDRCommand>().ReverseMap();
            CreateMap<CreateCDRCommand, CDRDataDto>().ReverseMap();
        }
    }
}
