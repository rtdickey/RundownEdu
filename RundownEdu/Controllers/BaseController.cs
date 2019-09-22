using Microsoft.AspNetCore.Mvc;
using RundownEdu.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.Controllers
{
    public class BaseController : Controller
    {
        public void FontColorManager(Show model)
        {
            if (model.Color != null)
            {
                string colorCode = model.Color.TrimStart('#');
                Color showColor = Color.FromArgb(255, // hardcoded opaque
                int.Parse(colorCode.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(colorCode.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(colorCode.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
                if (showColor.GetBrightness() <= 0.5)
                {
                    model.FontColor = "#FFFFFF";
                }
            }
        }
    }
}
