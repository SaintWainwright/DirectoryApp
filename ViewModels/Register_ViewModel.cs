using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryApp.ContentPages;
using System.Windows.Input;
using DirectoryApp.View;
using System.Collections.ObjectModel;
using DirectoryApp.Service;

namespace DirectoryApp.ViewModels
{
    public partial class Register_ViewModel : MainViewModel
    {
        private readonly StudentServices studentServices;
        public Register_ViewModel()
        {
            NewStudent = new Student();
            InitializeSchoolPrograms();
            InitializeYearLevels();
            studentServices = new StudentServices();
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

        private string _StudentIDEntry;
        public string StudentIDEntry
        {
            get { return _StudentIDEntry; }
            set
            {
                _StudentIDEntry = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_StudentIDEntry));
                if (StudentIDEntry.All(char.IsDigit) || String.IsNullOrEmpty(StudentIDEntry))
                {
                    NewStudent.StudentID = StudentIDEntry;
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Student ID", "Required. Numeric values only & Only 5 Digits", "Okay");
                }
            }
        }

        private DateTime _DateToday = DateTime.Today;
        public DateTime DateToday
        {
            get { return _DateToday; }
            set { _DateToday = value; }
        }

        private string _MobileNoEntry;
        public string MobileNoEntry
        {
            get { return _MobileNoEntry; }
            set
            {
                _MobileNoEntry = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_MobileNoEntry));
                if (MobileNoEntry.All(char.IsDigit) || String.IsNullOrEmpty(MobileNoEntry))
                {
                    NewStudent.MobileNo = MobileNoEntry;
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Mobile No", "Number Input Only", "Okay");
                }
            }
        }

        private ObservableCollection<String> _SchoolProgram;
        private ObservableCollection<String> _Courses;
        private ObservableCollection<String> _YearLevel;

        public ObservableCollection<String> SchoolProgram
        {
            get { return  _SchoolProgram; }
            set
            {
                _SchoolProgram = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_SchoolProgram));
            }
        }

        public ObservableCollection<String> Courses
        {
            get { return _Courses; }
            set
            {
                _Courses = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_Courses));
            }
        }

        public ObservableCollection<String> YearLevel
        {
            get { return _YearLevel; }
            set
            {
                _YearLevel = value;
                OnPropertyChanged(nameof(_YearLevel));
            }
        }

        private void InitializeSchoolPrograms()
        {
            SchoolProgram = new ObservableCollection<string>
            {
                "School of Engineering",
                "School of Computer Studies",
                "School of Law",
                "School of Arts and Sciences",
                "School of Business and Management",
                "School of Education",
                "School of Allied Medical Sciences"
            };
        }
        private string _SchoolProgramPicker;
        public string SchoolProgramPicker
        {
            get { return _SchoolProgramPicker; }
            set
            {
                _SchoolProgramPicker = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_SchoolProgramPicker));
                NewStudent.SchoolProgram = SchoolProgramPicker;
                InitializeCourses();
            }
        }
        public void InitializeCourses()
        {
            Courses = new ObservableCollection<string>();
            switch (SchoolProgramPicker)
            {
                case "School of Engineering":
                    Courses.Add("Bachelor of Science in Civil Engineering");
                    Courses.Add("Bachelor of Science in Computer Engineering");
                    Courses.Add("Bachelor of Science in Electrical Engineering");
                    Courses.Add("Bachelor of Science in Electronics Engineering");
                    Courses.Add("Bachelor of Science in Industrial Engineering");
                    Courses.Add("Bachelor of Science in Mechanical Engineering");
                    break;
                case "School of Computer Studies":
                    Courses.Add("Bachelor of Science in Computer Science");
                    Courses.Add("Bachelor of Science in Information Technology");
                    Courses.Add("Bachelor of Science in Information Systems");
                    break;
                case "School of Law":
                    Courses.Add("Bachelor of Laws");
                    break;
                case "School of Arts and Sciences":
                    Courses.Add("Bachelor of Arts in Communication");
                    Courses.Add("Bachelor of Arts in Marketing Communication");
                    Courses.Add("Bachelor of Arts in Journalism");
                    Courses.Add("Bachelor of Arts in English Language Studies");
                    Courses.Add("Bachelor of Science in Biology major in Medical Biology");
                    Courses.Add("Bachelor of Science in Biology major in Microbiology");
                    Courses.Add("Bachelor of Science in Psychology");
                    Courses.Add("Bachelor of Library and Information Science");
                    Courses.Add("Bachelor of Arts in International Studies");
                    Courses.Add("Bachelor of Arts in Political Science");
                    break;
                case "School of Business and Management":
                    Courses.Add("Bachelor of Science in Accountancy");
                    Courses.Add("Bachelor of Science in Management Accounting");
                    Courses.Add("Bachelor of Science in Business Administration  Financial Management");
                    Courses.Add("Bachelor of Science in Entrepreneurship");
                    Courses.Add("Bachelor of Science in Business Administration  Operation Management");
                    Courses.Add("Bachelor of Science in Business Administration  Marketing Management");
                    Courses.Add("Bachelor of Science in Business Administration  Human Resource Development Management");
                    Courses.Add("Bachelor of Science in Hospitality Management major in Food and Beverage");
                    Courses.Add("Bachelor of Science in Tourism Management");
                    break;
                case "School of Education":
                    Courses.Add("Bachelor of Elementary Education");
                    Courses.Add("Bachelor of Early Childhood Education");
                    Courses.Add("Bachelor of Physical Education");
                    Courses.Add("Bachelor of Secondary Education Major in English");
                    Courses.Add("Bachelor of Secondary Education Major in Filipino");
                    Courses.Add("Bachelor of Secondary Education Major in Mathematics");
                    Courses.Add("Bachelor of Secondary Education Major in Science");
                    Courses.Add("Bachelor of Special Needs Education-Generalist");
                    Courses.Add("Bachelor of Special Needs Education major in Early Childhood Education");
                    Courses.Add("Bachelor of Special Needs Education major in Elementary School Teaching");
                    break;
                case "School of Allied Medical Sciences":
                    Courses.Add("Bachelor of Science in Nursing");
                    break;
            }
        }
        private void InitializeYearLevels()
        {
            YearLevel = new ObservableCollection<string>
            {
                "1st Year",
                "2nd Year",
                "3rd Year",
                "4th Year",
                "5th Year",
                "Other"
            };
        }
        //ResetButtion
        private void Reset()
        {
            StudentIDEntry = string.Empty;
            NewStudent.FirstName = string.Empty;
            NewStudent.LastName = string.Empty;
            NewStudent.Email = string.Empty;
            NewStudent.Password = string.Empty;
            NewStudent.ConfirmPassword = string.Empty;
            NewStudent.Gender = string.Empty;
            NewStudent.BirthDate = DateToday;
            MobileNoEntry = string.Empty;
            NewStudent.City = string.Empty;
            SchoolProgramPicker = string.Empty;
            NewStudent.Course = string.Empty;
            NewStudent.YearLevel = string.Empty;
        }
        public ICommand ResetCommand => new Command(Reset);

        //Validate Form
        private bool ValidateForm()
        {
            bool allFieldsFilled = false;
            if ((!string.IsNullOrWhiteSpace(StudentIDEntry) )&&
                !string.IsNullOrWhiteSpace(NewStudent.FirstName) &&
                !string.IsNullOrWhiteSpace(NewStudent.LastName) &&
                !string.IsNullOrWhiteSpace(NewStudent.Email) &&
                !string.IsNullOrWhiteSpace(NewStudent.Password) &&
                !string.IsNullOrWhiteSpace(NewStudent.ConfirmPassword) &&
                !string.IsNullOrWhiteSpace(NewStudent.Gender) &&
                !string.IsNullOrWhiteSpace(NewStudent.City) &&
                !string.IsNullOrWhiteSpace(SchoolProgramPicker) &&
                !string.IsNullOrWhiteSpace(NewStudent.YearLevel) &&
                !string.IsNullOrWhiteSpace(NewStudent.Course))
            {
                allFieldsFilled = true;
            }

            return allFieldsFilled;
        }
        private bool CheckStudentIDExisting()
        {
            foreach (var studentListed in studentServices.GetStudents())
            {
                if (StudentIDEntry == studentListed.StudentID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private bool CheckSamePassword()
        {
            return (NewStudent.Password == NewStudent.ConfirmPassword);
        }
        private string MissingFields()
        {
            string ConcatonateString = string.Empty;
            if (!ValidateForm())
            {
                if (string.IsNullOrWhiteSpace(StudentIDEntry))
                {
                    ConcatonateString += "Student ID \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.FirstName))
                {
                    ConcatonateString += "First Name \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.LastName))
                {
                    ConcatonateString += "Last Name \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.Email))
                {
                    ConcatonateString += "Email \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.Password))
                {
                    ConcatonateString += "Password \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.ConfirmPassword))
                {
                    ConcatonateString += "Confirm Password \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.Gender))
                {
                    ConcatonateString += "Gender \n";
                }
                if (string.IsNullOrWhiteSpace(MobileNoEntry))
                {
                    ConcatonateString += "Mobile No. \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.City))
                {
                    ConcatonateString += "City \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.SchoolProgram))
                {
                    ConcatonateString += "School Program \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.Course))
                {
                    ConcatonateString += "Course \n";
                }
                if (string.IsNullOrWhiteSpace(NewStudent.YearLevel))
                {
                    ConcatonateString += "Year Level \n";
                }
            }
            return ConcatonateString;
        }
        private void Submit()
        {
            if (!ValidateForm())
            {
                Shell.Current.DisplayAlert("The Following Fields Are Empty", MissingFields(), "Continue");
            }
            else if (!CheckSamePassword())
            {
                Shell.Current.DisplayAlert("Passwords Not Matching!", "Please input same password on both entries", "Continue");
            }
            else if(CheckStudentIDExisting())
            {
                Shell.Current.DisplayAlert("Student ID Existing!", "ID and user already exists. Please enter a new user to register", "Okay");
            }
            else
            {
                studentServices.AddStudent(NewStudent);
                Shell.Current.DisplayAlert("Register Success!", "Sucessfully Registered your Account", "Continue");
                Shell.Current.GoToAsync("..");
            }
        }
        public ICommand SubmitCommand => new Command(Submit);
    }
}
