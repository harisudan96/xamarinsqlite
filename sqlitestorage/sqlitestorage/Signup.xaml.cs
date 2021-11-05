using Newtonsoft.Json;
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
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
         
        }

        private async void signUp_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userNameEntry.Text))
            {

                Person person = new Person()
                {
                    Email = emailEntry.Text,
                    
                    Username = userNameEntry.Text,
                    Password = passwordEntry.Text,
                    Confirmpassword = confirmpasswordEntry.Text,
                    Phonenumber = phoneEntry.Text,
                 Date= MainLabel.Text
                };

                //Add New Person
                await App.SQLiteDb.SaveItemAsync(person);

                await DisplayAlert("Success", "Data saved successfully!", "OK");
                emailEntry.Text = string.Empty;
                userNameEntry.Text = string.Empty;
                passwordEntry.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                phoneEntry.Text = string.Empty;
                MainLabel.Text = string.Empty;
                await Navigation.PushAsync(new MainPage());

            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }
        }

        private void MainDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
           
                MainLabel.Text = e.NewDate.ToLongDateString();
      

        }
    }
}