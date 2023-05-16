using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.EntityLayer.Concrete
{
    public class Post
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDate { get; set; }
        public bool PostStatus { get; set; }

        //NP

        [Required(ErrorMessage = "Category is required")]

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Book is required")]

        public int BookID { get; set; }
        public virtual Book Book { get; set; }


        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
