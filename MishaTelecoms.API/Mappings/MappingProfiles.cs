using AutoMapper;
using MishaTelecoms.API.Models.Requests.CDRData.Post.Create;
using MishaTelecoms.API.Models.Requests.CDRData.Post.Update;
using MishaTelecoms.API.Models.Requests.UserData.Post.Create;
using MishaTelecoms.API.Models.Requests.UserData.Post.Delete;
using MishaTelecoms.API.Models.Requests.UserData.Post.Update;
using MishaTelecoms.Application.Dtos;
using MishaTelecoms.Application.Features.CDRData.Commands.Create;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateAll;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCalledNumber;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallingNumber;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCallType;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCost;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateCountry;
using MishaTelecoms.Application.Features.CDRData.Commands.Updates.UpdateDuration;
using MishaTelecoms.Application.Features.User.Commands.CreateUser;
using MishaTelecoms.Application.Features.User.Commands.DeleteUser;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateAll;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateEmail;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateEmailConfirmed;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateNormalizedEmail;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateNormalizedUserName;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePassword;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePhoneNumber;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdatePhoneNumberConfirmed;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateTwoFactorEnabled;
using MishaTelecoms.Application.Features.User.Commands.UpdateUser.UpdateUserName;
using MishaTelecoms.Domain.Entities;

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

            // Create User Request
            CreateMap<CreateUserRequest, CreateUserCommand>().ReverseMap();
            CreateMap<CreateUserCommand, ApplicationUserDto>().ReverseMap();

            // Update User Requests
            CreateMap<UpdateUserAllRequest, UpdateUserAllCommand>().ReverseMap();
            CreateMap<UpdateUserAllCommand, ApplicationUserDto>().ReverseMap();
            CreateMap<UpdateUserNameRequest, UpdateUserUserNameCommand>().ReverseMap();
            CreateMap<UpdateUserNormalizedUserNameRequest, UpdateUserNormalizedUserNameCommand>().ReverseMap();
            CreateMap<UpdateUserEmailRequest, UpdateUserEmailCommand>().ReverseMap();
            CreateMap<UpdateUserNormalizedEmailRequest, UpdateUserNormalizedEmailCommand>().ReverseMap();
            CreateMap<UpdateUserEmailConfirmedRequest, UpdateUserEmailConfirmedCommand>().ReverseMap();
            CreateMap<UpdateUserPhoneNumberRequest, UpdateUserPhoneNumberCommand>().ReverseMap();
            CreateMap<UpdateUserPhoneNumberConfirmedRequest, UpdateUserPhoneNumberConfirmedCommand>().ReverseMap();
            CreateMap<UpdateUserPasswordHashRequest, UpdateUserPasswordCommand>().ReverseMap();
            CreateMap<UpdateUserTwoFactorEnabledRequest, UpdateUserTwoFactorEnabledCommand>().ReverseMap();

            // Delete User Request
            CreateMap<DeleteUserRequest, DeleteUserCommand>().ReverseMap();

            // Application -> Infrastructure Layer
            CreateMap<ApplicationUserDto, ApplicationUserDto>().ReverseMap();
            CreateMap<CDRDataDto, CDRData>().ReverseMap();
        }
    }
}
