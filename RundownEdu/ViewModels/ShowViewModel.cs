using Microsoft.EntityFrameworkCore;
using RundownEdu.Interfaces;
using RundownEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.ViewModels
{
    public class ShowViewModel : IConvertToModel<Show, RundownEduDBContext>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public String FontColor { get; set; }
        public virtual List<RundownViewModel> Rundowns { get; set; } = new List<RundownViewModel>();

        public ShowViewModel() { }
        public ShowViewModel(Show model)
        {
            Id = model.Id;
            Title = model.Title;
            Color = model.Color;
            FontColor = model.FontColor;
            model.Rundowns.ForEach(x => Rundowns.Add(new RundownViewModel(x)));
        }

        public Show ConvertToModel(RundownEduDBContext context)
        {
            throw new NotImplementedException();
        }

        public Show ConvertToModel(RundownEduDBContext context, Show model)
        {
            throw new NotImplementedException();
        }

        public Show ConvertVMToModel(RundownEduDBContext context, Show model)
        {
            model.Id = Id;
            model.Title = Title;
            model.Color = Color;
            model.FontColor = FontColor;
            if (Rundowns == null) { Rundowns = new List<RundownViewModel>(); }
            for (int i = 0; i < model.Rundowns.Count(); i++) {
                int itemId = model.Rundowns[i].Id;
                var editedItem = Rundowns.Find(x => x.Id == itemId);
                if (editedItem != null)
                {
                    model.Rundowns[i] = editedItem.ConvertToModel(context, model.Rundowns[i]);
                }
                else
                {
                    var delItem = context.Rundowns.Find(itemId);
                    if (delItem != null)
                    {
                        context.Entry(delItem).State = EntityState.Deleted;
                    }
                }
            }
            return model;
        }
    }
}
