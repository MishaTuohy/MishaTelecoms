using AutoMapper;
using MishaTelecoms.API.Models.Requests.CDRData.Post.Create;
using MishaTelecoms.API.Models.Requests.CDRData.Post.Update;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Features.CDRData.Commands.Create;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateAll;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCalledNumber;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallingNumber;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallType;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCost;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCountry;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateDuration;

namespace MishaTelecoms.API.Mappings
{
    /// <summary>
    /// Used for passing objects between application layer and api
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Create CDR Request
            CreateMap<CreateCDRCommand, CDRDataDto>().ReverseMap();
            CreateMap<CreateCDRRequest, CreateCDRCommand>().ReverseMap();

            // Update CDR Requests
            CreateMap<UpdateCDRAllRequest, UpdateCDRAllCommand>().ReverseMap();
            CreateMap<UpdateCDRAllCommand, CDRDataDto>().ReverseMap();
            CreateMap<UpdateCDRCalledNumberRequest, UpdateCDRCalledNumberCommand>().ReverseMap();
            CreateMap<UpdateCDRCallingNumberRequest, UpdateCDRCallingNumberCommand>().ReverseMap();
            CreateMap<UpdateCDRCountryRequest, UpdateCDRCountryCommand>().ReverseMap();
            CreateMap<UpdateCDRCallTypeRequest, UpdateCDRCallTypeCommand>().ReverseMap();
            CreateMap<UpdateCDRDurationRequest, UpdateCDRDurationCommand>().ReverseMap();
            CreateMap<UpdateCDRCostRequest, UpdateCDRCostCommand>().ReverseMap();
        }
    }
}
