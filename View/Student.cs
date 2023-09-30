using DirectoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.View
{
    public class Student : MainViewModel
    {
        private int studentID;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string confirmPassword;
        private string gender;
        private DateTime birthDate;
        private string mobileNo;
        private string city;
        private string schoolProgram;
        private string course;
        private string yearLevel;

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; OnPropertyChanged(); OnPropertyChanged(nameof(studentID)); }
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
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); OnPropertyChanged(nameof(password)); }
        }
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; OnPropertyChanged(); OnPropertyChanged(nameof(confirmPassword)); }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged(); OnPropertyChanged(nameof(gender)); }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; OnPropertyChanged(); OnPropertyChanged(nameof(birthDate)); }
        }
        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; OnPropertyChanged(); OnPropertyChanged(nameof(mobileNo)); }
        }
        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(); OnPropertyChanged(nameof(city)); }
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
        public string YearLevel
        {
            get { return yearLevel; }
            set { yearLevel = value; OnPropertyChanged(); OnPropertyChanged(nameof(yearLevel)); }
        }
    }
}
