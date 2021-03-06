USE [master]
GO
/****** Object:  Database [CoffeShopSystem]    Script Date: 8/16/2017 7:59:23 AM ******/
CREATE DATABASE [CoffeShopSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoffeShopSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CoffeShopSystem.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CoffeShopSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CoffeShopSystem_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CoffeShopSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoffeShopSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoffeShopSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoffeShopSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoffeShopSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CoffeShopSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoffeShopSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [CoffeShopSystem] SET  MULTI_USER 
GO
ALTER DATABASE [CoffeShopSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoffeShopSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoffeShopSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoffeShopSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CoffeShopSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CoffeShopSystem]
GO
/****** Object:  Table [dbo].[City]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[CityID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupTable]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [ntext] NULL,
	[Surcharge] [money] NULL,
	[IsDelete] [bit] NULL,
	[ShopID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Material]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[CategoryID] [int] NULL,
	[UnitPrice] [money] NULL,
	[Inventory] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK__Material__3214EC2781447DBA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialCategory]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK__Material__3214EC279CD79602] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialLog]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialID] [int] NULL,
	[EmployeeID] [int] NULL,
	[Inventory] [int] NULL,
	[UnitPrice] [money] NULL,
	[Type] [bit] NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_MaterialLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableID] [int] NOT NULL,
	[PromotionID] [int] NULL,
	[UserID] [int] NOT NULL,
	[SetDate] [datetime] NULL,
	[TotalMoney] [money] NULL,
	[Status] [bit] NULL,
	[isDelete] [bit] NULL,
	[ShopID] [int] NOT NULL,
 CONSTRAINT [PK__Order__3214EC27A0264A38] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [money] NULL,
	[Money] [money] NULL,
	[isDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryID] [int] NOT NULL,
	[ShopID] [int] NULL,
	[Name] [nvarchar](255) NOT NULL,
	[UnitPrice] [money] NULL,
	[Desciption] [ntext] NULL,
	[StatDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Discount] [int] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [ntext] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Promotion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ShopID] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[BasePurchase] [decimal](18, 0) NULL,
	[Discount] [decimal](18, 0) NULL,
	[Description] [varchar](max) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shop]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[WardID] [int] NULL,
	[DetailAddress] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShopUser]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ShopID] [int] NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[GroupTableID] [int] NOT NULL,
	[Description] [ntext] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[WardID] [int] NULL,
	[DetailAddress] [nvarchar](255) NULL,
	[BirthDay] [datetime] NULL,
	[Sex] [nvarchar](10) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ward](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DistrictID] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[MaterialView]    Script Date: 8/16/2017 7:59:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[MaterialView] as
select m.*, mc.Name as CategoryName
from Material m, MaterialCategory mc
where m.CategoryID = mc.ID and m.IsDelete = 0 and mc.IsDelete = 0
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (1, N'TP Hồ Chí Minh', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (2, N'An Giang', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (3, N'Bà Rịa - Vũng Tàu', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (4, N'Bắc Giang', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (5, N'Bắc Kạn', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (6, N'Bạc Liêu', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (7, N'Bắc Ninh', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (8, N'Bến Tre', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (9, N'Bình Định', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (10, N'Bình Dương', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (11, N'Bình Phước', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (12, N'Bình Thuận', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (13, N'Cà Mau', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (14, N'Cao Bằng', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (15, N'Đắk Lắk', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (16, N'Đắk Nông', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (17, N'Điện Biên', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (18, N'Đồng Nai', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (19, N'Đồng Tháp', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (20, N'Gia Lai', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (21, N'Hà Giang', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (22, N'Hà Nam', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (23, N'Hà Tĩnh', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (24, N'Hải Dương', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (25, N'Hậu Giang', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (26, N'Hòa Bình', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (27, N'Hưng Yên', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (28, N'Khánh Hòa', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (29, N'Kiên Giang', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (30, N'Kon Tum', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (31, N'Lai Châu', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (32, N'Lâm Đồng', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (33, N'Lạng Sơn', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (34, N'Lào Cai', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (35, N'Long An', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (36, N'Nam Định', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (37, N'Nghệ An', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (38, N'Ninh Bình', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (39, N'Ninh Thuận', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (40, N'Phú Thọ', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (41, N'Quảng Bình	', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (42, N'Quảng Nam', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (43, N'Quảng Ngãi', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (44, N'Quảng Ninh', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (45, N'Quảng Trị', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (46, N'Sóc Trăng', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (47, N'Sơn La', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (48, N'Tây Ninh', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (49, N'Thái Bình', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (50, N'Thái Nguyên', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (51, N'Thanh Hóa', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (52, N'Thừa Thiên Huế', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (53, N'Tiền Giang', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (54, N'Trà Vinh', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (55, N'Tuyên Quang', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (56, N'Vĩnh Long', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (57, N'Vĩnh Phúc', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (58, N'Yên Bái', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (59, N'Phú Yên	', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (60, N'Cần Thơ', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (61, N'Đà Nẵng', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (62, N'Hải Phòng', NULL, 1)
INSERT [dbo].[City] ([ID], [Name], [Description], [IsDelete]) VALUES (63, N'Hà Nội', NULL, 1)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (1, N'Quận 1', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (2, N'Quận 2', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (3, N'Quận 3', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (4, N'Quận 4', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (5, N'Quận 5', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (6, N'Quận 6', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (7, N'Quận 7', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (8, N'Quận 8', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (9, N'Quận 9', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (10, N'Quận 10', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (11, N'Quận 11', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (12, N'Quận 12', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (13, N'Quận Tân Bình', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (14, N'Quận Bình Thạnh', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (15, N'Quận Gò Vấp', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (16, N'Quận Thủ Đức', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (17, N'Quận Phú Nhuận', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (18, N'Quận Tân Phú', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (19, N'Quận Bình Tân', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (20, N'Huyện Bình Chánh', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (21, N'Huyện Nhà Bé', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (22, N'Huyện Cần Giờ', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (23, N'Huyện Hóc Môn', 1, NULL, 0)
INSERT [dbo].[District] ([ID], [Name], [CityID], [Description], [IsDelete]) VALUES (24, N'Huyện Củ Chi', 1, NULL, 0)
SET IDENTITY_INSERT [dbo].[District] OFF
SET IDENTITY_INSERT [dbo].[GroupTable] ON 

INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (1, N'Bàn máy lạnh', N'Bàn trong phòng máy lạnh', 10000.0000, 0, 1)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (2, N'Bàn ngoài trời', N'Bàn ngồi ngoài trời', 0.0000, 0, 1)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (3, N'Bàn quạt', N'Bàn trong nhà quạt', 50000.0000, 0, 1)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (4, N'Bàn sân thượng', N'Bàn trên sân thượng thoáng mát', 0.0000, 0, 2)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (5, N'Bàn họp', N'Bàn lớn dành cho cuộc họp', 0.0000, 0, 2)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (6, N'Bàn víp', N'Bàn lớn, nhiều người', 50000.0000, 0, 3)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (7, N'Bàn nhóm', N'Nhiều dành cho nhiều người đi theo nhóm', 0.0000, 0, 3)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (8, N'123', N'123', 123.0000, 1, 1)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (9, N'1', N'1', 1.0000, NULL, 1)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (10, N'1', N'1', 1.0000, NULL, 1)
INSERT [dbo].[GroupTable] ([ID], [Name], [Description], [Surcharge], [IsDelete], [ShopID]) VALUES (11, N'2', N'2', 2.0000, 1, 1)
SET IDENTITY_INSERT [dbo].[GroupTable] OFF
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (1, N'Bột cà phê', 1, 12.0000, 1, N'', CAST(N'2017-08-09T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (2, N'Bột trà xanh', 1, 2222.0000, 30, N'ahihi đô ngốc', CAST(N'2017-07-18T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (3, N'Bột ngũ cốc', 1, 1.0000, 22, N'', CAST(N'2017-07-13T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (4, N'Mì gói', 4, 1.0000, 1, N'', CAST(N'2017-08-07T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (5, N'Mì ly', 4, NULL, 0, NULL, NULL, 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (6, N'Mì vắt', 4, NULL, 0, NULL, NULL, 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (7, N'Sữa đặc', 5, NULL, 0, NULL, NULL, 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (8, N'Sữa gầy', 5, NULL, 0, NULL, NULL, 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (9, N'Sữa hộp', 5, NULL, 0, NULL, NULL, 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (10, N'Bơ lạt', 6, NULL, 0, NULL, NULL, 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (11, N'Mì cay', 4, 15000.0000, 1, N'đang cập nhật...', CAST(N'2017-08-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (12, N'Bột ca cao', 1, 12.0000, 12, N'làm thức uống ca cao', CAST(N'2017-08-11T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (13, N'Ahihi', 3, NULL, NULL, N'đang cập nhật...', NULL, 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (14, N'Đồ ngốc', 2, NULL, 12, N'đang cập nhật...', NULL, 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (15, N'bột lúa mạch', 1, 12000.0000, 12, N'đang cập nhật...', CAST(N'2017-08-11T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Material] ([ID], [Name], [CategoryID], [UnitPrice], [Inventory], [Description], [CreatedDate], [IsDelete]) VALUES (17, N'bột lúa mạch', 1, 12001.0000, 11, N'đang cập nhật...', CAST(N'2017-08-11T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Material] OFF
SET IDENTITY_INSERT [dbo].[MaterialCategory] ON 

INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (1, N'Bột', NULL, NULL, 1)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (2, N'Hạt', NULL, NULL, 0)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (3, N'Trái cây', NULL, NULL, 0)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (4, N'Mì', NULL, NULL, 1)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (5, N'Sữa', NULL, NULL, 0)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (6, N'Bơ', NULL, NULL, 0)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (7, N'Kem', NULL, NULL, 0)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (8, N'Thịt', NULL, NULL, 0)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (9, N'Rau cải', NULL, NULL, 1)
INSERT [dbo].[MaterialCategory] ([ID], [Name], [Description], [CreatedDate], [IsDelete]) VALUES (17, N'testsldkfjsdlkf', N'note something...dfgdfg', NULL, 0)
SET IDENTITY_INSERT [dbo].[MaterialCategory] OFF
SET IDENTITY_INSERT [dbo].[MaterialLog] ON 

INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (3, 2, 3, 20, 20000.0000, 1, NULL, CAST(N'2017-03-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (6, 2, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (7, 10, 1, 152, 958950.0000, 0, N'test 14.10', CAST(N'2017-10-28T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (8, 4, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (9, 5, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (10, 1, NULL, 999, 10000.0000, 0, N'testing 123', CAST(N'2018-04-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (11, 2, NULL, 10, 10000.0000, 0, N'testing 123', CAST(N'2017-07-14T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (12, 3, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (13, 4, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (14, 5, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (15, 1, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (16, 8, 1, 12345, 10000.0000, 0, N'test', CAST(N'2017-07-07T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (17, 3, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (18, 4, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (19, 5, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (20, 1, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (22, 4, 2, 10, 10000.0000, 1, NULL, CAST(N'2017-08-09T11:07:15.190' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (23, 7, 3, 4, 1.0000, 1, N'đang cập nhật...', CAST(N'2017-08-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (24, 6, 2, 5, 4.0000, 1, N'đang cập nhật...', CAST(N'2017-08-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (25, 8, 1, 5, 5.0000, 1, N'đang cập nhật...', CAST(N'2017-08-02T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (26, 7, 3, 4, 6.0000, 1, N'đang cập nhật...', CAST(N'2017-08-31T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (27, 4, 4, 99, 99.0000, 1, N'đang cập nhật...', CAST(N'2017-08-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (28, 8, 2, 11, 11.0000, 1, N'đang cập nhật...', CAST(N'2017-08-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (29, 1, 2, 1, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (30, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (31, 1, 1, 0, 1.0000, 1, NULL, CAST(N'2017-07-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (32, 1, 1, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (33, 1, 1, 1, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (34, 1, 1, 0, 1.0000, 1, N'testing', CAST(N'2017-02-08T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (35, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (36, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (37, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (38, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (39, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (40, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (41, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-07-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (42, 1, 2, 0, 11.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (43, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (44, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (45, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (46, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (47, 1, 2, 0, 1.0000, 1, NULL, CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (48, 7, 1, 998877, 803345.0000, 0, N'teset', CAST(N'2017-08-23T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (49, 8, 1, 33, 1.0000, 0, N'testing today', CAST(N'2017-08-10T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (50, 6, 1, 3, 3.0000, 0, N'đang cập nhật...', CAST(N'2017-08-31T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (51, 6, 1, 111, 111.0000, 0, N'đang cập nhật...', CAST(N'2017-07-25T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (52, 3, 1, 5, 10.0000, 0, N'đang cập nhật...', CAST(N'2017-08-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (53, 9, 1, 99, 999.0000, 0, N'đang cập nhật...', CAST(N'2017-08-17T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (54, 7, 1, 88, 888.0000, 0, N'đang cập nhật...', CAST(N'2017-07-20T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (55, 10, 1, 152, 958950.0000, 0, N'test 14.9', CAST(N'2017-10-28T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (56, 13, 1, 152, 958950.0000, 0, N'test 14.9', CAST(N'2017-10-28T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (57, 3, 1, 152, 958950.0000, 0, N'test 14.9', CAST(N'2017-10-28T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (58, 3, 1, 152, 958950.0000, 0, N'test 14.9', CAST(N'2017-10-28T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (59, 9, 1, 3, 1.0000, 0, N'testing', CAST(N'2017-08-14T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (60, 14, 1, 5, 1.0000, 1, N'đang cập nhật...', CAST(N'2017-08-01T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (61, 15, 1, 1, 1.0000, 0, N'đang cập nhật...', CAST(N'2017-08-14T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (62, 13, 1, 2, 4.0000, 0, N'đang cập nhật...', CAST(N'2017-08-14T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (63, 14, 1, 3, 1.0000, 0, N'đang cập nhật...', CAST(N'2017-08-31T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (64, 1, 1, 1, 1.0000, 1, N'đang cập nhật...', CAST(N'2017-08-04T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (65, 1, NULL, 14, 14.0000, 0, N'đang cập nhật...', CAST(N'2017-08-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (66, 1, NULL, 15, 15.0000, 0, N'đang cập nhật...', CAST(N'2017-08-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (67, 1, NULL, 5, 5.0000, 0, N'đang cập nhật...', CAST(N'2017-08-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[MaterialLog] ([ID], [MaterialID], [EmployeeID], [Inventory], [UnitPrice], [Type], [Description], [CreatedDate], [IsDelete]) VALUES (68, 1, NULL, 23, 23.0000, 0, N'đang cập nhật...', CAST(N'2017-08-15T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[MaterialLog] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (1, 3, 1, 1, CAST(N'2017-05-14T00:00:00.000' AS DateTime), 470000.0000, 0, 0, 1)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (2, 3, 2, 2, CAST(N'2017-08-14T00:00:00.000' AS DateTime), 408000.0000, 0, 0, 2)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (3, 3, 1, 3, CAST(N'2017-07-14T00:00:00.000' AS DateTime), 295000.0000, 0, 0, 3)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (4, 4, 3, 4, CAST(N'2017-06-14T00:00:00.000' AS DateTime), 97000.0000, 0, 1, 1)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (5, 5, 4, 5, CAST(N'2017-05-14T00:00:00.000' AS DateTime), 42000.0000, 0, 1, 5)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (6, 6, 1, 6, CAST(N'2017-06-14T00:00:00.000' AS DateTime), 600000.0000, 0, 0, 6)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (7, 7, 2, 7, CAST(N'2017-06-14T00:00:00.000' AS DateTime), 0.0000, 0, 0, 1)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (8, 2, 1, 8, CAST(N'2017-09-14T00:00:00.000' AS DateTime), 450000.0000, 1, 1, 2)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (9, 9, 1, 9, CAST(N'2017-02-14T00:00:00.000' AS DateTime), 0.0000, 1, 0, 1)
INSERT [dbo].[Order] ([ID], [TableID], [PromotionID], [UserID], [SetDate], [TotalMoney], [Status], [isDelete], [ShopID]) VALUES (10, 10, 4, 10, CAST(N'2017-04-14T00:00:00.000' AS DateTime), 632000.0000, 1, 0, 4)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderProduct] ON 

INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (1, 1, 1, 1, 35000.0000, 35000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (2, 1, 2, 6, 45000.0000, 270000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (3, 1, 3, 3, 55000.0000, 165000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (4, 2, 4, 10, 29000.0000, 290000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (5, 2, 5, 2, 59000.0000, 118000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (6, 3, 6, 4, 59000.0000, 236000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (7, 3, 7, 1, 59000.0000, 59000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (8, 4, 8, 1, 59000.0000, 59000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (9, 4, 9, 1, 38000.0000, 38000.0000, 0)
INSERT [dbo].[OrderProduct] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Money], [isDelete]) VALUES (10, 5, 10, 1, 42000.0000, 42000.0000, 0)
SET IDENTITY_INSERT [dbo].[OrderProduct] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (1, 1, 1, N'AMERICANO', 35000.0000, N'Espresso, nước nóng', CAST(N'2017-07-14T00:00:00.000' AS DateTime), CAST(N'2017-10-07T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (2, 1, 1, N'CAPPUCCINO', 45000.0000, N'espresso, sữa tươi, bọt sữa', CAST(N'2017-07-10T00:00:00.000' AS DateTime), CAST(N'2017-07-17T18:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (3, 1, 1, N'CARAMEL MACCHIATO', 55000.0000, N'Espresso, sữa tươi, caramel', CAST(N'2017-07-14T00:00:00.000' AS DateTime), CAST(N'2017-07-15T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (4, 1, 1, N'VIETNAMESE WHITE COFFEE', 29000.0000, N'Bạc sỉu', CAST(N'2017-07-14T00:00:00.000' AS DateTime), CAST(N'2017-07-15T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (5, 2, 1, N'COOKIE ICE BLEND', 59000.0000, N'Bánh cookie, sữa tươi, kem tươi', CAST(N'2017-07-14T00:00:00.000' AS DateTime), CAST(N'2017-07-16T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (6, 2, 1, N'MOCHA ICE BLENDED', 59000.0000, N'Espresso, sữa tươi, sôcôla, kem tươi', CAST(N'2017-07-14T00:00:00.000' AS DateTime), CAST(N'2017-07-17T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (7, 3, 1, N'CHOCOLATE ICE BLENDED', 59000.0000, N'Sôcôla, sữa tươi, kem tươi', CAST(N'2017-07-14T00:00:00.000' AS DateTime), CAST(N'2017-07-17T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (8, 3, 1, N'HOT CHOCOLATE TOFFEE ALMOND', 59000.0000, N'Sôcôla, hạnh nhân, kem tươi, kẹo marshmallow', CAST(N'2017-07-15T00:00:00.000' AS DateTime), CAST(N'2017-07-20T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (9, 4, 1, N'BLACK TEA MACCHIATO', 38000.0000, N'Trà đen, váng sữa', CAST(N'2017-07-14T00:00:00.000' AS DateTime), CAST(N'2017-07-15T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductCategoryID], [ShopID], [Name], [UnitPrice], [Desciption], [StatDate], [EndDate], [Discount], [IsDelete]) VALUES (10, 4, 1, N'PEACH TEA MANIA', 42000.0000, N'Trà đào, cam, sả', CAST(N'2017-07-14T00:00:00.000' AS DateTime), CAST(N'2017-07-15T00:00:00.000' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ID], [Name], [Description], [IsDelete]) VALUES (1, N'ESPRESSO & COFFEE', N'NẾU BẠN ĐANG TÌM KIẾM MỘT THỨC UỐNG GIÚP BẠN TỈNH TÁO VÀ SẢNG KHOÁI, BẠN SẼ KHÔNG THẤT VỌNG VỚI CÁC MÓN CÀ PHÊ ĐÁ XAY. CHỈ CẦN LỰA CHỌN HƯƠNG VỊ ƯA THÍCH KÈM CÀ PHÊ CỦA BẠN TRONG THỰC ĐƠN CỦA CHÚNG TÔI.', 0)
INSERT [dbo].[ProductCategory] ([ID], [Name], [Description], [IsDelete]) VALUES (2, N'CHOCOLATE', N'KHÔNG CÓ KHOẢNG THỜI GIAN NÀO QUÝ GIÁ NHƯ KHI Ở BÊN CẠNH BẠN BÈ, TRỪ KHI BẠN CÓ MỘT LY CHOCOLATE. VÀ NIỀM HẠNH PHÚC CỦA CHÚNG TÔI LÀ PHỤC VỤ BẠN NHỮNG KHOẢNG THỜI GIAN QUÝ GIÁ NHƯ THẾ.', 0)
INSERT [dbo].[ProductCategory] ([ID], [Name], [Description], [IsDelete]) VALUES (3, N'SPECIAL TEA', N'BẤT CỨ THỜI ĐIỂM NÀO CŨNG LÀ THỜI GIAN ĐỂ UỐNG MỘT LY TRÀ. BẠN CHỌN LY TRÀ NÀO CHO HÔM NAY?', 0)
INSERT [dbo].[ProductCategory] ([ID], [Name], [Description], [IsDelete]) VALUES (4, N'SMOOTHIES', N'ĐÓ LÀ SỨC SỐNG, SỰ TƯƠI MÁT VÀ NHỮNG MÀU SẮC. ĐƯỢC TẠO RA BỞI SỰ PHA TRỘN GIỮA SỮA CHUA, TRÁI CÂY & SỮA TƯƠI, SMOOTHIES SẼ LÀ SỰ LỰA CHỌN HOÀN HẢO ĐỂ THƯ GIÃN VÀ BỔ SUNG SỨC SỐNG CHO LÀN DA. HÃY LỰA CHỌN CHO NGÀY CỦA BẠN SỰ TƯƠI MỚI VÀ ĐẦY NĂNG LƯỢNG', 0)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[Promotion] ON 

INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (1, N'Promotion name 1', NULL, CAST(N'2017-07-17' AS Date), CAST(N'2017-07-27' AS Date), CAST(10 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), NULL, 0)
INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (2, N'Promotion name 2', NULL, CAST(N'2017-07-17' AS Date), CAST(N'2017-07-27' AS Date), CAST(10 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), NULL, 0)
INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (3, N'Promotion name 3', NULL, CAST(N'2017-07-17' AS Date), CAST(N'2017-07-27' AS Date), CAST(1000 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (4, N'Promotion name 4', NULL, CAST(N'2017-07-17' AS Date), CAST(N'2017-07-27' AS Date), CAST(10 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), NULL, 0)
INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (5, N'5', NULL, CAST(N'2010-10-10' AS Date), CAST(N'2010-09-09' AS Date), CAST(1000 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), N'12', NULL)
INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (6, N'6', NULL, CAST(N'2010-10-10' AS Date), CAST(N'2010-09-09' AS Date), CAST(1000 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'1', 0)
INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (7, N'p', NULL, CAST(N'2010-10-10' AS Date), CAST(N'2010-09-09' AS Date), CAST(1000 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'1', NULL)
INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (8, N'promo', NULL, CAST(N'2010-10-10' AS Date), CAST(N'2010-09-09' AS Date), CAST(1000 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'11', NULL)
INSERT [dbo].[Promotion] ([ID], [Name], [ShopID], [StartDate], [EndDate], [BasePurchase], [Discount], [Description], [IsDelete]) VALUES (9, N'Pro', NULL, CAST(N'2010-10-10' AS Date), CAST(N'2010-09-09' AS Date), CAST(1000 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), N'1', NULL)
SET IDENTITY_INSERT [dbo].[Promotion] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [Name], [Description], [IsDelete]) VALUES (1, N'Admin', N'Quản trị hệ thống', 0)
INSERT [dbo].[Role] ([ID], [Name], [Description], [IsDelete]) VALUES (2, N'Owner', N'Chủ của hàng', 0)
INSERT [dbo].[Role] ([ID], [Name], [Description], [IsDelete]) VALUES (3, N'Employee', N'Nhân viên của hàng', 0)
INSERT [dbo].[Role] ([ID], [Name], [Description], [IsDelete]) VALUES (4, N'Customer', N'Khách hàng', 0)
INSERT [dbo].[Role] ([ID], [Name], [Description], [IsDelete]) VALUES (5, N'Chef', N'Đầu bếp', 0)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Shop] ON 

INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (1, N'Coffee House', 2, N'523 Đỗ Xuân Hợp', NULL, NULL)
INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (2, N'Coffee Bean & Tea Leaf', 3, N'123 Nguyễn Thi Minh Khai', NULL, NULL)
INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (3, N'Coffee Highlend', 4, N'243 Điện Biên Phủ', NULL, NULL)
INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (4, N'Thuc Coffee', 5, N'35 Lê Lai', NULL, NULL)
INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (5, N'Phuc Long Tea & Coffee', 6, N'231 Nguyễn Văn Cừ , Trung Tâm thương mại Nowzone', NULL, NULL)
INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (6, N'Bool Coffee', 7, N'57 Nguyễn Trãi', NULL, NULL)
INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (7, N'q', 1, N'test', N'test2', 1)
INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (8, N'q222', 1, N'q222', N'test', 1)
INSERT [dbo].[Shop] ([ID], [Name], [WardID], [DetailAddress], [Description], [IsDelete]) VALUES (9, N'222', 1, N'222', N'11', 1)
SET IDENTITY_INSERT [dbo].[Shop] OFF
SET IDENTITY_INSERT [dbo].[ShopUser] ON 

INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (1, NULL, 1, 1, N'Tài khoản quản trị viên 1', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (2, NULL, 2, 1, N'Tài khoản quản trị viên 2', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (3, 1, 3, 2, N'Chủ cửa hàng 1', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (4, 2, 4, 2, N'Chủ của hàng 2', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (5, 1, 5, 3, N'Nhân viên 1 của hàng 1', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (6, 2, 6, 3, N'Nhân viên 1 của hàng 2', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (7, 1, 7, 4, N'Khách hàng 1 của hàng 1', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (8, 1, 8, 4, N'Khách hàng 2 của hàng 1', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (9, 1, 9, 4, N'Khách hàng 3 của hàng 1', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (10, 2, 10, 4, N'Khách hàng 1 của hàng 2', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (11, 2, 11, 4, N'Khách hàng 2 của hàng 2', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (12, 2, 12, 4, N'Khách hàng 3 của hàng 2', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (13, 1, 13, 3, N'a', 1)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (14, 1, 14, 5, N'b2', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (15, 1, 15, 3, N'c', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (16, 1, 16, 3, N'd', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (17, 1, 17, 3, N'e', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (18, 1, 18, 3, N'f', 0)
INSERT [dbo].[ShopUser] ([ID], [ShopID], [UserID], [RoleID], [Description], [IsDelete]) VALUES (19, 1, 19, 3, N'g', 0)
SET IDENTITY_INSERT [dbo].[ShopUser] OFF
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (1, N'Bàn 1', 1, NULL, 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (2, N'Bàn 2', 1, NULL, 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (3, N'Bàn 3', 2, NULL, 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (4, N'Bàn 4', 2, NULL, 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (5, N'Bàn 5', 1, NULL, 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (6, N'Bàn 6', 2, NULL, 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (7, N'Bàn 7', 3, NULL, 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (8, N'Bàn 8', 5, N'Bàn lớn, nhiều người', 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (9, N'Bàn 9', 3, N'Bàn lớn, nhiều người', 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (10, N'Bàn 10', 4, N'Nhiều người', 0)
INSERT [dbo].[Table] ([ID], [Name], [GroupTableID], [Description], [IsDelete]) VALUES (11, N'asd', 2, N'sad', 1)
SET IDENTITY_INSERT [dbo].[Table] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (1, N'admin', N'Admin 1', N'123456', N'admin@gmail.com', 11, N'Số 10 đường 1', CAST(N'1995-01-01T00:00:00.000' AS DateTime), N'Nam', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (2, N'CoffeeSystem', N'Admin 2', N'123456', N'CoffeeShop@gmail.com', 2, N'Số 25 đường 10', CAST(N'1996-03-05T00:00:00.000' AS DateTime), N'Nam', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (3, N'dvdu', N'Đoàn Văn Dự', N'123456', N'ddu@gmail.com', 1, N'Số 10 đường 1', CAST(N'1995-01-01T00:00:00.000' AS DateTime), N'Nam', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (4, N'tvky', N'Trương Vô Kỵ', N'123456', N'kytruong@gmail.com', 2, N'Số 25 đường 10', CAST(N'1996-03-05T00:00:00.000' AS DateTime), N'Nam', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (5, N'kvphong', N'Kiều Văn Phong', N'123456', N'kphong@gmail.com', 9, N'Số 30 đường 5', CAST(N'1995-05-03T00:00:00.000' AS DateTime), N'Nam', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (6, N'htdung', N'Hoàng Thị Dung', N'123456', N'dungnhi@gmail.com', 4, N'Số 11 đường 4', CAST(N'1997-02-04T00:00:00.000' AS DateTime), N'Nữ', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (7, N'ttman', N'Triệu Thị Mẫn', N'123456', N'mannhi@gmail.com', 3, N'Số 3 đường 6', CAST(N'1994-11-10T00:00:00.000' AS DateTime), N'Nữ', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (8, N'qrtinh', N'Quach Rất Tĩnh', N'123456', N'tinhca@gmail.com', 1, N'Số 10 Lê Lợi', CAST(N'1995-08-12T00:00:00.000' AS DateTime), N'Nam', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (9, N'dvqua', N'Dương Văn Quá', N'123456', N'quanhi@gmail.com', 5, N'Số 30 Nguyễn Văn Cừ', CAST(N'1996-08-07T00:00:00.000' AS DateTime), N'Nam', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (10, N'ccnhuoc', N'Chu Chỉ Nhược', N'123456', N'nhuocchu@gmail.com', 6, N'Số 10 đường 2', CAST(N'1995-04-07T00:00:00.000' AS DateTime), N'Nữ', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (11, N'lhxung', N'Lệnh Hồ Xung', N'123456', N'xungca@gmail.com', 1, N'Số 23 Trần Hừng Đạo', CAST(N'1992-03-03T00:00:00.000' AS DateTime), N'Nam', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (12, N'tlnu', N'Tiểu Long Nữ', N'123456', N'longnhi@gmail.com', 1, N'Số 10 Nguyễn Trãi', CAST(N'1995-01-01T00:00:00.000' AS DateTime), N'Nữ', N'', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (13, N'aaaaa', N'a2', N'a', N'a@a', 1, N'a', CAST(N'2017-08-01T00:00:00.000' AS DateTime), N'Nam', N'a', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (14, N'bbbbb2', N'b22', N'b2', N'b@b2', 13, N'b2', CAST(N'2017-08-01T00:00:00.000' AS DateTime), N'Nữ', N'b2', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (15, N'ccccc', N'c', N'c', N'c@c.com', 1, N'c', CAST(N'2017-07-01T00:00:00.000' AS DateTime), N'Nam', N'c', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (16, N'ddddd', N'd', N'd', N'd@d.com', 12, N'd', CAST(N'2017-08-01T00:00:00.000' AS DateTime), N'Nam', N'd', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (17, N'eeeee', N'e', N'e', N'e@e.com', 31, N'e', CAST(N'2017-08-01T00:00:00.000' AS DateTime), N'Nam', N'e', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (18, N'fffff', N'f', N'f', N'f@f.com', 2, N'f', CAST(N'2017-08-01T00:00:00.000' AS DateTime), N'Nam', N'f', 0)
INSERT [dbo].[User] ([ID], [Username], [Name], [Password], [Email], [WardID], [DetailAddress], [BirthDay], [Sex], [Description], [IsDelete]) VALUES (19, N'ggggg', N'g', N'g', N'g@g.com', 11, N'g', CAST(N'2017-08-01T00:00:00.000' AS DateTime), N'Nam', N'g', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Ward] ON 

INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (1, 1, N'Phường Tân Định', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (2, 1, N'Phường Đa Kao', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (3, 1, N'Phường Bến Nghé', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (4, 1, N'Phường Bến Thành', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (5, 1, N'Phường Nguyễn Thái Bình', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (6, 1, N'Phường Phạm Ngũ Lão', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (7, 1, N'Phường Cầu Ông Lãnh', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (8, 1, N'Phường Cô Giang', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (9, 1, N'Phường Nguyễn Cư Trinh', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (10, 1, N'Phường Cầu Kho', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (11, 2, N'Phường Thảo Điền', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (12, 2, N'Phường An Phú', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (13, 2, N'Phường Bình An', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (14, 2, N'Phường Bình Trưng Đông', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (15, 2, N'Phường Bình Trưng Tây', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (16, 2, N'Phường Bình Khánh', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (17, 2, N'Phường An Khánh', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (18, 2, N'Phường Cát Lái', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (19, 2, N'Phường Thạnh Mỹ Lợi', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (20, 2, N'Phường An Lợi Đông', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (21, 2, N'Phường Thủ Thiêm', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (22, 3, N'Phường 01', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (23, 3, N'Phường 02', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (24, 3, N'Phường 03', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (25, 3, N'Phường 04', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (26, 3, N'Phường 05', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (27, 3, N'Phường 06', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (28, 3, N'Phường 07', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (29, 3, N'Phường 08', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (30, 3, N'Phường 09', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (31, 3, N'Phường 10', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (32, 3, N'Phường 11', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (33, 3, N'Phường 12', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (34, 4, N'Phường 01', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (35, 4, N'Phường 02', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (36, 4, N'Phường 03', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (37, 4, N'Phường 04', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (38, 4, N'Phường 05', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (39, 4, N'Phường 06', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (40, 4, N'Phường 08', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (41, 4, N'Phường 09', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (42, 4, N'Phường 10', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (43, 4, N'Phường 12', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (44, 4, N'Phường 13', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (45, 4, N'Phường 14', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (46, 4, N'Phường 15', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (47, 4, N'Phường 16', NULL, 0)
INSERT [dbo].[Ward] ([ID], [DistrictID], [Name], [Description], [IsDelete]) VALUES (48, 4, N'Phường 18', NULL, 0)
SET IDENTITY_INSERT [dbo].[Ward] OFF
ALTER TABLE [dbo].[City] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[District] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[GroupTable] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Material] ADD  CONSTRAINT [DF_Material_Inventory]  DEFAULT ((0)) FOR [Inventory]
GO
ALTER TABLE [dbo].[Material] ADD  CONSTRAINT [DF__Material__IsDele__02FC7413]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[MaterialCategory] ADD  CONSTRAINT [DF__MaterialC__IsDel__05D8E0BE]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[MaterialLog] ADD  CONSTRAINT [DF_MaterialLog_Quantity]  DEFAULT ((0)) FOR [Inventory]
GO
ALTER TABLE [dbo].[MaterialLog] ADD  CONSTRAINT [DF_MaterialLog_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_PromotionID]  DEFAULT ((1)) FOR [PromotionID]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF__Order__isDelete__2C3393D0]  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[OrderProduct] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT ((0)) FOR [BasePurchase]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Promotion] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Role] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Shop] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[ShopUser] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Table] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Ward] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[GroupTable]  WITH CHECK ADD  CONSTRAINT [FK_GroupTable_Shop] FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([ID])
GO
ALTER TABLE [dbo].[GroupTable] CHECK CONSTRAINT [FK_GroupTable_Shop]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_Material_MaterialCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[MaterialCategory] ([ID])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_Material_MaterialCategory]
GO
ALTER TABLE [dbo].[MaterialLog]  WITH CHECK ADD  CONSTRAINT [FK_MaterialLog_Material] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Material] ([ID])
GO
ALTER TABLE [dbo].[MaterialLog] CHECK CONSTRAINT [FK_MaterialLog_Material]
GO
ALTER TABLE [dbo].[MaterialLog]  WITH CHECK ADD  CONSTRAINT [FK_MaterialLog_User] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[MaterialLog] CHECK CONSTRAINT [FK_MaterialLog_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__Promotion__398D8EEE] FOREIGN KEY([PromotionID])
REFERENCES [dbo].[Promotion] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__Promotion__398D8EEE]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__TableID__3A81B327] FOREIGN KEY([TableID])
REFERENCES [dbo].[Table] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__TableID__3A81B327]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__UserID__3B75D760] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__UserID__3B75D760]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_ORDER_SHOP] FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_ORDER_SHOP]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__Order__3C69FB99] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__Order__3C69FB99]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[ProductCategory] ([ID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([ID])
GO
ALTER TABLE [dbo].[Promotion]  WITH CHECK ADD FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([ID])
GO
ALTER TABLE [dbo].[Shop]  WITH CHECK ADD FOREIGN KEY([WardID])
REFERENCES [dbo].[Ward] ([ID])
GO
ALTER TABLE [dbo].[ShopUser]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[ShopUser]  WITH CHECK ADD FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([ID])
GO
ALTER TABLE [dbo].[ShopUser]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD FOREIGN KEY([GroupTableID])
REFERENCES [dbo].[GroupTable] ([ID])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([WardID])
REFERENCES [dbo].[Ward] ([ID])
GO
ALTER TABLE [dbo].[Ward]  WITH CHECK ADD FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([ID])
GO
USE [master]
GO
ALTER DATABASE [CoffeShopSystem] SET  READ_WRITE 
GO
