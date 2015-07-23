using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1.Library
{
    public class FileBookListService : IBookListService
    {
        private ILogger logger;
        private string path;
        private List<Book> list = new List<Book>();

        public FileBookListService(string path)
            : this(path, new NloggerAdapter())
        {
        }

        public FileBookListService(string path, ILogger logger)
        {
            if (ReferenceEquals(logger, null) || string.IsNullOrEmpty(path))
            {
                Exception e = new ArgumentNullException();
                logger.Error("Trying to create object with null argument.", e);
                throw e;
            }
            this.logger = logger;
            this.path = path;
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Exception e =  new ArgumentNullException();
                logger.Error("Adding null to storage.", e);
                throw e;
            }
            if (!Contains(book))
            {
                list.Add(book);
                AppendBookToFile(book);
                logger.Debug("Book added.");
            }
            else
                logger.Debug("Trying to add a book that is already in the storage.");
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Exception e = new ArgumentNullException();
                logger.Error("Removing null from storage.", e);
                throw e;
            }
            if (!Contains(book))
            {
                Exception e = new ArgumentException();
                logger.Error("trying to remove book from storage that is not there.", e);
                throw e;
            }
            else
            {
                list.Remove(book);
                logger.Debug("Book removed.");
                WriteListToFile();
            }
        }

        public bool Contains(Book book)
        {
            ReadListFromFile();
            return list.Contains(book);
        }

        public List<Book> FindByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                Exception e = new ArgumentNullException();
                logger.Error("Trying to find a book with null title.", e);
                throw e;
            }
            ReadListFromFile();
            return list.FindAll((Book b) => b.Title == title);
        }

        public void SortBookByTitle()
        {
            ReadListFromFile();
            list.Sort((Book b1, Book b2) => string.Compare(b1.Title, b2.Title, true));
            WriteListToFile();
        }

        public List<Book> FindByAuthor(string author)
        {
            if (string.IsNullOrEmpty(author))
            {
                Exception e = new ArgumentNullException();
                logger.Error("Trying to find a book with null author.", e);
                throw e;
            }
            ReadListFromFile();
            return list.FindAll((Book b) => b.Author == author);
        }

        public void SortBookByAuthor()
        {
            ReadListFromFile();
            list.Sort((Book b1, Book b2) => string.Compare(b1.Author, b2.Author, true));
            WriteListToFile();
        }


        public List<Book> FindByYear(int year)
        {
            if (year < 0)
            {
                Exception e = new ArgumentNullException();
                logger.Error("Trying to find a book with negative year value.", e);
                throw e;
            }
            ReadListFromFile();
            return list.FindAll((Book b) => b.Year == year);
        }

        public void SortBookByYear()
        {
            ReadListFromFile();
            list.Sort((Book b1, Book b2) => b1.Year.CompareTo(b2.Year));
            WriteListToFile();
        }

        public List<Book> FindByPages(int pages)
        {
            if (pages < 1)
            {
                Exception e = new ArgumentNullException();
                logger.Error("Trying to find a book with non-natural page number.", e);
                throw e;
            }
            ReadListFromFile();
            return list.FindAll((Book b) => b.Pages == pages);
        }

        public void SortBookByPages()
        {
            ReadListFromFile();
            list.Sort((Book b1, Book b2) => b1.Pages.CompareTo(b2.Pages));
            WriteListToFile();
        }

        private void AppendBookToFile(Book book)
        {
            Stream fileStream = File.Open(path, FileMode.Append, FileAccess.Write);
            using (BinaryWriter output = new BinaryWriter(fileStream))
            {
                output.Write(book.Author);
                output.Write(book.Title);
                output.Write(book.Year);
                output.Write(book.Pages);
            }
        }


        private void WriteListToFile()
        {
            Stream fileStream = File.Open(path, FileMode.Truncate, FileAccess.Write);
            using (BinaryWriter output = new BinaryWriter(fileStream))
            {
                foreach (var book in list)
                {
                    output.Write(book.Author);
                    output.Write(book.Title);
                    output.Write(book.Year);
                    output.Write(book.Pages);
                }
            }
        }

        private void ReadListFromFile()
        {
            Stream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            using (BinaryReader input = new BinaryReader(fileStream))
            {
                list.Clear();
                while (input.BaseStream.Position < input.BaseStream.Length)
                {
                    Book book = new Book();
                    book.Author = input.ReadString();
                    book.Title = input.ReadString();
                    book.Year = input.ReadInt32();
                    book.Pages = input.ReadInt32();
                    list.Add(book);
                }
            }
        }
    }
}
