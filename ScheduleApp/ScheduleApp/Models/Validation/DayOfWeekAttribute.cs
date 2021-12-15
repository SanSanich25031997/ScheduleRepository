using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScheduleApp.Models.Validation
{
    public class DayOfWeekAttribute : ValidationAttribute
    {
        public List<string> DayOfWeeksList { get; set; }

        public DayOfWeekAttribute()
        {
            DayOfWeeksList = new List<string>
            { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"};
        }

        public override bool IsValid(object value)
        {
            if(value != null)
            {
                foreach(var dayOfWeek in DayOfWeeksList)
                {
                    if(dayOfWeek.Equals(value.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
