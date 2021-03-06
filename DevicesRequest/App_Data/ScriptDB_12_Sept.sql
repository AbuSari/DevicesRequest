USE [master]
GO
/****** Object:  Database [DevicesRequest]    Script Date: 9/12/2018 12:37:24 PM ******/
CREATE DATABASE [DevicesRequest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DevicesRequest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\DevicesRequest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DevicesRequest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\DevicesRequest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DevicesRequest] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DevicesRequest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DevicesRequest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DevicesRequest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DevicesRequest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DevicesRequest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DevicesRequest] SET ARITHABORT OFF 
GO
ALTER DATABASE [DevicesRequest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DevicesRequest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DevicesRequest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DevicesRequest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DevicesRequest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DevicesRequest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DevicesRequest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DevicesRequest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DevicesRequest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DevicesRequest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DevicesRequest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DevicesRequest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DevicesRequest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DevicesRequest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DevicesRequest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DevicesRequest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DevicesRequest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DevicesRequest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DevicesRequest] SET  MULTI_USER 
GO
ALTER DATABASE [DevicesRequest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DevicesRequest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DevicesRequest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DevicesRequest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DevicesRequest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DevicesRequest] SET QUERY_STORE = OFF
GO
USE [DevicesRequest]
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
USE [DevicesRequest]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminRoles]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRoles](
	[AdminId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [nvarchar](100) NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [nvarchar](100) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_AdminRoles] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[BuildingId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[ParentId] [int] NULL,
	[DirectorEmail] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
	[DirectorName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
	[UnitsInStock] [int] NULL,
	[UnitsOnOrder] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[LevelId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
	[BuildingId] [int] NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[LevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PoRceived]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PoRceived](
	[PoRceivedId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyNameEn] [nvarchar](100) NULL,
	[CompanyNameAr] [nvarchar](100) NULL,
	[PoCode] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_PoRceived] PRIMARY KEY CLUSTERED 
(
	[PoRceivedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
	[NeedApproved] [bit] NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportId] [int] IDENTITY(1,1) NOT NULL,
	[Details] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
	[ItemId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestItems]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestItems](
	[ItemId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Quantity] [int] NULL,
	[RequestDate] [datetime] NULL,
	[StutusId] [int] NULL,
	[TypeOfRequestId] [int] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[DirectorRecommondation] [nvarchar](500) NULL,
 CONSTRAINT [PK_RequestItems] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestStatus]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestStatus](
	[RequestStatusId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[StatusCode] [nvarchar](10) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[RequestStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Status] UNIQUE NONCLUSTERED 
(
	[StatusCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipment]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment](
	[PoRceivedId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Shipment] PRIMARY KEY CLUSTERED 
(
	[PoRceivedId] ASC,
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfRequest]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfRequest](
	[TypeOfRequestId] [int] IDENTITY(1,1) NOT NULL,
	[NameEn] [nvarchar](100) NULL,
	[NameAr] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_TypeOfRequest] PRIMARY KEY CLUSTERED 
(
	[TypeOfRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstNameAr] [nvarchar](30) NULL,
	[LastNameAr] [nvarchar](30) NULL,
	[FirstNameEn] [nvarchar](30) NULL,
	[LastNameEn] [nvarchar](30) NULL,
	[JobNumber] [nvarchar](15) NULL,
	[LevelId] [int] NULL,
	[DepartmentId] [int] NULL,
	[PositionId] [int] NULL,
	[RoomNo] [nvarchar](15) NULL,
	[Telephon] [nvarchar](15) NULL,
	[Mobile] [nvarchar](15) NULL,
	[UserEmail] [nvarchar](100) NULL,
	[DirectorEmail] [nvarchar](100) NULL,
	[CereatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdateBy] [nvarchar](100) NULL,
	[LastUpdateDate] [datetime] NULL,
	[Comment] [nvarchar](500) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdminRoles]  WITH CHECK ADD  CONSTRAINT [FK_AdminRoles_Admin] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admin] ([AdminId])
GO
ALTER TABLE [dbo].[AdminRoles] CHECK CONSTRAINT [FK_AdminRoles_Admin]
GO
ALTER TABLE [dbo].[AdminRoles]  WITH CHECK ADD  CONSTRAINT [FK_AdminRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[AdminRoles] CHECK CONSTRAINT [FK_AdminRoles_Role]
GO
ALTER TABLE [dbo].[Level]  WITH CHECK ADD  CONSTRAINT [FK_Level_Building] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Building] ([BuildingId])
GO
ALTER TABLE [dbo].[Level] CHECK CONSTRAINT [FK_Level_Building]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_RequestItems] FOREIGN KEY([ItemId], [UserId])
REFERENCES [dbo].[RequestItems] ([ItemId], [UserId])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_RequestItems]
GO
ALTER TABLE [dbo].[RequestItems]  WITH CHECK ADD  CONSTRAINT [FK_RequestItems_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[RequestItems] CHECK CONSTRAINT [FK_RequestItems_Item]
GO
ALTER TABLE [dbo].[RequestItems]  WITH CHECK ADD  CONSTRAINT [FK_RequestItems_Status] FOREIGN KEY([StutusId])
REFERENCES [dbo].[RequestStatus] ([RequestStatusId])
GO
ALTER TABLE [dbo].[RequestItems] CHECK CONSTRAINT [FK_RequestItems_Status]
GO
ALTER TABLE [dbo].[RequestItems]  WITH CHECK ADD  CONSTRAINT [FK_RequestItems_TypeOfRequest] FOREIGN KEY([TypeOfRequestId])
REFERENCES [dbo].[TypeOfRequest] ([TypeOfRequestId])
GO
ALTER TABLE [dbo].[RequestItems] CHECK CONSTRAINT [FK_RequestItems_TypeOfRequest]
GO
ALTER TABLE [dbo].[RequestItems]  WITH CHECK ADD  CONSTRAINT [FK_RequestItems_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RequestItems] CHECK CONSTRAINT [FK_RequestItems_User]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [FK_Shipment_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [FK_Shipment_Item]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [FK_Shipment_PoRceived] FOREIGN KEY([PoRceivedId])
REFERENCES [dbo].[PoRceived] ([PoRceivedId])
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [FK_Shipment_PoRceived]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Department]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Level] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([LevelId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Level]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Position]
GO
/****** Object:  StoredProcedure [dbo].[AddShipment]    Script Date: 9/12/2018 12:37:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddShipment] 
@PoRceivedId int,
@ItemId int,
@Quantity int,
@CreatedBy nvarchar(100),
@status int output
as
BEGIN

BEGIN TRY 
	BEGIN TRANSACTION

	INSERT INTO [dbo].[Shipment]
           ([PoRceivedId]
           ,[ItemId]
           ,[Quantity]
           ,[CreatedBy]
           ,[CreatedDate]) 
		   VALUES
           (@PoRceivedId
           ,@ItemId
           ,@Quantity
           ,@CreatedBy
           ,getdate())

	UPDATE [dbo].[Item]
	 SET [UnitsInStock] = [UnitsInStock] + @Quantity
	 WHERE [ItemId] = @ItemId
	 Set @status=1
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	Set @status=-1
END CATCH
END
GO
USE [master]
GO
ALTER DATABASE [DevicesRequest] SET  READ_WRITE 
GO
