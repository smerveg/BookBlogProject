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
    public class AuthorValidator:AbstractValidator<Author>
    {
        private bool DuplicateAuthor(string name,string lastName,int id)
        {
            using (var c=new Context())
            {
                var result = c.Authors.Where(x => x.AuthorName.Equals(name,StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (result != null && result.AuthorLastName.Equals(lastName,StringComparison.CurrentCultureIgnoreCase) && result.AuthorID!=id)
                {
                    return true;
                }
                else
                { return false; }
            }
        }
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Author name is required");
            RuleFor(x => x.AuthorName).MinimumLength(3).WithMessage("Author name must be at least 3 characters");

            RuleFor(x => x.AuthorLastName).NotEmpty().WithMessage("Author lastname is required");
            RuleFor(x => x.AuthorLastName).MinimumLength(3).WithMessage("Author lastname must be at least 3 characters");

            RuleFor(x => new { x.AuthorName, x.AuthorLastName,x.AuthorID }).Must(x => !DuplicateAuthor(x.AuthorName, x.AuthorLastName,x.AuthorID)).OverridePropertyName(x=>x.AuthorName)
                .WithMessage("Author already exists.");
            
            
        }
    }
}
