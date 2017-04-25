using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using BookStoreT3.DataAccess.Entities;

namespace BookStoreT3.DataAccess.DbInitializer
{
    public class BookStoreT3DbInitializer : DropCreateDatabaseAlways<BookStoreT3ModelContainer>
    {
        protected override void Seed(BookStoreT3ModelContainer context)
        {
            context.TypeOfBooks.Add(new TypeOfBook { Type = "Action" });
            context.TypeOfBooks.Add(new TypeOfBook { Type = "Science" });
            context.TypeOfBooks.Add(new TypeOfBook { Type = "Fantasy" });
            context.TypeOfBooks.Add(new TypeOfBook { Type = "Horror" });

            context.SaveChanges();

            context.Users.Add(new User { FirstName = "Andrew", LastName = "Popov" });
            context.Users.Add(new User { FirstName = "Valeriy", LastName = "Miladze" });
            context.Users.Add(new User { FirstName = "Anya", LastName = "Chebysheva" });
            context.Users.Add(new User { FirstName = "Ira", LastName = "Datch" });

            context.SaveChanges();

            context.Books.Add(new Book { Author = "Grach", Name = "Pirates Treasure", TypeOfBook = context.TypeOfBooks.Find(1), Value = 500 });
            context.Books.Add(new Book { Author = "Vodolaz", Name = "Science vs Tricks", TypeOfBook = context.TypeOfBooks.Find(2), Value = 600 });
            context.Books.Add(new Book { Author = "Gorniy", Name = "Time Travel", TypeOfBook = context.TypeOfBooks.Find(3), Value = 700 });
            context.Books.Add(new Book { Author = "Zeves", Name = "Future Vision", TypeOfBook = context.TypeOfBooks.Find(4), Value = 800 });
            context.Books.Add(new Book { Author = "Marcelus", Name = "English Chronics", TypeOfBook = context.TypeOfBooks.Find(1), Value = 900 });
            context.Books.Add(new Book { Author = "Kronekor", Name = "Colisium Competion", TypeOfBook = context.TypeOfBooks.Find(2), Value = 1000 });
            context.Books.Add(new Book { Author = "Tanya", Name = "Demon Path", TypeOfBook = context.TypeOfBooks.Find(3), Value = 1100 });
            context.Books.Add(new Book { Author = "Tirion", Name = "World War II", TypeOfBook = context.TypeOfBooks.Find(4), Value = 1200 });

            context.SaveChanges();

            context.ExtraInfoes.Add(new ExtraInfo { Isbn10 = "isbn10", Isbn13 = "isbn13", Year = 2003, Book = context.Books.Find(1) });
            context.ExtraInfoes.Add(new ExtraInfo { Isbn10 = "isbn10", Isbn13 = "isbn13", Book = context.Books.Find(2) });
            context.ExtraInfoes.Add(new ExtraInfo { Isbn10 = "isbn10", Year = 2005, Book = context.Books.Find(3) });
            context.ExtraInfoes.Add(new ExtraInfo { Isbn10 = "isbn10", Book = context.Books.Find(4) });
            context.ExtraInfoes.Add(new ExtraInfo { Isbn13 = "isbn13", Year = 2007, Book = context.Books.Find(5) });
            context.ExtraInfoes.Add(new ExtraInfo { Isbn13 = "isbn13", Book = context.Books.Find(6) });
            context.ExtraInfoes.Add(new ExtraInfo { Year = 2009, Book = context.Books.Find(7) });
            context.ExtraInfoes.Add(new ExtraInfo { Book = context.Books.Find(8) });

            context.SaveChanges();

            Order o1 = new Order();
            Order o2 = new Order();
            Order o3 = new Order();
            Order o4 = new Order();

            o1.User = context.Users.Find(1);
            o2.User = context.Users.Find(2);
            o3.User = context.Users.Find(3);
            o4.User = context.Users.Find(4);


            o1.TotalValue = (context.Books.Find(1).Value + context.Books.Find(2).Value + context.Books.Find(3).Value) * 1.1;
            o2.TotalValue = (context.Books.Find(3).Value + context.Books.Find(4).Value + context.Books.Find(5).Value) * 1.1;
            o3.TotalValue = (context.Books.Find(5).Value + context.Books.Find(6).Value + context.Books.Find(7).Value) * 1.1;
            o4.TotalValue = (context.Books.Find(7).Value + context.Books.Find(8).Value + context.Books.Find(1).Value) * 1.1;


            o1.Comment = "com1";
            o3.Comment = "com2";
            o4.Comment = "com3";

            o1.Books.Add(context.Books.Find(1));
            o1.Books.Add(context.Books.Find(2));
            o1.Books.Add(context.Books.Find(3));

            o2.Books.Add(context.Books.Find(3));
            o2.Books.Add(context.Books.Find(4));
            o2.Books.Add(context.Books.Find(5));

            o3.Books.Add(context.Books.Find(5));
            o3.Books.Add(context.Books.Find(6));
            o3.Books.Add(context.Books.Find(7));

            o4.Books.Add(context.Books.Find(7));
            o4.Books.Add(context.Books.Find(8));
            o4.Books.Add(context.Books.Find(1));



            context.Orders.Add(o1);
            context.Orders.Add(o2);
            context.Orders.Add(o3);
            context.Orders.Add(o4);


            context.SaveChanges();
            
            base.Seed(context);
        }
    }
}
