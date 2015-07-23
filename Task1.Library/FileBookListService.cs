using System;

namespace Task1.Library
{
    class FileBookListService : IBookListService
    {
        private ILogger logger;
        public FileBookListService()
            : this(new NloggerAdapter())
        {
        }

        public FileBookListService(ILogger logger)
        {
            if (ReferenceEquals(logger, null))
                throw new ArgumentNullException();
            this.logger = logger;
        }

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Book[] FindByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void SortBookByTitle()
        {
            throw new NotImplementedException();
        }

        public Book[] FindByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public void SortBookByAuthor()
        {
            throw new NotImplementedException();
        }

        public Book[] FindByYear(int Year)
        {
            throw new NotImplementedException();
        }

        public void SortBookByYear()
        {
            throw new NotImplementedException();
        }

        public Book[] FindByLanguage(string language)
        {
            throw new NotImplementedException();
        }

        public void SortBookByLanguage()
        {
            throw new NotImplementedException();
        }
    }
}
