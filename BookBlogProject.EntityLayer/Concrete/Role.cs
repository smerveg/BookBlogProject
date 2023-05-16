using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.EntityLayer.Concrete
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string RoleCode { get; set; }
        public bool RoleStatus { get; set; }

        //NP

        public ICollection<Person> People { get; set; }
    }
}
