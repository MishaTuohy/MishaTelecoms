using AutoMapper;
using MishaTelecoms.API.Models;
using MishaTelecoms.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
