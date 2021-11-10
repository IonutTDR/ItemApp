using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.ViewModels
{
    public class CommentToCreate
    {
        [Required(ErrorMessage = "You should provide a text value")]
        [MaxLength(50)]
        public string Text { get; set; }
    }
}
