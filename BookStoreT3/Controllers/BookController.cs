using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BookStoreT3.DataAccess.Entities;
using System.Web.Http.Description;
using BookStoreT3.Operations.Abstraction;
using BookStoreT3.DataModel.Models;

namespace BookStoreT3.Controllers
{
    [RoutePrefix("books")]
    public class BookController : ApiController
    {
        private readonly IBooksOperaton _bookOperations;

        public BookController(IBooksOperaton bookOperations)
        {
            _bookOperations = bookOperations;
        }

        [HttpGet]
        [Route ("book")]
        //[ResponseType(typeof(List<BookModel>))]
        public IHttpActionResult GetBooks()
        {
            return Ok(_bookOperations.GetAllBooks());
        }
        

    }
}
