using System;

namespace Task1.Library
{
    interface IBookListService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        Book[] FindByTitle(string title);
        void SortBookByTitle();
        Book[] FindByAuthor(string author);
        void SortBookByAuthor();
        Book[] FindByYear(int Year);
        void SortBookByYear();
        Book[] FindByLanguage(string language);
        void SortBookByLanguage();
    }
}
