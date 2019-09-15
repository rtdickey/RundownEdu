using RundownEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.ViewModels
{
    public class StoryViewModel
    {
        public int StoryId;
        public string Title;
        public int RundownId;
        public Rundown Rundown;
        public List<Segment> Segments;
        public string Index;

        public StoryViewModel() { }
        public StoryViewModel(RundownEduDBContext db, Story model)
        {
            this.StoryId = model.StoryId;
            this.Title = model.Title;
            this.RundownId = model.RundownId;
        }
    }
}
