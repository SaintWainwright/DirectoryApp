using DirectoryApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Service
{
    class StudentCollection
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Users.txt");
        ObservableCollection<Student> StudentList = new ObservableCollection<Student>();


    }
}
