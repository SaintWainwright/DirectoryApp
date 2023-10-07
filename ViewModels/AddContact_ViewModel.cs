using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DirectoryApp.Service;
using DirectoryApp.Services;
using DirectoryApp.View;
using Contact = DirectoryApp.View.Contact;

namespace DirectoryApp.ViewModels
{
    [QueryProperty(nameof(StudentID), "id")]
    public partial class AddContact_ViewModel : MainViewModel
    {
        private readonly ContactServices contactServices = new ContactServices();
        private readonly StudentServices studentServices = new StudentServices();
        private string studentID;
        public string StudentID
        {
            get { return studentID; }
            set
            {
                studentID = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(studentID));
                foreach (var student in studentServices.GetStudents())
                {
                    if (StudentID == student.StudentID)
                    {
                        NewStudent = student;
                    }
                }
            }
        }

        private Student _NewStudent;
        public Student NewStudent
        {
            get { return _NewStudent; }
            set
            {
                _NewStudent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_NewStudent));
            }
        }
    }
}
