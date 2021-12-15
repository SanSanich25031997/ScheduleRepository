using ScheduleApp.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ScheduleApp.Models
{
    public class Subject : INotifyPropertyChanged
    {
        public string Name { get; set; }
        [DayOfWeek(ErrorMessage = "Указанного дня недели не сущесвует или введено Воскресенье!")]
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
