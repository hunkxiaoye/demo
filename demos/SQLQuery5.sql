USE [master]
GO
/****** Object:  Database [demo]    Script Date: 2014/10/12 23:06:06 ******/
CREATE DATABASE [demo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'demo', FILENAME = N'D:\DataBase\MSSQL11.MSSQLSERVER\MSSQL\DATA\demo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'demo_log', FILENAME = N'D:\DataBase\MSSQL11.MSSQLSERVER\MSSQL\DATA\demo_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [demo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [demo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [demo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [demo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [demo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [demo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [demo] SET ARITHABORT OFF 
GO
ALTER DATABASE [demo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [demo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [demo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [demo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [demo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [demo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [demo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [demo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [demo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [demo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [demo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [demo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [demo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [demo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [demo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [demo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [demo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [demo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [demo] SET RECOVERY FULL 
GO
ALTER DATABASE [demo] SET  MULTI_USER 
GO
ALTER DATABASE [demo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [demo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [demo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [demo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'demo', N'ON'
GO
USE [demo]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 2014/10/12 23:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[areaname] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_AREA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attr]    Script Date: 2014/10/12 23:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attr](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[attrname] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_ATTR] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Info]    Script Date: 2014/10/12 23:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aid] [int] NOT NULL,
	[sid] [int] NOT NULL,
	[mid] [int] NOT NULL,
	[rid] [int] NOT NULL,
	[tops] [int] NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[comment] [nvarchar](max) NOT NULL,
	[attrid] [int] NOT NULL,
	[title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_INFO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mark]    Script Date: 2014/10/12 23:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[markname] [nvarchar](20) NOT NULL,
	[markurl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MARK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Retriecal]    Script Date: 2014/10/12 23:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Retriecal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rename] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_RETRIECAL] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 2014/10/12 23:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[statename] [nvarchar](20) NOT NULL,
	[aid] [int] NOT NULL,
 CONSTRAINT [PK_STATE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Area] ON 

GO
INSERT [dbo].[Area] ([id], [areaname]) VALUES (1, N'亚洲')
GO
INSERT [dbo].[Area] ([id], [areaname]) VALUES (2, N'欧洲')
GO
INSERT [dbo].[Area] ([id], [areaname]) VALUES (3, N'大洋洲')
GO
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
SET IDENTITY_INSERT [dbo].[Attr] ON 

GO
INSERT [dbo].[Attr] ([id], [attrname]) VALUES (1, N'推荐')
GO
INSERT [dbo].[Attr] ([id], [attrname]) VALUES (2, N'置顶')
GO
INSERT [dbo].[Attr] ([id], [attrname]) VALUES (3, N'  赞')
GO
SET IDENTITY_INSERT [dbo].[Attr] OFF
GO
SET IDENTITY_INSERT [dbo].[Info] ON 

GO
INSERT [dbo].[Info] ([id], [aid], [sid], [mid], [rid], [tops], [description], [comment], [attrid], [title]) VALUES (1, 2, 4, 1, 1, 1, N'这是红酒开阶立极', N'进口', 1, N'三得利红酒')
GO
SET IDENTITY_INSERT [dbo].[Info] OFF
GO
SET IDENTITY_INSERT [dbo].[Mark] ON 

GO
INSERT [dbo].[Mark] ([id], [markname], [markurl]) VALUES (1, N'三得利', N'。。。。。。。')
GO
SET IDENTITY_INSERT [dbo].[Mark] OFF
GO
SET IDENTITY_INSERT [dbo].[Retriecal] ON 

GO
INSERT [dbo].[Retriecal] ([id], [rename]) VALUES (1, N'日用百货')
GO
INSERT [dbo].[Retriecal] ([id], [rename]) VALUES (2, N'红酒')
GO
INSERT [dbo].[Retriecal] ([id], [rename]) VALUES (3, N'黑啤')
GO
SET IDENTITY_INSERT [dbo].[Retriecal] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 

GO
INSERT [dbo].[State] ([id], [statename], [aid]) VALUES (2, N'英国', 2)
GO
INSERT [dbo].[State] ([id], [statename], [aid]) VALUES (3, N'法国', 2)
GO
INSERT [dbo].[State] ([id], [statename], [aid]) VALUES (4, N'西班牙', 2)
GO
INSERT [dbo].[State] ([id], [statename], [aid]) VALUES (5, N'中国', 1)
GO
INSERT [dbo].[State] ([id], [statename], [aid]) VALUES (6, N'新西兰', 3)
GO
SET IDENTITY_INSERT [dbo].[State] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Attr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品牌信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Mark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Retriecal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产地表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'State'
GO
USE [master]
GO
ALTER DATABASE [demo] SET  READ_WRITE 
GO
