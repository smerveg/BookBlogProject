using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Abstract
{
    public interface IPersonService:IGenericService<Person>
    {
        List<Person> PeopleWithRoles();
        string GetRoleCode(string mail);
        List<Role> GetAllRolesByFilter(Expression<Func<Role, bool>> filter);
        string PasswordEncryption(string password);
        bool PasswordVerification(string password, string storedHash);
        
    }
}
