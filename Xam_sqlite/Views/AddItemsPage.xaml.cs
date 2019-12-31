using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam_sqlite.Models;
using Xam_sqlite.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_sqlite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemsPage : ContentPage
    {
        public AddItemsPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await DbService.Instance.InsertReplaceAsyncWithChildren(new ToDoItemModel()
            {
                ItemName = E1.Text,
                ItemDescription = E2.Text
            }))
            {
                await DisplayAlert(E1.Text, "Success!", "ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(E1.Text, "Failed to add!", "ok");
            }


        }
    }
}