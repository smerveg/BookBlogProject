using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.EntityLayer.Concrete
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorBiography { get; set; }
        public bool AuthorStatus { get; set; }

        //NP

        public ICollection<Book> Books { get; set; }

    }

}
