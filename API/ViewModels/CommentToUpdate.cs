using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.ViewModels
{
    public class CommentToUpdate
    {
        [Required(ErrorMessage = "You should provide a text value")]
        public string Text { get; set; }
    }
}
