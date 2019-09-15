using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.Models
{
    public enum SegmentType { Intro, Main }

    public class Segment
    {
        public int SegmentId { get; set; }
        public SegmentType Type { get; set; }
        public string Reader { get; set; }
        public string EstimatedReadTime { get; set; }
        public string ActualReadTime { get; set; }
        [ForeignKey("Story")]
        public int StoryId { get; set; }
        public Story Story { get; set; }

    }
}
