using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Services.Models.Item, ViewModels.Item>();
            CreateMap<ViewModels.ItemToCreate, Services.Models.ItemToCreate>();
            CreateMap<Services.Models.ItemToCreate, ViewModels.Item>();  
        }
    }
}
