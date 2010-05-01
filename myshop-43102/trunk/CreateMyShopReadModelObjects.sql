USE [MyShopReadModel]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/19/2009 23:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [text] NOT NULL,
	[UnitPrice] [decimal](18, 0) NOT NULL,
	[UnitsInStock] [int] NOT NULL,
	[ImageFilename] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 12/19/2009 23:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Visits](
	[Id] [uniqueidentifier] NOT NULL,
	[VisitorId] [uniqueidentifier] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Url] [varchar](max) NOT NULL,
	[IpAddress] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Visitors]    Script Date: 12/19/2009 23:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitors](
	[Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Visitors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/19/2009 23:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 12/19/2009 23:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCarts]    Script Date: 12/19/2009 23:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCarts](
	[Id] [uniqueidentifier] NOT NULL,
	[VisitorId] [uniqueidentifier] NOT NULL,
	[CreationTimeStamp] [datetime] NULL,
 CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCartItems]    Script Date: 12/19/2009 23:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCartItems](
	[ShoppingCartId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_ShoppingCartItems] PRIMARY KEY CLUSTERED 
(
	[ShoppingCartId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_ShoppingCarts_CreationTimeStamp]    Script Date: 12/19/2009 23:25:12 ******/
ALTER TABLE [dbo].[ShoppingCarts] ADD  CONSTRAINT [DF_ShoppingCarts_CreationTimeStamp]  DEFAULT (getdate()) FOR [CreationTimeStamp]
GO
/****** Object:  ForeignKey [FK_ShoppingCartItems_Products]    Script Date: 12/19/2009 23:25:12 ******/
ALTER TABLE [dbo].[ShoppingCartItems]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItems_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCartItems] CHECK CONSTRAINT [FK_ShoppingCartItems_Products]
GO
/****** Object:  ForeignKey [FK_ShoppingCartItems_ShoppingCarts]    Script Date: 12/19/2009 23:25:12 ******/
ALTER TABLE [dbo].[ShoppingCartItems]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItems_ShoppingCarts] FOREIGN KEY([ShoppingCartId])
REFERENCES [dbo].[ShoppingCarts] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCartItems] CHECK CONSTRAINT [FK_ShoppingCartItems_ShoppingCarts]
GO