
using Maui.MyContacts.Models;

namespace Maui.MyContacts.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {
		var newContact = new Models.Contact()
		{
			Name = ContactCtrl.Name,
			Email = ContactCtrl.Email,
			PhoneNumber = ContactCtrl.PhoneNumber
		};

		ContactRepository.AddContact(newContact);
    }
}