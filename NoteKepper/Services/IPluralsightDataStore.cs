using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteKepper.Models;

namespace NoteKepper.Services
{
    public interface IPluralsightDataStore
    {
        Task<string> AddNoteAsync(Note CourseNote);
        Task<bool> UpdateNoteAsync(Note CourseNote);
        Task<Note> GetNoteAsync(string id);
        Task<IList<Note>> GetNotesAsync();
        Task<IList<string>> GetCoursesAsync();
    }
}
