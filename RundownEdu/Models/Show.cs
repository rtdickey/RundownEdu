using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.Models
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        [NotMapped]
        public string FontColor { get; set; } = "#000000";
        public bool Active { get; set; }
        public virtual List<Rundown> Rundowns { get; set; }
    }
}
