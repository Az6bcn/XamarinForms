using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKepper.Models;
using NoteKepper.Views;
using NoteKepper.ViewModels;

namespace NoteKepper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Note;
            if (item == null)
                return;

            // Navigate to a new Page: ItemDetailViewModel
            /*
             * Performs hierarchical navigation, (hierarchical navigation => we can freely move from one page to another),
             * we are navigating within the existing navigation page.
             */

            // await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            /*
             * Performs a modal navigation and allows us to perform specific actions to leave that page
             * i.e do stuff then pop the navigation stack to leave the page.
             *
             * To leave the page we have to pop the Page of the navigation stack, in the Page we going to.
             *
             * new NavigationPage(): makes it show the toolbar at the top (incase we need the toolbar to show buttons e.g cancel/save)
             *
             * without the new NavigationPage() our page won't have the toolbar.
             */
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage(new ItemDetailViewModel(item))), true);

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage()));
        }

        /// <summary>
        /// Is a Callback function that's called just before the Page becomes visible, its used
        /// to execute or initiate some actions before the user sees the Page
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Notes.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}