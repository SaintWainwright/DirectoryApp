using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DirectoryApp.Service;
using DirectoryApp.Services;
using DirectoryApp.View;
using Contact = DirectoryApp.View.Contact;

namespace DirectoryApp.ViewModels
{
    [QueryProperty(nameof(StudentID), "id")]
    public partial class Home_ViewModel : MainViewModel
    {
        private readonly ContactServices contactServices = new();
        private readonly StudentServices studentServices = new();
        private string studentID;
        public string StudentID 
        {
            get { return studentID; }
            set
            {
                studentID = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(studentID));
                foreach(var student in studentServices.GetStudents())
                {
                    if(StudentID == student.StudentID)
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
                GetContacts();
            }
        }
        private ObservableCollection<Contact> contactsList;
        public ObservableCollection<Contact> ContactsList
        {
            get { return contactsList; }
            set { contactsList = value; OnPropertyChanged(); OnPropertyChanged(nameof(contactsList)); }
        }
        private void AddContact()
        {
            string StudentID = NewStudent.StudentID;
            Shell.Current.GoToAsync($"{nameof(AddContact)}?id={StudentID}");
        }
        public ICommand AddContactCommand => new Command(AddContact);
        private void GetContacts()
        {
            if(StudentID != null) 
            {
                ContactsList = contactServices.GetContacts(NewStudent);
            }
        }
    }
}