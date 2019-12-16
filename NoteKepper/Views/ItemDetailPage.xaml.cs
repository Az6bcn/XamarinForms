using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKepper.Models;
using NoteKepper.ViewModels;

namespace NoteKepper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
          
            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public void Cancel_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Cancel Option", "Cancel was Selected", "Button 2", "Button 1");
        }

        public void Save_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Save Option", "Save was Selected", "Button 2", "Button 1");
        }
    }
}