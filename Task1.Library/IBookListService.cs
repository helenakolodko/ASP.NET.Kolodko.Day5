using System;
using System.Collections.Generic;

namespace Task1.Library
{
    public interface IBookListService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        List<Book> FindByTitle(string title);
        void SortBookByTitle();
        List<Book> FindByAuthor(string author);
        void SortBookByAuthor();
        List<Book> FindByYear(int year);
        void SortBookByYear();
        List<Book> FindByPages(int pages);
        void SortBookByPages();
    }
}
