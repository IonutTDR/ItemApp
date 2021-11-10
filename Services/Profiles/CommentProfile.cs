using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<DataAccess.Entities.Comment, Models.Comment>().ReverseMap();
            CreateMap<Models.CommentToCreate, DataAccess.Entities.Comment>();
            CreateMap<Models.CommentToUpdate, DataAccess.Entities.Comment>();
        }
    }
}
