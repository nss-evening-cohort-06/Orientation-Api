USE [master]
GO
DROP DATABASE [SNQHM_bangazoncli_db]
GO
/****** Object:  Database [SNQHM_bangazoncli_db]    Script Date: 4/23/2018 8:03:22 PM ******/
CREATE DATABASE [SNQHM_bangazoncli_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SNQHM_bangazoncli_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SNQHM_bangazoncli_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SNQHM_bangazoncli_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SNQHM_bangazoncli_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SNQHM_bangazoncli_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET RECOVERY FULL 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET  MULTI_USER 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET QUERY_STORE = OFF
GO
USE [SNQHM_bangazoncli_db]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SNQHM_bangazoncli_db]
GO
/****** Object:  Table [dbo].[Computer]    Script Date: 4/23/2018 8:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computer](
	[ComputerID] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [varchar](50) NULL,
	[Make] [varchar](50) NULL,
	[PurchaseDate] [datetime] NULL,
 CONSTRAINT [PK_Computer] PRIMARY KEY CLUSTERED 
(
	[ComputerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/23/2018 8:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[City] [varchar](30) NOT NULL,
	[State] [char](2) NOT NULL,
	[ZipCode] [int] NOT NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/23/2018 8:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Budget] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/23/2018 8:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DepartmentID] [int] NULL,
	[StartDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeComputer]    Script Date: 4/23/2018 8:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeComputer](
	[EmployeeComputerID] [int] IDENTITY(1,1) NOT NULL,
	[AssignedDate] [datetime] NULL,
	[ReturnedDate] [datetime] NULL,
	[EmployeeID] [int] NULL,
	[ComputerID] [int] NULL,
 CONSTRAINT [PK_EmployeeComputer] PRIMARY KEY CLUSTERED 
(
	[EmployeeComputerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTraining]    Script Date: 4/23/2018 8:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTraining](
	[EmployeeTrainingID] [int] NOT NULL,
	[EmployeeID] [int] NULL,
	[TrainingProgramID] [int] NULL,
 CONSTRAINT [PK_EmployeeTraining] PRIMARY KEY CLUSTERED 
(
	[EmployeeTrainingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/23/2018 8:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Paid] [bit] NOT NULL,
	[Purchased] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 4/23/2018 8:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 4/23/2018 8:03:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType] [varchar](30) NOT NULL,
	[PaymentAccountNum] [int] NOT NULL,
	[CusID] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/23/2018 8:03:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Price] [money] NOT NULL,
	[Owner] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[OutOfStock] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingProgram]    Script Date: 4/23/2018 8:03:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingProgram](
	[TrainingProgramID] [int] NOT NULL,
	[MaxAttendees] [int] NULL,
	[TrainingTitle] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_TrainingProgram] PRIMARY KEY CLUSTERED 
(
	[TrainingProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IFK_OrderCustomerID]    Script Date: 4/23/2018 8:03:23 PM ******/
CREATE NONCLUSTERED INDEX [IFK_OrderCustomerID] ON [dbo].[Customer]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_PaymentCusID]    Script Date: 4/23/2018 8:03:23 PM ******/
CREATE NONCLUSTERED INDEX [IFK_PaymentCusID] ON [dbo].[Customer]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_ProductOwnder]    Script Date: 4/23/2018 8:03:23 PM ******/
CREATE NONCLUSTERED INDEX [IFK_ProductOwnder] ON [dbo].[Customer]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_OrderOrderID]    Script Date: 4/23/2018 8:03:23 PM ******/
CREATE NONCLUSTERED INDEX [IFK_OrderOrderID] ON [dbo].[Order]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_OrderPaymentID]    Script Date: 4/23/2018 8:03:23 PM ******/
CREATE NONCLUSTERED INDEX [IFK_OrderPaymentID] ON [dbo].[Payment]
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IFK_OrderItemProductID]    Script Date: 4/23/2018 8:03:23 PM ******/
CREATE NONCLUSTERED INDEX [IFK_OrderItemProductID] ON [dbo].[Product]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_OutOfStock]  DEFAULT ((0)) FOR [OutOfStock]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_DepartmentID]
GO
ALTER TABLE [dbo].[EmployeeComputer]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeComputer_EmployeeComputer1] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[EmployeeComputer] ([EmployeeComputerID])
GO
ALTER TABLE [dbo].[EmployeeComputer] CHECK CONSTRAINT [FK_EmployeeComputer_EmployeeComputer1]
GO
ALTER TABLE [dbo].[EmployeeComputer]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeComputer_EmployeeComputer2] FOREIGN KEY([ComputerID])
REFERENCES [dbo].[EmployeeComputer] ([EmployeeComputerID])
GO
ALTER TABLE [dbo].[EmployeeComputer] CHECK CONSTRAINT [FK_EmployeeComputer_EmployeeComputer2]
GO
ALTER TABLE [dbo].[EmployeeTraining]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EmployeeTraining] CHECK CONSTRAINT [FK_EmployeeID]
GO
ALTER TABLE [dbo].[EmployeeTraining]  WITH CHECK ADD  CONSTRAINT [FK_TrainingProgramID] FOREIGN KEY([TrainingProgramID])
REFERENCES [dbo].[TrainingProgram] ([TrainingProgramID])
GO
ALTER TABLE [dbo].[EmployeeTraining] CHECK CONSTRAINT [FK_TrainingProgramID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_CustomerID]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_PaymentID] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([PaymentID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_PaymentID]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderID]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_ProductID]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_CusID] FOREIGN KEY([CusID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_CusID]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Owner] FOREIGN KEY([Owner])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Owner]
GO
USE [master]
GO
ALTER DATABASE [SNQHM_bangazoncli_db] SET  READ_WRITE 
GO
