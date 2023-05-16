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
    public class PostValidator:AbstractValidator<Post>
    {
        private bool DuplicatePost(string post,int id)
        {
            using (var c=new Context())
            {
                var result = c.Posts.Where(x => x.PostTitle.Equals(post, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (result != null && result.PostID != id)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        private bool EmptyBook(int bookId)
        {
            return bookId == 0 ? true : false;
        }
        public PostValidator()
        {
            RuleFor(x => x.PostTitle).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.PostTitle).MinimumLength(3).WithMessage("Title must be at least 3 characters");
            //RuleFor(x => x.PostTitle).Must(x => !DuplicatePost(x)).WithMessage("Post title already exists.");
            RuleFor(x => new { x.PostTitle, x.PostID }).Must(x => !DuplicatePost(x.PostTitle, x.PostID)).OverridePropertyName(x => x.PostTitle).WithMessage("Post title already exists.");

            RuleFor(x => x.PostContent).NotEmpty().WithMessage("Content is required");
            RuleFor(x => x.PostContent).MinimumLength(3).WithMessage("Content must be at least 3 characters");

            RuleFor(x => x.BookID).Must(x=>!EmptyBook(x)).WithMessage("Book is required");

        }
    }
}
