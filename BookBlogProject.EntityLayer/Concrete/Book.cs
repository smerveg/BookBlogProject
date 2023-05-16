using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.EntityLayer.Concrete
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int? ReleaseYear { get; set; }
        public string BookDescription { get; set; }
        public string BookImage { get; set; }
        public int? PageCount { get; set; }
        public string Publisher { get; set; }
        public bool BookStatus { get; set; }

        //NP

        public ICollection<Post> Posts { get; set; }

        public ICollection<Author> Authors { get; set; }

        //[Required(ErrorMessage = "Category is required")]
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        //[Required(ErrorMessage = "Author is required")]
        //public int AuthorID { get; set; }
        //public virtual Author Author { get; set; }

    }
}
