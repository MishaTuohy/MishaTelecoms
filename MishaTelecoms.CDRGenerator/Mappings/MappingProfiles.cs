using AutoMapper;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.CDRGenerator.Models;

namespace MishaTelecoms.API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CDRDataDto, CDRDataModel>().ReverseMap();
        }
    }
}
