using BookBlogProject.WebAPI.Models;
using BookBlogProject.WebAPI.Models.Abstract;
using BookBlogProject.WebAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBlogProject.WebAPI.Controllers
{
    public class BooksController : ApiController
    {
        private IBookRepository _repository;
        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<BookDTO> Get()
        {
            return _repository.GetAllBook();
        }
        [Route("api/Books/{bookId}")]
        [HttpGet]
        public HttpResponseMessage Get(int bookId)
        {
            var result = _repository.GetBookById(bookId);
            //return result; ;

            if (result == null)
            {
                var response = this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");                
                return response;
            }
            else
            {
                var response = this.Request.CreateResponse<BookDetailDTO>(result);
                return response;
            }

        }


    }
}