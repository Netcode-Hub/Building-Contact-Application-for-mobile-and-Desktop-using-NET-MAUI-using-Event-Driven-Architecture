using Maui.MyContacts.Models;
using System.Collections.ObjectModel;

namespace Maui.MyContacts.Views;

public partial class MainContactPage : ContentPage
{
	public MainContactPage()
	{
		InitializeComponent();
		

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts();
    }

    private void LoadContacts()
	{
		var results = new ObservableCollection<Models.Contact>(ContactRepository.GetAllContacts());
		xmlContactList.ItemsSource = results;

    }

    private async void xmlContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(xmlContactList.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Models.Contact)xmlContactList.SelectedItem).Id}");
        }
    }

    private void xmlContactList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        xmlContactList.SelectedItem = null;
    }

    private void BtnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void MenuItemDelete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Models.Contact;
        ContactRepository.DeleteContact(contact.Id);
        LoadContacts();
    }

    private void MenuItemEdit_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Models.Contact;
        Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={contact.Id}");
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var results = new ObservableCollection<Models.Contact>(ContactRepository.Searchcontacts(((SearchBar)sender).Text));
        xmlContactList.ItemsSource = results;
    }
}