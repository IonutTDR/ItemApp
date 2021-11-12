using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ItemToCreate
    {
        [Required(ErrorMessage = "You should provide a title value")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You should provide a description value")]
        public string Description { get; set; }
    }
}
