using System;
using AutoMapper;
using JustInfo.Domain.Models;

namespace JustInfo.Helpers.Mappings
{
    public class ViewModelToEntityMapping : Profile
    {
        public ViewModelToEntityMapping()
        {
            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
