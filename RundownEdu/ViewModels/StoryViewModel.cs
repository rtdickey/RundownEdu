using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using RundownEdu.Interfaces;
using RundownEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.ViewModels
{
    public class StoryViewModel : IConvertToModel<Story, RundownEduDBContext>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RundownId { get; set; }
        public RundownViewModel Rundown { get; set; }
        public List<Segment> Segments { get; set; }
        public string Index { get; set; }

        public StoryViewModel() { }
        public StoryViewModel(Story model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.RundownId = model.RundownId;
        }

        public Story ConvertToModel(RundownEduDBContext context)
        {
            return ConvertVMToModel(context, new Story());
        }

        public Story ConvertToModel(RundownEduDBContext context, Story model)
        {
            return ConvertVMToModel(context, model);
        }

        public Story ConvertVMToModel(RundownEduDBContext context, Story model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.RundownId = model.RundownId;
            return model;
        }
    }
}
