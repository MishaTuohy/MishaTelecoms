﻿using AutoMapper;
using MishaTelecoms.API.Models;
using MishaTelecoms.Application.Dtos;

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