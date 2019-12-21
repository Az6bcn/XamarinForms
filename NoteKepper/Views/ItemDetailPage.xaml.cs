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

        public ItemDetailPage(ItemDetailViewModel _viewModel)
        {
            InitializeComponent();

            viewModel = _viewModel;

            // set Binding Context for this page
            BindingContext = _viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            viewModel = new ItemDetailViewModel();

            /* set a new instance of the ViewModel has the Binding Context for this page
               when this ctor is used
            */
            BindingContext = viewModel;
        }

        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void Save_Clicked(object sender, EventArgs e)
        {
            if (!viewModel.IsNewNote)
            {
                MessagingCenter.Send(this, "UpdateNote", viewModel.Note);
            }
            else
            {
                MessagingCenter.Send(this, "SaveNote", viewModel.Note);
            }

            await Navigation.PopModalAsync();
        }
    }
}