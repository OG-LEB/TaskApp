using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksApp.TaskModels;

namespace TasksApp.Saves
{
    class DataSaver
    {
        private readonly string path;
        public DataSaver(string path) 
        {
            this.path = path;
        }

        public BindingList<TaskModel> LoadData() 
        {
            var fileExists = File.Exists(path);
            if (!fileExists) 
            {
                File.CreateText(path).Dispose();
                return new BindingList<TaskModel>();
            }
            using (var reader = File.OpenText(path)) 
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskModel>>(fileText);
            }
        }

        public void SaveData(object taskDataList) 
        {
            using (StreamWriter writer = File.CreateText(path)) 
            {
                string output = JsonConvert.SerializeObject(taskDataList);
                writer.WriteLine(output);
            }
        }
    }
}
