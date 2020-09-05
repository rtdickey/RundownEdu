using RundownEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.ViewModels
{
    public class ShowViewModel
    {
    }

    public class ShowOverviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public String FontColor { get; set; }
        public virtual List<RundownOverviewViewModel> Rundowns { get; set; } = new List<RundownOverviewViewModel>();

        public ShowOverviewViewModel() { }
        public ShowOverviewViewModel(RundownEduDBContext db, Show model)
        {
            Id = model.Id;
            Title = model.Title;
            Color = model.Color;
            FontColor = model.FontColor;
            model.Rundowns.ForEach(x => Rundowns.Add(new RundownOverviewViewModel(x)));
        }
    }
}
