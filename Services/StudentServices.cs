using DirectoryApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DirectoryApp.Service
{
    class StudentServices
    {
        string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Users.txt");

        public void AddStudent(Student student)
        {
            ObservableCollection<Student> StudentCollection = GetStudents();
            if(student != null)
            {
                StudentCollection.Add(student);
                var StudentList = JsonSerializer.Serialize<ObservableCollection<Student>>(StudentCollection);
                File.WriteAllText(filePath, StudentList);
            }
        }

        public ObservableCollection<Student> GetStudents()
        {
            if(!File.Exists(filePath)) 
            {
                return new ObservableCollection<Student>();
            }
            
            string FileUsers = File.ReadAllText(filePath);
            var StudentList = JsonSerializer.Deserialize<ObservableCollection<Student>>(FileUsers);

            return StudentList;
        }
    }
}
