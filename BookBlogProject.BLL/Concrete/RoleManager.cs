using BookBlogProject.BLL.Abstract;
using BookBlogProject.DAL.Abstract;
using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDAL _roleDal;
        public RoleManager(IRoleDAL roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> GetAll()
        {
            return _roleDal.GetAll();

        }

        public List<Role> GetAllByFilter(Expression<Func<Role, bool>> filter)
        {
            return _roleDal.GetAllByFilter(filter);
        }

        public Role GetById(int id)
        {
            return _roleDal.GetById(id);
        }
        public void Add(Role entity)
        {
            _roleDal.Add(entity);
        }

        public void Delete(Role entity)
        {
            entity.RoleStatus = false;
            _roleDal.Delete(entity);
        }

        public void Update(Role entity)
        {
            _roleDal.Update(entity);
        }

        public List<Person> GetAllUsersByFilter(Expression<Func<Person, bool>> filter)
        {
            return _roleDal.GetAllUsersByFilter(filter);
        }

        public void DeleteUser(Person p)
        {
            _roleDal.DeleteUser(p);
        }

        public bool DuplicateRecordControl(Expression<Func<Role, bool>> record)
        {
            throw new NotImplementedException();
        }
    }
}
