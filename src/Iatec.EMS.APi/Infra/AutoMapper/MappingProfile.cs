using AutoMapper;
using Iatec.EMS.Api.ViewModels;
using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Services.DTOs;

namespace Iatec.EMS.Api.Infra.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
            CreateMap<LoginUserViewModel, UserDTO>().ReverseMap();
            #endregion

            #region Event
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<CreateEventViewModel, EventDTO>().ReverseMap();
            CreateMap<UpdateEventViewModel, EventDTO>().ReverseMap();
            #endregion

            #region EventPartipant
            CreateMap<EventParticipant, EventParticipantDTO>().ReverseMap();
            #endregion
        }
    }
}
