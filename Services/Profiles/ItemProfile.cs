using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<DataAccess.Entities.Item, Models.Item>().ReverseMap();
            CreateMap<Models.ItemToCreate, DataAccess.Entities.Item>();
            CreateMap<Models.ItemToUpdate, DataAccess.Entities.Item>();
        }
    }
}
