using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryApp.ContentPages;
using System.Windows.Input;
using DirectoryApp.View;
using System.Collections.ObjectModel;

namespace DirectoryApp.ViewModels
{
    public partial class Register_ViewModel : MainViewModel
    {
        public Register_ViewModel()
        {
            NewStudent = new Student();
            InitializeSchoolPrograms();
            InitializeYearLevels();
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
                int intOnly;
                if ((int.TryParse(value, out intOnly)) || String.IsNullOrEmpty(StudentIDEntry))
                {
                    NewStudent.StudentID = intOnly;
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Student ID", "Required. Numeric values only", "Okay");
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
                int intOnly;
                if ((int.TryParse(value, out intOnly)) || String.IsNullOrEmpty(_MobileNoEntry))
                {
                    NewStudent.MobileNo = intOnly.ToString();
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
                    Courses .Add("Bachelor of Science in Biology major in Medical Biology");
                    Courses.Add("Bachelor of Science in Biology major in Microbiology");
                    Courses.Add("Bachelor of Science in Psychology");
                    Courses .Add("Bachelor of Library and Information Science");
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
    }
}
