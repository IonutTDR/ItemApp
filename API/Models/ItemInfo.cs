using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfComments { 
            get
            {
                return Comments.Count();
            } 
        }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
