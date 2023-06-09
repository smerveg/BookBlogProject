USE [BookBlogDB]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [AuthorLastName], [AuthorBiography], [AuthorStatus]) VALUES (1016, N'Georges', N'Perec', N'Georges Perec (1936-82) won the Prix Renaudot in 1965 for his first novel THINGS: A STORY OF THE SIXTIES, and went on to exercise his unrivalled mastery of language in almost every imaginable kind of writing, from the apparently trivial to the deeply personal. He composed acrostics, anagrams, autobiography, criticism, crosswords, descriptions of dreams, film scripts, heterograms, lipograms, memor.', 1)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [AuthorLastName], [AuthorBiography], [AuthorStatus]) VALUES (1017, N'Dino', N'Buzzati', N'Dino Buzzati was born in Italy in 1906. After receiving a law degree from the University of Milan, he worked as a reporter and later as special correspondent and editor for the Corriere della Sera. His literary career began in 1933 with the publication of Barnabas of the Mountains and The Secret of the Old Forest; however, it was not until publication of The Tartar Steppe in 1940 and The Seven Messengers in 1942 that he received proper recognition in the mainstream of contemporary European literature. His works have been translated into many languages. Buzzati died in Milan in 1972.', 1)
SET IDENTITY_INSERT [dbo].[Authors] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (21, N'Adventure', N'Adventure', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (22, N'Romance', N'Romance', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (23, N'Mystery', N'Mystery', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (24, N'History', N'History', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (25, N'Travel', N'Travel', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (26, N'Science Fiction', N'Science Fiction', 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryStatus]) VALUES (27, N'Literature', N'Literature', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookID], [BookName], [BookDescription], [PageCount], [Publisher], [BookStatus], [CategoryID], [ReleaseYear], [BookImage]) VALUES (1033, N'A void', N'Anton Vowl is missing. Ransacking his Paris flat, a group of his faithful companions trawl through his diary for any hint as to his location and, insidiously, a ghost, from Vowl’s past starts to cast its malignant shadow. This virtuoso story, chock-full of plots and subplots, shows the skill of both author and translator who impart all the action without a crucial grammatical prop: the letter ‘e’.', 304, N'RANDOM HOUSE UK', 1, 27, 2008, N'/Image/void.jpg.jpg')
INSERT [dbo].[Books] ([BookID], [BookName], [BookDescription], [PageCount], [Publisher], [BookStatus], [CategoryID], [ReleaseYear], [BookImage]) VALUES (1034, N'53 Days', N'"53 Days," is a supremely satisfying, engrossing, and truly original mystery. ', 272, N'VERBA MUNDI', 1, 23, 2015, N'/Image/53.jpg.jpg')
SET IDENTITY_INSERT [dbo].[Books] OFF
INSERT [dbo].[BookAuthors] ([Book_BookID], [Author_AuthorID]) VALUES (1033, 1016)
INSERT [dbo].[BookAuthors] ([Book_BookID], [Author_AuthorID]) VALUES (1034, 1016)
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName], [RoleDescription], [RoleStatus], [RoleCode]) VALUES (6, N'Admin', N'Admin', 1, N'A')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [RoleDescription], [RoleStatus], [RoleCode]) VALUES (7, N'Editor', N'Editor', 1, N'E')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [RoleDescription], [RoleStatus], [RoleCode]) VALUES (8, N'Post Author', N'Post author', 1, N'PA')
INSERT [dbo].[Roles] ([RoleID], [RoleName], [RoleDescription], [RoleStatus], [RoleCode]) VALUES (1006, N'Default User', N'Default User', 1, N'DU')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonID], [Name], [LastName], [Password], [Mail], [PersonStatus], [RoleID], [UserName]) VALUES (1028, N'David', N'Williams', N'zZizkDxwkemAcRqKc9OW84LBGJjeWRLLKazzneEmgxInU4yXFwBCOw==', N'dw@mail.com', 1, 6, N'dws')
INSERT [dbo].[People] ([PersonID], [Name], [LastName], [Password], [Mail], [PersonStatus], [RoleID], [UserName]) VALUES (1029, N'Monica', N'Smith', N'2J4pkU9e3una+BAGbpq92fza11haOeO5l2tHdQ2Hv/qwr3KX2sWEAg==', N'ms@mail.com', 1, 7, N'mss')
INSERT [dbo].[People] ([PersonID], [Name], [LastName], [Password], [Mail], [PersonStatus], [RoleID], [UserName]) VALUES (1030, N'Anna', N'Legend', N'XBmeOOOI/qzNuYJOZiMF9XuhKgMju7pLLs4VvdvHa7y18vFyEtwHzw==', N'al@mail.com', 1, 8, N'alegend')
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([PostID], [PostTitle], [PostContent], [PostDate], [PostStatus], [PersonID], [CategoryID], [BookID], [Person_PersonID], [Category_CategoryID], [Book_BookID]) VALUES (1, N'The standard Lorem Ipsum passage, used since the 1500s', N'"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."', CAST(N'2023-05-09T01:04:36.823' AS DateTime), 1, 23, 27, 1033, NULL, NULL, NULL)
INSERT [dbo].[Posts] ([PostID], [PostTitle], [PostContent], [PostDate], [PostStatus], [PersonID], [CategoryID], [BookID], [Person_PersonID], [Category_CategoryID], [Book_BookID]) VALUES (2, N'Section 1.10.32 of "de Finibus Bonorum et Malorum", written by Cicero in 45 BC', N'"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?"', CAST(N'2023-05-09T13:24:44.707' AS DateTime), 1, 23, 27, 1033, NULL, NULL, NULL)
INSERT [dbo].[Posts] ([PostID], [PostTitle], [PostContent], [PostDate], [PostStatus], [PersonID], [CategoryID], [BookID], [Person_PersonID], [Category_CategoryID], [Book_BookID]) VALUES (3, N'Lorem ipsum', N'lorem lorem', CAST(N'2023-05-16T14:42:36.290' AS DateTime), 1, 1023, 23, 1034, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Posts] OFF
