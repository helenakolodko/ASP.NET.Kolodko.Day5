using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;
            if (Author != other.Author || Title != other.Title || 
                Year != other.Year || Language != other.Language)
                return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;
            Book book = obj as Book;
            if (ReferenceEquals(book, null))
                return false;
            else
                return Equals(book);
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, this))
                return 0;
            if (ReferenceEquals(other, null))
                return 1;
            // TODO: 
                
        }
    }
}
