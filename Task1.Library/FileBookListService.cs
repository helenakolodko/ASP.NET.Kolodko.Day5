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

        public void FindByTag(BookTag tag, string name)
        {
            throw new NotImplementedException();
        }

        public void SortBookByTag(BookTag tag)
        {
            throw new NotImplementedException();
        }
    }
}
