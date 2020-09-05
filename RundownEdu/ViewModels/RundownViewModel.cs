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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }
        public virtual List<StoryViewModel> Stories { get; set; } = new List<StoryViewModel>();
        public bool Active { get; set; }

        public RundownViewModel() { }

        public RundownViewModel(Rundown model)
        {
            Id = model.Id;
            Title = model.Title;
            StartTime = model.StartTime;
            EndTime = model.EndTime;
            ShowId = model.ShowId;
            Show = model.Show;
            EndTime = model.EndTime;
            if (model.Stories is null) { model.Stories = new List<Story>(); }
            model.Stories.ForEach(x => Stories.Add(new StoryViewModel(x)));
            Active = model.Active;
        }
    }

    public class RundownOverviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ShowId { get; set; }
        public string ShowTitle { get; set; }
        public string ShowColor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<StoryViewModel> Stories { get; set; } = new List<StoryViewModel>();
        public bool Active { get; set; }

        public RundownOverviewViewModel() { }

        public RundownOverviewViewModel(Rundown model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.StartTime = model.StartTime;
            this.ShowId = model.ShowId;
            this.ShowTitle = model.Show?.Title;
            this.ShowColor = model.Show?.Color;
            this.EndTime = model.EndTime;
            if (model.Stories is null) { model.Stories = new List<Story>(); }
            model.Stories.ForEach(x => Stories.Add(new StoryViewModel(x)));
            this.Active = model.Active;
        }
    }
}
