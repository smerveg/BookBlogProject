using BookBlogProject.WebAPI.Models;
using BookBlogProject.WebAPI.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBlogProject.WebAPI.Controllers
{
    public class AuthorsController : ApiController
    {
        private IAuthorRepository _repository;
        public AuthorsController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public HttpResponseMessage PostAuthor([FromBody] Author a)
        {
            a = _repository.AddAuthor(a);
            var response = this.Request.CreateResponse<Author>(HttpStatusCode.Created, a);
            string uri = Url.Link("DefaultApi", new { id = a.AuthorID });

            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage PutAuthor([FromBody] Author a)
        {
            var result = _repository.GetAuthorById(a.AuthorID);

            if (result == null)
            {
                var response = this.Request.CreateResponse<Author>(HttpStatusCode.NotFound, a);
                string uri = Url.Link("DefaultApi", new { id = a.AuthorID });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                a = _repository.UpdateAuthor(a);
                var response = this.Request.CreateResponse<Author>(HttpStatusCode.OK, a);
                string uri = Url.Link("DefaultApi", new { id = a.AuthorID });
                response.Headers.Location = new Uri(uri);
                return response;

            }



        }
        public HttpResponseMessage DeleteAuthor([FromBody] Author a)
        {
            var result = _repository.GetAuthorById(a.AuthorID);

            if (result == null)
            {
                var response = this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");

                return response;

            }
            else
            {
                a = _repository.DeleteAuthor(a);
                var response = this.Request.CreateResponse<Author>(HttpStatusCode.OK, a);
                string uri = Url.Link("DefaultApi", new { id = a.AuthorID });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }
    }
}