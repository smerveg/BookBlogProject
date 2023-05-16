using BookBlogProject.DAL.Concrete;
using BookBlogProject.EntityLayer.Concrete;
using BookBlogProject.EntityLayer.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBlogProject.BLL.ValidationRules
{
    public class BookValidator:AbstractValidator<BookVM>
    {
        private bool DuplicateBook(string book,int id)
        {
            using (var c=new Context())
            {
                var result = c.Books.Where(x => x.BookName.Equals(book, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (result != null && result.BookID != id)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public BookValidator()
        {
            RuleFor(x => x.BookName).NotEmpty().WithMessage("Book name is required");
            RuleFor(x => x.BookName).MinimumLength(3).WithMessage("Book name must be at least 3 characters");
            //RuleFor(x=>x.BookName).Must(x=>!DuplicateBook(x)).WithMessage("Book already exists.");
            RuleFor(x => new { x.BookName, x.BookID }).Must(x => !DuplicateBook(x.BookName, x.BookID)).OverridePropertyName(x => x.BookName).WithMessage("Book already exists.");

            //RuleFor(x => x.CategoryID).Equal(0).WithMessage("Category is required");


            RuleFor(x=>x.SelectedAuthors).NotNull().WithMessage("Author is required");
            

        }
    }
}
