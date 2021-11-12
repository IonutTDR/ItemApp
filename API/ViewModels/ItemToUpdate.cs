using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ItemToUpdate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DataAccess.Entities.State State { get; set; }
    }
}
