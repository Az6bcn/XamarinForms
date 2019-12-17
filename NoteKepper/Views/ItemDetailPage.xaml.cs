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
        public Note Note { get; set; }
        public IList<string> CourseList { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            Init();

            // set Binding Context for this page
            BindingContext = Note;
            // set pickers binding context: this, so we can access any property in this class. else we can assign it to property that will hold the value
            NoteCourse.BindingContext = this;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            Init();

            // set Binding Context for this page
            BindingContext = Note;
            // set pickers binding context
            NoteCourse.BindingContext = this;
        }

        async void Init()
        {
            var pluralsightDataStore = new MockPluralsightDataStore();
            CourseList = await pluralsightDataStore.GetCoursesAsync();

            Note = new Note {
                Heading = "Test Note",
                Text = "Test for a test note",
                Course = CourseList[0]
            };
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