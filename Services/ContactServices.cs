using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryApp.View;
using System.Collections.ObjectModel;
using System.Text.Json;
using Contact = DirectoryApp.View.Contact;

namespace DirectoryApp.Services
{
    class ContactServices
    {
        string filePath = FileSystem.Current.AppDataDirectory;

        public void AddContact(Contact contact, Student student)
        {
            ObservableCollection<Contact> ContactCollection = GetContacts(student);
            if (contact != null)
            {
                ContactCollection.Add(contact);
                string contactsFilePath = Path.Combine(filePath, $"S{student.StudentID}.txt");
                var ContactList = JsonSerializer.Serialize<ObservableCollection<Contact>>(ContactCollection);
                File.WriteAllText(contactsFilePath, ContactList);
            }
        }

        public ObservableCollection<Contact> GetContacts(Student student)
        {
            string contactsFilePath = Path.Combine(filePath, $"S{student.StudentID}.txt");
            if (!File.Exists(contactsFilePath))
            {
                return new ObservableCollection<Contact>();
            }

            string FileUsers = File.ReadAllText(contactsFilePath);
            var ContactList = JsonSerializer.Deserialize<ObservableCollection<Contact>>(FileUsers);

            return ContactList;
        }
    }
}
