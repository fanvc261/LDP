USE [LDP]
GO
/****** Object:  StoredProcedure [dbo].[Wiget_Update]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Wiget_Update]
GO
/****** Object:  StoredProcedure [dbo].[Wiget_SelectPage]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_SelectPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Wiget_SelectPage]
GO
/****** Object:  StoredProcedure [dbo].[Wiget_SelectOne]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_SelectOne]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Wiget_SelectOne]
GO
/****** Object:  StoredProcedure [dbo].[Wiget_SelectByPageContainer]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_SelectByPageContainer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Wiget_SelectByPageContainer]
GO
/****** Object:  StoredProcedure [dbo].[Wiget_SelectAll]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Wiget_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[Wiget_Insert]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Wiget_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Wiget_GetCount]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_GetCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Wiget_GetCount]
GO
/****** Object:  StoredProcedure [dbo].[Wiget_Delete]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Wiget_Delete]
GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_Update]
GO
/****** Object:  StoredProcedure [dbo].[User_SelectPage]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_SelectPage]
GO
/****** Object:  StoredProcedure [dbo].[User_SelectOneByUserName]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectOneByUserName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_SelectOneByUserName]
GO
/****** Object:  StoredProcedure [dbo].[User_SelectOne]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectOne]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_SelectOne]
GO
/****** Object:  StoredProcedure [dbo].[User_SelectAll]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_Insert]
GO
/****** Object:  StoredProcedure [dbo].[User_GetCount]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_GetCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_GetCount]
GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_Delete]
GO
/****** Object:  StoredProcedure [dbo].[Setting_Update]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Setting_Update]
GO
/****** Object:  StoredProcedure [dbo].[Setting_SelectPage]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_SelectPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Setting_SelectPage]
GO
/****** Object:  StoredProcedure [dbo].[Setting_SelectOneByName]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_SelectOneByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Setting_SelectOneByName]
GO
/****** Object:  StoredProcedure [dbo].[Setting_SelectOne]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_SelectOne]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Setting_SelectOne]
GO
/****** Object:  StoredProcedure [dbo].[Setting_SelectAll]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Setting_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[Setting_Insert]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Setting_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Setting_GetCount]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_GetCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Setting_GetCount]
GO
/****** Object:  StoredProcedure [dbo].[Setting_Delete]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Setting_Delete]
GO
/****** Object:  StoredProcedure [dbo].[Category_Update]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Category_Update]
GO
/****** Object:  StoredProcedure [dbo].[Category_SelectPage]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_SelectPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Category_SelectPage]
GO
/****** Object:  StoredProcedure [dbo].[Category_SelectOne]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_SelectOne]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Category_SelectOne]
GO
/****** Object:  StoredProcedure [dbo].[Category_SelectByStatus]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_SelectByStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Category_SelectByStatus]
GO
/****** Object:  StoredProcedure [dbo].[Category_SelectAll]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Category_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[Category_Insert]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Category_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Category_GetCount]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_GetCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Category_GetCount]
GO
/****** Object:  StoredProcedure [dbo].[Category_Delete]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Category_Delete]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__User__Option__25869641]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF__User__Option__25869641]
END

GO
/****** Object:  Table [dbo].[Wiget]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget]') AND type in (N'U'))
DROP TABLE [dbo].[Wiget]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting]') AND type in (N'U'))
DROP TABLE [dbo].[Setting]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
USE [master]
GO
/****** Object:  Database [LDP]    Script Date: 9/22/2017 6:24:22 PM ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'LDP')
DROP DATABASE [LDP]
GO
/****** Object:  Database [LDP]    Script Date: 9/22/2017 6:24:22 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'LDP')
BEGIN
CREATE DATABASE [LDP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LDP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQL2016\MSSQL\DATA\LDP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LDP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQL2016\MSSQL\DATA\LDP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LDP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LDP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LDP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LDP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LDP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LDP] SET ARITHABORT OFF 
GO
ALTER DATABASE [LDP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LDP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LDP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LDP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LDP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LDP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LDP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LDP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LDP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LDP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LDP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LDP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LDP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LDP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LDP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LDP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LDP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LDP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LDP] SET  MULTI_USER 
GO
ALTER DATABASE [LDP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LDP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LDP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LDP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LDP] SET DELAYED_DURABILITY = DISABLED 
GO
USE [LDP]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryGuid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[KeyMenu] [nvarchar](1000) NOT NULL,
	[SeName] [nvarchar](1000) NOT NULL,
	[MetaTitle] [ntext] NOT NULL,
	[MetaKeywords] [ntext] NOT NULL,
	[MetaDescription] [ntext] NOT NULL,
	[Status] [int] NOT NULL,
	[Option] [int] NOT NULL,
	[Rank] [int] NOT NULL,
	[Icon] [nvarchar](250) NULL,
	[ClassMenu] [nvarchar](250) NULL,
	[ClassBody] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Setting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SettingGuid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Content] [ntext] NOT NULL,
	[Option] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](1000) NOT NULL,
	[Email] [nvarchar](1000) NOT NULL,
	[Status] [int] NOT NULL,
	[Password] [nvarchar](400) NOT NULL,
	[FullName] [nvarchar](1000) NULL,
	[Option] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Wiget]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wiget](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WigetGuid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Content] [ntext] NOT NULL,
	[Status] [int] NOT NULL,
	[Option] [int] NOT NULL,
	[Rank] [int] NOT NULL,
	[PageId] [int] NOT NULL,
	[ContainerGuid] [uniqueidentifier] NOT NULL,
	[ClassBody] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [CategoryGuid], [Name], [KeyMenu], [SeName], [MetaTitle], [MetaKeywords], [MetaDescription], [Status], [Option], [Rank], [Icon], [ClassMenu], [ClassBody]) VALUES (1, N'3fe9cad2-6d68-46ff-a099-a05dd209707b', N'Homepage', N'HP', N'', N'yoga,home,', N'yoga,home,', N'Server you can use the function', 1, 0, 0, N'', N'', N'homepage')
INSERT [dbo].[Category] ([Id], [CategoryGuid], [Name], [KeyMenu], [SeName], [MetaTitle], [MetaKeywords], [MetaDescription], [Status], [Option], [Rank], [Icon], [ClassMenu], [ClassBody]) VALUES (2, N'81554287-da61-4bfb-9c96-7c1ca497cbec', N'Thanks', N'', N'thanks', N'yoga,home,thanks', N'yoga,home,thanks, thank you', N'Server you can use the function , thanks', 1, 0, -1, N'', N'', N'')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [SettingGuid], [Name], [Content], [Option]) VALUES (1, N'11d14c93-f9b8-4d56-9a57-0f6f82541c3d', N'Embed.Header', N'&lt;script&gt;alert(1)&lt;/script&gt;
&lt;iframe src="https://clients5.google.com/pagead/drt/dn/" aria-hidden="true" style="display: none;"&gt;&lt;/iframe &gt;', 0)
INSERT [dbo].[Setting] ([Id], [SettingGuid], [Name], [Content], [Option]) VALUES (2, N'f4ddede4-595e-4ca4-9cea-fa39cedce2c8', N'Site.Title', N'Yaga', 0)
INSERT [dbo].[Setting] ([Id], [SettingGuid], [Name], [Content], [Option]) VALUES (3, N'48b16d7a-4b48-4ca2-9212-61c29c09c4a3', N'Embed.Body', N'&lt;div class="ctr-p" id="viewport"&gt;&lt;/div&gt;', 0)
SET IDENTITY_INSERT [dbo].[Setting] OFF
SET IDENTITY_INSERT [dbo].[Wiget] ON 

INSERT [dbo].[Wiget] ([Id], [WigetGuid], [Name], [Content], [Status], [Option], [Rank], [PageId], [ContainerGuid], [ClassBody]) VALUES (1, N'3cbe8289-a490-45d6-a68f-a4bbc0141a30', N'Yoga.Price - Bảng giá theo tuần / tháng / năm', N'sdsa dsa&amp;nbsp;&amp;nbsp; &lt;strong&gt;dasdasddad&lt;/strong&gt;sadasda sa&lt;br /&gt;', 1, 0, 2, 1, N'a2336516-70b3-4891-889b-73ee828f6f91', N'classbodywi1')
INSERT [dbo].[Wiget] ([Id], [WigetGuid], [Name], [Content], [Status], [Option], [Rank], [PageId], [ContainerGuid], [ClassBody]) VALUES (2, N'4a5292ce-175d-4073-9f05-402e479defdd', N'Yoga.Content - Lợi ích của việc tập yoga mỗi ngày ', N'In this version, the Editor provides the core HTML editing engine, 
which includes basic text formatting, hyperlinks, lists, and image 
handling. The widget &lt;strong&gt;outputs identical HTML&lt;/strong&gt; across all major browsers, follows accessibility standards and provides API for content manipulation.  &lt;p&gt;Features include:&lt;/p&gt;&lt;ul&gt;&lt;li&gt;Text formatting &amp;amp; alignment&lt;/li&gt;&lt;li&gt;Bulleted and numbered lists&lt;/li&gt;&lt;li&gt;Hyperlink and image dialogs&lt;/li&gt;&lt;li&gt;Cross-browser support&lt;/li&gt;&lt;li&gt;Identical HTML output across browsers&lt;/li&gt;&lt;li&gt;Gracefully degrades to a &lt;code&gt;textarea&lt;/code&gt; when JavaScript is turned off&lt;/li&gt;&lt;/ul&gt;', 1, 0, 1, 0, N'a2336516-70b3-4891-889b-73ee828f6f91', N'aaa')
SET IDENTITY_INSERT [dbo].[Wiget] OFF
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__User__Option__25869641]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [Option]
END

GO
/****** Object:  StoredProcedure [dbo].[Category_Delete]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Category_Delete] AS' 
END
GO


ALTER PROCEDURE [dbo].[Category_Delete]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-20
Last Modified: 		2017-9-20
*/

@Id int

AS

DELETE FROM [dbo].[Category]
WHERE
	[Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[Category_GetCount]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_GetCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Category_GetCount] AS' 
END
GO



ALTER PROCEDURE [dbo].[Category_GetCount]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-20
Last Modified: 		2017-9-20
*/

AS

SELECT COUNT(*) FROM [dbo].[Category]


GO
/****** Object:  StoredProcedure [dbo].[Category_Insert]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Category_Insert] AS' 
END
GO



ALTER PROCEDURE [dbo].[Category_Insert]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-20
Last Modified: 		2017-9-20
*/

@CategoryGuid uniqueidentifier,
@Name nvarchar(1000),
@KeyMenu nvarchar(1000),
@SeName nvarchar(1000),
@MetaTitle ntext,
@MetaKeywords ntext,
@MetaDescription ntext,
@Status int,
@Option int,
@Rank int,
@Icon nvarchar(250),
@ClassMenu nvarchar(250),
@ClassBody nvarchar(250)

	
AS

INSERT INTO 	[dbo].[Category] 
(
				[CategoryGuid],
				[Name],
				[KeyMenu],
				[SeName],
				[MetaTitle],
				[MetaKeywords],
				[MetaDescription],
				[Status],
				[Option],
				[Rank],
				[Icon],
				[ClassMenu],
				[ClassBody]
) 

VALUES 
(
				@CategoryGuid,
				@Name,
				@KeyMenu,
				@SeName,
				@MetaTitle,
				@MetaKeywords,
				@MetaDescription,
				@Status,
				@Option,
				@Rank,
				@Icon,
				@ClassMenu,
				@ClassBody
				
)
SELECT @@IDENTITY 



GO
/****** Object:  StoredProcedure [dbo].[Category_SelectAll]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_SelectAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Category_SelectAll] AS' 
END
GO


ALTER PROCEDURE [dbo].[Category_SelectAll]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-20
Last Modified: 		2017-9-20
*/

AS


SELECT
		[Id],
		[CategoryGuid],
		[Name],
		[KeyMenu],
		[SeName],
		[MetaTitle],
		[MetaKeywords],
		[MetaDescription],
		[Status],
		[Option],
		[Rank],
		[Icon],
		[ClassMenu],
		[ClassBody]
		
FROM
		[dbo].[Category]


GO
/****** Object:  StoredProcedure [dbo].[Category_SelectByStatus]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_SelectByStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Category_SelectByStatus] AS' 
END
GO


ALTER PROCEDURE [dbo].[Category_SelectByStatus]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-20
Last Modified: 		2017-9-20
*/
@Status INT
AS


SELECT
		[Id],
		[CategoryGuid],
		[Name],
		[KeyMenu],
		[SeName],
		[MetaTitle],
		[MetaKeywords],
		[MetaDescription],
		[Status],
		[Option],
		[Rank],
		[Icon],
		[ClassMenu],
		[ClassBody]
		
FROM
		[dbo].[Category]
WHERE ([Status] & @Status ) >= @Status


GO
/****** Object:  StoredProcedure [dbo].[Category_SelectOne]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_SelectOne]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Category_SelectOne] AS' 
END
GO


ALTER PROCEDURE [dbo].[Category_SelectOne]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-20
Last Modified: 		2017-9-20
*/

@Id int

AS


SELECT
		[Id],
		[CategoryGuid],
		[Name],
		[KeyMenu],
		[SeName],
		[MetaTitle],
		[MetaKeywords],
		[MetaDescription],
		[Status],
		[Option],
		[Rank],
		[Icon],
		[ClassMenu],
		[ClassBody]
		
FROM
		[dbo].[Category]
		
WHERE
		[Id] = @Id


GO
/****** Object:  StoredProcedure [dbo].[Category_SelectPage]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_SelectPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Category_SelectPage] AS' 
END
GO





ALTER PROCEDURE [dbo].[Category_SelectPage]

-- Author:   			fanvc261@gmail.com
-- Created: 			2017-9-20
-- Last Modified: 		2017-9-20

@PageNumber 			int,
@PageSize 			int

AS

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int


SET @PageLowerBound = (@PageSize * @PageNumber) - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

SELECT * FROM 
    (SELECT
            ROW_NUMBER() OVER(ORDER BY 
    			[Id] ASC 
                
            ) AS IndexID,
    		[Id],
    		[CategoryGuid],
    		[Name],
    		[KeyMenu],
    		[SeName],
    		[MetaTitle],
    		[MetaKeywords],
    		[MetaDescription],
    		[Status],
    		[Option],
    		[Rank],
    		[Icon],
    		[ClassMenu],
    		[ClassBody]
            
    		
    FROM
    		[dbo].[Category]
    
    -- WHERE

    -- ORDER BY

    ) AS t
WHERE
    t.IndexID > @PageLowerBound 
		AND t.IndexID < @PageUpperBound
-- ORDER BY


GO
/****** Object:  StoredProcedure [dbo].[Category_Update]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Category_Update] AS' 
END
GO



ALTER PROCEDURE [dbo].[Category_Update]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-20
Last Modified: 		2017-9-20
*/
	
@Id int, 
@CategoryGuid uniqueidentifier, 
@Name nvarchar(1000), 
@KeyMenu nvarchar(1000), 
@SeName nvarchar(1000), 
@MetaTitle ntext, 
@MetaKeywords ntext, 
@MetaDescription ntext, 
@Status int, 
@Option int, 
@Rank int, 
@Icon nvarchar(250), 
@ClassMenu nvarchar(250), 
@ClassBody nvarchar(250) 


AS

UPDATE 		[dbo].[Category] 

SET
			[CategoryGuid] = @CategoryGuid,
			[Name] = @Name,
			[KeyMenu] = @KeyMenu,
			[SeName] = @SeName,
			[MetaTitle] = @MetaTitle,
			[MetaKeywords] = @MetaKeywords,
			[MetaDescription] = @MetaDescription,
			[Status] = @Status,
			[Option] = @Option,
			[Rank] = @Rank,
			[Icon] = @Icon,
			[ClassMenu] = @ClassMenu,
			[ClassBody] = @ClassBody
			
WHERE
			[Id] = @Id


GO
/****** Object:  StoredProcedure [dbo].[Setting_Delete]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Setting_Delete] AS' 
END
GO


ALTER PROCEDURE [dbo].[Setting_Delete]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@Id int

AS

DELETE FROM [dbo].[Setting]
WHERE
	[Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[Setting_GetCount]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_GetCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Setting_GetCount] AS' 
END
GO



ALTER PROCEDURE [dbo].[Setting_GetCount]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

AS

SELECT COUNT(*) FROM [dbo].[Setting]


GO
/****** Object:  StoredProcedure [dbo].[Setting_Insert]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Setting_Insert] AS' 
END
GO



ALTER PROCEDURE [dbo].[Setting_Insert]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@SettingGuid uniqueidentifier,
@Name nvarchar(1000),
@Content ntext,
@Option int

	
AS

INSERT INTO 	[dbo].[Setting] 
(
				[SettingGuid],
				[Name],
				[Content],
				[Option]
) 

VALUES 
(
				@SettingGuid,
				@Name,
				@Content,
				@Option
				
)
SELECT @@IDENTITY 



GO
/****** Object:  StoredProcedure [dbo].[Setting_SelectAll]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_SelectAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Setting_SelectAll] AS' 
END
GO


ALTER PROCEDURE [dbo].[Setting_SelectAll]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

AS


SELECT
		[Id],
		[SettingGuid],
		[Name],
		[Content],
		[Option]
		
FROM
		[dbo].[Setting]


GO
/****** Object:  StoredProcedure [dbo].[Setting_SelectOne]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_SelectOne]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Setting_SelectOne] AS' 
END
GO


ALTER PROCEDURE [dbo].[Setting_SelectOne]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@Id int

AS


SELECT
		[Id],
		[SettingGuid],
		[Name],
		[Content],
		[Option]
		
FROM
		[dbo].[Setting]
		
WHERE
		[Id] = @Id


GO
/****** Object:  StoredProcedure [dbo].[Setting_SelectOneByName]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_SelectOneByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Setting_SelectOneByName] AS' 
END
GO


ALTER PROCEDURE [dbo].[Setting_SelectOneByName]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@Name NVARCHAR(1000)

AS


SELECT
		[Id],
		[SettingGuid],
		[Name],
		[Content],
		[Option]
		
FROM
		[dbo].[Setting]
		
WHERE
		[Name] = @Name


GO
/****** Object:  StoredProcedure [dbo].[Setting_SelectPage]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_SelectPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Setting_SelectPage] AS' 
END
GO





ALTER PROCEDURE [dbo].[Setting_SelectPage]

-- Author:   			fanvc261@gmail.com
-- Created: 			2017-9-13
-- Last Modified: 		2017-9-13

@PageNumber 			int,
@PageSize 			int

AS

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int


SET @PageLowerBound = (@PageSize * @PageNumber) - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

SELECT * FROM 
    (SELECT
            ROW_NUMBER() OVER(ORDER BY 
    			[Id] ASC 
                
            ) AS IndexID,
    		[Id],
    		[SettingGuid],
    		[Name],
    		[Content],
    		[Option]
            
    		
    FROM
    		[dbo].[Setting]
    
    -- WHERE

    -- ORDER BY

    ) AS t
WHERE
    t.IndexID > @PageLowerBound 
		AND t.IndexID < @PageUpperBound
-- ORDER BY


GO
/****** Object:  StoredProcedure [dbo].[Setting_Update]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setting_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Setting_Update] AS' 
END
GO



ALTER PROCEDURE [dbo].[Setting_Update]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/
	
@Id int, 
@SettingGuid uniqueidentifier, 
@Name nvarchar(1000), 
@Content ntext, 
@Option int 


AS

UPDATE 		[dbo].[Setting] 

SET
			[SettingGuid] = @SettingGuid,
			[Name] = @Name,
			[Content] = @Content,
			[Option] = @Option
			
WHERE
			[Id] = @Id


GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[User_Delete] AS' 
END
GO


ALTER PROCEDURE [dbo].[User_Delete]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@Id int

AS

DELETE FROM [dbo].[User]
WHERE
	[Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[User_GetCount]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_GetCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[User_GetCount] AS' 
END
GO



ALTER PROCEDURE [dbo].[User_GetCount]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

AS

SELECT COUNT(*) FROM [dbo].[User]


GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[User_Insert] AS' 
END
GO



ALTER PROCEDURE [dbo].[User_Insert]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@UserGuid uniqueidentifier,
@UserName nvarchar(1000),
@Email nvarchar(1000),
@Status int,
@Password nvarchar(400),
@FullName nvarchar(1000),
@Option int

	
AS

INSERT INTO 	[dbo].[User] 
(
				[UserGuid],
				[UserName],
				[Email],
				[Status],
				[Password],
				[FullName],
				[Option]
) 

VALUES 
(
				@UserGuid,
				@UserName,
				@Email,
				@Status,
				@Password,
				@FullName,
				@Option
				
)
SELECT @@IDENTITY 



GO
/****** Object:  StoredProcedure [dbo].[User_SelectAll]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[User_SelectAll] AS' 
END
GO


ALTER PROCEDURE [dbo].[User_SelectAll]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

AS


SELECT
		[Id],
		[UserGuid],
		[UserName],
		[Email],
		[Status],
		[Password],
		[FullName],
		[Option]
		
FROM
		[dbo].[User]


GO
/****** Object:  StoredProcedure [dbo].[User_SelectOne]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectOne]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[User_SelectOne] AS' 
END
GO


ALTER PROCEDURE [dbo].[User_SelectOne]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@Id int

AS


SELECT
		[Id],
		[UserGuid],
		[UserName],
		[Email],
		[Status],
		[Password],
		[FullName],
		[Option]
		
FROM
		[dbo].[User]
		
WHERE
		[Id] = @Id


GO
/****** Object:  StoredProcedure [dbo].[User_SelectOneByUserName]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectOneByUserName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[User_SelectOneByUserName] AS' 
END
GO


ALTER PROCEDURE [dbo].[User_SelectOneByUserName]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@UserName nvarchar(1000)

AS


SELECT
		[Id],
		[UserGuid],
		[UserName],
		[Email],
		[Status],
		[Password],
		[FullName],
		[Option]
		
FROM
		[dbo].[User]
		
WHERE
		[UserName] = @UserName


GO
/****** Object:  StoredProcedure [dbo].[User_SelectPage]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[User_SelectPage] AS' 
END
GO





ALTER PROCEDURE [dbo].[User_SelectPage]

-- Author:   			fanvc261@gmail.com
-- Created: 			2017-9-13
-- Last Modified: 		2017-9-13

@PageNumber 			int,
@PageSize 			int

AS

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int


SET @PageLowerBound = (@PageSize * @PageNumber) - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

SELECT * FROM 
    (SELECT
            ROW_NUMBER() OVER(ORDER BY 
    			[Id] ASC 
                
            ) AS IndexID,
    		[Id],
    		[UserGuid],
    		[UserName],
    		[Email],
    		[Status],
    		[Password],
    		[FullName],
    		[Option]
            
    		
    FROM
    		[dbo].[User]
    
    -- WHERE

    -- ORDER BY

    ) AS t
WHERE
    t.IndexID > @PageLowerBound 
		AND t.IndexID < @PageUpperBound
-- ORDER BY


GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[User_Update] AS' 
END
GO



ALTER PROCEDURE [dbo].[User_Update]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/
	
@Id int, 
@UserGuid uniqueidentifier, 
@UserName nvarchar(1000), 
@Email nvarchar(1000), 
@Status int, 
@Password nvarchar(400), 
@FullName nvarchar(1000), 
@Option int 


AS

UPDATE 		[dbo].[User] 

SET
			[UserGuid] = @UserGuid,
			[UserName] = @UserName,
			[Email] = @Email,
			[Status] = @Status,
			[Password] = @Password,
			[FullName] = @FullName,
			[Option] = @Option
			
WHERE
			[Id] = @Id


GO
/****** Object:  StoredProcedure [dbo].[Wiget_Delete]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Wiget_Delete] AS' 
END
GO


ALTER PROCEDURE [dbo].[Wiget_Delete]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@Id int

AS

DELETE FROM [dbo].[Wiget]
WHERE
	[Id] = @Id

GO
/****** Object:  StoredProcedure [dbo].[Wiget_GetCount]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_GetCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Wiget_GetCount] AS' 
END
GO



ALTER PROCEDURE [dbo].[Wiget_GetCount]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

AS

SELECT COUNT(*) FROM [dbo].[Wiget]


GO
/****** Object:  StoredProcedure [dbo].[Wiget_Insert]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Wiget_Insert] AS' 
END
GO



ALTER PROCEDURE [dbo].[Wiget_Insert]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@WigetGuid uniqueidentifier,
@Name nvarchar(1000),
@Content ntext,
@Status int,
@Option int,
@Rank int,
@PageId int,
@ContainerGuid uniqueidentifier,
@ClassBody nvarchar(250)

	
AS

INSERT INTO 	[dbo].[Wiget] 
(
				[WigetGuid],
				[Name],
				[Content],
				[Status],
				[Option],
				[Rank],
				[PageId],
				[ContainerGuid],
				[ClassBody]
) 

VALUES 
(
				@WigetGuid,
				@Name,
				@Content,
				@Status,
				@Option,
				@Rank,
				@PageId,
				@ContainerGuid,
				@ClassBody
				
)
SELECT @@IDENTITY 



GO
/****** Object:  StoredProcedure [dbo].[Wiget_SelectAll]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_SelectAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Wiget_SelectAll] AS' 
END
GO


ALTER PROCEDURE [dbo].[Wiget_SelectAll]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

AS


SELECT
		[Id],
		[WigetGuid],
		[Name],
		[Content],
		[Status],
		[Option],
		[Rank],
		[PageId],
		[ContainerGuid],
		[ClassBody]
		
FROM
		[dbo].[Wiget]


GO
/****** Object:  StoredProcedure [dbo].[Wiget_SelectByPageContainer]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_SelectByPageContainer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Wiget_SelectByPageContainer] AS' 
END
GO


ALTER PROCEDURE [dbo].[Wiget_SelectByPageContainer]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/
@PageId int,
@ContainerGuid uniqueidentifier,
@Status int = -1
AS

IF (@Status >0)
BEGIN
	SELECT
			[Id],
			[WigetGuid],
			[Name],
			[Content],
			[Status],
			[Option],
			[Rank],
			[PageId],
			[ContainerGuid],
			[ClassBody]
		
	FROM
			[dbo].[Wiget]

	WHERE [PageId] = @PageId
	AND [ContainerGuid] = @ContainerGuid
	AND ([Status] & @Status) >= @Status
	ORDER BY [Rank] ASC
END
ELSE IF (@Status  = 0)
BEGIN
	SELECT
			[Id],
			[WigetGuid],
			[Name],
			[Content],
			[Status],
			[Option],
			[Rank],
			[PageId],
			[ContainerGuid],
			[ClassBody]
		
	FROM
			[dbo].[Wiget]

	WHERE [PageId] = @PageId
	AND [ContainerGuid] = @ContainerGuid
	AND [Status] = 0
	ORDER BY [Rank] ASC
END
ELSE
BEGIN
	SELECT
			[Id],
			[WigetGuid],
			[Name],
			[Content],
			[Status],
			[Option],
			[Rank],
			[PageId],
			[ContainerGuid],
			[ClassBody]
		
	FROM
			[dbo].[Wiget]

	WHERE [PageId] = @PageId
	AND [ContainerGuid] = @ContainerGuid
	ORDER BY [Rank] ASC
END

GO
/****** Object:  StoredProcedure [dbo].[Wiget_SelectOne]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_SelectOne]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Wiget_SelectOne] AS' 
END
GO


ALTER PROCEDURE [dbo].[Wiget_SelectOne]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/

@Id int

AS


SELECT
		[Id],
		[WigetGuid],
		[Name],
		[Content],
		[Status],
		[Option],
		[Rank],
		[PageId],
		[ContainerGuid],
		[ClassBody]
		
FROM
		[dbo].[Wiget]
		
WHERE
		[Id] = @Id


GO
/****** Object:  StoredProcedure [dbo].[Wiget_SelectPage]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_SelectPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Wiget_SelectPage] AS' 
END
GO





ALTER PROCEDURE [dbo].[Wiget_SelectPage]

-- Author:   			fanvc261@gmail.com
-- Created: 			2017-9-13
-- Last Modified: 		2017-9-13

@PageNumber 			int,
@PageSize 			int

AS

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int


SET @PageLowerBound = (@PageSize * @PageNumber) - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

SELECT * FROM 
    (SELECT
            ROW_NUMBER() OVER(ORDER BY 
    			[Id] ASC 
                
            ) AS IndexID,
    		[Id],
    		[WigetGuid],
    		[Name],
    		[Content],
    		[Status],
    		[Option],
    		[Rank],
    		[PageId],
    		[ContainerGuid],
    		[ClassBody]
            
    		
    FROM
    		[dbo].[Wiget]
    
    -- WHERE

    -- ORDER BY

    ) AS t
WHERE
    t.IndexID > @PageLowerBound 
		AND t.IndexID < @PageUpperBound
-- ORDER BY


GO
/****** Object:  StoredProcedure [dbo].[Wiget_Update]    Script Date: 9/22/2017 6:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wiget_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Wiget_Update] AS' 
END
GO



ALTER PROCEDURE [dbo].[Wiget_Update]

/*
Author:   			fanvc261@gmail.com
Created: 			2017-9-13
Last Modified: 		2017-9-13
*/
	
@Id int, 
@WigetGuid uniqueidentifier, 
@Name nvarchar(1000), 
@Content ntext, 
@Status int, 
@Option int, 
@Rank int, 
@PageId int, 
@ContainerGuid uniqueidentifier, 
@ClassBody nvarchar(250) 


AS

UPDATE 		[dbo].[Wiget] 

SET
			[WigetGuid] = @WigetGuid,
			[Name] = @Name,
			[Content] = @Content,
			[Status] = @Status,
			[Option] = @Option,
			[Rank] = @Rank,
			[PageId] = @PageId,
			[ContainerGuid] = @ContainerGuid,
			[ClassBody] = @ClassBody
			
WHERE
			[Id] = @Id


GO
USE [master]
GO
ALTER DATABASE [LDP] SET  READ_WRITE 
GO
