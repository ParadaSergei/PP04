USE [master]
GO
/****** Object:  Database [YchotRemontnihKomplektuishuh]    Script Date: 26.01.2024 17:33:07 ******/
CREATE DATABASE [YchotRemontnihKomplektuishuh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YchotRemontnihKomplektuishuh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\YchotRemontnihKomplektuishuh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'YchotRemontnihKomplektuishuh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\YchotRemontnihKomplektuishuh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YchotRemontnihKomplektuishuh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET ARITHABORT OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET RECOVERY FULL 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET  MULTI_USER 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'YchotRemontnihKomplektuishuh', N'ON'
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET QUERY_STORE = ON
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [YchotRemontnihKomplektuishuh]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 26.01.2024 17:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Id_Account_data] [int] NULL,
	[Privilege_account] [varchar](255) NULL,
	[Date_Created] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account_Data]    Script Date: 26.01.2024 17:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_Data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Familia] [varchar](255) NULL,
	[Device_Remont_type] [varchar](255) NULL,
	[Raspisanie_work] [varchar](255) NULL,
	[Zarplata] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Remont]    Script Date: 26.01.2024 17:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Remont](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Id_Account_Data] [int] NULL,
	[Id_Detail] [int] NULL,
	[Type_neispravnosti] [varchar](255) NULL,
	[Device_names] [varchar](255) NULL,
	[Price] [decimal](10, 2) NULL,
	[Start_remonta_po_time] [datetime] NULL,
	[End_remonta_po_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sclad]    Script Date: 26.01.2024 17:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sclad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Device_type] [varchar](255) NULL,
	[Detali] [varchar](255) NULL,
	[Kolichestvo] [int] NULL,
	[Pribitie_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [Login], [Password], [Id_Account_data], [Privilege_account], [Date_Created]) VALUES (3, N'admin', N'admin', 1, N'admin', CAST(N'2023-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Account] ([id], [Login], [Password], [Id_Account_data], [Privilege_account], [Date_Created]) VALUES (5, N'user', N'user', 3, N'employee', CAST(N'2023-01-23T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Account_Data] ON 

INSERT [dbo].[Account_Data] ([id], [Name], [Familia], [Device_Remont_type], [Raspisanie_work], [Zarplata]) VALUES (1, N'Сергей', N'Парада', N'Телефон', N'3/4', CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[Account_Data] ([id], [Name], [Familia], [Device_Remont_type], [Raspisanie_work], [Zarplata]) VALUES (3, N'Аня ', N'Гинасевна', N'Ноутбук', N'2/2', CAST(20000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Account_Data] OFF
GO
SET IDENTITY_INSERT [dbo].[Remont] ON 

INSERT [dbo].[Remont] ([id], [Name], [Id_Account_Data], [Id_Detail], [Type_neispravnosti], [Device_names], [Price], [Start_remonta_po_time], [End_remonta_po_time]) VALUES (4, N'Ли', 1, 1, N'Экран', N'Телефон', CAST(1500.00 AS Decimal(10, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Remont] OFF
GO
SET IDENTITY_INSERT [dbo].[Sclad] ON 

INSERT [dbo].[Sclad] ([id], [Device_type], [Detali], [Kolichestvo], [Pribitie_time]) VALUES (1, N'Телефон', N'Экран', 2, CAST(N'2022-11-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Sclad] ([id], [Device_type], [Detali], [Kolichestvo], [Pribitie_time]) VALUES (3, N'Ноутбуки', N'Кнопки', 15, CAST(N'2023-05-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Sclad] ([id], [Device_type], [Detali], [Kolichestvo], [Pribitie_time]) VALUES (4, N'Телефон', N'Аккамулятор', 5, CAST(N'2023-01-11T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sclad] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([Id_Account_data])
REFERENCES [dbo].[Account_Data] ([id])
GO
ALTER TABLE [dbo].[Remont]  WITH CHECK ADD FOREIGN KEY([Id_Account_Data])
REFERENCES [dbo].[Account_Data] ([id])
GO
ALTER TABLE [dbo].[Remont]  WITH CHECK ADD FOREIGN KEY([Id_Detail])
REFERENCES [dbo].[Sclad] ([id])
GO
USE [master]
GO
ALTER DATABASE [YchotRemontnihKomplektuishuh] SET  READ_WRITE 
GO
