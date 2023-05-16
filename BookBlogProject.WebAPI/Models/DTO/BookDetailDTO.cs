using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookBlogProject.WebAPI.Models.DTO
{
    public class BookDetailDTO
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int? PageCount { get; set; }
        public string Publisher { get; set; }
        public bool BookStatus { get; set; }
        public int? ReleaseYear { get; set; }
        public string CategoryName { get; set; }       
        public List<Author> AuthorList { get; set; }
        public List<string> Authors { get; set; }
    }
}