USE [master]
GO
/****** Object:  Database [VeriParkDemo]    Script Date: 22.10.2020 05:01:51 ******/
CREATE DATABASE [VeriParkDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VeriParkDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VeriParkDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VeriParkDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VeriParkDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VeriParkDemo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VeriParkDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VeriParkDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VeriParkDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VeriParkDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VeriParkDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VeriParkDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [VeriParkDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VeriParkDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VeriParkDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VeriParkDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VeriParkDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VeriParkDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VeriParkDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VeriParkDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VeriParkDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VeriParkDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VeriParkDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VeriParkDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VeriParkDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VeriParkDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VeriParkDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VeriParkDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VeriParkDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VeriParkDemo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VeriParkDemo] SET  MULTI_USER 
GO
ALTER DATABASE [VeriParkDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VeriParkDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VeriParkDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VeriParkDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VeriParkDemo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VeriParkDemo] SET QUERY_STORE = OFF
GO
USE [VeriParkDemo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22.10.2020 05:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 22.10.2020 05:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](max) NULL,
	[CurrencyCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountryBasedHoliday]    Script Date: 22.10.2020 05:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryBasedHoliday](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[HolidayDate] [datetime2](7) NOT NULL,
	[HolidayType] [nvarchar](max) NULL,
 CONSTRAINT [PK_CountryBasedHoliday] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountryBasedWeekend]    Script Date: 22.10.2020 05:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryBasedWeekend](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[WeekendDay] [int] NOT NULL,
 CONSTRAINT [PK_CountryBasedWeekend] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Penalty]    Script Date: 22.10.2020 05:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Penalty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CheckedOutDate] [datetime2](7) NOT NULL,
	[RetunDate] [datetime2](7) NOT NULL,
	[BussinesDay] [int] NOT NULL,
	[CountryId] [int] NULL,
	[PenaltyAmount] [float] NOT NULL,
 CONSTRAINT [PK_Penalty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201020135732_init', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201020140031_init_SecondCountry', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201021110732_NewVersionOfDb', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201021111014_NewVersionOfDb2', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201021113225_NewVersionOfDb3', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201021233251_NewVersionOfDb4', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201022015654_NewVersionOfDb5', N'3.1.9')
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [CountryName], [CurrencyCode]) VALUES (1007, N'Turkiye', N'TRY')
INSERT [dbo].[Country] ([Id], [CountryName], [CurrencyCode]) VALUES (1008, N'Amerika', N'USD')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[CountryBasedHoliday] ON 

INSERT [dbo].[CountryBasedHoliday] ([Id], [CountryId], [HolidayDate], [HolidayType]) VALUES (13, 1007, CAST(N'2020-10-29T00:00:00.0000000' AS DateTime2), N'Formal')
INSERT [dbo].[CountryBasedHoliday] ([Id], [CountryId], [HolidayDate], [HolidayType]) VALUES (14, 1007, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), N'Formal')
INSERT [dbo].[CountryBasedHoliday] ([Id], [CountryId], [HolidayDate], [HolidayType]) VALUES (15, 1007, CAST(N'2020-11-10T00:00:00.0000000' AS DateTime2), N'Formal')
INSERT [dbo].[CountryBasedHoliday] ([Id], [CountryId], [HolidayDate], [HolidayType]) VALUES (16, 1008, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), N'Formal')
INSERT [dbo].[CountryBasedHoliday] ([Id], [CountryId], [HolidayDate], [HolidayType]) VALUES (17, 1008, CAST(N'2020-11-22T00:00:00.0000000' AS DateTime2), N'Formal')
INSERT [dbo].[CountryBasedHoliday] ([Id], [CountryId], [HolidayDate], [HolidayType]) VALUES (18, 1008, CAST(N'2020-10-31T00:00:00.0000000' AS DateTime2), N'Formal')
SET IDENTITY_INSERT [dbo].[CountryBasedHoliday] OFF
SET IDENTITY_INSERT [dbo].[CountryBasedWeekend] ON 

INSERT [dbo].[CountryBasedWeekend] ([Id], [CountryId], [WeekendDay]) VALUES (9, 1008, 2)
INSERT [dbo].[CountryBasedWeekend] ([Id], [CountryId], [WeekendDay]) VALUES (10, 1008, 1)
INSERT [dbo].[CountryBasedWeekend] ([Id], [CountryId], [WeekendDay]) VALUES (11, 1007, 0)
INSERT [dbo].[CountryBasedWeekend] ([Id], [CountryId], [WeekendDay]) VALUES (12, 1007, 6)
SET IDENTITY_INSERT [dbo].[CountryBasedWeekend] OFF
SET IDENTITY_INSERT [dbo].[Penalty] ON 

INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (14, CAST(N'2020-10-18T04:27:00.0000000' AS DateTime2), CAST(N'2020-10-24T04:27:00.0000000' AS DateTime2), 5, 1007, 0)
INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (15, CAST(N'2020-10-04T04:27:00.0000000' AS DateTime2), CAST(N'2020-10-31T04:27:00.0000000' AS DateTime2), 19, 1007, 45)
INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (16, CAST(N'2019-12-15T04:29:00.0000000' AS DateTime2), CAST(N'2020-01-11T04:30:00.0000000' AS DateTime2), 18, 1008, 40)
INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (17, CAST(N'2020-10-11T04:30:00.0000000' AS DateTime2), CAST(N'2020-11-07T04:30:00.0000000' AS DateTime2), 18, 1008, 40)
INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (18, CAST(N'2020-10-18T04:31:00.0000000' AS DateTime2), CAST(N'2020-10-28T04:31:00.0000000' AS DateTime2), 7, 1007, 0)
INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (19, CAST(N'2020-10-11T04:31:00.0000000' AS DateTime2), CAST(N'2020-11-06T04:31:00.0000000' AS DateTime2), 17, 1008, 35)
INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (20, CAST(N'2020-10-13T04:37:00.0000000' AS DateTime2), CAST(N'2020-10-24T04:37:00.0000000' AS DateTime2), 9, 1007, 0)
INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (21, CAST(N'2020-10-22T04:37:00.0000000' AS DateTime2), CAST(N'2020-10-22T04:38:00.0000000' AS DateTime2), 0, 1007, 0)
INSERT [dbo].[Penalty] ([Id], [CheckedOutDate], [RetunDate], [BussinesDay], [CountryId], [PenaltyAmount]) VALUES (22, CAST(N'2020-10-11T04:44:00.0000000' AS DateTime2), CAST(N'2020-10-31T04:44:00.0000000' AS DateTime2), 14, 1007, 20)
SET IDENTITY_INSERT [dbo].[Penalty] OFF
/****** Object:  Index [IX_CountryBasedHoliday_CountryId]    Script Date: 22.10.2020 05:01:52 ******/
CREATE NONCLUSTERED INDEX [IX_CountryBasedHoliday_CountryId] ON [dbo].[CountryBasedHoliday]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CountryBasedWeekend_CountryId]    Script Date: 22.10.2020 05:01:52 ******/
CREATE NONCLUSTERED INDEX [IX_CountryBasedWeekend_CountryId] ON [dbo].[CountryBasedWeekend]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Penalty_CountryId]    Script Date: 22.10.2020 05:01:52 ******/
CREATE NONCLUSTERED INDEX [IX_Penalty_CountryId] ON [dbo].[Penalty]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Penalty] ADD  DEFAULT ((0)) FOR [BussinesDay]
GO
ALTER TABLE [dbo].[CountryBasedHoliday]  WITH CHECK ADD  CONSTRAINT [FK_CountryBasedHoliday_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[CountryBasedHoliday] CHECK CONSTRAINT [FK_CountryBasedHoliday_Country_CountryId]
GO
ALTER TABLE [dbo].[CountryBasedWeekend]  WITH CHECK ADD  CONSTRAINT [FK_CountryBasedWeekend_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[CountryBasedWeekend] CHECK CONSTRAINT [FK_CountryBasedWeekend_Country_CountryId]
GO
ALTER TABLE [dbo].[Penalty]  WITH CHECK ADD  CONSTRAINT [FK_Penalty_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Penalty] CHECK CONSTRAINT [FK_Penalty_Country_CountryId]
GO
USE [master]
GO
ALTER DATABASE [VeriParkDemo] SET  READ_WRITE 
GO
