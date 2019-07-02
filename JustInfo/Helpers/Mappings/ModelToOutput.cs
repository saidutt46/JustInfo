using System;
using AutoMapper;
using JustInfo.Domain.Models;
using JustInfo.UIResources.UIOutput;

namespace JustInfo.Helpers.Mappings
{
    public class ModelToOutput : Profile
    {
        public ModelToOutput()
        {
            CreateMap<Scrap, ScrapOutput>();
            CreateMap<UserInfo, UserProfileResponse>();
        }
    }
}
