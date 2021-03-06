USE [dynamicloopgooglemaps]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 09/06/2013 17:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 09/06/2013 17:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[ISBN] [nvarchar](255) NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookStores]    Script Date: 09/06/2013 17:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookStores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[City] [nvarchar](255) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
 CONSTRAINT [PK_BookStores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookStoresBooks]    Script Date: 09/06/2013 17:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookStoresBooks](
	[BookId] [int] NOT NULL,
	[BookStoreId] [int] NOT NULL,
 CONSTRAINT [PK_BookStoresBooks_1] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[BookStoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [FirstName], [LastName]) VALUES (4, N'Cormac', N'McCarthy')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName]) VALUES (5, N'Harlan', N'Coben')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName]) VALUES (6, N'John', N'Grisham')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName]) VALUES (7, N'George R. R.', N'Martin')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName]) VALUES (8, N'J. R. R.', N'Tolkien')
SET IDENTITY_INSERT [dbo].[Authors] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (3, N'The Road', N'9780330468464', 4)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (5, N'Blood Meridian', N'9780330510940', 4)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (6, N'No Country For Old Men', N'9780330454537', 4)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (7, N'Outer Dark', N'9780330511223', 4)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (8, N'Tell No One', N'9781409117025', 5)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (9, N'Stay Close', N'9781409117223', 5)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (10, N'Caught', N'9781409117209', 5)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (11, N'Gone For Good', N'9781409117087', 5)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (12, N'The confession', N'9780099545798', 6)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (13, N'The Litigators', N'9781444729726', 6)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (14, N'The Partners', N'9780099537151', 6)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (15, N'The Rainmakers', N'9780099537175', 6)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (16, N'A Song Of Ice And Fire', N'9780007428540', 7)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (17, N'A Clash Of Kings', N'9780007447831', 7)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (18, N'A Storm Of Swords', N'9780007447855', 7)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (19, N'Dance With Dragons', N'9780007466061', 7)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (20, N'The Hobbit', N'9780007487288', 8)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (21, N'The Fellowship Of The Ring', N'9780007203543', 8)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (22, N'The Two Towers', N'9780007203550', 8)
INSERT [dbo].[Books] ([Id], [Title], [ISBN], [AuthorId]) VALUES (23, N'The Return Of The King', N'9780007203567', 8)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[BookStores] ON 

INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (5, N'Daunt Books', N'London', 51.52048, -0.151985)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (6, N'Persephone Books', N'London', 51.522109, -0.11879)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (7, N'London Review Books', N'London', 51.518164, -0.12409)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (8, N'Foyles', N'London', 51.515353, -0.129755)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (9, N'Waterstones Piccadilly', N'London', 51.509237, -0.135065)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (10, N'Tabernacle Bookshop', N'London', 51.493275, -0.097911)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (11, N'WHSmith', N'London', 51.512522, -0.088942)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (12, N'Books for Cooks', N'London', 51.515339, -0.202861)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (13, N'Bookart', N'London', 51.526375, -0.083234)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (14, N'Stanfords', N'London', 51.511634, -0.125216)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (15, N'Penguin Books', N'London', 51.510183, -0.121574)
INSERT [dbo].[BookStores] ([Id], [Name], [City], [Latitude], [Longitude]) VALUES (16, N'John Sandoe', N'London', 51.49103, -0.160766)
SET IDENTITY_INSERT [dbo].[BookStores] OFF
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (3, 8)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (3, 12)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (3, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (5, 5)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (5, 9)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (5, 13)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (5, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (5, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (6, 5)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (6, 9)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (6, 10)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (6, 11)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (6, 12)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (6, 13)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (6, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (6, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (7, 5)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (7, 6)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (7, 11)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (7, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (7, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (8, 6)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (8, 8)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (8, 11)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (8, 13)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (8, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (8, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 5)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 6)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 9)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 10)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 11)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 12)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 13)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (9, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (10, 6)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (10, 9)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (10, 11)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (10, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (10, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 5)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 6)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 8)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 10)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 11)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 13)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (11, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (12, 6)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (12, 11)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (12, 12)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (12, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (12, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (13, 6)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (13, 8)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (13, 9)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (13, 11)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (13, 13)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (13, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (13, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (14, 6)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (14, 10)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (14, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (14, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (15, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (15, 8)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (15, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (15, 15)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (15, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (16, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (16, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (17, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (17, 9)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (17, 10)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (17, 12)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (17, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (17, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (18, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (18, 8)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (18, 12)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (18, 13)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (18, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (19, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (19, 9)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (19, 10)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (19, 13)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (19, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (20, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (20, 12)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (20, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (20, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (21, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (21, 12)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (21, 16)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (22, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (22, 8)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (22, 9)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (22, 16)
GO
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (23, 7)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (23, 10)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (23, 14)
INSERT [dbo].[BookStoresBooks] ([BookId], [BookStoreId]) VALUES (23, 16)
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO
ALTER TABLE [dbo].[BookStoresBooks]  WITH CHECK ADD  CONSTRAINT [FK_BookStoresBooks_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[BookStoresBooks] CHECK CONSTRAINT [FK_BookStoresBooks_Books]
GO
ALTER TABLE [dbo].[BookStoresBooks]  WITH CHECK ADD  CONSTRAINT [FK_BookStoresBooks_BookStores] FOREIGN KEY([BookStoreId])
REFERENCES [dbo].[BookStores] ([Id])
GO
ALTER TABLE [dbo].[BookStoresBooks] CHECK CONSTRAINT [FK_BookStoresBooks_BookStores]
GO
