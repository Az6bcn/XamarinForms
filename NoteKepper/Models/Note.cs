﻿using System;
namespace NoteKepper.Models
{
    public class Note
    {
        public string Id { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public string Course { get; set; }
        public bool IsUpdate { get; set; }
    }
}
