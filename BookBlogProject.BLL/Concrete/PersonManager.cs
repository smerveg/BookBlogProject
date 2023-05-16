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
    public class PersonManager : IPersonService
    {
        IPersonDAL _personDal;

        public PersonManager(IPersonDAL personDal)
        {
            _personDal = personDal;
        }
        public void Add(Person entity)
        {
            _personDal.Add(entity);
        }

        public void Delete(Person entity)
        {
            entity.PersonStatus = false;
            _personDal.Delete(entity);
        }

        public List<Person> PeopleWithRoles()
        {
            return _personDal.PeopleWithRoles();
        }

        public List<Person> GetAll()
        {
            return _personDal.GetAll();
        }

        public List<Person> GetAllByFilter(Expression<Func<Person, bool>> filter)
        {
            return _personDal.GetAllByFilter(filter);
        }

        public Person GetById(int id)
        {
            return _personDal.GetById(id);
        }

        public void Update(Person entity)
        {
            _personDal.Update(entity);
        }
        public List<Role> GetAllRolesByFilter(Expression<Func<Role, bool>> filter)
        {
            return _personDal.GetAllRolesByFilter(filter);
        }

        public bool DuplicateRecordControl(Expression<Func<Person, bool>> record)
        {
            return _personDal.DuplicateRecordControl(record);
        }

        public string PasswordEncryption(string password)
        {
            return _personDal.PasswordEncryption(password);
        }

        public bool PasswordVerification(string password, string storedHash)
        {
            return _personDal.PasswordVerification(password, storedHash);
        }

        public string GetRoleCode(string userName)
        {
            return _personDal.GetRoleCode(userName);
        }
    }
}
