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
using System.Windows.Input;
using DirectoryApp.ContentPages;

namespace DirectoryApp.ViewModels
{
    [QueryProperty(nameof(StudentID), "id")]
    public partial class AddContact_ViewModel : MainViewModel
    {
        public AddContact_ViewModel()
        {
            NewContact = new Contact();
            InitializeSchoolPrograms();
        }
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
        private Contact _NewContact;
        public Contact NewContact
        {
            get { return _NewContact; }
            set
            {
                _NewContact = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_NewContact));
            }
        }
        private string _ContactType;
        public string ContactType
        {
            get { return _ContactType; }
            set
            {
                _ContactType = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_ContactType));
                NewContact.Type = ContactType;
                IsFaculty();
            }
        }
        private string _ContactIDEntry;
        public string ContactIDEntry
        {
            get { return _ContactIDEntry; }
            set
            {
                _ContactIDEntry = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_ContactIDEntry));
                if (_ContactIDEntry.All(char.IsDigit) || String.IsNullOrEmpty(_ContactIDEntry))
                {
                    NewContact.ContactID = _ContactIDEntry;
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Contact ID", "Required. Numeric values only", "Okay");
                }
            }
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
                    NewContact.MobileNo = MobileNoEntry;
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Mobile No", "Number Input Only", "Okay");
                }
            }
        }
        private bool _CanPick = true;
        public bool CanPick
        {
            get { return _CanPick; }
            set
            {
                _CanPick = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_CanPick));
            }
        }
        private int _MaxLength = 5;
        public int MaxLength
        {
            get { return _MaxLength; }
            set
            {
                _MaxLength = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_MaxLength));
            }
        }
        private void IsFaculty()
        {
            if (NewContact.Type == "Faculty")
            {
                CanPick = false;
                MaxLength = 4;
                ContactIDEntry = string.Empty;
                NewContact.Course = string.Empty;
                NewContact.Course = "N/A";
            }
            else
            {
                MaxLength = 5;
                ContactIDEntry = string.Empty;
                CanPick = true;
            }
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
                NewContact.SchoolProgram = SchoolProgramPicker;
                InitializeCourses();
            }
        }
        private ObservableCollection<String> _SchoolProgram;
        private ObservableCollection<String> _Courses;
        public ObservableCollection<String> SchoolProgram
        {
            get { return _SchoolProgram; }
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
        private void Reset()
        {
            ContactType = string.Empty;
            ContactIDEntry = string.Empty;
            NewContact.LastName = string.Empty;
            NewContact.FirstName = string.Empty;
            NewContact.Email = string.Empty;
            MobileNoEntry = string.Empty;
            SchoolProgramPicker = string.Empty;
            NewContact.Course = string.Empty;
        }
        public ICommand ResetCommand => new Command(Reset);
        private bool ValidateForm()
        {
            bool allFieldsFilled = false;
            if ((!string.IsNullOrWhiteSpace(ContactType))&&
                !string.IsNullOrWhiteSpace(ContactIDEntry) &&
                !string.IsNullOrWhiteSpace(NewContact.LastName) &&
                !string.IsNullOrWhiteSpace(NewContact.FirstName) &&
                !string.IsNullOrWhiteSpace(NewContact.Email) &&
                !string.IsNullOrWhiteSpace(MobileNoEntry) &&
                !string.IsNullOrWhiteSpace(SchoolProgramPicker) &&
                (!string.IsNullOrWhiteSpace(NewContact.Course) || !CanPick))
            {
                allFieldsFilled = true;
            }
            return allFieldsFilled;
        }
        private string MissingFields()
        {
            string ConcatonateString = string.Empty;
            if (!ValidateForm())
            {
                if (string.IsNullOrWhiteSpace(ContactIDEntry))
                {
                    ConcatonateString += "Contact ID \n";
                }
                if (string.IsNullOrWhiteSpace(NewContact.FirstName))
                {
                    ConcatonateString += "First Name \n";
                }
                if (string.IsNullOrWhiteSpace(NewContact.LastName))
                {
                    ConcatonateString += "Last Name \n";
                }
                if (string.IsNullOrWhiteSpace(NewContact.Email))
                {
                    ConcatonateString += "Email \n";
                }
                if (string.IsNullOrWhiteSpace(ContactType))
                {
                    ConcatonateString += "Contact Type \n";
                }
                if (string.IsNullOrWhiteSpace(MobileNoEntry))
                {
                    ConcatonateString += "Mobile No. \n";
                }
                if (string.IsNullOrWhiteSpace(NewContact.SchoolProgram))
                {
                    ConcatonateString += "School Program \n";
                }
                if (string.IsNullOrWhiteSpace(NewContact.Course))
                {
                    ConcatonateString += "Course \n";
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
            else
            {
                if (NewContact.Type == "Faculty" && NewContact.Course == null)
                    NewContact.Course = "N/A";
                contactServices.AddContact(NewContact, NewStudent);
                string StudentID = NewStudent.StudentID;
                Shell.Current.GoToAsync($"{nameof(Home)}?id={StudentID}");
            }
        }
        public ICommand SubmitCommand => new Command(Submit);
    }
}