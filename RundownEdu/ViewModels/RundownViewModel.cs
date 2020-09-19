using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using RundownEdu.Interfaces;
using RundownEdu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RundownEdu.ViewModels
{
    public class RundownViewModel : IConvertToModel<Rundown, RundownEduDBContext>
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
            Active = model.Active;
            if (model.Stories == null) { model.Stories = new List<Story>(); }
            model.Stories.ForEach(x => Stories.Add(new StoryViewModel(x)));
        }

        public Rundown ConvertToModel(RundownEduDBContext context)
        {
            return ConvertVMToModel(context, new Rundown());
        }

        public Rundown ConvertToModel(RundownEduDBContext context, Rundown model)
        {
            return ConvertVMToModel(context, model);
        }

        public Rundown ConvertVMToModel(RundownEduDBContext context, Rundown model)
        {
            model.Id = Id;
            model.Title = Title;
            model.StartTime = StartTime;
            model.EndTime = EndTime;
            model.ShowId = ShowId;
            model.Show = Show;
            model.EndTime = EndTime;
            model.Active = Active;
            if (Stories == null) { Stories = new List<StoryViewModel>(); }
            for (int i = 0; i < model.Stories.Count(); i++)
            {
                int itemId = model.Stories[i].Id;
                var editedItem = Stories.Find(x => x.Id == itemId);
                if (editedItem != null)
                {
                    model.Stories[i] = editedItem.ConvertToModel(context, model.Stories[i]);
                }
                else
                {
                    var delItem = context.Stories.Find(itemId);
                    if (delItem != null)
                    {
                        context.Entry(delItem).State = EntityState.Deleted;
                    }
                }
            }
            return model;
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
