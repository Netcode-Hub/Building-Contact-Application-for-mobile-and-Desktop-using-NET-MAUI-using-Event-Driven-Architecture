
using Maui.MyContacts.Views;

namespace Maui.MyContacts.Models
{
    public class ContactRepository
    {
        public static List<Contact> contactList = new List<Contact>()
        {
            new Contact() {Id = 1, Name="John Doe", Email="Doe@doe.com", PhoneNumber = 123456789},
            new Contact(){Id =2, Name ="Frank Hook", Email = "Frank@frank.com", PhoneNumber = 012345787},
            new Contact() {Id = 3, Name = "Frederick Asante", Email="Asante@gmail.com", PhoneNumber=024587795},
            new Contact() {Id = 4, Name="James Moore ", Email="James@doe.com", PhoneNumber = 78965},
            new Contact(){Id =5, Name ="Andrews Hughes", Email = "Andrews@frank.com", PhoneNumber = 145563},
            new Contact() {Id = 6, Name = "Rick Mars", Email="Rick@gmail.com", PhoneNumber=7896665},
            new Contact() {Id = 7, Name="Mabel Rosemond", Email="Mabel@doe.com", PhoneNumber = 741258},
            new Contact(){Id =8, Name ="Gifty Kicks", Email = "Gifty@frank.com", PhoneNumber = 9632587},
            new Contact() {Id = 9, Name = "Frankline Davis", Email="Frankline@gmail.com", PhoneNumber=1230457},
            new Contact() {Id = 10, Name="Genesis Great", Email="Genesis@doe.com", PhoneNumber = 012455785},
            new Contact(){Id =11, Name ="Simon Peter", Email = "Simon@frank.com", PhoneNumber = 032657895},
            new Contact() {Id = 12, Name = "Seth Klean", Email="Seth@gmail.com", PhoneNumber=045789963}
        };

        //CRUD => Create, Read, Update, Delete

        //Create
        public static void AddContact(Contact contact)
        {
            if (contact != null)
            {
                var checkEmail = contactList.FirstOrDefault(x => x.Email.Equals(contact.Email));
                if (checkEmail != null)
                {
                    Shell.Current.DisplayAlert("Error", "Contact already Added", "Ok");
                    return;
                }
                int maxId = contactList.Max(x => x.Id);
                contact.Id = maxId + 1;
                contactList.Add(contact);
                Shell.Current.DisplayAlert("Succes", "Contact Added Done", "Ok");
                //absolute path
                Shell.Current.GoToAsync($"//{nameof(MainContactPage)}");
            }
        }

        // Read 1 (All)
        public static List<Contact> GetAllContacts() => contactList;


        // Read 2 (individual)
        public static Contact GetContactById(int id)
        {
            var result = contactList.FirstOrDefault(x => x.Id == id);
            return result;
        }

        //Update
        public static void UpdateContact(Contact contact)
        {
            var result = contactList.FirstOrDefault(x => x.Id == contact.Id);
            if (result != null)
            {
                result.Name = contact.Name;
                result.Email = contact.Email;
                result.PhoneNumber = contact.PhoneNumber;
                Shell.Current.DisplayAlert("Succes", "Contact Updated Done", "Ok");
                Shell.Current.GoToAsync("..");
            }
        }

        //Delete
        public static void DeleteContact(int id)
        {
            var result = contactList.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                contactList.Remove(result);
                Shell.Current.DisplayAlert("Succes", "Contact Deleted Done", "Ok");
            }
        }

        //Search
        public static List<Contact> Searchcontacts(string filter)
        {
            var contacts = contactList.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.ToLower().Contains(filter.ToLower())).ToList();
           
            if (contacts == null || contacts.Count <= 0)
                contacts = contactList.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.ToLower().Contains(filter.ToLower())).ToList();
            else return contacts;

            if (contacts == null || contacts.Count <= 0)
                contacts = contactList.Where(x => x.PhoneNumber == int.Parse(filter)).ToList();
            else return contacts;

            return contacts;
        }

    }
}
