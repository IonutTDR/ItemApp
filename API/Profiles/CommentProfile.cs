using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Services.Models.Comment, ViewModels.Comment>();
            CreateMap<ViewModels.CommentToCreate, Services.Models.CommentToCreate>();
            CreateMap<Services.Models.CommentToCreate, ViewModels.Comment>();
            CreateMap<ViewModels.CommentToUpdate, Services.Models.CommentToUpdate>();
        }
    }
}
