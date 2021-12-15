using ScheduleApp.Dictionaries;
using ScheduleApp.Models;
using ScheduleApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string path;
        private BindingList<Subject> subjectsBindingList;
        private FileIOService fileIOService;
        private Dictionary<string, int> dayOfWeekDictionary;

        public MainWindow()
        {
            path = $"{Environment.CurrentDirectory}\\subjects.json";
            subjectsBindingList = new BindingList<Subject>();
            fileIOService = new FileIOService(path);
            dayOfWeekDictionary = DayOfWeekDictionary.GetDictionary();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                subjectsBindingList = fileIOService.LoadData();
                var subjectsList = new List<Subject>();

                if(subjectsBindingList != null || subjectsBindingList.Count != 0)
                {
                    subjectsList = subjectsBindingList.Where(x => x.DayOfWeek != null)
                        .OrderBy(x => dayOfWeekDictionary[x.DayOfWeek.ToLower()]).ToList();
                    subjectsBindingList = new BindingList<Subject>();

                    foreach (var subject in subjectsList)
                    {
                        subjectsBindingList.Add(new Subject
                        {                
                            Name = subject.Name,
                            DayOfWeek = subject.DayOfWeek,
                            StartTime = subject.StartTime,
                            EndTime = subject.EndTime
                        });
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                Close();
            }

            dgSchedule.ItemsSource = subjectsBindingList;
            subjectsBindingList.ListChanged += SubjectsBindingList_ListChanged;
        }

        private void SubjectsBindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted
                || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    fileIOService.SaveData(sender);
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    Close();
                }
            }
        }
    }
}
