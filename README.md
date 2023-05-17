# BookBlogProject
Book Blog Project is a N-tier .NET MVC project.
Code-First approach is used.
MSSQL is used as database. 
Soft delete approach is used.
Fluent validation is used for validation.
AutoMapper is used for mapping.
Role-based authorization is used.

Project contains a book blog management system. System contains 4 different roles. Every user has only one role. Log in and register pages can be accessed via book blog.

1)Default user: When user registers, the system define user as a default user. This role has not any permission. To access the pages, a role should be assigned to default user by the admin.

2)Admin:This role has permission to access and modify every data.

3)Editor:This role has permission to modify book and author data.

4)Post Author:This role has permission to modify posts.

After Editor add authors and books to the system, Post Author can add a post.
Books,authors,posts,post authors which are added the system, can be seen in the book blog.

Also project has web api methods which perform CRUD operations.


