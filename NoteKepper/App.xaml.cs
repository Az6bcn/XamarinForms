using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoteKepper.Services;
using NoteKepper.Views;

namespace NoteKepper
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            // MainPage set the root page i.e start up page when the App loads
             MainPage = new MainPage(); // Default main page

            // change applications MainPage (to ItemDetailPage) i.e start up page
            // MainPage = new ItemDetailPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
