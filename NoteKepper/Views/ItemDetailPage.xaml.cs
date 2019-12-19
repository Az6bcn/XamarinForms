using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKepper.Models;
using NoteKepper.ViewModels;
using System.Collections.Generic;
using NoteKepper.Services;

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

            // set Binding Context for this page
            BindingContext = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            viewModel = new ItemDetailViewModel();

            // set ViewModel has the Binding Context for this page
            BindingContext = viewModel;
        }

        public void Cancel_Clicked(object sender, EventArgs e)
        {
            viewModel.NoteHeading = "XXXXXXXXX";
            DisplayAlert("Cancel Option",
                $"Heading Value is {viewModel.NoteHeading}",
                "Button 2", "Button 1");
        }

        public void Save_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Save Option", "Save was Selected", "Button 2", "Button 1");
        }
    }
}