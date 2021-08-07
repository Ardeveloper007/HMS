USE [master]
GO
/****** Object:  Database [dbHostiptalERP]    Script Date: 7/26/2021 10:40:43 PM ******/
CREATE DATABASE [dbHostiptalERP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbHostiptalERP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbHostiptalERP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbHostiptalERP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbHostiptalERP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbHostiptalERP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbHostiptalERP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbHostiptalERP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbHostiptalERP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbHostiptalERP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbHostiptalERP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbHostiptalERP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET RECOVERY FULL 
GO
ALTER DATABASE [dbHostiptalERP] SET  MULTI_USER 
GO
ALTER DATABASE [dbHostiptalERP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbHostiptalERP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbHostiptalERP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbHostiptalERP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbHostiptalERP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbHostiptalERP] SET QUERY_STORE = OFF
GO
USE [dbHostiptalERP]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[Address] [nvarchar](max) NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[CompanyId] [int] NULL,
	[BranchId] [int] NULL,
	[Role_Id] [int] NULL,
	[IsActive] [bit] NULL,
	[EntryUser] [int] NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScreenDefinition]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScreenDefinition](
	[ScreenId] [int] IDENTITY(1,1) NOT NULL,
	[ScreenName] [nvarchar](100) NULL,
	[ScreenAlias] [nvarchar](100) NULL,
 CONSTRAINT [PK_ScreenDefinition] PRIMARY KEY CLUSTERED 
(
	[ScreenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScreenRight]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScreenRight](
	[ScreenRightId] [int] IDENTITY(1,1) NOT NULL,
	[ScreenRightName] [nvarchar](50) NULL,
	[ScreenId] [int] NULL,
 CONSTRAINT [PK_ScreenRight] PRIMARY KEY CLUSTERED 
(
	[ScreenRightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_InventoryTransaction]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_InventoryTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RefDocumentTypeId] [int] NULL,
	[RefDocIdNo] [int] NULL,
	[DocDate] [date] NULL,
	[SupplierCustomerId] [int] NULL,
	[CategoryId] [int] NULL,
	[ItemId] [int] NULL,
	[QtyIn] [float] NULL,
	[QtyOut] [float] NULL,
	[ItemRate] [float] NULL,
	[ExpiryDate] [date] NULL,
	[Remarks] [nvarchar](500) NULL,
 CONSTRAINT [PK_tbl_InventoryTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Item_Allocation]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Item_Allocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Item_Id] [int] NULL,
	[PurchaseAccount] [int] NULL,
	[SaleAccount] [int] NULL,
	[COGSGLAC] [int] NULL,
	[IsActive] [bit] NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Company_Id] [int] NULL,
	[Branch_Id] [int] NULL,
 CONSTRAINT [PK_tbl_Item_Allocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Item_Def]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Item_Def](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Id] [int] NULL,
	[Item_Name] [nvarchar](50) NULL,
	[PackQty] [int] NULL,
	[Entry_Date] [datetime] NULL,
 CONSTRAINT [PK_tbl_Item_Def] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PurchaseDetail]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PurchaseDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseMaster_Id] [int] NULL,
	[CategoryId] [int] NULL,
	[ItemId] [int] NULL,
	[PackQty] [int] NULL,
	[ItemQty] [float] NULL,
	[NetQty] [float] NULL,
	[UnitRate] [float] NULL,
	[ItemRate] [float] NULL,
	[ItemAmount] [float] NULL,
	[BillAmount] [float] NULL,
	[ExpiryDate] [date] NULL,
	[RemarksDetail] [nvarchar](500) NULL,
 CONSTRAINT [PK_tbl_PurchaseDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PurchaseMaster]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PurchaseMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](50) NULL,
	[DocumentTypeId] [int] NULL,
	[DocDate] [date] NULL,
	[SupplierCustomerId] [int] NULL,
	[ManualBillNo] [nvarchar](50) NULL,
	[BillAmount] [float] NULL,
	[Remarks] [nvarchar](500) NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Company_Id] [int] NULL,
	[Branch_Id] [int] NULL,
 CONSTRAINT [PK_tbl_PurchaseMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PurchaseReturnDetail]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PurchaseReturnDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseReturnMaster_Id] [int] NULL,
	[CategoryId] [int] NULL,
	[ItemId] [int] NULL,
	[PackQty] [int] NULL,
	[ItemQty] [float] NULL,
	[NetQty] [float] NULL,
	[UnitRate] [float] NULL,
	[ItemRate] [float] NULL,
	[ItemAmount] [float] NULL,
	[BillAmount] [float] NULL,
	[ExpiryDate] [date] NULL,
	[RemarksDetail] [nvarchar](500) NULL,
 CONSTRAINT [PK_tbl_PurchaseReturnDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PurchaseReturnMaster]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PurchaseReturnMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentTypeId] [int] NULL,
	[DocDate] [date] NULL,
	[OrderNo] [nvarchar](50) NULL,
	[SupplierCustomerId] [int] NULL,
	[ManualBillNo] [nvarchar](50) NULL,
	[BillAmount] [float] NULL,
	[Remarks] [nvarchar](500) NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Company_Id] [int] NULL,
	[Branch_Id] [int] NULL,
 CONSTRAINT [PK_tbl_PurchaseReturnMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SaleDetail]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SaleDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaleMaster_Id] [int] NULL,
	[CategoryId] [int] NULL,
	[ItemId] [int] NULL,
	[ItemQty] [float] NULL,
	[UnitRate] [float] NULL,
	[ItemRate] [float] NULL,
	[ItemAmount] [float] NULL,
	[BillAmount] [float] NULL,
	[Discount] [float] NULL,
	[FinalAmount] [float] NULL,
	[ExpiryDate] [date] NULL,
	[RemarksDetail] [nvarchar](500) NULL,
 CONSTRAINT [PK_tbl_SaleDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SaleMaster]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SaleMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](50) NULL,
	[DocumentTypeId] [int] NULL,
	[DocDate] [date] NULL,
	[SupplierCustomerId] [int] NULL,
	[ManualBillNo] [nvarchar](50) NULL,
	[BillAmount] [float] NULL,
	[Remarks] [nvarchar](500) NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Company_Id] [int] NULL,
	[Branch_Id] [int] NULL,
 CONSTRAINT [PK_tbl_SaleMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SaleReturnDetail]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SaleReturnDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaleReturnMaster_Id] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[ItemId] [int] NULL,
	[ItemQty] [float] NULL,
	[UnitRate] [float] NULL,
	[ItemRate] [float] NULL,
	[ItemAmount] [float] NULL,
	[BillAmount] [float] NULL,
	[Discount] [float] NULL,
	[FinalAmount] [float] NULL,
	[ExpiryDate] [date] NULL,
	[RemarksDetail] [nvarchar](500) NULL,
 CONSTRAINT [PK_tbl_SaleReturnDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SaleReturnMaster]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SaleReturnMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](50) NULL,
	[DocumentTypeId] [int] NULL,
	[DocDate] [date] NULL,
	[SupplierCustomerId] [int] NULL,
	[ManualBillNo] [nvarchar](50) NULL,
	[BillAmount] [float] NULL,
	[Remarks] [nvarchar](500) NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Company_Id] [int] NULL,
	[Branch_Id] [int] NULL,
 CONSTRAINT [PK_tbl_SaleReturnMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblActivityLogs]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblActivityLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NULL,
	[Date] [date] NULL,
	[Datetime] [datetime] NULL,
	[Activity] [nvarchar](50) NULL,
	[Screen_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblActivityLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBranches]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBranches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Branch_Name] [nvarchar](500) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](500) NULL,
	[Contact_No] [nvarchar](500) NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Company_Id] [int] NULL,
 CONSTRAINT [PK_tblBranches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](550) NULL,
	[Entry_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCOA]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCOA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubAccount_Id] [int] NULL,
	[Account_Code] [int] NULL,
	[Account_Title] [nvarchar](550) NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Company_Id] [int] NULL,
	[Branch_Id] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tblCOA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCOAOpeningBalance]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCOAOpeningBalance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[COA_Id] [int] NULL,
	[Debit] [float] NULL,
	[Credit] [float] NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Company_Id] [int] NULL,
	[Branch_Id] [int] NULL,
 CONSTRAINT [PK_tblCOAOpeningBalance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCompany]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCompany](
	[Company_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](250) NULL,
	[Logo] [nvarchar](max) NULL,
	[Entry_Date] [datetime] NULL,
	[Email] [nvarchar](250) NULL,
	[Reporting_Title] [nvarchar](250) NULL,
 CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED 
(
	[Company_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDocumentType]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDocumentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Document_Type_Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblDocumentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOPD]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOPD](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dr_Id] [int] NULL,
	[Customer_Id] [int] NULL,
	[Fees] [float] NULL,
	[Datetime] [datetime] NULL,
	[Token_No] [int] NULL,
	[Visited] [bit] NULL,
	[Day] [date] NULL,
 CONSTRAINT [PK_tblOPD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblParentAccount]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblParentAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Account] [nvarchar](250) NULL,
	[Type] [int] NULL,
	[Type_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblParentAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubAccount]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubAccount_Name] [nvarchar](250) NULL,
	[Parent_Account_Id] [int] NULL,
	[Company_Id] [int] NULL,
	[Entry_Date] [datetime] NULL,
	[Modify_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Branch_Id] [int] NULL,
 CONSTRAINT [PK_tblSubAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSupplierCustomer]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplierCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Profile_Name] [nvarchar](550) NULL,
	[Address] [nvarchar](550) NULL,
	[Contact_No] [nvarchar](550) NULL,
	[Reporting_Title] [nvarchar](550) NULL,
	[GlAccount_Id] [int] NULL,
	[SupplierCustomerType] [nvarchar](50) NULL,
	[Entry_Date] [datetime] NULL,
	[Entry_User] [int] NULL,
	[Modify_User] [int] NULL,
	[Modify_Date] [datetime] NULL,
	[Company_Id] [int] NULL,
	[Branch_Id] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tblSupplierCustomer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSystemConfigrations]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSystemConfigrations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Configration_Name] [nvarchar](max) NULL,
	[Configration_Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSystemConfigrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUserRights]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserRights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ScreenId] [int] NULL,
	[RightId] [int] NULL,
	[Value] [bit] NULL,
 CONSTRAINT [PK_TblUserRights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVoucherDetail]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVoucherDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Voucher_Head_Id] [int] NULL,
	[COA_Id] [int] NULL,
	[Against_COA_Id] [int] NULL,
	[Comments] [nvarchar](max) NULL,
	[DebitAmount] [float] NULL,
	[CreditAmount] [float] NULL,
	[Item_Id] [int] NULL,
	[ChequeNo] [nvarchar](550) NULL,
 CONSTRAINT [PK_tblVoucherDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVoucherHead]    Script Date: 7/26/2021 10:40:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVoucherHead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentType_Id] [int] NULL,
	[RefDocTypeId] [int] NULL,
	[RefDocNoId] [int] NULL,
	[Voucher_Code] [int] NULL,
	[Voucher_Date] [datetime] NULL,
	[Voucher_Amount] [float] NULL,
	[RefrenceAccount] [int] NULL,
	[AgainstAccount] [int] NULL,
	[Entry_User] [int] NULL,
	[Branch_Id] [int] NULL,
	[Company_Id] [int] NULL,
	[DoctorAmount] [float] NULL,
 CONSTRAINT [PK_tblVoucherHead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (2, N'ShopKeeper')
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [Password], [PhoneNumber], [UserName], [Address], [FirstName], [LastName], [CompanyId], [BranchId], [Role_Id], [IsActive], [EntryUser]) VALUES (1, N'123', N'', N'admin', N'', N'Abdul', N'Rehman', 1, 1, 1, 1, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Password], [PhoneNumber], [UserName], [Address], [FirstName], [LastName], [CompanyId], [BranchId], [Role_Id], [IsActive], [EntryUser]) VALUES (2, N'123', N'', N'saa', N'', N'Saad', N'Zahid', 1, 1, 2, 1, NULL)
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[ScreenDefinition] ON 

INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (1, N'frmDefineCategory', N'Define Category')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (2, N'frmAddItem', N'Define Item')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (3, N'frmSupplierCustomer', N'Define Supplier Customer')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (4, N'ItemAllocation', N'Item Allocation')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (5, N'OPD', N'OPD')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (6, N'frmPurchase', N'Purchase ')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (7, N'frmPurchaseReturn', N'Purchase Return')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (8, N'frmSale', N'Sale')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (9, N'frmSaleReturn', N'Sale Return')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (10, N'AcfrmCOA', N'Chart Of Account')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (11, N'OpeningBalance', N'Opening Balance')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (12, N'Voucher', N'Voucher')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (13, N'frmUserRights', N'User Rights')
INSERT [dbo].[ScreenDefinition] ([ScreenId], [ScreenName], [ScreenAlias]) VALUES (14, N'Dashboard', N'Dashboard')
SET IDENTITY_INSERT [dbo].[ScreenDefinition] OFF
GO
SET IDENTITY_INSERT [dbo].[ScreenRight] ON 

INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (1, N'Save', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (2, N'Print', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (3, N'Update', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (4, N'Field Chooser', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (5, N'Save Layout', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (6, N'Grid Print', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (7, N'Grid Export', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (8, N'Group Collapse', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (9, N'Group Expand', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (10, N'Report Export', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (11, N'Report Print', 1)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (12, N'Save', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (13, N'Print', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (14, N'Update', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (15, N'Field Chooser', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (16, N'Save Layout', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (17, N'Grid Print', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (18, N'Grid Export', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (19, N'Group Collapse', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (20, N'Group Expand', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (21, N'Report Export', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (22, N'Report Print', 2)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (23, N'Save', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (24, N'Print', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (25, N'Update', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (26, N'Field Chooser', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (27, N'Save Layout', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (28, N'Grid Print', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (29, N'Grid Export', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (30, N'Group Collapse', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (31, N'Group Expand', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (32, N'Report Export', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (33, N'Report Print', 3)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (34, N'Save', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (35, N'Print', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (36, N'Update', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (37, N'Field Chooser', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (38, N'Save Layout', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (39, N'Grid Print', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (40, N'Grid Export', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (41, N'Group Collapse', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (42, N'Group Expand', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (43, N'Report Export', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (44, N'Report Print', 4)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (45, N'Save', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (46, N'Print', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (47, N'Update', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (48, N'Field Chooser', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (49, N'Save Layout', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (50, N'Grid Print', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (51, N'Grid Export', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (52, N'Group Collapse', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (53, N'Group Expand', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (54, N'Report Export', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (55, N'Report Print', 5)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (56, N'Save', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (57, N'Print', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (58, N'Update', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (59, N'Field Chooser', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (60, N'Save Layout', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (61, N'Grid Print', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (62, N'Grid Export', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (63, N'Group Collapse', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (64, N'Group Expand', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (65, N'Report Export', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (66, N'Report Print', 6)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (67, N'Save', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (68, N'Print', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (69, N'Update', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (70, N'Field Chooser', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (71, N'Save Layout', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (72, N'Grid Print', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (73, N'Grid Export', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (74, N'Group Collapse', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (75, N'Group Expand', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (76, N'Report Export', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (77, N'Report Print', 7)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (78, N'Save', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (79, N'Print', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (80, N'Update', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (81, N'Field Chooser', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (82, N'Save Layout', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (83, N'Grid Print', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (84, N'Grid Export', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (85, N'Group Collapse', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (86, N'Group Expand', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (87, N'Report Export', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (88, N'Report Print', 8)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (89, N'Save', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (90, N'Print', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (91, N'Update', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (92, N'Field Chooser', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (93, N'Save Layout', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (94, N'Grid Print', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (95, N'Grid Export', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (96, N'Group Collapse', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (97, N'Group Expand', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (98, N'Report Export', 9)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (99, N'Report Print', 9)
GO
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (100, N'Save', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (101, N'Print', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (102, N'Update', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (103, N'Field Chooser', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (104, N'Save Layout', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (105, N'Grid Print', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (106, N'Grid Export', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (107, N'Group Collapse', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (108, N'Group Expand', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (109, N'Report Export', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (110, N'Report Print', 10)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (112, N'Save', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (113, N'Print', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (114, N'Update', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (115, N'Field Chooser', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (116, N'Save Layout', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (117, N'Grid Print', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (118, N'Grid Export', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (119, N'Group Collapse', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (120, N'Group Expand', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (121, N'Report Export', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (122, N'Report Print', 11)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (123, N'Save', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (124, N'Print', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (125, N'Update', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (126, N'Field Chooser', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (127, N'Save Layout', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (128, N'Grid Print', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (129, N'Grid Export', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (130, N'Group Collapse', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (131, N'Group Expand', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (132, N'Report Export', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (133, N'Report Print', 12)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (146, N'Save', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (147, N'Print', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (148, N'Update', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (149, N'Field Chooser', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (150, N'Save Layout', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (151, N'Grid Print', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (152, N'Grid Export', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (153, N'Group Collapse', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (154, N'Group Expand', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (155, N'Report Export', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (156, N'Report Print', 13)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (157, N'Open UserRight', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (158, N'Open Configuration', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (159, N'Open Account Module', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (160, N'Open Miscellaneous', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (161, N'Open Inventory', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (162, N'Open OPD ', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (163, N'Open Inventory Reports', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (164, N'Open Accounts Reports', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (165, N'View Doctors', 14)
INSERT [dbo].[ScreenRight] ([ScreenRightId], [ScreenRightName], [ScreenId]) VALUES (166, N'Add Doctors', 14)
SET IDENTITY_INSERT [dbo].[ScreenRight] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_InventoryTransaction] ON 

INSERT [dbo].[tbl_InventoryTransaction] ([Id], [RefDocumentTypeId], [RefDocIdNo], [DocDate], [SupplierCustomerId], [CategoryId], [ItemId], [QtyIn], [QtyOut], [ItemRate], [ExpiryDate], [Remarks]) VALUES (81, 1, 48, CAST(N'2021-06-20' AS Date), 24, 17, 22, 20, 0, 160, CAST(N'2021-07-27' AS Date), N'')
INSERT [dbo].[tbl_InventoryTransaction] ([Id], [RefDocumentTypeId], [RefDocIdNo], [DocDate], [SupplierCustomerId], [CategoryId], [ItemId], [QtyIn], [QtyOut], [ItemRate], [ExpiryDate], [Remarks]) VALUES (82, 1, 49, CAST(N'2021-06-20' AS Date), 24, 17, 23, 200, 0, 200, CAST(N'2021-08-20' AS Date), N'')
INSERT [dbo].[tbl_InventoryTransaction] ([Id], [RefDocumentTypeId], [RefDocIdNo], [DocDate], [SupplierCustomerId], [CategoryId], [ItemId], [QtyIn], [QtyOut], [ItemRate], [ExpiryDate], [Remarks]) VALUES (83, 1, 50, CAST(N'2021-06-28' AS Date), 24, 17, 22, 200, 0, 100, CAST(N'2021-07-29' AS Date), N'')
INSERT [dbo].[tbl_InventoryTransaction] ([Id], [RefDocumentTypeId], [RefDocIdNo], [DocDate], [SupplierCustomerId], [CategoryId], [ItemId], [QtyIn], [QtyOut], [ItemRate], [ExpiryDate], [Remarks]) VALUES (84, 1, 51, CAST(N'2021-06-28' AS Date), 24, 20, 35, 10, 0, 20000, CAST(N'2021-07-29' AS Date), N'')
SET IDENTITY_INSERT [dbo].[tbl_InventoryTransaction] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Item_Allocation] ON 

INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (22, 27, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (23, 28, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (24, 29, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (25, 30, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (26, 31, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (27, 32, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (28, 33, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (32, 37, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (33, 38, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (34, 40, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (35, 39, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Item_Allocation] ([Id], [Item_Id], [PurchaseAccount], [SaleAccount], [COGSGLAC], [IsActive], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (36, 41, 74, 81, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Item_Allocation] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Item_Def] ON 

INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (27, 17, N'Novidate 250 mg', 20, CAST(N'2021-06-19T05:15:48.447' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (28, 17, N'Novidate 500 mg ', 20, CAST(N'2021-06-19T05:16:01.497' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (29, 17, N'Amoxil 250', 30, CAST(N'2021-06-19T05:16:10.290' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (30, 17, N'Amoxil 500 mg ', 30, CAST(N'2021-06-19T05:16:20.033' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (31, 18, N'Voran ', 10, CAST(N'2021-06-19T05:16:28.963' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (32, 18, N'Oxidil 1G', 1, CAST(N'2021-06-19T05:16:40.480' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (33, 18, N'Cobalmin ', 10, CAST(N'2021-06-19T05:16:51.483' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (37, 17, N'Ponstan Fort', 10, CAST(N'2021-06-19T23:27:55.230' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (38, 17, N'Qalsan-D', 10, CAST(N'2021-06-20T02:49:19.990' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (39, 20, N'Samsung Galaxy S10', 1, CAST(N'2021-06-28T02:13:40.573' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (40, 19, N'Plastic Water Bottle', 1, CAST(N'2021-06-28T02:13:54.467' AS DateTime))
INSERT [dbo].[tbl_Item_Def] ([Id], [Category_Id], [Item_Name], [PackQty], [Entry_Date]) VALUES (41, 17, N'Panadol', 50, CAST(N'2021-07-26T20:39:07.623' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_Item_Def] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_PurchaseDetail] ON 

INSERT [dbo].[tbl_PurchaseDetail] ([Id], [PurchaseMaster_Id], [CategoryId], [ItemId], [PackQty], [ItemQty], [NetQty], [UnitRate], [ItemRate], [ItemAmount], [BillAmount], [ExpiryDate], [RemarksDetail]) VALUES (72, 48, 17, 22, 20, 1, 20, 8, 160, 160, 160, CAST(N'2021-07-27' AS Date), N'')
INSERT [dbo].[tbl_PurchaseDetail] ([Id], [PurchaseMaster_Id], [CategoryId], [ItemId], [PackQty], [ItemQty], [NetQty], [UnitRate], [ItemRate], [ItemAmount], [BillAmount], [ExpiryDate], [RemarksDetail]) VALUES (73, 49, 17, 23, 20, 10, 200, 10, 200, 2000, 2000, CAST(N'2021-08-20' AS Date), N'')
INSERT [dbo].[tbl_PurchaseDetail] ([Id], [PurchaseMaster_Id], [CategoryId], [ItemId], [PackQty], [ItemQty], [NetQty], [UnitRate], [ItemRate], [ItemAmount], [BillAmount], [ExpiryDate], [RemarksDetail]) VALUES (74, 50, 17, 22, 20, 10, 200, 5, 100, 1000, 1000, CAST(N'2021-07-29' AS Date), N'')
INSERT [dbo].[tbl_PurchaseDetail] ([Id], [PurchaseMaster_Id], [CategoryId], [ItemId], [PackQty], [ItemQty], [NetQty], [UnitRate], [ItemRate], [ItemAmount], [BillAmount], [ExpiryDate], [RemarksDetail]) VALUES (75, 51, 20, 35, 1, 10, 10, 20000, 20000, 200000, 200000, CAST(N'2021-07-29' AS Date), N'')
SET IDENTITY_INSERT [dbo].[tbl_PurchaseDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_PurchaseMaster] ON 

INSERT [dbo].[tbl_PurchaseMaster] ([Id], [OrderNo], [DocumentTypeId], [DocDate], [SupplierCustomerId], [ManualBillNo], [BillAmount], [Remarks], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (48, N'PO-1', 1, CAST(N'2021-06-20' AS Date), 24, N'', 160, N'', CAST(N'2021-06-20T02:52:38.250' AS DateTime), CAST(N'2021-06-20T02:52:38.250' AS DateTime), 1, 1, 1, 1)
INSERT [dbo].[tbl_PurchaseMaster] ([Id], [OrderNo], [DocumentTypeId], [DocDate], [SupplierCustomerId], [ManualBillNo], [BillAmount], [Remarks], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (49, N'PO-2', 1, CAST(N'2021-06-20' AS Date), 24, N'', 2000, N'', CAST(N'2021-06-20T02:55:18.300' AS DateTime), CAST(N'2021-06-20T02:55:18.300' AS DateTime), 1, 1, 1, 1)
INSERT [dbo].[tbl_PurchaseMaster] ([Id], [OrderNo], [DocumentTypeId], [DocDate], [SupplierCustomerId], [ManualBillNo], [BillAmount], [Remarks], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (50, N'PO-3', 1, CAST(N'2021-06-28' AS Date), 24, N'', 1000, N'', CAST(N'2021-06-28T02:12:31.783' AS DateTime), CAST(N'2021-06-28T02:12:31.783' AS DateTime), 1, 1, 1, 1)
INSERT [dbo].[tbl_PurchaseMaster] ([Id], [OrderNo], [DocumentTypeId], [DocDate], [SupplierCustomerId], [ManualBillNo], [BillAmount], [Remarks], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (51, N'PO-4', 1, CAST(N'2021-06-28' AS Date), 24, N'', 200000, N'', CAST(N'2021-06-28T02:17:41.090' AS DateTime), CAST(N'2021-06-28T02:17:41.090' AS DateTime), 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tbl_PurchaseMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[tblActivityLogs] ON 

INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (1, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T12:33:08.190' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (2, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T12:34:28.333' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (3, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T12:35:39.453' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (4, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T12:39:42.370' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (5, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T12:40:20.443' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (6, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T13:01:17.143' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (7, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T13:40:10.443' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (8, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T13:47:27.920' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (9, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T13:49:06.133' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (10, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T13:49:48.773' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (11, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T14:06:03.837' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (12, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T14:16:25.497' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (13, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T14:19:41.587' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (14, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T14:22:07.667' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (15, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T14:51:09.097' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (16, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T15:04:05.053' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (17, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T15:31:52.867' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (18, 1, CAST(N'2021-05-01' AS Date), CAST(N'2021-05-01T15:45:19.103' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (19, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T19:51:09.180' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (20, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T19:55:35.367' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (21, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T22:14:22.633' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (22, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T22:24:09.247' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (23, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T22:28:18.297' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (24, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T22:30:21.563' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (25, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T22:34:47.330' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (26, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T22:53:52.970' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (27, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T23:09:12.790' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (28, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T23:10:56.340' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (29, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T23:17:11.633' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (30, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T23:28:38.887' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (31, 1, CAST(N'2021-05-02' AS Date), CAST(N'2021-05-02T23:50:24.760' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (32, 1, CAST(N'2021-05-03' AS Date), CAST(N'2021-05-03T22:15:46.660' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (33, 1, CAST(N'2021-05-03' AS Date), CAST(N'2021-05-03T22:43:46.263' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (34, 1, CAST(N'2021-05-03' AS Date), CAST(N'2021-05-03T22:52:35.973' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (35, 1, CAST(N'2021-05-03' AS Date), CAST(N'2021-05-03T23:15:25.380' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (36, 1, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05T21:51:59.927' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (37, 1, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05T21:53:19.993' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (38, 1, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05T21:55:34.917' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (39, 1, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05T21:57:36.237' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (40, 1, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05T22:03:32.470' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (41, 1, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05T22:05:11.310' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (42, 1, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05T22:07:12.870' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (43, 1, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05T22:13:14.253' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (44, 1, CAST(N'2021-05-06' AS Date), CAST(N'2021-05-06T21:40:44.980' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (45, 1, CAST(N'2021-05-06' AS Date), CAST(N'2021-05-06T21:42:03.723' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (46, 1, CAST(N'2021-05-06' AS Date), CAST(N'2021-05-06T21:54:28.183' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (47, 1, CAST(N'2021-05-06' AS Date), CAST(N'2021-05-06T21:55:05.127' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (48, 1, CAST(N'2021-05-06' AS Date), CAST(N'2021-05-06T22:00:44.757' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (49, 1, CAST(N'2021-05-06' AS Date), CAST(N'2021-05-06T22:02:52.603' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (50, 1, CAST(N'2021-05-08' AS Date), CAST(N'2021-05-08T15:38:07.547' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (51, 1, CAST(N'2021-05-08' AS Date), CAST(N'2021-05-08T15:39:40.373' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (52, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T11:21:48.343' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (53, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T11:27:01.800' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (54, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T11:45:51.090' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (55, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T11:47:39.400' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (56, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T13:27:48.277' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (57, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T13:35:33.373' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (58, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T13:40:44.817' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (59, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T13:51:54.247' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (60, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T14:01:53.283' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (61, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T15:11:29.673' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (62, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T15:12:27.660' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (63, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T15:23:16.027' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (64, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T16:53:48.030' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (65, 1, CAST(N'2021-05-09' AS Date), CAST(N'2021-05-09T16:54:28.390' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (66, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T15:25:50.930' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (67, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T15:31:30.730' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (68, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T15:32:13.373' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (69, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T15:37:57.237' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (70, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T15:38:35.400' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (71, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T15:39:07.307' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (72, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T15:40:07.373' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (73, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T17:22:52.333' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (74, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T17:32:12.817' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (75, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T17:34:05.590' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (76, 1, CAST(N'2021-05-11' AS Date), CAST(N'2021-05-11T17:37:12.233' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (77, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T16:39:24.010' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (78, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T16:40:27.723' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (79, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T17:19:32.493' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (80, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T17:51:12.347' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (81, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T17:56:12.877' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (82, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T17:59:58.917' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (83, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T18:02:13.937' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (84, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T18:21:34.833' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (85, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T18:23:08.753' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (86, 1, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-12T19:11:00.393' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (87, 1, CAST(N'2021-05-16' AS Date), CAST(N'2021-05-16T20:45:27.420' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (88, 1, CAST(N'2021-05-16' AS Date), CAST(N'2021-05-16T20:48:18.170' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (89, 1, CAST(N'2021-05-16' AS Date), CAST(N'2021-05-16T21:18:45.350' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (90, 1, CAST(N'2021-05-16' AS Date), CAST(N'2021-05-16T21:21:26.953' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (91, 1, CAST(N'2021-05-16' AS Date), CAST(N'2021-05-16T21:24:41.420' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (92, 1, CAST(N'2021-05-16' AS Date), CAST(N'2021-05-16T21:27:04.617' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (93, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T19:37:35.257' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (94, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T19:46:57.793' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (95, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T20:06:53.140' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (96, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T20:12:17.157' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (97, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T20:24:39.767' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (98, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T20:35:57.393' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (99, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T20:40:23.050' AS DateTime), N'Login', N'Login')
GO
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (100, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T21:05:43.020' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (101, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T23:06:41.973' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (102, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T23:10:41.080' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (103, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T23:16:18.217' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (104, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T23:22:08.810' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (105, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T23:32:41.740' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (106, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T23:36:08.027' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (107, 1, CAST(N'2021-05-19' AS Date), CAST(N'2021-05-19T23:39:38.993' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (108, 1, CAST(N'2021-05-24' AS Date), CAST(N'2021-05-24T21:02:11.203' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (109, 1, CAST(N'2021-05-24' AS Date), CAST(N'2021-05-24T21:06:28.387' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (110, 1, CAST(N'2021-05-24' AS Date), CAST(N'2021-05-24T21:12:51.097' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (111, 1, CAST(N'2021-05-25' AS Date), CAST(N'2021-05-25T23:20:04.777' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (112, 1, CAST(N'2021-05-25' AS Date), CAST(N'2021-05-25T23:22:01.730' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (113, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T01:24:03.393' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (114, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T01:25:01.530' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (115, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T01:34:11.003' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (116, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T01:37:18.930' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (117, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T08:47:55.320' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (118, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T08:52:50.537' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (119, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T08:54:19.077' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (120, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T09:06:51.380' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (121, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T09:08:29.147' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (122, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T11:12:40.810' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (123, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T11:41:05.790' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (124, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T11:58:36.920' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (125, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T19:31:33.290' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (126, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T19:37:52.870' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (127, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T23:29:35.137' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (128, 1, CAST(N'2021-05-28' AS Date), CAST(N'2021-05-28T23:57:28.257' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (129, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T00:15:36.600' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (130, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T00:21:28.910' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (131, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T00:30:12.860' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (132, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T00:44:36.747' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (133, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:12:48.607' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (134, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:15:06.527' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (135, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:16:45.240' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (136, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:20:33.117' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (137, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:21:44.627' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (138, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:23:34.163' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (139, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:28:21.100' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (140, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:32:54.357' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (141, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:50:21.720' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (142, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:57:08.803' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (143, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T08:58:01.367' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (144, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:05:04.223' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (145, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:07:06.877' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (146, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:14:44.420' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (147, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:27:42.100' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (148, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:33:55.510' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (149, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:48:40.063' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (150, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:50:39.930' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (151, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:54:53.197' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (152, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T09:55:34.050' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (153, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:07:32.903' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (154, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:10:48.163' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (155, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:12:11.423' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (156, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:16:28.557' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (157, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:26:45.733' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (158, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:31:02.820' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (159, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:33:11.363' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (160, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:36:27.813' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (161, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:46:35.493' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (162, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:52:49.377' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (163, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T10:58:21.690' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (164, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T11:03:29.533' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (165, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T11:42:11.483' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (166, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T11:55:14.610' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (167, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T12:01:23.850' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (168, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T12:04:55.167' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (169, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T13:08:53.460' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (170, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T13:11:16.960' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (171, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T14:15:49.660' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (172, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T14:37:36.453' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (173, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T15:03:29.493' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (174, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T15:05:02.547' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (175, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T15:06:11.673' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (176, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T15:06:54.487' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (177, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T15:42:40.080' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (178, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T15:47:19.877' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (179, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T15:50:17.010' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (180, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T16:04:54.757' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (181, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T16:15:29.890' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (182, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T16:17:55.537' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (183, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T17:19:31.187' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (184, 1, CAST(N'2021-05-29' AS Date), CAST(N'2021-05-29T17:38:19.330' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (185, 1, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-08T21:16:58.490' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (186, 1, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-08T21:58:36.240' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (187, 1, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-08T22:04:28.797' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (188, 1, CAST(N'2021-06-08' AS Date), CAST(N'2021-06-08T22:05:18.753' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (189, 1, CAST(N'2021-06-09' AS Date), CAST(N'2021-06-09T20:51:05.727' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (190, 1, CAST(N'2021-06-09' AS Date), CAST(N'2021-06-09T21:45:02.360' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (191, 1, CAST(N'2021-06-09' AS Date), CAST(N'2021-06-09T22:07:34.727' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (192, 1, CAST(N'2021-06-10' AS Date), CAST(N'2021-06-10T02:45:27.633' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (193, 1, CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T22:24:36.077' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (194, 1, CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T22:31:32.460' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (195, 1, CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T22:50:55.873' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (196, 1, CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T22:58:16.927' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (197, 1, CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T23:00:49.933' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (198, 1, CAST(N'2021-06-12' AS Date), CAST(N'2021-06-12T23:21:09.413' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (199, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T00:02:31.667' AS DateTime), N'Login', N'Login')
GO
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (200, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T00:06:55.890' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (201, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T00:17:34.970' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (202, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T00:31:25.393' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (203, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T00:36:07.880' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (204, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T00:39:03.320' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (205, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T00:43:46.063' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (206, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T20:57:43.227' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (207, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T21:03:35.760' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (208, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T21:42:32.340' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (209, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T22:09:58.273' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (210, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T23:07:30.033' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (211, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-13T23:30:20.127' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (212, 1, CAST(N'2021-06-14' AS Date), CAST(N'2021-06-14T21:06:22.237' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (213, 1, CAST(N'2021-06-14' AS Date), CAST(N'2021-06-14T21:30:45.487' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (214, 1, CAST(N'2021-06-14' AS Date), CAST(N'2021-06-14T21:37:38.200' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (215, 1, CAST(N'2021-06-14' AS Date), CAST(N'2021-06-14T22:20:59.470' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (216, 1, CAST(N'2021-06-14' AS Date), CAST(N'2021-06-14T22:30:11.907' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (217, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T21:38:22.857' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (218, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T22:46:20.463' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (219, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T22:47:41.243' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (220, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:08:38.793' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (221, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:09:37.030' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (222, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:14:24.350' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (223, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:15:54.570' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (224, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:17:13.497' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (225, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:24:47.840' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (226, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:27:30.780' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (227, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:28:44.763' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (228, 1, CAST(N'2021-06-16' AS Date), CAST(N'2021-06-16T23:42:59.570' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (229, 1, CAST(N'2021-06-17' AS Date), CAST(N'2021-06-17T00:05:07.223' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (230, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T08:37:11.653' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (231, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T08:39:36.627' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (232, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T08:41:19.570' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (233, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T08:42:36.487' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (234, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T08:47:38.047' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (235, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T08:54:51.440' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (236, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T08:57:35.207' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (237, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T09:08:06.413' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (238, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T09:10:22.517' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (239, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T09:12:16.730' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (240, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T09:17:34.973' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (241, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T09:49:05.207' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (242, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T10:20:02.570' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (243, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T10:59:49.377' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (244, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T11:14:29.080' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (245, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T11:19:14.613' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (246, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T11:21:19.103' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (247, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T11:23:27.930' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (248, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T11:25:42.930' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (249, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T11:43:40.900' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (250, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T11:46:32.123' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (251, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T11:56:21.777' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (252, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T12:07:19.520' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (253, 1, CAST(N'2021-06-18' AS Date), CAST(N'2021-06-18T12:28:18.063' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (254, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T00:32:44.957' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (255, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T01:19:47.163' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (256, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T01:30:32.313' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (257, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T01:58:19.437' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (258, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T03:05:02.093' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (259, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T03:44:45.217' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (260, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T03:53:31.333' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (261, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T03:55:11.843' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (262, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T03:57:17.217' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (263, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T04:03:52.313' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (264, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T04:31:25.907' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (265, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T04:51:37.950' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (266, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T05:07:36.550' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (267, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T05:29:43.300' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (268, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T05:30:37.550' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (269, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T05:31:45.403' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (270, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T05:37:42.880' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (271, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T05:47:11.217' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (272, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T06:03:32.977' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (273, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T22:52:00.687' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (274, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T22:55:57.267' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (275, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T23:05:44.970' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (276, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T23:23:06.907' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (277, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T23:27:35.210' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (278, 1, CAST(N'2021-06-19' AS Date), CAST(N'2021-06-19T23:29:15.143' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (279, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T00:02:03.430' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (280, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T00:03:02.947' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (281, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T00:15:15.360' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (282, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T00:26:31.147' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (283, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T00:45:30.903' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (284, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T01:00:13.577' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (285, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T01:11:14.970' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (286, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T01:13:11.417' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (287, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T01:57:40.957' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (288, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T02:05:51.733' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (289, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T02:11:50.267' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (290, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T02:13:05.770' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (291, 1, CAST(N'2021-06-20' AS Date), CAST(N'2021-06-20T02:28:44.753' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (292, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T02:10:55.687' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (293, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T02:15:24.600' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (294, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T02:19:22.463' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (295, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T09:32:27.560' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (296, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T09:39:39.117' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (297, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T09:45:23.250' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (298, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T11:41:42.613' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (299, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:13:18.073' AS DateTime), N'Login', N'Login')
GO
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (300, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:17:44.043' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (301, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:34:57.787' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (302, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:37:24.583' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (303, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:41:11.397' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (304, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:43:19.857' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (305, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:45:23.420' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (306, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:53:29.113' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (307, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:54:54.123' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (308, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:57:15.717' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (309, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T12:57:40.890' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (310, 1, CAST(N'2021-06-28' AS Date), CAST(N'2021-06-28T13:15:12.953' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (311, 1, CAST(N'2021-07-03' AS Date), CAST(N'2021-07-03T01:52:27.650' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (312, 1, CAST(N'2021-07-03' AS Date), CAST(N'2021-07-03T01:54:36.873' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (313, 1, CAST(N'2021-07-03' AS Date), CAST(N'2021-07-03T02:11:47.613' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (314, 1, CAST(N'2021-07-03' AS Date), CAST(N'2021-07-03T02:12:34.867' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (315, 1, CAST(N'2021-07-03' AS Date), CAST(N'2021-07-03T02:13:44.217' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (316, 1, CAST(N'2021-07-03' AS Date), CAST(N'2021-07-03T02:14:48.620' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (317, 1, CAST(N'2021-07-03' AS Date), CAST(N'2021-07-03T02:15:26.560' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (318, 1, CAST(N'2021-07-03' AS Date), CAST(N'2021-07-03T02:17:29.600' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (319, 1, CAST(N'2021-07-15' AS Date), CAST(N'2021-07-15T20:50:31.670' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (320, 1, CAST(N'2021-07-15' AS Date), CAST(N'2021-07-15T20:50:41.073' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (321, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T20:57:17.490' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (322, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T21:02:17.683' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (323, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T21:14:20.340' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (324, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T21:22:21.783' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (325, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T22:15:18.457' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (326, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T22:24:55.147' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (327, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T22:28:42.323' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (328, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T22:34:36.610' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (329, 1, CAST(N'2021-07-16' AS Date), CAST(N'2021-07-16T22:39:55.747' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (330, 1, CAST(N'2021-07-17' AS Date), CAST(N'2021-07-17T20:41:42.757' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (331, 1, CAST(N'2021-07-17' AS Date), CAST(N'2021-07-17T20:57:54.887' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (332, 1, CAST(N'2021-07-17' AS Date), CAST(N'2021-07-17T21:11:05.723' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (333, 1, CAST(N'2021-07-17' AS Date), CAST(N'2021-07-17T21:23:25.280' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (334, 1, CAST(N'2021-07-17' AS Date), CAST(N'2021-07-17T22:02:12.033' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (335, 2, CAST(N'2021-07-17' AS Date), CAST(N'2021-07-17T22:03:42.630' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (336, 1, CAST(N'2021-07-19' AS Date), CAST(N'2021-07-19T14:18:20.993' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (337, 2, CAST(N'2021-07-19' AS Date), CAST(N'2021-07-19T14:19:09.397' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (338, 2, CAST(N'2021-07-19' AS Date), CAST(N'2021-07-19T14:21:40.060' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (339, 1, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T17:19:02.483' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (340, 1, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T17:26:54.773' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (341, 1, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T17:37:16.293' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (342, 1, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T17:39:01.410' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (343, 2, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T17:39:44.410' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (344, 2, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T17:41:37.937' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (345, 2, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T17:49:36.773' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (346, 1, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T22:36:06.453' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (347, 1, CAST(N'2021-07-20' AS Date), CAST(N'2021-07-20T22:36:56.847' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (348, 2, CAST(N'2021-07-24' AS Date), CAST(N'2021-07-24T22:28:31.303' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (349, 2, CAST(N'2021-07-24' AS Date), CAST(N'2021-07-24T22:53:22.240' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (350, 1, CAST(N'2021-07-24' AS Date), CAST(N'2021-07-24T23:29:15.880' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (351, 2, CAST(N'2021-07-25' AS Date), CAST(N'2021-07-25T00:25:20.987' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (352, 2, CAST(N'2021-07-25' AS Date), CAST(N'2021-07-25T20:22:21.987' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (353, 2, CAST(N'2021-07-25' AS Date), CAST(N'2021-07-25T20:22:46.353' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (354, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T20:33:05.500' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (355, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T20:34:42.383' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (356, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T20:36:16.730' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (357, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T20:38:15.763' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (358, 1, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T20:41:23.697' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (359, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T20:42:22.857' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (360, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T20:45:00.610' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (361, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T20:50:43.207' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (362, 1, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T21:04:43.600' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (363, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T21:05:20.020' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (364, 1, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T21:20:39.243' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (365, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T21:21:10.943' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (366, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T21:22:02.160' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (367, 1, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T21:23:22.907' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (368, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T21:54:33.277' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (369, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T21:59:34.640' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (370, 2, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T22:01:22.817' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (371, 1, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T22:01:53.877' AS DateTime), N'Login', N'Login')
INSERT [dbo].[tblActivityLogs] ([Id], [User_Id], [Date], [Datetime], [Activity], [Screen_Name]) VALUES (372, 1, CAST(N'2021-07-26' AS Date), CAST(N'2021-07-26T22:03:58.803' AS DateTime), N'Login', N'Login')
SET IDENTITY_INSERT [dbo].[tblActivityLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[tblBranches] ON 

INSERT [dbo].[tblBranches] ([Id], [Branch_Name], [Address], [Email], [Contact_No], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id]) VALUES (1, N'HMS', N'Model Town', NULL, NULL, NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[tblBranches] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([Id], [Category_Name], [Entry_Date], [Entry_User]) VALUES (17, N'Tablets', CAST(N'2021-06-14T22:30:31.600' AS DateTime), 1)
INSERT [dbo].[tblCategory] ([Id], [Category_Name], [Entry_Date], [Entry_User]) VALUES (18, N'Injections', CAST(N'2021-06-08T21:32:11.997' AS DateTime), 1)
INSERT [dbo].[tblCategory] ([Id], [Category_Name], [Entry_Date], [Entry_User]) VALUES (19, N'Bottle', CAST(N'2021-06-28T02:13:13.290' AS DateTime), 1)
INSERT [dbo].[tblCategory] ([Id], [Category_Name], [Entry_Date], [Entry_User]) VALUES (20, N'Mobile', CAST(N'2021-06-28T02:13:19.570' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCOA] ON 

INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (74, 43, 20043001, N'Medicine Stocks', CAST(N'2021-06-19T05:09:14.830' AS DateTime), CAST(N'2021-06-19T05:09:14.830' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (75, 44, 20044001, N'Shoaib C-A/C', CAST(N'2021-06-19T05:09:49.793' AS DateTime), CAST(N'2021-06-19T05:09:49.793' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (76, 44, 20044002, N'Hamza C-A/C', CAST(N'2021-06-19T05:10:07.537' AS DateTime), CAST(N'2021-06-19T05:10:07.537' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (77, 45, 20045001, N'Cash In Hand', CAST(N'2021-06-19T05:10:26.870' AS DateTime), CAST(N'2021-06-19T05:10:26.870' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (78, 45, 20045002, N'UBL Bank Account', CAST(N'2021-06-19T05:10:46.017' AS DateTime), CAST(N'2021-06-19T05:10:46.017' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (79, 46, 30046001, N'Saad S-A/C', CAST(N'2021-06-19T05:11:14.440' AS DateTime), CAST(N'2021-06-19T05:11:14.440' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (80, 46, 30046002, N'Ibrar S-A/C', CAST(N'2021-06-19T05:11:39.110' AS DateTime), CAST(N'2021-06-19T05:11:39.110' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (81, 47, 40047001, N'Local Sale', CAST(N'2021-06-19T05:12:02.867' AS DateTime), CAST(N'2021-06-19T05:12:02.867' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (82, 47, 40047002, N'OPD', CAST(N'2021-06-19T05:12:10.143' AS DateTime), CAST(N'2021-06-19T05:12:10.143' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (83, 48, 50048001, N'Medicine CGS', CAST(N'2021-06-19T05:12:44.507' AS DateTime), CAST(N'2021-06-19T05:12:44.507' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (84, 46, 30046003, N'Abdul Rehman D-A/C', CAST(N'2021-06-20T00:16:02.557' AS DateTime), CAST(N'2021-06-20T00:16:02.557' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (85, 46, 30046004, N'Dr. Usman Zafar Dar', CAST(N'2021-06-20T02:34:48.043' AS DateTime), CAST(N'2021-06-20T02:34:48.043' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (87, 44, 20044003, N'Customer C-A/C', CAST(N'2021-06-28T12:18:09.480' AS DateTime), CAST(N'2021-06-28T12:18:09.480' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (88, 46, 30046005, N'Talha S-A/C', CAST(N'2021-06-28T12:37:41.660' AS DateTime), CAST(N'2021-06-28T12:37:41.660' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (89, 44, 20044004, N'Ahmed C-A/C', CAST(N'2021-06-28T12:45:50.473' AS DateTime), CAST(N'2021-06-28T12:45:50.473' AS DateTime), 1, 1, 1, 1, 1)
INSERT [dbo].[tblCOA] ([Id], [SubAccount_Id], [Account_Code], [Account_Title], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id], [IsActive]) VALUES (90, 46, 30046006, N'Dr. Oune Zahid Dr-A/C', CAST(N'2021-06-28T12:46:52.507' AS DateTime), CAST(N'2021-06-28T12:46:52.507' AS DateTime), 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tblCOA] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCOAOpeningBalance] ON 

INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (50, 74, 0, 0, CAST(N'2021-06-19T05:09:14.830' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (51, 75, 0, 0, CAST(N'2021-06-19T05:09:49.793' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (52, 76, 0, 0, CAST(N'2021-06-19T05:10:07.537' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (53, 77, 0, 0, CAST(N'2021-06-19T05:10:26.870' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (54, 78, 0, 0, CAST(N'2021-06-19T05:10:46.017' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (55, 79, 0, 0, CAST(N'2021-06-19T05:11:14.440' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (56, 80, 0, 0, CAST(N'2021-06-19T05:11:39.110' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (57, 81, 0, 0, CAST(N'2021-06-19T05:12:02.867' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (58, 82, 0, 0, CAST(N'2021-06-19T05:12:10.143' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (59, 83, 0, 0, CAST(N'2021-06-19T05:12:44.507' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (60, 84, 0, 0, CAST(N'2021-06-20T00:16:02.557' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (61, 85, 0, 0, CAST(N'2021-06-20T02:34:48.043' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (62, 87, 0, 0, CAST(N'2021-06-28T12:18:09.480' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (63, 88, 0, 0, CAST(N'2021-06-28T12:37:41.660' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (64, 89, 0, 0, CAST(N'2021-06-28T12:45:50.473' AS DateTime), NULL, 1, NULL, 1, 1)
INSERT [dbo].[tblCOAOpeningBalance] ([Id], [COA_Id], [Debit], [Credit], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Company_Id], [Branch_Id]) VALUES (65, 90, 0, 0, CAST(N'2021-06-28T12:46:52.507' AS DateTime), NULL, 1, NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[tblCOAOpeningBalance] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCompany] ON 

INSERT [dbo].[tblCompany] ([Company_Id], [Name], [Address], [PhoneNo], [Logo], [Entry_Date], [Email], [Reporting_Title]) VALUES (1, N'Life Line Hospital GRW', N'Model Town GRW', N'0000000000', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblCompany] OFF
GO
SET IDENTITY_INSERT [dbo].[tblDocumentType] ON 

INSERT [dbo].[tblDocumentType] ([Id], [Document_Type_Name]) VALUES (1, N'Purchase')
INSERT [dbo].[tblDocumentType] ([Id], [Document_Type_Name]) VALUES (2, N'Sale')
INSERT [dbo].[tblDocumentType] ([Id], [Document_Type_Name]) VALUES (3, N'Purchase Return')
INSERT [dbo].[tblDocumentType] ([Id], [Document_Type_Name]) VALUES (4, N'Sale Return')
INSERT [dbo].[tblDocumentType] ([Id], [Document_Type_Name]) VALUES (5, N' Voucher')
INSERT [dbo].[tblDocumentType] ([Id], [Document_Type_Name]) VALUES (6, N'OPD')
SET IDENTITY_INSERT [dbo].[tblDocumentType] OFF
GO
SET IDENTITY_INSERT [dbo].[tblOPD] ON 

INSERT [dbo].[tblOPD] ([Id], [Dr_Id], [Customer_Id], [Fees], [Datetime], [Token_No], [Visited], [Day]) VALUES (25, 22, 75, 1000, CAST(N'2021-06-20T02:44:01.263' AS DateTime), 1, NULL, CAST(N'2021-06-20' AS Date))
INSERT [dbo].[tblOPD] ([Id], [Dr_Id], [Customer_Id], [Fees], [Datetime], [Token_No], [Visited], [Day]) VALUES (26, 22, 75, 1000, CAST(N'2021-06-20T02:44:59.543' AS DateTime), 2, NULL, CAST(N'2021-06-20' AS Date))
INSERT [dbo].[tblOPD] ([Id], [Dr_Id], [Customer_Id], [Fees], [Datetime], [Token_No], [Visited], [Day]) VALUES (27, 27, 76, 1000, CAST(N'2021-06-28T12:55:13.247' AS DateTime), 1, 0, CAST(N'2021-06-28' AS Date))
INSERT [dbo].[tblOPD] ([Id], [Dr_Id], [Customer_Id], [Fees], [Datetime], [Token_No], [Visited], [Day]) VALUES (29, 22, 75, 1000, CAST(N'2021-07-26T22:11:15.360' AS DateTime), 1, 0, CAST(N'2021-07-26' AS Date))
SET IDENTITY_INSERT [dbo].[tblOPD] OFF
GO
SET IDENTITY_INSERT [dbo].[tblParentAccount] ON 

INSERT [dbo].[tblParentAccount] ([Id], [Parent_Account], [Type], [Type_Name]) VALUES (1, N'Capital', 1, N'Capital')
INSERT [dbo].[tblParentAccount] ([Id], [Parent_Account], [Type], [Type_Name]) VALUES (2, N'Assets', 2, N'Assets')
INSERT [dbo].[tblParentAccount] ([Id], [Parent_Account], [Type], [Type_Name]) VALUES (3, N'Laibility', 3, N'Laibility')
INSERT [dbo].[tblParentAccount] ([Id], [Parent_Account], [Type], [Type_Name]) VALUES (4, N'Revenue', 4, N'Revenue')
INSERT [dbo].[tblParentAccount] ([Id], [Parent_Account], [Type], [Type_Name]) VALUES (5, N'Expense', 5, N'Expense')
SET IDENTITY_INSERT [dbo].[tblParentAccount] OFF
GO
SET IDENTITY_INSERT [dbo].[tblSubAccount] ON 

INSERT [dbo].[tblSubAccount] ([Id], [SubAccount_Name], [Parent_Account_Id], [Company_Id], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Branch_Id]) VALUES (43, N'Stock', 2, 1, CAST(N'2021-06-19T05:08:09.720' AS DateTime), CAST(N'2021-06-19T05:08:09.720' AS DateTime), 1, 1, 1)
INSERT [dbo].[tblSubAccount] ([Id], [SubAccount_Name], [Parent_Account_Id], [Company_Id], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Branch_Id]) VALUES (44, N'Debitors', 2, 1, CAST(N'2021-06-19T05:08:30.170' AS DateTime), CAST(N'2021-06-19T05:08:30.170' AS DateTime), 1, 1, 1)
INSERT [dbo].[tblSubAccount] ([Id], [SubAccount_Name], [Parent_Account_Id], [Company_Id], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Branch_Id]) VALUES (45, N'Cash & Bank', 2, 1, CAST(N'2021-06-19T05:08:54.237' AS DateTime), CAST(N'2021-06-19T05:08:54.237' AS DateTime), 1, 1, 1)
INSERT [dbo].[tblSubAccount] ([Id], [SubAccount_Name], [Parent_Account_Id], [Company_Id], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Branch_Id]) VALUES (46, N'Creditors', 3, 1, CAST(N'2021-06-19T05:10:57.103' AS DateTime), CAST(N'2021-06-19T05:10:57.103' AS DateTime), 1, 1, 1)
INSERT [dbo].[tblSubAccount] ([Id], [SubAccount_Name], [Parent_Account_Id], [Company_Id], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Branch_Id]) VALUES (47, N'Sales', 4, 1, CAST(N'2021-06-19T05:11:49.243' AS DateTime), CAST(N'2021-06-19T05:11:49.243' AS DateTime), 1, 1, 1)
INSERT [dbo].[tblSubAccount] ([Id], [SubAccount_Name], [Parent_Account_Id], [Company_Id], [Entry_Date], [Modify_Date], [Entry_User], [Modify_User], [Branch_Id]) VALUES (48, N'CGS', 5, 1, CAST(N'2021-06-19T05:12:31.307' AS DateTime), CAST(N'2021-06-19T05:12:31.307' AS DateTime), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tblSubAccount] OFF
GO
SET IDENTITY_INSERT [dbo].[tblSupplierCustomer] ON 

INSERT [dbo].[tblSupplierCustomer] ([Id], [Profile_Name], [Address], [Contact_No], [Reporting_Title], [GlAccount_Id], [SupplierCustomerType], [Entry_Date], [Entry_User], [Modify_User], [Modify_Date], [Company_Id], [Branch_Id], [IsActive]) VALUES (22, N'Dr Usman Zafar Dar', N'Gujranwala', N'0333-4742423', N'Dr Usman Zafar Dar', 85, N'Doctor', CAST(N'2021-06-20T02:40:29.687' AS DateTime), 1, NULL, NULL, 1, 1, 1)
INSERT [dbo].[tblSupplierCustomer] ([Id], [Profile_Name], [Address], [Contact_No], [Reporting_Title], [GlAccount_Id], [SupplierCustomerType], [Entry_Date], [Entry_User], [Modify_User], [Modify_Date], [Company_Id], [Branch_Id], [IsActive]) VALUES (23, N'Shoaib Sohail', N'Gujranwala', N'00000', N'Shoaib Sohail', 75, N'Customer', CAST(N'2021-06-20T02:43:39.687' AS DateTime), 1, NULL, NULL, 1, 1, 1)
INSERT [dbo].[tblSupplierCustomer] ([Id], [Profile_Name], [Address], [Contact_No], [Reporting_Title], [GlAccount_Id], [SupplierCustomerType], [Entry_Date], [Entry_User], [Modify_User], [Modify_Date], [Company_Id], [Branch_Id], [IsActive]) VALUES (24, N'Saad Zahid', N'Gujranwala', N'03014005752', N'Saad Zahid', 79, N'Supplier', CAST(N'2021-06-20T02:50:19.683' AS DateTime), 1, NULL, NULL, 1, 1, 1)
INSERT [dbo].[tblSupplierCustomer] ([Id], [Profile_Name], [Address], [Contact_No], [Reporting_Title], [GlAccount_Id], [SupplierCustomerType], [Entry_Date], [Entry_User], [Modify_User], [Modify_Date], [Company_Id], [Branch_Id], [IsActive]) VALUES (25, N'Talha S-A/C S-A/C', N'Lahore', N'030459494123', N'Talha S-A/C', 88, N'Supplier', CAST(N'2021-06-28T12:41:48.520' AS DateTime), 1, NULL, NULL, 1, 1, 1)
INSERT [dbo].[tblSupplierCustomer] ([Id], [Profile_Name], [Address], [Contact_No], [Reporting_Title], [GlAccount_Id], [SupplierCustomerType], [Entry_Date], [Entry_User], [Modify_User], [Modify_Date], [Company_Id], [Branch_Id], [IsActive]) VALUES (26, N'Ahmed C-A/C', N'Azam Market,Lahore', N'0301879411234', N'Ahmed C-A/C', 89, N'Customer', CAST(N'2021-06-28T12:46:11.973' AS DateTime), 1, NULL, NULL, 1, 1, 1)
INSERT [dbo].[tblSupplierCustomer] ([Id], [Profile_Name], [Address], [Contact_No], [Reporting_Title], [GlAccount_Id], [SupplierCustomerType], [Entry_Date], [Entry_User], [Modify_User], [Modify_Date], [Company_Id], [Branch_Id], [IsActive]) VALUES (27, N'Dr. Oune Zahid Dr-A/C', N'Lahore', N'000000', N'Dr. Oune Zahid', 90, N'Doctor', CAST(N'2021-06-28T12:46:52.507' AS DateTime), 1, NULL, NULL, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[tblSupplierCustomer] OFF
GO
SET IDENTITY_INSERT [dbo].[tblSystemConfigrations] ON 

INSERT [dbo].[tblSystemConfigrations] ([Id], [Configration_Name], [Configration_Value]) VALUES (7, N'Cash In Hand', N'77')
INSERT [dbo].[tblSystemConfigrations] ([Id], [Configration_Name], [Configration_Value]) VALUES (13, N'OPD', N'82')
INSERT [dbo].[tblSystemConfigrations] ([Id], [Configration_Name], [Configration_Value]) VALUES (14, N'Item Purchase A/C', N'74')
INSERT [dbo].[tblSystemConfigrations] ([Id], [Configration_Name], [Configration_Value]) VALUES (15, N'Item Sale A/C', N'81')
INSERT [dbo].[tblSystemConfigrations] ([Id], [Configration_Name], [Configration_Value]) VALUES (16, N'Item CGS A/C', N'83')
INSERT [dbo].[tblSystemConfigrations] ([Id], [Configration_Name], [Configration_Value]) VALUES (17, N'OPD Percentage', N'50')
INSERT [dbo].[tblSystemConfigrations] ([Id], [Configration_Name], [Configration_Value]) VALUES (18, N'Creditors Sub A/C', N'46')
INSERT [dbo].[tblSystemConfigrations] ([Id], [Configration_Name], [Configration_Value]) VALUES (19, N'Debitors Sub A/C', N'44')
SET IDENTITY_INSERT [dbo].[tblSystemConfigrations] OFF
GO
SET IDENTITY_INSERT [dbo].[TblUserRights] ON 

INSERT [dbo].[TblUserRights] ([Id], [UserId], [ScreenId], [RightId], [Value]) VALUES (1, 1, 1, 1, 1)
INSERT [dbo].[TblUserRights] ([Id], [UserId], [ScreenId], [RightId], [Value]) VALUES (2, 1, 1, 3, 1)
INSERT [dbo].[TblUserRights] ([Id], [UserId], [ScreenId], [RightId], [Value]) VALUES (3, 1, 2, 12, 1)
INSERT [dbo].[TblUserRights] ([Id], [UserId], [ScreenId], [RightId], [Value]) VALUES (16, 2, 14, 160, 1)
INSERT [dbo].[TblUserRights] ([Id], [UserId], [ScreenId], [RightId], [Value]) VALUES (17, 2, 1, 1, 1)
INSERT [dbo].[TblUserRights] ([Id], [UserId], [ScreenId], [RightId], [Value]) VALUES (18, 2, 2, 14, 1)
SET IDENTITY_INSERT [dbo].[TblUserRights] OFF
GO
SET IDENTITY_INSERT [dbo].[tblVoucherDetail] ON 

INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (353, 99, 75, 82, N'Amount Deduted From Customer A/C from OPD', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (354, 99, 82, 75, N'Amount Added To OPD A/C from OPD', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (355, 99, 77, 82, N'Amount Added To Cash In Hand A/C from OPD', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (356, 99, 82, 77, N'Amount Deducted from OPD A/C from OPD', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (357, 99, 77, 85, N'Amount Added To Cash in Hand DR Part A/C from OPD', 0, 500, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (358, 99, 85, 77, N'Amount Deducted from DR A/C and Added in Cash In Hand A/C from OPD', 500, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (359, 100, 75, 82, N'Amount Deduted From Customer A/C from OPD', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (360, 100, 82, 75, N'Amount Added To OPD A/C from OPD', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (361, 100, 77, 82, N'Amount Added To Cash In Hand A/C from OPD', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (362, 100, 82, 77, N'Amount Deducted from OPD A/C from OPD', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (363, 100, 77, 85, N'Amount Added To Cash in Hand DR Part A/C from OPD', 0, 500, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (364, 100, 85, 77, N'Amount Deducted from DR A/C and Added in Cash In Hand A/C from OPD', 500, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (365, 101, 85, 0, N'', 0, 500, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (366, 101, 77, 0, N'', 500, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (367, 102, 75, 0, N'', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (368, 102, 77, 0, N'', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (369, 103, 74, 79, N'Product Debit for Purchase', 160, 0, 22, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (370, 103, 79, 74, N'Supplier Credit for Purchase', 0, 160, 22, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (371, 103, 79, 77, N'Amount Added To Supplier A/C from Purchase', 0, 100, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (372, 103, 77, 79, N'Amount deducted from Cash in Hand from Purchase', 100, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (373, 104, 79, 0, N'', 0, 60, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (374, 104, 77, 0, N'', 60, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (375, 105, 74, 79, N'Product Debit for Purchase', 2000, 0, 23, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (376, 105, 79, 74, N'Supplier Credit for Purchase', 0, 2000, 23, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (377, 105, 79, 77, N'Amount Added To Supplier A/C from Purchase', 0, 1500, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (378, 105, 77, 79, N'Amount deducted from Cash in Hand from Purchase', 1500, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (379, 106, 74, 79, N'Product Debit for Purchase', 1000, 0, 22, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (380, 106, 79, 74, N'Supplier Credit for Purchase', 0, 1000, 22, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (381, 106, 79, 77, N'Received amount', 0, 500, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (382, 106, 77, 79, N'Received amount', 500, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (383, 107, 74, 79, N'Product Debit for Purchase', 200000, 0, 35, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (384, 107, 79, 74, N'Supplier Credit for Purchase', 0, 200000, 35, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (385, 107, 79, 77, N'Received amount', 0, 10000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (386, 107, 77, 79, N'Received amount', 10000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (387, 108, 76, 82, N'Amount Deduted From Customer A/C from OPD', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (388, 108, 82, 76, N'Amount Added To OPD A/C from OPD', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (389, 108, 77, 82, N'Amount Added To Cash In Hand A/C from OPD', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (390, 108, 82, 77, N'Amount Deducted from OPD A/C from OPD', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (391, 108, 77, 90, N'Amount Added To Cash in Hand DR Part A/C from OPD', 0, 500, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (392, 108, 90, 77, N'Amount Deducted from DR A/C and Added in Cash In Hand A/C from OPD', 500, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (393, 109, 75, 82, N'Amount Deduted From Customer A/C from OPD', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (394, 109, 82, 75, N'Amount Added To OPD A/C from OPD', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (395, 109, 77, 82, N'Amount Added To Cash In Hand A/C from OPD', 0, 1000, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (396, 109, 82, 77, N'Amount Deducted from OPD A/C from OPD', 1000, 0, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (397, 109, 77, 90, N'Amount Added To Cash in Hand DR Part A/C from OPD', 0, 500, NULL, N'')
INSERT [dbo].[tblVoucherDetail] ([Id], [Voucher_Head_Id], [COA_Id], [Against_COA_Id], [Comments], [DebitAmount], [CreditAmount], [Item_Id], [ChequeNo]) VALUES (398, 109, 90, 77, N'Amount Deducted from DR A/C and Added in Cash In Hand A/C from OPD', 500, 0, NULL, N'')
SET IDENTITY_INSERT [dbo].[tblVoucherDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[tblVoucherHead] ON 

INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (99, 5, 6, 25, 1001, CAST(N'2021-06-20T02:44:01.310' AS DateTime), 1000, 75, 85, 1, 1, 1, 500)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (100, 5, 6, 26, 1002, CAST(N'2021-06-20T02:44:59.553' AS DateTime), 1000, 75, 85, 1, 1, 1, 500)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (101, 5, 0, 0, 1003, CAST(N'2021-06-20T02:46:14.197' AS DateTime), 500, 0, 0, 1, 1, 1, NULL)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (102, 5, 0, 0, 1004, CAST(N'2021-06-20T02:47:24.537' AS DateTime), 1000, 0, 0, 1, 1, 1, NULL)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (103, 5, 1, 48, 1005, CAST(N'2021-06-20T02:52:38.283' AS DateTime), 160, 79, 0, 1, 1, 1, NULL)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (104, 5, 0, 0, 1006, CAST(N'2021-06-20T02:53:23.407' AS DateTime), 60, 0, 0, 1, 1, 1, NULL)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (105, 5, 1, 49, 1007, CAST(N'2021-06-20T02:55:18.310' AS DateTime), 2000, 79, 0, 1, 1, 1, NULL)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (106, 5, 1, 50, 1008, CAST(N'2021-06-28T02:12:31.840' AS DateTime), 1000, 0, 0, 1, 1, 1, NULL)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (107, 5, 1, 51, 1009, CAST(N'2021-06-28T02:17:41.140' AS DateTime), 200000, 0, 0, 1, 1, 1, NULL)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (108, 5, 6, 27, 1010, CAST(N'2021-06-28T12:55:13.290' AS DateTime), 1000, 76, 90, 1, 1, 1, 500)
INSERT [dbo].[tblVoucherHead] ([Id], [DocumentType_Id], [RefDocTypeId], [RefDocNoId], [Voucher_Code], [Voucher_Date], [Voucher_Amount], [RefrenceAccount], [AgainstAccount], [Entry_User], [Branch_Id], [Company_Id], [DoctorAmount]) VALUES (109, 5, 6, 28, 1011, CAST(N'2021-06-28T12:58:17.173' AS DateTime), 1000, 75, 90, 1, 1, 1, 500)
SET IDENTITY_INSERT [dbo].[tblVoucherHead] OFF
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_tblBranches] FOREIGN KEY([BranchId])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_tblBranches]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_tblCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_tblCompany]
GO
ALTER TABLE [dbo].[tbl_InventoryTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tbl_InventoryTransaction_tbl_Item_Allocation] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tbl_Item_Allocation] ([Id])
GO
ALTER TABLE [dbo].[tbl_InventoryTransaction] CHECK CONSTRAINT [FK_tbl_InventoryTransaction_tbl_Item_Allocation]
GO
ALTER TABLE [dbo].[tbl_InventoryTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tbl_InventoryTransaction_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tbl_InventoryTransaction] CHECK CONSTRAINT [FK_tbl_InventoryTransaction_tblCategory]
GO
ALTER TABLE [dbo].[tbl_InventoryTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tbl_InventoryTransaction_tblSupplierCustomer] FOREIGN KEY([SupplierCustomerId])
REFERENCES [dbo].[tblSupplierCustomer] ([Id])
GO
ALTER TABLE [dbo].[tbl_InventoryTransaction] CHECK CONSTRAINT [FK_tbl_InventoryTransaction_tblSupplierCustomer]
GO
ALTER TABLE [dbo].[tbl_Item_Allocation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_Allocation_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_Item_Allocation] CHECK CONSTRAINT [FK_tbl_Item_Allocation_AspNetUsers]
GO
ALTER TABLE [dbo].[tbl_Item_Allocation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_Allocation_tbl_Item_Def] FOREIGN KEY([Item_Id])
REFERENCES [dbo].[tbl_Item_Def] ([Id])
GO
ALTER TABLE [dbo].[tbl_Item_Allocation] CHECK CONSTRAINT [FK_tbl_Item_Allocation_tbl_Item_Def]
GO
ALTER TABLE [dbo].[tbl_Item_Allocation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_Allocation_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tbl_Item_Allocation] CHECK CONSTRAINT [FK_tbl_Item_Allocation_tblBranches]
GO
ALTER TABLE [dbo].[tbl_Item_Allocation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_Allocation_tblCOA] FOREIGN KEY([PurchaseAccount])
REFERENCES [dbo].[tblCOA] ([Id])
GO
ALTER TABLE [dbo].[tbl_Item_Allocation] CHECK CONSTRAINT [FK_tbl_Item_Allocation_tblCOA]
GO
ALTER TABLE [dbo].[tbl_Item_Allocation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_Allocation_tblCOA1] FOREIGN KEY([SaleAccount])
REFERENCES [dbo].[tblCOA] ([Id])
GO
ALTER TABLE [dbo].[tbl_Item_Allocation] CHECK CONSTRAINT [FK_tbl_Item_Allocation_tblCOA1]
GO
ALTER TABLE [dbo].[tbl_Item_Allocation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_Allocation_tblCOA2] FOREIGN KEY([COGSGLAC])
REFERENCES [dbo].[tblCOA] ([Id])
GO
ALTER TABLE [dbo].[tbl_Item_Allocation] CHECK CONSTRAINT [FK_tbl_Item_Allocation_tblCOA2]
GO
ALTER TABLE [dbo].[tbl_Item_Allocation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_Allocation_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tbl_Item_Allocation] CHECK CONSTRAINT [FK_tbl_Item_Allocation_tblCompany]
GO
ALTER TABLE [dbo].[tbl_Item_Def]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_Def_tblCategory] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tbl_Item_Def] CHECK CONSTRAINT [FK_tbl_Item_Def_tblCategory]
GO
ALTER TABLE [dbo].[tbl_PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseDetail_tbl_Item_Allocation] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tbl_Item_Allocation] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseDetail] CHECK CONSTRAINT [FK_tbl_PurchaseDetail_tbl_Item_Allocation]
GO
ALTER TABLE [dbo].[tbl_PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseDetail_tbl_PurchaseMaster] FOREIGN KEY([PurchaseMaster_Id])
REFERENCES [dbo].[tbl_PurchaseMaster] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseDetail] CHECK CONSTRAINT [FK_tbl_PurchaseDetail_tbl_PurchaseMaster]
GO
ALTER TABLE [dbo].[tbl_PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseDetail_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseDetail] CHECK CONSTRAINT [FK_tbl_PurchaseDetail_tblCategory]
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseMaster_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster] CHECK CONSTRAINT [FK_tbl_PurchaseMaster_AspNetUsers]
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseMaster_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster] CHECK CONSTRAINT [FK_tbl_PurchaseMaster_tblBranches]
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseMaster_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster] CHECK CONSTRAINT [FK_tbl_PurchaseMaster_tblCompany]
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseMaster_tblDocumentType1] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[tblDocumentType] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster] CHECK CONSTRAINT [FK_tbl_PurchaseMaster_tblDocumentType1]
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseMaster_tblSupplierCustomer1] FOREIGN KEY([SupplierCustomerId])
REFERENCES [dbo].[tblSupplierCustomer] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseMaster] CHECK CONSTRAINT [FK_tbl_PurchaseMaster_tblSupplierCustomer1]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnDetail_tbl_Item_Allocation] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tbl_Item_Allocation] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnDetail] CHECK CONSTRAINT [FK_tbl_PurchaseReturnDetail_tbl_Item_Allocation]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnDetail_tbl_PurchaseReturnMaster] FOREIGN KEY([PurchaseReturnMaster_Id])
REFERENCES [dbo].[tbl_PurchaseReturnMaster] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnDetail] CHECK CONSTRAINT [FK_tbl_PurchaseReturnDetail_tbl_PurchaseReturnMaster]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnDetail_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnDetail] CHECK CONSTRAINT [FK_tbl_PurchaseReturnDetail_tblCategory]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnMaster_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster] CHECK CONSTRAINT [FK_tbl_PurchaseReturnMaster_AspNetUsers]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnMaster_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster] CHECK CONSTRAINT [FK_tbl_PurchaseReturnMaster_tblBranches]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnMaster_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster] CHECK CONSTRAINT [FK_tbl_PurchaseReturnMaster_tblCompany]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnMaster_tblDocumentType] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[tblDocumentType] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster] CHECK CONSTRAINT [FK_tbl_PurchaseReturnMaster_tblDocumentType]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnMaster_tblSupplierCustomer] FOREIGN KEY([SupplierCustomerId])
REFERENCES [dbo].[tblSupplierCustomer] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnMaster] CHECK CONSTRAINT [FK_tbl_PurchaseReturnMaster_tblSupplierCustomer]
GO
ALTER TABLE [dbo].[tbl_SaleDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleDetail_tbl_Item_Allocation] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tbl_Item_Allocation] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleDetail] CHECK CONSTRAINT [FK_tbl_SaleDetail_tbl_Item_Allocation]
GO
ALTER TABLE [dbo].[tbl_SaleDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleDetail_tbl_SaleMaster] FOREIGN KEY([SaleMaster_Id])
REFERENCES [dbo].[tbl_SaleMaster] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleDetail] CHECK CONSTRAINT [FK_tbl_SaleDetail_tbl_SaleMaster]
GO
ALTER TABLE [dbo].[tbl_SaleDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleDetail_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleDetail] CHECK CONSTRAINT [FK_tbl_SaleDetail_tblCategory]
GO
ALTER TABLE [dbo].[tbl_SaleMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleMaster_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleMaster] CHECK CONSTRAINT [FK_tbl_SaleMaster_AspNetUsers]
GO
ALTER TABLE [dbo].[tbl_SaleMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleMaster_tbl_SaleMaster] FOREIGN KEY([Id])
REFERENCES [dbo].[tbl_SaleMaster] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleMaster] CHECK CONSTRAINT [FK_tbl_SaleMaster_tbl_SaleMaster]
GO
ALTER TABLE [dbo].[tbl_SaleMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleMaster_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleMaster] CHECK CONSTRAINT [FK_tbl_SaleMaster_tblBranches]
GO
ALTER TABLE [dbo].[tbl_SaleMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleMaster_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tbl_SaleMaster] CHECK CONSTRAINT [FK_tbl_SaleMaster_tblCompany]
GO
ALTER TABLE [dbo].[tbl_SaleMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleMaster_tblDocumentType] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[tblDocumentType] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleMaster] CHECK CONSTRAINT [FK_tbl_SaleMaster_tblDocumentType]
GO
ALTER TABLE [dbo].[tbl_SaleMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleMaster_tblSupplierCustomer] FOREIGN KEY([SupplierCustomerId])
REFERENCES [dbo].[tblSupplierCustomer] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleMaster] CHECK CONSTRAINT [FK_tbl_SaleMaster_tblSupplierCustomer]
GO
ALTER TABLE [dbo].[tbl_SaleReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnDetail_tbl_Item_Allocation] FOREIGN KEY([ItemId])
REFERENCES [dbo].[tbl_Item_Allocation] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnDetail] CHECK CONSTRAINT [FK_tbl_SaleReturnDetail_tbl_Item_Allocation]
GO
ALTER TABLE [dbo].[tbl_SaleReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnDetail_tbl_SaleReturnMaster] FOREIGN KEY([SaleReturnMaster_Id])
REFERENCES [dbo].[tbl_SaleReturnMaster] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnDetail] CHECK CONSTRAINT [FK_tbl_SaleReturnDetail_tbl_SaleReturnMaster]
GO
ALTER TABLE [dbo].[tbl_SaleReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnDetail_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnDetail] CHECK CONSTRAINT [FK_tbl_SaleReturnDetail_tblCategory]
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnMaster_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster] CHECK CONSTRAINT [FK_tbl_SaleReturnMaster_AspNetUsers]
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnMaster_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster] CHECK CONSTRAINT [FK_tbl_SaleReturnMaster_tblBranches]
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnMaster_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster] CHECK CONSTRAINT [FK_tbl_SaleReturnMaster_tblCompany]
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnMaster_tblDocumentType] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[tblDocumentType] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster] CHECK CONSTRAINT [FK_tbl_SaleReturnMaster_tblDocumentType]
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnMaster_tblSupplierCustomer] FOREIGN KEY([SupplierCustomerId])
REFERENCES [dbo].[tblSupplierCustomer] ([Id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnMaster] CHECK CONSTRAINT [FK_tbl_SaleReturnMaster_tblSupplierCustomer]
GO
ALTER TABLE [dbo].[tblActivityLogs]  WITH CHECK ADD  CONSTRAINT [FK_tblActivityLogs_AspNetUsers] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblActivityLogs] CHECK CONSTRAINT [FK_tblActivityLogs_AspNetUsers]
GO
ALTER TABLE [dbo].[tblBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblBranches_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblBranches] CHECK CONSTRAINT [FK_tblBranches_AspNetUsers]
GO
ALTER TABLE [dbo].[tblBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblBranches_AspNetUsers1] FOREIGN KEY([Modify_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblBranches] CHECK CONSTRAINT [FK_tblBranches_AspNetUsers1]
GO
ALTER TABLE [dbo].[tblBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblBranches_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tblBranches] CHECK CONSTRAINT [FK_tblBranches_tblCompany]
GO
ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblCategory_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblCategory] CHECK CONSTRAINT [FK_tblCategory_AspNetUsers]
GO
ALTER TABLE [dbo].[tblCOA]  WITH CHECK ADD  CONSTRAINT [FK_tblCOA_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblCOA] CHECK CONSTRAINT [FK_tblCOA_AspNetUsers]
GO
ALTER TABLE [dbo].[tblCOA]  WITH CHECK ADD  CONSTRAINT [FK_tblCOA_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tblCOA] CHECK CONSTRAINT [FK_tblCOA_tblBranches]
GO
ALTER TABLE [dbo].[tblCOA]  WITH CHECK ADD  CONSTRAINT [FK_tblCOA_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tblCOA] CHECK CONSTRAINT [FK_tblCOA_tblCompany]
GO
ALTER TABLE [dbo].[tblCOA]  WITH CHECK ADD  CONSTRAINT [FK_tblCOA_tblSubAccount] FOREIGN KEY([SubAccount_Id])
REFERENCES [dbo].[tblSubAccount] ([Id])
GO
ALTER TABLE [dbo].[tblCOA] CHECK CONSTRAINT [FK_tblCOA_tblSubAccount]
GO
ALTER TABLE [dbo].[tblCOAOpeningBalance]  WITH CHECK ADD  CONSTRAINT [FK_tblCOAOpeningBalance_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblCOAOpeningBalance] CHECK CONSTRAINT [FK_tblCOAOpeningBalance_AspNetUsers]
GO
ALTER TABLE [dbo].[tblCOAOpeningBalance]  WITH CHECK ADD  CONSTRAINT [FK_tblCOAOpeningBalance_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tblCOAOpeningBalance] CHECK CONSTRAINT [FK_tblCOAOpeningBalance_tblBranches]
GO
ALTER TABLE [dbo].[tblCOAOpeningBalance]  WITH CHECK ADD  CONSTRAINT [FK_tblCOAOpeningBalance_tblCOA] FOREIGN KEY([COA_Id])
REFERENCES [dbo].[tblCOA] ([Id])
GO
ALTER TABLE [dbo].[tblCOAOpeningBalance] CHECK CONSTRAINT [FK_tblCOAOpeningBalance_tblCOA]
GO
ALTER TABLE [dbo].[tblCOAOpeningBalance]  WITH CHECK ADD  CONSTRAINT [FK_tblCOAOpeningBalance_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tblCOAOpeningBalance] CHECK CONSTRAINT [FK_tblCOAOpeningBalance_tblCompany]
GO
ALTER TABLE [dbo].[tblOPD]  WITH CHECK ADD  CONSTRAINT [FK_tblOPD_tblCOA] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[tblCOA] ([Id])
GO
ALTER TABLE [dbo].[tblOPD] CHECK CONSTRAINT [FK_tblOPD_tblCOA]
GO
ALTER TABLE [dbo].[tblOPD]  WITH CHECK ADD  CONSTRAINT [FK_tblOPD_tblSupplierCustomer] FOREIGN KEY([Dr_Id])
REFERENCES [dbo].[tblSupplierCustomer] ([Id])
GO
ALTER TABLE [dbo].[tblOPD] CHECK CONSTRAINT [FK_tblOPD_tblSupplierCustomer]
GO
ALTER TABLE [dbo].[tblSubAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblSubAccount_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblSubAccount] CHECK CONSTRAINT [FK_tblSubAccount_AspNetUsers]
GO
ALTER TABLE [dbo].[tblSubAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblSubAccount_AspNetUsers1] FOREIGN KEY([Modify_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblSubAccount] CHECK CONSTRAINT [FK_tblSubAccount_AspNetUsers1]
GO
ALTER TABLE [dbo].[tblSubAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblSubAccount_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tblSubAccount] CHECK CONSTRAINT [FK_tblSubAccount_tblBranches]
GO
ALTER TABLE [dbo].[tblSubAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblSubAccount_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tblSubAccount] CHECK CONSTRAINT [FK_tblSubAccount_tblCompany]
GO
ALTER TABLE [dbo].[tblSubAccount]  WITH CHECK ADD  CONSTRAINT [FK_tblSubAccount_tblParentAccount] FOREIGN KEY([Parent_Account_Id])
REFERENCES [dbo].[tblParentAccount] ([Id])
GO
ALTER TABLE [dbo].[tblSubAccount] CHECK CONSTRAINT [FK_tblSubAccount_tblParentAccount]
GO
ALTER TABLE [dbo].[tblSupplierCustomer]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierCustomer_AspNetUsers] FOREIGN KEY([Entry_User])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tblSupplierCustomer] CHECK CONSTRAINT [FK_tblSupplierCustomer_AspNetUsers]
GO
ALTER TABLE [dbo].[tblSupplierCustomer]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierCustomer_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tblSupplierCustomer] CHECK CONSTRAINT [FK_tblSupplierCustomer_tblBranches]
GO
ALTER TABLE [dbo].[tblSupplierCustomer]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierCustomer_tblCOA] FOREIGN KEY([GlAccount_Id])
REFERENCES [dbo].[tblCOA] ([Id])
GO
ALTER TABLE [dbo].[tblSupplierCustomer] CHECK CONSTRAINT [FK_tblSupplierCustomer_tblCOA]
GO
ALTER TABLE [dbo].[tblSupplierCustomer]  WITH CHECK ADD  CONSTRAINT [FK_tblSupplierCustomer_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tblSupplierCustomer] CHECK CONSTRAINT [FK_tblSupplierCustomer_tblCompany]
GO
ALTER TABLE [dbo].[tblVoucherDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblVoucherDetail_tblVoucherHead] FOREIGN KEY([Voucher_Head_Id])
REFERENCES [dbo].[tblVoucherHead] ([Id])
GO
ALTER TABLE [dbo].[tblVoucherDetail] CHECK CONSTRAINT [FK_tblVoucherDetail_tblVoucherHead]
GO
ALTER TABLE [dbo].[tblVoucherHead]  WITH CHECK ADD  CONSTRAINT [FK_tblVoucherHead_tblBranches] FOREIGN KEY([Branch_Id])
REFERENCES [dbo].[tblBranches] ([Id])
GO
ALTER TABLE [dbo].[tblVoucherHead] CHECK CONSTRAINT [FK_tblVoucherHead_tblBranches]
GO
ALTER TABLE [dbo].[tblVoucherHead]  WITH CHECK ADD  CONSTRAINT [FK_tblVoucherHead_tblCompany] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[tblCompany] ([Company_Id])
GO
ALTER TABLE [dbo].[tblVoucherHead] CHECK CONSTRAINT [FK_tblVoucherHead_tblCompany]
GO
ALTER TABLE [dbo].[tblVoucherHead]  WITH CHECK ADD  CONSTRAINT [FK_tblVoucherHead_tblDocumentType] FOREIGN KEY([DocumentType_Id])
REFERENCES [dbo].[tblDocumentType] ([Id])
GO
ALTER TABLE [dbo].[tblVoucherHead] CHECK CONSTRAINT [FK_tblVoucherHead_tblDocumentType]
GO
/****** Object:  StoredProcedure [dbo].[GetExpiryWiseProductForSale]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetExpiryWiseProductForSale]
@itemId int
as
begin
select sum(QtyIn)-sum(QtyOut) as AvailableQty,ExpiryDate,ItemId from tbl_InventoryTransaction where ItemId = @itemId
group by ExpiryDate,ItemId
having (sum(QtyIn)-sum(QtyOut)) > 0
order by ExpiryDate
end
GO
/****** Object:  StoredProcedure [dbo].[GetReminingAmounts]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetReminingAmounts]
@COA_Id int = null
as
begin
select COA.Id as COAId,Reporting_Title as Title, SupplierCustomerType as Type, ISNULL(TotalReceivebles.TotalReceivebles,0) as TotalReceivebles,
ISNULL(Received.Received,0) as Received,ISNULL(TotaPayables.TotaPayables,0) as TotaPayables,ISNULL(Paid.Paid,0) as Paid,
(ISNULL(TotalReceivebles.TotalReceivebles,0)-ISNULL(Received.Received,0)) as PendingReceiveables,
(ISNULL(TotaPayables.TotaPayables,0)-ISNULL(Paid.Paid,0)) as PendingPayable,
((ISNULL(TotalReceivebles.TotalReceivebles,0)-ISNULL(Received.Received,0))-(ISNULL(TotaPayables.TotaPayables,0)-ISNULL(Paid.Paid,0))) as Remaining
from tblSupplierCustomer SC
inner join tblCOA COA on COA.Id = SC.GlAccount_Id
left outer join(
select sum(VH.Voucher_Amount) as TotalReceivebles, RefrenceAccount as COA from tblVoucherHead VH 
where  ((@COA_Id is null) or (RefrenceAccount = @COA_Id)) and VH.RefDocTypeId in (2,3,0,6)
group by RefrenceAccount
)TotalReceivebles on TotalReceivebles.COA = COA.Id
left outer join (
select * from (
select sum(VD.DebitAmount) as Received,COA_Id as COA from tblVoucherDetail VD 
inner join tblVoucherHead VH on VH.Id = VD.Voucher_Head_Id
where VH.RefDocTypeId in (2,3,0,6) and ((@COA_Id is null) or (COA_Id = @COA_Id)) and VD.Item_Id is null
group by COA_Id
)a where COA <> 0 )Received on Received.COA = COA.Id  
left outer join(
select sum(VH.Voucher_Amount) as TotaPayables, RefrenceAccount as COA from tblVoucherHead VH 
where  ((@COA_Id is null) or (RefrenceAccount = @COA_Id))  and VH.RefDocTypeId in (1,4,0) 
group by RefrenceAccount
)TotaPayables on TotaPayables.COA = COA.Id
left outer join (
select * from (
select sum(VD.CreditAmount) as Paid ,COA_Id as COA from tblVoucherDetail VD 
inner join tblVoucherHead VH on VH.Id = VD.Voucher_Head_Id
where VH.RefDocTypeId in (1,4,0) and ((@COA_Id is null) or (COA_Id = @COA_Id)) and VD.Item_Id is null
group by COA_Id
)a where COA <> 0
)Paid on Paid.COA = COA.Id
where ((@COA_Id is null) or (COA.Id = @COA_Id)) and SC.SupplierCustomerType <> 'Doctor'
end


GO
/****** Object:  StoredProcedure [dbo].[GetReminingAmountsForDoctor]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetReminingAmountsForDoctor]
@COA_Id int = null
as
begin
select COA.Id as COAId,Reporting_Title as Title, SupplierCustomerType as Type,
ISNULL(TotaPayables.Payables,0) as TotaPayables, ISNULL(Paid.Paid,0) as Paid,(ISNULL(TotaPayables.Payables,0) - ISNULL(Paid.Paid,0)) as Pending
from tblSupplierCustomer SC
inner join tblCOA COA on COA.Id = SC.GlAccount_Id
left outer join(
select * from (
select sum(VD.DebitAmount) as Payables ,COA_Id as COA from tblVoucherDetail VD 
inner join tblVoucherHead VH on VH.Id = VD.Voucher_Head_Id
where VH.RefDocTypeId in (6) and  ((@COA_Id is null) or (COA_Id = @COA_Id)) and VD.Item_Id is null
group by COA_Id
)a where COA <> 0
--select sum(VH.DoctorAmount) as TotaPayables, AgainstAccount as COA from tblVoucherHead VH 
--where  ((@COA_Id is null) or (AgainstAccount = @COA_Id)) and VH.RefDocTypeId in (6) 
--group by AgainstAccount
)TotaPayables on TotaPayables.COA = COA.Id
left outer join (
select * from (
select sum(VD.CreditAmount) as Paid ,COA_Id as COA from tblVoucherDetail VD 
inner join tblVoucherHead VH on VH.Id = VD.Voucher_Head_Id
where VH.RefDocTypeId in (0) and  ((@COA_Id is null) or (COA_Id = @COA_Id)) and VD.Item_Id is null
group by COA_Id
)a where COA <> 0
)Paid on Paid.COA = COA.Id
where ((@COA_Id is null) or (COA.Id = @COA_Id)) and SC.SupplierCustomerType = 'Doctor'
end


GO
/****** Object:  StoredProcedure [dbo].[ItemWiseRevenue]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ItemWiseRevenue]
@ItemId int = null
as
begin
select DEF.Id as ItemId, AL.Id as ItemCOAId,DEF.Item_Name as ItemName,DEF.PackQty,
ISNULL(Purchase.Purchase ,0) as Purchase,ISNULL(PurchaseReturn.PurchaseReturn ,0) as PurchaseReturn,
ISNULL(Sale.Sale ,0) as Sale,ISNULL(SaleReturn.SaleReturn ,0) as SaleReturn,
(ISNULL(Sale.Sale ,0)-ISNULL(SaleReturn.SaleReturn ,0))-(ISNULL(Purchase.Purchase ,0)-ISNULL(PurchaseReturn.PurchaseReturn ,0)) as ItemRevenue
from tbl_Item_Def DEF 
inner join tbl_Item_Allocation AL on AL.Item_Id = DEF.Id
left outer join (
select sum(DebitAmount) as Purchase,Item_Id from tblVoucherDetail VD
inner join tblVoucherHead VH on VD.Voucher_Head_Id = VH.Id
where Item_Id is not null and ((@ItemId is null) or (Item_Id = @ItemId)) and COA_Id = 74 and VH.RefDocTypeId in (1,4)
group by Item_Id
) Purchase on Purchase.Item_Id = AL.Id
left outer join (
select sum(DebitAmount) as PurchaseReturn,Item_Id from tblVoucherDetail VD
inner join tblVoucherHead VH on VD.Voucher_Head_Id = VH.Id
where Item_Id is not null and ((@ItemId is null) or (Item_Id = @ItemId))and Against_COA_Id = 74 and VH.RefDocTypeId in (2,3)
group by Item_Id
) PurchaseReturn on PurchaseReturn.Item_Id = AL.Id
left outer join (
select sum(DebitAmount)  as Sale,Item_Id from tblVoucherDetail VD
inner join tblVoucherHead VH on VD.Voucher_Head_Id = VH.Id
where Item_Id is not null and ((@ItemId is null) or (Item_Id = @ItemId)) and Against_COA_Id = 81 and VH.RefDocTypeId in (2,3)
group by Item_Id
) Sale on Sale.Item_Id = AL.Id
left outer join (
select sum(DebitAmount) as SaleReturn,Item_Id from tblVoucherDetail VD
inner join tblVoucherHead VH on VD.Voucher_Head_Id = VH.Id
where Item_Id is not null and ((@ItemId is null) or (Item_Id = @ItemId)) and COA_Id = 81 and VH.RefDocTypeId in (1,4)
group by Item_Id
) SaleReturn on SaleReturn.Item_Id = AL.Id
where ((@ItemId is null) or ( AL.Id  = @ItemId))
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetUserRights_UserId]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--       Proc_GetUserRights_UserId '2','frmDefineCategory','ShopKeeper'
CREATE proc [dbo].[Proc_GetUserRights_UserId] 
@UserId int = NULL,
@ScreenName nvarchar(50) = NULL,
@Role nvarchar(250) = null
As 
Begin

if(@Role = 'Admin' or @Role = 'Administrator')
select ScreenDefinition.ScreenId As ScreenID,ScreenDefinition.ScreenName,ScreenAlias,ScreenRight.ScreenId As RightsID,ScreenRight.ScreenRightName,1 as Value from ScreenRight
left outer join ScreenDefinition on ScreenDefinition.ScreenId=ScreenRight.ScreenId
left outer join (select ScreenId,RightId,Value from  tblUserRights where UserId = @UserId) UR on UR.ScreenId = ScreenDefinition.ScreenId and UR.RightId = ScreenRight.ScreenRightId
where ScreenDefinition.ScreenName = @ScreenName
else
select ScreenDefinition.ScreenId As ScreenID,ScreenDefinition.ScreenName,ScreenAlias,ScreenRight.ScreenRightId As RightsID,ScreenRight.ScreenRightName,
case when Ur.Value ='true' then 1 else 0 ENd as Value from ScreenRight

left outer join ScreenDefinition on ScreenDefinition.ScreenId=ScreenRight.ScreenId
left outer join (select ScreenId,RightId,Value from  tblUserRights where UserId = @UserId) UR on UR.ScreenId = ScreenDefinition.ScreenId and UR.RightId = ScreenRight.ScreenRightId
where ScreenDefinition.ScreenName = @ScreenName
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_Payables_Rpt]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--																	[dbo].[Proc_Payables_Rpt] 4,4,4,'2018-12-08','2019-12-08'
create Proc [dbo].[Proc_Payables_Rpt]
@OrganizationId Int, @CompanyId Int, @FinancialYearId Int, @VoucherDateF date, @VoucherDateT date
As

----------------------------------------------
----DEBUG CODE PLEASE DON'T REMOVE THIS
----------------------------------------------
--	Exec [dbo].[Proc_Payables_Rpt] 1,1,1,'2015/01/01', '2018/01/01'
--DECLARE @OrganizationId Int =1
--DECLARE @CompanyId Int = 1
--DECLARE @FinancialYearId Int =1
--DECLARE @VoucherDateF date = '2017-07-01 00:00:00.000'
--DECLARE @VoucherDateT date ='2018-07-01 00:00:00.000'

------------------------------------------


Begin
Select 
AccountId, AccountCode, AccountTitle, AccountClass, AccountTypeId, AccountGroup, Sum(ObDebit) as ObDebit, Sum(ObCredit) as ObCredit,  sum(CurrDebit) as CurrDebit, sum(CurrCredit) as CurrCredit, 
 case When Sum(ObDebit) - Sum(ObCredit) + sum(CurrDebit) - sum(CurrCredit) > 0 then Sum(ObDebit) - Sum(ObCredit) + sum(CurrDebit) - sum(CurrCredit) Else 0 end ClDebit, 
  case When Sum(ObDebit) - Sum(ObCredit) + sum(CurrDebit) - sum(CurrCredit) < 0 then ABS(Sum(ObDebit) - Sum(ObCredit) + sum(CurrDebit) - sum(CurrCredit)) Else 0 end ClCredit, 
 OrganizationId, CompanyId, FinancialYearId 
 From (
			Select AccountId, AccountCode, AccountTitle, AccountClass, AccountTypeId, AccountGroup, 
			case When Sum(YearObDebit) - Sum(YearObCredit) > 0 then Sum(YearObDebit) - Sum(YearObCredit) Else 0 end ObDebit, 
			case When Sum(YearObDebit) - Sum(YearObCredit) < 0 then ABS(Sum(YearObDebit) - Sum(YearObCredit)) Else 0 end ObCredit, 
			 0 as CurrDebit, 0 as CurrCredit, 0 As ClDebit, 0 as Clcredit, OrganizationId, CompanyId, FinancialYearId 
			 From (
					SELECT Ob.ChartOfAccountId as AccountId, Coa.AccountCode, Coa.AccountTitle, Coa.AccountClass, Coa.AccountTypeId, Coa.AccountGroup, Ob.YearObDebit as YearObDebit, Ob.YearObCredit as YearObCredit, Ob.OrganizationId, Ob.CompanyId, Ob.FinancialYearId FROM V_AccountsOpeningBalances AS Ob INNER JOIN V_ChartOfAccount AS Coa ON Ob.ChartOfAccountId = Coa.Id 
						Where Ob.OrganizationId= @OrganizationId 
						and Ob.CompanyId = @CompanyId 
						and  Ob.FinancialYearId = @FinancialYearId 
						GROUP BY Ob.Id, Ob.ChartOfAccountId, Ob.YearObDebit, Ob.YearObCredit, 
						Ob.CompanyId, Ob.FinancialYearId, Ob.OrganizationId, Coa.AccountCode, Coa.AccountTitle, Coa.AccountClass, Coa.AccountTypeId, Coa.AccountGroup
					Union All 
					SELECT Vd.AccountId, Coa.AccountCode, Coa.AccountTitle, Coa.AccountClass, Coa.AccountTypeId, Coa.AccountGroup, 
						case When Sum(Vd.DebitAmount) - Sum(Vd.CreditAmount) > 0 then Sum(Vd.DebitAmount) - Sum(Vd.CreditAmount) Else 0 end DebitAmount, 
						case When Sum(Vd.DebitAmount) - Sum(Vd.CreditAmount) < 0 then ABS(Sum(Vd.DebitAmount) - Sum(Vd.CreditAmount)) Else 0 end CreditAmount, 
						VH.OrganizationId, VH.CompanyId, VH.FinancialYearId FROM V_VoucherHead AS VH INNER JOIN V_VoucherDetail AS Vd ON VH.Id = Vd.VoucherHeadId 
						INNER JOIN  V_ChartOfAccount AS Coa ON Vd.AccountId = Coa.Id 
						Where VH.OrganizationId= @OrganizationId 
						and VH.CompanyId = @CompanyId 
						and  VH.FinancialYearId = @FinancialYearId 
						and Vh.VoucherDate < @VoucherDateF 
						GROUP BY Vd.AccountId, VH.OrganizationId, VH.CompanyId, VH.FinancialYearId, Coa.AccountCode, 
						Coa.AccountTitle, Coa.AccountClass, Coa.AccountTypeId, Coa.AccountGroup, Vh.VoucherDate
				  ) A Group By AccountId, AccountCode, AccountTitle, AccountClass, AccountTypeId, AccountGroup, OrganizationId, CompanyId, FinancialYearId 

			Union All SELECT Vd.AccountId, Coa.AccountCode, Coa.AccountTitle, Coa.AccountClass, Coa.AccountTypeId, Coa.AccountGroup, 0, 0, SUM(Vd.DebitAmount) AS DebitAmount, SUM(Vd.CreditAmount) AS CreditAmount, 0, 0, VH.OrganizationId, VH.CompanyId, VH.FinancialYearId FROM V_VoucherHead AS VH INNER JOIN V_VoucherDetail AS Vd ON VH.Id = Vd.VoucherHeadId INNER JOIN  V_ChartOfAccount AS Coa ON Vd.AccountId = Coa.Id 
				Where VH.OrganizationId= @OrganizationId and VH.CompanyId = @CompanyId and  VH.FinancialYearId = @FinancialYearId and VoucherDate >= @VoucherDateF and Vh.VoucherDate <= @VoucherDateT GROUP BY Vd.AccountId, VH.OrganizationId, VH.CompanyId, VH.FinancialYearId, Coa.AccountCode, Coa.AccountTitle, Coa.AccountClass, Coa.AccountTypeId, Coa.AccountGroup, Vh.VoucherDate
) B  Group By AccountId, AccountCode, AccountTitle, AccountClass, AccountTypeId, AccountGroup, OrganizationId, CompanyId, FinancialYearId
	 --Having (Sum(B.ObDebit) - Sum(B.ObCredit) + sum(B.CurrDebit) - sum(B.CurrCredit)) < 0  and B.AccountTypeId  = 3 -- Receivables & Payables
	 Having ( Sum(ObDebit) - Sum(ObCredit) + sum(CurrDebit) - sum(CurrCredit) ) < 0  and B.AccountTypeId  = 3 -- Receivables & Payables
End





GO
/****** Object:  StoredProcedure [dbo].[Proc_tblUserRights_Insert]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Proc_tblUserRights_Insert]
(
	@UserId INT,
	@ScreenId INT,
	@RightId INT,
	@Value BIT
)

AS

BEGIN

INSERT INTO [dbo].[tblUserRights]
(
	[UserId],
	[ScreenId],
	[RightId],
	[Value]
)
VALUES
(
	@UserId,
	@ScreenId,
	@RightId,
	@Value
)



End
GO
/****** Object:  StoredProcedure [dbo].[Proc_tblUserRights_UserId]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_tblUserRights_UserId]
@UserId int = null
As 
Begin

select ScreenDefinition.ScreenId As ScreenID,ScreenDefinition.ScreenName,ScreenAlias,ScreenRight.ScreenRightId As RightsID,
ScreenRight.ScreenRightName,isnull(UR.Value,0) as Value from screenRight 
left outer join ScreenDefinition on ScreenDefinition.ScreenId =screenRight.ScreenId
left outer join (select ScreenId,RightId,Value from  tblUserRights where UserId = @UserId) UR on UR.ScreenId = ScreenDefinition.ScreenId 
and UR.RightId = screenRight.ScreenRightId

--Left Outer join 
--select AppModules.Id As ModuleID,AppModules.ModuleDescription,ScreenDefinition.Id As ScreenID,ScreenDefinition.ScreenName,ScreenAlias,ScreenRights.Id As RightsID,
--ScreenRights.RightName,isnull(UR.Value,0) as Value from ScreenRights
--left outer join ScreenDefinition on ScreenDefinition.Id=ScreenRights.ScreenID
--left outer join AppModules on ScreenDefinition.ModuleId=AppModules.Id
--left outer join (select ScreenId,RightId,Value from  tblUserRights where UserId = @UserId) UR on UR.ScreenId = ScreenDefinition.Id and UR.RightId = ScreenRights.Id


End








GO
/****** Object:  StoredProcedure [dbo].[Proc_UserLogin]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--  Proc_UserLogin 'admin','123'
CREATE Proc [dbo].[Proc_UserLogin]
@Username nvarchar(100),
@Password nvarchar(50)
AS
begin

SELECT        u.EntryUser, u.IsActive, u.Role_Id, u.BranchId, u.CompanyId, u.LastName, u.FirstName, u.Address, u.UserName, u.PhoneNumber, u.Password, u.Id, r.Name
FROM            AspNetUsers AS u INNER JOIN
                         AspNetRoles AS r ON u.Role_Id = r.Id
where u.UserName=@Username And u.Password=@Password And u.IsActive=1


end
GO
/****** Object:  StoredProcedure [dbo].[Proc_UserRights_DeleteByUserID]    Script Date: 7/26/2021 10:40:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Proc_UserRights_DeleteByUserID]
(
	@UserId int = null
)

AS

BEGIN
delete from tblUserRights where UserId = @UserId

SELECT SCOPE_IDENTITY()
END
GO
USE [master]
GO
ALTER DATABASE [dbHostiptalERP] SET  READ_WRITE 
GO
