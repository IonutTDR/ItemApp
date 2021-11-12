using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class Item
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DataAccess.Entities.State State { get; set; }
        public int NumberOfComments { get; set; }
    }
}
