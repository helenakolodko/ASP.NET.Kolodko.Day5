using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }

        public override int GetHashCode()
        {
            int result = Author.GetHashCode() * 31 + Title.GetHashCode();
            result *= 31;
            result += Year;
            result *= 31;
            result += Pages;
            return result;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;
            if (Author != other.Author || Title != other.Title || 
                Year != other.Year || Pages != other.Pages)
                return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(obj, this))
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
            int result = String.Compare(Author, other.Author, true);
            if (result == 0)
            {
                result = String.Compare(Title, other.Title, true);
                if (result == 0)
                {
                    result = Year.CompareTo(other.Year);
                    if (result == 0)
                        result = Pages.CompareTo(other.Pages);
                }
            }
            return result;
        }
    }
}
