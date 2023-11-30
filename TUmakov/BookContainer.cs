using System;
using System.Collections.Generic;

namespace TUmakov
{
    internal class BookContainer
    {
        private List<Book> books;
        public BookContainer()
        {
            books = new List<Book>();
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void SortBooks(Comparison<Book> temp)
        {
            books.Sort(temp);
        }
        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
