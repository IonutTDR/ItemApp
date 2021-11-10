using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public int NumberOfComments
        {
            get
            {
                return Comments.Count();
            }
        }
        public ICollection<Models.Comment> Comments { get; set; } = new List<Models.Comment>();
    }
}
