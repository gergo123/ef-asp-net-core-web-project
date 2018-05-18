using AutoMapper;
using Db3.Model.Placeholder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.ViewModels;

namespace Web1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Since every property is the same, we dont need to explicitly specify mapping details
            CreateMap<PlaceholderEntity, PlaceHolderViewModel>();
            CreateMap<PlaceHolderViewModel, PlaceholderEntity>();

            CreateMap<SimplePlaceHolderEntity, SimplePlaceHolderViewModel>();
            CreateMap<SimplePlaceHolderViewModel, SimplePlaceHolderEntity>();
        }
    }
}
