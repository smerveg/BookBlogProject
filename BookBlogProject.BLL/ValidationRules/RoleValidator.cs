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
    public class RoleValidator:AbstractValidator<Role>
    {
        private bool DuplicateRole(string role)
        {
            using (var c = new Context())
            {
                var result = c.Roles.Where(x => x.RoleName.Equals(role, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                return result != null ? true : false;
            }
        }
        public RoleValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Role name is required");
            RuleFor(x => x.RoleName).MinimumLength(3).WithMessage("Role name must be at least 3 characters");
            RuleFor(x => x.RoleName).Must(x => !DuplicateRole(x)).WithMessage("Role already exists.");


        }
    }
}
