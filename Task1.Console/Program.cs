using System;
using System.Collections.Generic;
using Task1.Library;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookListService s = new FileBookListService("list.bin");
            s.AddBook(new Book() { Title = "Crime and Punishment", Author = "Fedor Dostoevsky", Year = 1995, Pages = 777 });
            s.AddBook(new Book() { Title = "To Kill a Mockingbird", Author = "Harper Li", Year = 1995, Pages = 377 });
            s.AddBook(new Book() { Title = "Solaris", Author = "Stanislav Lem", Year = 1995, Pages = 277 });

            s.RemoveBook(new Book() { Title = "To Kill a Mockingbird", Author = "Harper Li", Year = 1995, Pages = 377 });
        }
    }
}
