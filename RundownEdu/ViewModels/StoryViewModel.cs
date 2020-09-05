using RundownEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.ViewModels
{
    public class StoryViewModel
    {
        public int StoryId { get; set; }
        public string Title { get; set; }
        public int RundownId { get; set; }
        public Rundown Rundown { get; set; }
        public List<Segment> Segments { get; set; }
        public string Index { get; set; }

        public StoryViewModel() { }
        public StoryViewModel(Story model)
        {
            this.StoryId = model.StoryId;
            this.Title = model.Title;
            this.RundownId = model.RundownId;
        }
    }
}
