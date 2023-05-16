using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.EntityLayer.ViewModels
{
    public class BookVM
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int? ReleaseYear { get; set; }
        public string BookDescription { get; set; }
        public string BookImage { get; set; }
        public int? PageCount { get; set; }
        public string Publisher { get; set; }
        public bool BookStatus { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Post> Posts { get; set; }

        //---

        public string AuthorVal { get; set; }

        //[Required(ErrorMessage = "Author is required")]
        public IEnumerable<int> SelectedAuthors { get; set; }
        public IEnumerable<Author> AuthorList { get; set; }
        public List<AuthorVM> AuthorInfos { get; set; }

        //---
        public IEnumerable<Author> Authors { get; set; }

       
    }
}
