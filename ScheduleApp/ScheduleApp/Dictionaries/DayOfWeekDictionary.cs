using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Dictionaries
{
    public static class DayOfWeekDictionary
    {
        public static Dictionary<string , int> GetDictionary()
        {
            return new Dictionary<string, int>
            { {"понедельник", 1}, {"вторник", 2}, {"среда", 3},
              {"четверг", 4}, {"пятница", 5}, {"суббота", 6}};
        }
    }
}
