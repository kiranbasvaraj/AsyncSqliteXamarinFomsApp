﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class HomePage : ContentPage
    {
        public List<ToDoItemModel> list;
        public HomePage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<object>(this, "added", (s) =>
            {
                this.OnAppearing();
            });
        }

        private async void AddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsPage());
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //   await DbService.Instance.CreateAppTables();
            await DbService.Instance.CreateTable<ToDoItemModel>();
            await DbService.Instance.CreateTable<Demo>();

        }

        protected async override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
            
                var x = await DbService.Instance.GetAllWithChildren<ToDoItemModel>();
                listview.ItemsSource = x;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}