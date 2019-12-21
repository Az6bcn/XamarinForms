using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteKepper.Models;

namespace NoteKepper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public IList<string> CourseList { get; set; }
        public bool IsNewNote { get; set; }


        /* we need propeties that corresponds to each models properties in this viewModel
        that data bind to, so that we can provide change notifications
        e.g
            Need property (NoteHeading) that will corressponds to Note.Heading property
            Need property (NoteTitle) that will correspond to Note.Title property

            These properties are just gonna be responsible for getting the data from our data model (not storing data);
        */

        public string NoteHeading
        {
            get { return Note.Heading; }
            set
            {
                // assign the value we recieve to Note.Heading in our model when modified and then fire a PropertyChanged Notification (event)
                Note.Heading = value;
                OnPropertyChanged();
            }

        }

        public string NoteText
        {
            get { return Note.Text; }
            set
            {
                Note.Text = value;
                OnPropertyChanged();
            }

        }

        public string NoteCourse
        {
            get { return Note.Course; }
            set
            {
                Note.Course = value;
                OnPropertyChanged();
            }

        }


        public ItemDetailViewModel(Note note = null)
        {
            CoursesListInit();
            Title = "Edit Note";
            Note = note ?? new Note();
        }


        public async void CoursesListInit()
        {
            CourseList = await PluralsightDataStore.GetCoursesAsync();
        }
    }
}
