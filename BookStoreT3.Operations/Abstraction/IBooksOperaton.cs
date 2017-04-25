using BookStoreT3.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreT3.Operations.Abstraction
{
    public interface IBooksOperaton
    {
        List<BookModel> GetAllBooks();
        BookModel GetBook(int id);
        void AddBook(AddBookModel book);
        void UpdateBook(BookModel book);
        void DeleteBook(int id);
    }
}
