using BookBlogProject.DAL.Abstract;
using BookBlogProject.DAL.Concrete;
using BookBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookBlogProject.DAL.EntityFramework
{
    public class EFPersonDAL : GenericRepository<Person>, IPersonDAL
    {
        public List<Person> PeopleWithRoles()
        {
            using (var c=new Context())
            {
                return c.People.Include("Role").ToList();


            }
        }

        public string GetRoleCode(string userName)
        {
            using (var c=new Context())
            {
                var result = c.People.Include(y=>y.Role).Where(x => x.UserName == userName).FirstOrDefault();
                return  result.Role.RoleCode;

            }
        }

        public List<Role> GetAllRolesByFilter(Expression<Func<Role, bool>> filter)
        {
            using (var c=new Context())
            {
                return  c.Roles.Where(filter).ToList();

            }
            
        }

        public string PasswordEncryption(string password)
        {

            string hashPass = string.Empty;
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[20]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[40];
            Array.Copy(salt, 0, hashBytes, 0, 20);
            Array.Copy(hash, 0, hashBytes, 20, 20);

            hashPass = Convert.ToBase64String(hashBytes);

            return hashPass;

        }
        public bool PasswordVerification(string password,string hashPass)
        {
            bool result = true;

            byte[] hashBytes = Convert.FromBase64String(hashPass);
            byte[] salt = new byte[20];
            Array.Copy(hashBytes, 0, salt, 0, 20);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 20] != hash[i])
                    {
                        result = false;
                    }
                }
            }
            catch (Exception)
            {

                result = false;
            }


            return result;

        }
    }
}
