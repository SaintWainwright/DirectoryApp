using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMAUIApp.ViewModel
{
    public class Student
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

        public int StudentID { get => studentID; set => studentID=value; }
        public string FirstName { get => firstName; set => firstName=value; }
        public string LastName { get => lastName; set => lastName=value; }
        public string Email { get => email; set => email=value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string MobileNo { get => mobileNo; set => mobileNo = value; }
        public string City { get => city; set => city = value; }
        public string SchoolProgram { get => schoolProgram; set => schoolProgram = value; }
        public string Course { get => course; set => course = value; }
        public string YearLevel { get => yearLevel; set => yearLevel=value; }
    }
}
