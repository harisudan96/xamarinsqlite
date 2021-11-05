using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sqlitestorage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void signUp_Clicked(object sender, EventArgs e)

        {
            await Navigation.PushAsync(new Signup());
          
        }

      

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var personList = await App.SQLiteDb.GetItemsAsync();
            if (personList != null)
            {


                foreach (var item in personList)
                {


                    if (userNameEntry.Text == item.Username  && passwordEntry.Text == item.Confirmpassword )


                    {
                        await DisplayAlert("Success", "Login successfully!", "OK");

                        Application.Current.Properties["ID"] = item.PersonID;
                        await Application.Current.SavePropertiesAsync();
                        userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        await Navigation.PushAsync(new Editprofile());
                    }
                   

                }


            }
        }
    }
}
