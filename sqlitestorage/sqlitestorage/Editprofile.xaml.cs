using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sqlitestorage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editprofile : ContentPage
    {
        public Editprofile()
        {
            InitializeComponent();
            userNameEntry.Text = "hari";
            get();
        }

       public  async void get()
        {
            var personList = await App.SQLiteDb.GetItemsAsync();
            var value = Application.Current.Properties["ID"].ToString();
            IdLabel.Text =  value;
            if (personList != null)
            {


                foreach (var item in personList)
                {

                    if (Convert.ToInt32(IdLabel.Text)== item.PersonID)


                    {
                       

                        emailEntry.Text = item.Email;
                        DateOfBirth.Text = item.Date;
                        userNameEntry.Text = item.Username;
                        passwordEntry.Text = item.Password;
                        confirmpasswordEntry.Text = item.Confirmpassword;
                        phoneEntry.Text = item.Phonenumber;
                    }

                }
                }
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {

            Person person = new Person()
            {
                PersonID = Convert.ToInt32(IdLabel.Text),
                Email = emailEntry.Text,

                Username = userNameEntry.Text,
                Password = passwordEntry.Text,
                Confirmpassword = confirmpasswordEntry.Text,
                Phonenumber = phoneEntry.Text,
                Date = DateOfBirth.Text
            };

            //Update Person
            await App.SQLiteDb.SaveItemAsync(person);
            await DisplayAlert("Success", "Updated successfully!", "OK");
           IdLabel.Text = string.Empty;
            emailEntry.Text = string.Empty;
            userNameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
            confirmpasswordEntry.Text = string.Empty;
            phoneEntry.Text = string.Empty;
            DateOfBirth.Text = string.Empty;
            await Navigation.PushAsync(new MainPage());

        }
    }
}