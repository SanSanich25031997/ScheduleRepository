using Newtonsoft.Json;
using ScheduleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ScheduleApp.Services
{
    public class FileIOService
    {
        private readonly string path;

        public FileIOService(string path)
        {
            this.path = path;
        }

        public void SaveData(object subjectsList)
        {
            using(var writer = File.CreateText(path))
            {
                var output = JsonConvert.SerializeObject(subjectsList);
                writer.Write(output);
            }
        }

        public BindingList<Subject> LoadData()
        {
            var fileExists = File.Exists(path);
            if(!fileExists)
            {
                File.Create(path).Dispose();
                return new BindingList<Subject>();
            }
            using(var reader = File.OpenText(path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Subject>>(fileText);
            }
        }
    }
}
