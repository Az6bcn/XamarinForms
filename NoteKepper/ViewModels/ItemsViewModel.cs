using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NoteKepper.Models;
using NoteKepper.Views;
using NoteKepper.Services;

namespace NoteKepper.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        /* It is designed to cooperate with data binding exposes events that enable us to notify the UI
           when  change to the collection occurs, Add/Remove items.
        */
        public ObservableCollection<Note> Notes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            // Subscribe to Message Center Messages
            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "SaveNote",
                async (sender, note) => {
                    // add to note collection observable: it will notify the interface when the collection changes so it can re-read 
                    Notes.Add(note);

                    // update note in store/db
                    await PluralsightDataStore.AddNoteAsync(note);
                });

            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "UpdateNote",
               async (sender, note) => {
                   // Update note in data store
                   await PluralsightDataStore.UpdateNoteAsync(note);
                   // Modifying a member (our note) within an ObservableCollection
                   //  does not automatically refresh data binding .. so explicitly
                   //  repopulate the collection
                   await ExecuteLoadItemsCommand();
               });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Notes.Clear();
                var items = await PluralsightDataStore.GetNotesAsync();
                foreach (var item in items)
                {
                    Notes.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}