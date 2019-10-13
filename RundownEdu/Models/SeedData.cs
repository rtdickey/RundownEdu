using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RundownEdu.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                using (var context = new RundownEduDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RundownEduDBContext>>()))
                {
                    DateTime morningShowExample = new DateTime(2019, 10, 1, 6, 00, 00, DateTimeKind.Local);
                    DateTime afternoonShowExample = new DateTime(2019, 10, 1, 18, 00, 00, DateTimeKind.Local);
                    if (!context.Shows.Any())
                    {
                        //List<Rundown> rundowns = new List<Rundown>();
                        //rundowns.AddRange(context.Rundowns.ToList());
                        context.Shows.AddRange(
                            new Show
                            {
                                Title = "CHS Audio/Video Class",
                                Active = true
                            }
                        );
                        context.SaveChanges();
                    }

                    if (!context.Rundowns.Any())
                    {
                        context.Rundowns.AddRange(
                            new Rundown
                            {
                                Title = "Morning Show Example",
                                StartTime = morningShowExample.ToUniversalTime(),
                                EndTime = morningShowExample.AddMinutes(30).ToUniversalTime(),
                                ShowId = context.Shows.Select(s => s.Id).FirstOrDefault(),
                                Active = true
                            },
                            new Rundown
                            {
                                Title = "Afternoon Show Example",
                                StartTime = afternoonShowExample.ToUniversalTime(),
                                EndTime = afternoonShowExample.AddMinutes(30).ToUniversalTime(),
                                ShowId = context.Shows.Select(s => s.Id).FirstOrDefault(),
                                Active = true
                            }
                        );
                        context.SaveChanges();
                    }

                    if (!context.Stories.Any()) {
                        
                    }

                    if (!context.Segments.Any())
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("===> Error Here ===: " + ex);
            }

        }
    }
}