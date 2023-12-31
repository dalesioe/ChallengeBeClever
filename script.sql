USE [master]
GO
/****** Object:  Database [ChallengeBeClever]    Script Date: 22/6/2023 21:44:28 ******/
CREATE DATABASE [ChallengeBeClever]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChallengeBeClever', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ChallengeBeClever.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChallengeBeClever_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ChallengeBeClever_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ChallengeBeClever] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChallengeBeClever].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChallengeBeClever] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChallengeBeClever] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChallengeBeClever] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChallengeBeClever] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChallengeBeClever] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChallengeBeClever] SET  MULTI_USER 
GO
ALTER DATABASE [ChallengeBeClever] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChallengeBeClever] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChallengeBeClever] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChallengeBeClever] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChallengeBeClever] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChallengeBeClever] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ChallengeBeClever] SET QUERY_STORE = OFF
GO
USE [ChallengeBeClever]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 22/6/2023 21:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[RegisterType] [nvarchar](50) NOT NULL,
	[BusinessLocation] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[IVA] [decimal](18, 0) NOT NULL,
	[Interes] [decimal](18, 0) NULL,
	[Mora] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/6/2023 21:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [varchar](60) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [EmployeeId], [Date], [RegisterType], [BusinessLocation], [Amount], [IVA], [Interes], [Mora]) VALUES (1, 1, CAST(N'2023-06-22T18:29:06.697' AS DateTime), N'Prueba', N'Prueba', CAST(1 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 0)
INSERT [dbo].[Payments] ([Id], [EmployeeId], [Date], [RegisterType], [BusinessLocation], [Amount], [IVA], [Interes], [Mora]) VALUES (2, 1, CAST(N'2023-06-01T00:00:00.000' AS DateTime), N'Prueba 2', N'Prueba 2', CAST(124 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), 3)
INSERT [dbo].[Payments] ([Id], [EmployeeId], [Date], [RegisterType], [BusinessLocation], [Amount], [IVA], [Interes], [Mora]) VALUES (3, 1, CAST(N'2023-06-01T00:00:00.000' AS DateTime), N'Prueba 2', N'Prueba 2', CAST(124 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), 3)
INSERT [dbo].[Payments] ([Id], [EmployeeId], [Date], [RegisterType], [BusinessLocation], [Amount], [IVA], [Interes], [Mora]) VALUES (6, 1, CAST(N'2023-06-22T19:31:00.523' AS DateTime), N'Prueba 3', N'Prueba 3', CAST(4 AS Decimal(18, 0)), CAST(12 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), 1)
INSERT [dbo].[Payments] ([Id], [EmployeeId], [Date], [RegisterType], [BusinessLocation], [Amount], [IVA], [Interes], [Mora]) VALUES (7, 1, CAST(N'2023-06-22T00:00:00.000' AS DateTime), N'asd', N'asd', CAST(1 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[Payments] ([Id], [EmployeeId], [Date], [RegisterType], [BusinessLocation], [Amount], [IVA], [Interes], [Mora]) VALUES (8, 1, CAST(N'2023-06-22T19:31:00.523' AS DateTime), N'Prueba 3', N'Prueba 3', CAST(4 AS Decimal(18, 0)), CAST(12 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [DisplayName], [UserName], [Email], [Password], [CreatedDate]) VALUES (1, N'Emiliano D''Alesio', N'Admin', N'admin@abc.com', N'12345', CAST(N'2022-01-17T14:47:58.207' AS DateTime))
INSERT [dbo].[Users] ([UserId], [DisplayName], [UserName], [Email], [Password], [CreatedDate]) VALUES (2, N'BeCleaver', N'BeCleaver', N'BeCleaver@abc.com', N'12345', CAST(N'2023-06-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([UserId], [DisplayName], [UserName], [Email], [Password], [CreatedDate]) VALUES (4, N'Test', N'Test', N'test@asd.com', N'12345', CAST(N'2023-06-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeId_UserId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_EmployeeId_UserId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Payment] FOREIGN KEY([Id])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payment_Payment]
GO
/****** Object:  StoredProcedure [dbo].[SP_Alta_Pago]    Script Date: 22/6/2023 21:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Alta_Pago] 
@EmployeeId int,
@BusinessLocation nvarchar(50),
@RegisterType nvarchar(50),
@IVA decimal,
@Amount decimal,
@Date datetime,
@Interes decimal = 0,
@Mora int = 0

AS
BEGIN
BEGIN TRAN
	INSERT INTO [dbo].[Payments]
           ([EmployeeId]
           ,[Date]
           ,[RegisterType]
           ,[BusinessLocation]
           ,[Amount]
           ,[IVA]
           ,[Interes]
           ,[Mora])
     VALUES(
           @EmployeeId
           ,@Date
           ,@RegisterType
           ,@BusinessLocation
           ,@Amount
           ,@IVA
           ,@Interes
           ,@Mora)
		   	COMMIT
	SELECT Top 1 Id 
	FROM Payments 
	ORDER BY Id DESC

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Payment_Report]    Script Date: 22/6/2023 21:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Payment_Report] 
@DateFrom datetime,
@DateTo datetime

AS
BEGIN	
	SELECT COUNT(id) AS TotalPayments,
			MAX(Date) AS Max,
			MIN(Date) AS Min,
			AVG(Amount) AS AVGPayments,
			SUM(Amount)AS Total
	FROM Payments
	WHERE Date BETWEEN @DateFrom AND @DateTo
END
GO
USE [master]
GO
ALTER DATABASE [ChallengeBeClever] SET  READ_WRITE 
GO
