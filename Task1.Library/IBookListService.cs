using System;

namespace Task1.Library
{
    interface IBookListService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        void FindByTag(BookTag tag, string name);
        void SortBookByTag(BookTag tag);
    }
}
