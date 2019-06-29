using System;
using AutoMapper;
using JustInfo.Domain.Models;
using JustInfo.UIResources;

namespace JustInfo.Helpers.Mappings
{
    public class ToUIResponse : Profile
    {
        public ToUIResponse()
        {
            CreateMap<UserInfo, UserProfileResponse>();
            CreateMap<Scrap, ScrapResponse>();
            CreateMap<ScrapComment, ScrapCommentResponse>();
        }
    }
}
