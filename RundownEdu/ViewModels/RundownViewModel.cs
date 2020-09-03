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
        public int Id { get; set; }
        public string Title { get; set; }
        public int ShowId { get; set; }
        public string ShowTitle { get; set; }
        public string ShowColor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<StoryViewModel> Stories { get; set; }
        public bool Active { get; set; }

        public RundownViewModel() { }

        public RundownViewModel(RundownEduDBContext db, Rundown model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.StartTime = model.StartTime;
            this.ShowId = model.ShowId;
            this.ShowTitle = model.Show?.Title;
            this.ShowColor = model.Show?.Color;
            this.EndTime = model.EndTime;
            List<Story> stories = db.Stories.Where(x => x.RundownId == model.Id).ToList();
            this.Stories = new List<StoryViewModel>();
            stories.ForEach(s => this.Stories.Add(new StoryViewModel(db, s)));
            this.Active = model.Active;
        }
    }
}
