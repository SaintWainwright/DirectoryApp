using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryApp.ViewModels;

namespace DirectoryApp.View
{
    public class Contact : MainViewModel
    {
        private string contactID;
        private string firstName;
        private string lastName;
        private string email;
        private string type;
        private string mobileNo;
        private string schoolProgram;
        private string course;

        public string ContactID
        {
            get { return contactID; }
            set { contactID = value; OnPropertyChanged(); OnPropertyChanged(nameof(contactID)); }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(); OnPropertyChanged(nameof(firstName)); }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(); OnPropertyChanged(nameof(lastName)); }
        }
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); OnPropertyChanged(nameof(email)); }
        }
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(); OnPropertyChanged(nameof(type)); }
        }
        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; OnPropertyChanged(); OnPropertyChanged(nameof(mobileNo)); }
        }
        public string SchoolProgram
        {
            get { return schoolProgram; }
            set { schoolProgram = value; OnPropertyChanged(); OnPropertyChanged(nameof(schoolProgram)); }
        }
        public string Course
        {
            get { return course; }
            set { course = value; OnPropertyChanged(); OnPropertyChanged(nameof(course)); }
        }
    }
}
