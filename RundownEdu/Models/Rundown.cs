using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.Models
{
    public class Rundown
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required, Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Required, Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        public virtual List<Story> Stories { get; set; }
        [ForeignKey("Show"), Display(Name = "Show")]
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }
        public bool Active { get; set; }
    }
}
