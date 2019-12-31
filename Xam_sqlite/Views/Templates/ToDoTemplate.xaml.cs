using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam_sqlite.Models;
using Xam_sqlite.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_sqlite.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoTemplate : ContentView
    {
        public ToDoTemplate()
        {
            InitializeComponent();
        }

        private async void onDeleteTapped(object sender, EventArgs e)
        {
            var contx = this.BindingContext as ToDoItemModel;
            await DbService.Instance.DeleteData(contx);
            MessagingCenter.Send<object>(this, "added");

        }
    }
}