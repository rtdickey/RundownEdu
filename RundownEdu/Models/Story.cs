using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RundownEdu.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("Rundown")]
        public int RundownId { get; set; }
        public virtual Rundown Rundown { get; set; }
        public virtual List<Segment> Segments { get; set; }
        [NotMapped]
        public string Index { get; set; }
    }
}
