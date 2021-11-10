using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class ItemToCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
    }
}
