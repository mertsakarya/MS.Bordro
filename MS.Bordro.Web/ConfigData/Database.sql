USE [master]
GO
/****** Object:  Database [MS.Katusha.Domain.DbContext]    Script Date: 05/11/2012 15:08:37 ******/
CREATE DATABASE [MS.Katusha.Domain.DbContext] ON  PRIMARY 
( NAME = N'MS.Katusha.Domain.DbContext', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MS.Katusha.Domain.DbContext.mdf' , SIZE = 11520KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MS.Katusha.Domain.DbContext_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MS.Katusha.Domain.DbContext_log.LDF' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MS.Katusha.Domain.DbContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET ARITHABORT OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET  ENABLE_BROKER
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET  READ_WRITE
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET RECOVERY FULL
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET  MULTI_USER
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MS.Katusha.Domain.DbContext] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'MS.Katusha.Domain.DbContext', N'ON'
GO
USE [MS.Katusha.Domain.DbContext]
GO
/****** Object:  Table [dbo].[PhotoBackups]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhotoBackups](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Data] [varbinary](max) NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_PhotoBackups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConfigurationDatas]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigurationDatas](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ConfigurationDatas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeoTimeZones]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeoTimeZones](
	[TimeZoneId] [nvarchar](128) NOT NULL,
	[GMTOffset] [float] NOT NULL,
	[DSTOffset] [float] NOT NULL,
	[RawOffset] [float] NOT NULL,
 CONSTRAINT [PK_GeoTimeZones] PRIMARY KEY CLUSTERED 
(
	[TimeZoneId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeoNames]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeoNames](
	[GeoNameId] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[AsciiName] [nvarchar](200) NULL,
	[AlternateNames] [nvarchar](max) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[FeatureClass] [nvarchar](1) NULL,
	[FeatureCode] [nvarchar](10) NULL,
	[CountryCode] [nvarchar](2) NULL,
	[CC2] [nvarchar](60) NULL,
	[Admin1code] [nvarchar](20) NULL,
	[Admin2code] [nvarchar](80) NULL,
	[Admin3code] [nvarchar](20) NULL,
	[Admin4code] [nvarchar](20) NULL,
	[Population] [bigint] NOT NULL,
	[Elevation] [int] NOT NULL,
	[DEM] [nvarchar](max) NULL,
	[TimeZone] [nvarchar](40) NULL,
	[ModificationDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_GeoNames] PRIMARY KEY CLUSTERED 
(
	[GeoNameId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeoLanguages]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeoLanguages](
	[LanguageName] [nvarchar](128) NOT NULL,
	[ISO639_3] [nvarchar](max) NULL,
	[ISO639_2] [nvarchar](max) NULL,
	[ISO639_1] [nvarchar](max) NULL,
 CONSTRAINT [PK_GeoLanguages] PRIMARY KEY CLUSTERED 
(
	[LanguageName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeoCountries]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeoCountries](
	[ISO] [nvarchar](128) NOT NULL,
	[ISO3] [nvarchar](max) NULL,
	[ISONumeric] [int] NOT NULL,
	[FIPS] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Capital] [nvarchar](max) NULL,
	[Area] [int] NOT NULL,
	[Population] [bigint] NOT NULL,
	[Continent] [nvarchar](max) NULL,
	[TLD] [nvarchar](max) NULL,
	[CurrencyCode] [nvarchar](max) NULL,
	[CurrencyName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PostalCodeFormat] [nvarchar](max) NULL,
	[PostalCodeRegEx] [nvarchar](max) NULL,
	[Languages] [nvarchar](max) NULL,
	[GeoNameId] [int] NOT NULL,
	[Neighbors] [nvarchar](max) NULL,
	[EquivalentFipsCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_GeoCountries] PRIMARY KEY CLUSTERED 
(
	[ISO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[UserName] [nvarchar](64) NOT NULL,
	[FacebookUid] [nvarchar](max) NULL,
	[Email] [nvarchar](64) NOT NULL,
	[EmailValidated] [bit] NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Password] [nvarchar](14) NOT NULL,
	[Expires] [datetime] NOT NULL,
	[MembershipType] [tinyint] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileId] [bigint] NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[LastOnline] [datetime] NOT NULL,
	[Birthyear] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[CountryCode] [nvarchar](max) NULL,
	[CityCode] [int] NOT NULL,
	[BodyBuild] [tinyint] NOT NULL,
	[HairColor] [tinyint] NOT NULL,
	[EyeColor] [tinyint] NOT NULL,
	[CountriesToVisit] [nvarchar](max) NULL,
	[Searches] [nvarchar](max) NULL,
	[HasPhoto] [bit] NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ResourceKey] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[Language] [nvarchar](2) NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourceLookups]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceLookups](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ResourceKey] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[Language] [nvarchar](2) NULL,
	[LookupName] [nvarchar](max) NULL,
	[Order] [tinyint] NOT NULL,
	[LookupValue] [tinyint] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ResourceLookups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Name] [nvarchar](64) NULL,
	[Location_CityCode] [int] NOT NULL,
	[Location_CityName] [nvarchar](200) NULL,
	[Location_CountryCode] [nvarchar](2) NULL,
	[Location_CountryName] [nvarchar](200) NULL,
	[BodyBuild] [tinyint] NOT NULL,
	[EyeColor] [tinyint] NOT NULL,
	[HairColor] [tinyint] NOT NULL,
	[Smokes] [tinyint] NOT NULL,
	[Alcohol] [tinyint] NOT NULL,
	[Religion] [tinyint] NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[DickSize] [tinyint] NOT NULL,
	[DickThickness] [tinyint] NOT NULL,
	[BreastSize] [tinyint] NOT NULL,
	[Height] [int] NOT NULL,
	[BirthYear] [int] NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[ProfilePhotoGuid] [uniqueidentifier] NOT NULL,
	[FriendlyName] [nvarchar](64) NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Profiles] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visits](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileId] [bigint] NOT NULL,
	[VisitorProfileId] [bigint] NOT NULL,
	[VisitCount] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProfileId] ON [dbo].[Visits] 
(
	[ProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_VisitorProfileId] ON [dbo].[Visits] 
(
	[VisitorProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LanguagesSpokens]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguagesSpokens](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileId] [bigint] NOT NULL,
	[Language] [nvarchar](2) NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_LanguagesSpokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProfileId] ON [dbo].[LanguagesSpokens] 
(
	[ProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchingFors]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchingFors](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileId] [bigint] NOT NULL,
	[Search] [tinyint] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_SearchingFors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProfileId] ON [dbo].[SearchingFors] 
(
	[ProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountriesToVisits]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountriesToVisits](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileId] [bigint] NOT NULL,
	[Country] [nvarchar](2) NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_CountriesToVisits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProfileId] ON [dbo].[CountriesToVisits] 
(
	[ProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conversations]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FromId] [bigint] NOT NULL,
	[ToId] [bigint] NOT NULL,
	[Message] [nvarchar](4000) NOT NULL,
	[Subject] [nvarchar](255) NULL,
	[ReadDate] [datetime] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Conversations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FromId] ON [dbo].[Conversations] 
(
	[FromId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ToId] ON [dbo].[Conversations] 
(
	[ToId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 05/11/2012 15:08:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileId] [bigint] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ContentType] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProfileId] ON [dbo].[Photos] 
(
	[ProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Profiles_Users_UserId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Users_UserId]
GO
/****** Object:  ForeignKey [FK_Visits_Profiles_ProfileId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Profiles_ProfileId] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profiles] ([Id])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Profiles_ProfileId]
GO
/****** Object:  ForeignKey [FK_Visits_Profiles_VisitorProfileId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Profiles_VisitorProfileId] FOREIGN KEY([VisitorProfileId])
REFERENCES [dbo].[Profiles] ([Id])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Profiles_VisitorProfileId]
GO
/****** Object:  ForeignKey [FK_LanguagesSpokens_Profiles_ProfileId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[LanguagesSpokens]  WITH CHECK ADD  CONSTRAINT [FK_LanguagesSpokens_Profiles_ProfileId] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LanguagesSpokens] CHECK CONSTRAINT [FK_LanguagesSpokens_Profiles_ProfileId]
GO
/****** Object:  ForeignKey [FK_SearchingFors_Profiles_ProfileId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[SearchingFors]  WITH CHECK ADD  CONSTRAINT [FK_SearchingFors_Profiles_ProfileId] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SearchingFors] CHECK CONSTRAINT [FK_SearchingFors_Profiles_ProfileId]
GO
/****** Object:  ForeignKey [FK_CountriesToVisits_Profiles_ProfileId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[CountriesToVisits]  WITH CHECK ADD  CONSTRAINT [FK_CountriesToVisits_Profiles_ProfileId] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CountriesToVisits] CHECK CONSTRAINT [FK_CountriesToVisits_Profiles_ProfileId]
GO
/****** Object:  ForeignKey [FK_Conversations_Profiles_FromId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[Conversations]  WITH CHECK ADD  CONSTRAINT [FK_Conversations_Profiles_FromId] FOREIGN KEY([FromId])
REFERENCES [dbo].[Profiles] ([Id])
GO
ALTER TABLE [dbo].[Conversations] CHECK CONSTRAINT [FK_Conversations_Profiles_FromId]
GO
/****** Object:  ForeignKey [FK_Conversations_Profiles_ToId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[Conversations]  WITH CHECK ADD  CONSTRAINT [FK_Conversations_Profiles_ToId] FOREIGN KEY([ToId])
REFERENCES [dbo].[Profiles] ([Id])
GO
ALTER TABLE [dbo].[Conversations] CHECK CONSTRAINT [FK_Conversations_Profiles_ToId]
GO
/****** Object:  ForeignKey [FK_Photos_Profiles_ProfileId]    Script Date: 05/11/2012 15:08:38 ******/
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD  CONSTRAINT [FK_Photos_Profiles_ProfileId] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [FK_Photos_Profiles_ProfileId]
GO
