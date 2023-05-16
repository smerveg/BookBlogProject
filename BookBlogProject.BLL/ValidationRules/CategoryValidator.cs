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
    public class CategoryValidator:AbstractValidator<Category>
    {
        private bool DuplicateCategory(string category,int id)
        {
            using (var c = new Context())
            {
                var result = c.Categories.Where(x => x.CategoryName.Equals(category, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (result != null && result.CategoryID != id)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name is required");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Category name must be at least 3 characters");
            RuleFor(x => new { x.CategoryName, x.CategoryID }).Must(x => !DuplicateCategory(x.CategoryName, x.CategoryID)).OverridePropertyName(x => x.CategoryName).WithMessage("Category already exists.");
        }

    }
}
