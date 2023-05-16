using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.EntityLayer.Concrete
{
    public class Person
    {
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public bool PersonStatus { get; set; }

        //NP
        [Required(ErrorMessage ="Role is required")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
