using RundownEdu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.ViewModels
{
    public class RundownViewModel
    {
        public int Id;
        public string Title;
        public DateTime StartTime;
        public DateTime EndTime;
        public List<StoryViewModel> Stories;
        public int ShowId;
        public Show Show;
        public bool Active;

        public RundownViewModel() { }
        public RundownViewModel(RundownEduDBContext db, Rundown model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.StartTime = model.StartTime;
            this.EndTime = model.EndTime;
            List<Story> stories = db.Stories.Where(x => x.RundownId == model.Id).ToList();
            this.Stories = new List<StoryViewModel>();
            stories.ForEach(s => this.Stories.Add(new StoryViewModel(db, s)));
            this.ShowId = model.ShowId;
            this.Show = model.Show;
            this.Active = model.Active;
        }
    }
}
