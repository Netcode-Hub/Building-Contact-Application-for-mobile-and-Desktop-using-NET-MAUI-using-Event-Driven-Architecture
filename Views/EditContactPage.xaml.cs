using Maui.MyContacts.Models;

namespace Maui.MyContacts.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Models.Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

	public string ContactId
	{
		set
		{
			contact = ContactRepository.GetContactById(int.Parse(value));
			if(contact != null)
			{
				ContactCtrl.Name = contact.Name;
				ContactCtrl.Email = contact.Email;
				ContactCtrl.PhoneNumber = contact.PhoneNumber;
			}
		}
	}

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {
        contact.Name = ContactCtrl.Name;
        contact.Email = ContactCtrl.Email;
        contact.PhoneNumber = ContactCtrl.PhoneNumber;
		ContactRepository.UpdateContact(contact);
    }
}