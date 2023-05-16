using BookBlogProject.DAL.Concrete;
using BookBlogProject.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.ValidationRules
{
    public class PersonValidator:AbstractValidator<Person>
    {
        private bool DuplicateMail(string mail,int id)
        {
            using (var c=new Context())
            {
                var result=c.People.Where(x => x.Mail == mail).FirstOrDefault();
                if (result != null && result.PersonID != id)
                {
                    return true;
                }
                else
                    return false;
                
            }
        }

        private bool DuplicateUserName(string userName, int id)
        {
            using (var c = new Context())
            {
                var result = c.People.Where(x => x.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (result != null && result.PersonID != id)
                {
                    return true;
                }
                else
                    return false;

            }
        }
        private bool EmptyRole(int roleId)
        {
            return roleId == 0 ? true : false;
        }
        public PersonValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("User name must be at least 3 characters");
            RuleFor(x => new { x.UserName, x.PersonID }).Must(x => !DuplicateUserName(x.UserName, x.PersonID)).OverridePropertyName(x => x.UserName).WithMessage("User name already exists.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Person name must be at least 3 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Person lastname must be at least 3 characters");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Password must be at least 3 characters");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail is required");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => new { x.Mail,x.PersonID }).Must(x=>!DuplicateMail(x.Mail,x.PersonID)).OverridePropertyName(x => x.Mail).WithMessage("Mail address already exists.");

            RuleFor(x => x.RoleID).Must(x => !EmptyRole(x)).WithMessage("Role is required");


            //RuleFor(x => x.RoleID).Equal(0).WithMessage("Role is required");
            //RuleFor(x => x.PersonStatus).NotNull().WithMessage("Status can not be empty");


        }
    }
}
