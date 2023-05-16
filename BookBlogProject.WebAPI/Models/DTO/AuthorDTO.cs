using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookBlogProject.WebAPI.Models.DTO
{
    public class AuthorDTO
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorBiography { get; set; }
        public bool AuthorStatus { get; set; }
    }
}