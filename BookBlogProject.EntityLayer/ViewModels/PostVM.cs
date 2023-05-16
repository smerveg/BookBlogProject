using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.EntityLayer.ViewModels
{
    public class PostVM
   {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDate { get; set; }
        public bool PostStatus { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [Required(ErrorMessage ="Book is required")]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public int PersonID { get; set; }
        public string PersonFullName { get; set; }
    }
}
