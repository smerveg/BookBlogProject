using BookBlogProject.DAL.Abstract;
using BookBlogProject.DAL.Concrete;
using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.DAL.EntityFramework
{
    public class EFRoleDAL : GenericRepository<Role>, IRoleDAL
    {
        public void DeleteUser(Person p)
        {
            using (var c=new Context())
            {
                p.PersonStatus = false;
                var person = c.Entry(p);
                person.State = EntityState.Modified;
                c.SaveChanges();
            }
        }

        public List<Person> GetAllUsersByFilter(Expression<Func<Person, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.People.Include(x=>x.Role).Where(filter).ToList();
            }
        }
    }
}
