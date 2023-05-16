using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Abstract
{
    public interface IRoleService:IGenericService<Role>
    {
        List<Person> GetAllUsersByFilter(Expression<Func<Person, bool>> filter);
        void DeleteUser(Person p);
    }
}
