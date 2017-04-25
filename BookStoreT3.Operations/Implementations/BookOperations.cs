using BookStoreT3.DataAccess.Entities;
using BookStoreT3.Operations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreT3.DataModel.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BookStoreT3.Operations.Implementations
{
    public class BookOperations: IBooksOperaton
    {
        private readonly BookStoreT3ModelContainer context;

        public BookOperations(BookStoreT3ModelContainer context)
        {
            this.context = context;
        }

        public void AddBook(AddBookModel book)
        {
            var booktype = context.TypeOfBooks.Find(book.TypeOfBookId);
            if(booktype==null)
            {
                throw new IndexOutOfRangeException();
            }

            context.Books.Add(new Book { Author = book.Author, Name = book.Name, TypeOfBook = booktype, Value = book.Value });
            context.SaveChanges();

        }

        public void DeleteBook(int id)
        {
            var book = context.Books.Find(id);
            if(book==null)
            {
                throw new KeyNotFoundException();
            }

            context.Books.Remove(book);
            context.SaveChanges();

        }

        public List<BookModel> GetAllBooks()
        {
            return context.Books.Select(x => new BookModel { Author = x.Author, Id = x.Id, Name = x.Name, TypeOfBookId = x.TypeOfBookId, Value = x.Value }).ToList();
        }

        public BookModel GetBook(int id)
        {
            var book = context.Books.Find(id);
            if(book==null)
            {
                throw new KeyNotFoundException();
            }
            BookModel model = new BookModel { Author = book.Author, Id = book.Id, Name = book.Name, TypeOfBookId = book.TypeOfBookId, Value = book.Value };
            return model;

        }

        public void UpdateBook(BookModel book)
        {
            var book1 = context.Books.Find(book.Id);
            var booktype = context.TypeOfBooks.Find(book.TypeOfBookId);

            if(book1==null || booktype==null)
            {
                throw new Exception();
            }

            context.Entry(book1).State = EntityState.Modified;

            book1.Author = book.Author;
            book1.Name = book.Name;
            book1.TypeOfBookId = book.TypeOfBookId;
            book1.Value = book.Value;

            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw new DbUpdateConcurrencyException();
            }

        }
    }
}
