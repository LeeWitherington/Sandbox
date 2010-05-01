USE [MyShopEvents]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 12/10/2009 13:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Events](
	[EventProviderId] [uniqueidentifier] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Data] [varbinary](max) NOT NULL,
	[Name] [varchar](max) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventProviders]    Script Date: 12/10/2009 13:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventProviders](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
	[Version] [int] NOT NULL
) ON [PRIMARY]
GO
