using System;
using AutoMapper;
using JustInfo.Domain.Models;
using JustInfo.UIResources.UIInput;

namespace JustInfo.Helpers.Mappings
{
    public class InputToModel : Profile
    {
        public InputToModel()
        {
            CreateMap<ScrapInput, Scrap>();
        }
    }
}
