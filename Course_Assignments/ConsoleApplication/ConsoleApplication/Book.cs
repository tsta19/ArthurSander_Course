﻿using System;

namespace ConsoleApplication
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfPages { get; set; }
        public string Author { get; set; }
        public Boolean InformaionIsCorrect { get; set; }
    }
}