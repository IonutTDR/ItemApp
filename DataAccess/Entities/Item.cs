using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataAccess.Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public State State { get; set; }
        public int NumberOfComments
        {
            get
            {
                return Comments.Count();
            }
        }
        public ICollection<Entities.Comment> Comments { get; set; } = new List<Entities.Comment>();
    }
}
