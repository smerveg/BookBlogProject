using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.DAL.Abstract
{
    public interface IPersonDAL:IRepository<Person>
    {
        List<Person> PeopleWithRoles();
        string GetRoleCode(string userName);
        List<Role> GetAllRolesByFilter(Expression<Func<Role,bool>> filter);
        string PasswordEncryption(string password);
        bool PasswordVerification(string password, string storedHash);
        
    }
}
