USE [master]
GO
/****** Object:  Database [SCTSDB]    Script Date: 17/12/2018 23:21:56 ******/
CREATE DATABASE [SCTSDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SCTSDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SCTSDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SCTSDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SCTSDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SCTSDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SCTSDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SCTSDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SCTSDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SCTSDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SCTSDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SCTSDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SCTSDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SCTSDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SCTSDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SCTSDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SCTSDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SCTSDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SCTSDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SCTSDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SCTSDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SCTSDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SCTSDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SCTSDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SCTSDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SCTSDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SCTSDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SCTSDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SCTSDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SCTSDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SCTSDB] SET  MULTI_USER 
GO
ALTER DATABASE [SCTSDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SCTSDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SCTSDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SCTSDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SCTSDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SCTSDB', N'ON'
GO
ALTER DATABASE [SCTSDB] SET QUERY_STORE = OFF
GO
USE [SCTSDB]
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
USE [SCTSDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/12/2018 23:21:56 ******/
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
/****** Object:  Table [dbo].[ApiClaims]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[Type] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ApiClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiResources]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiResources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[DisplayName] [nvarchar](200) NULL,
	[Enabled] [bit] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ApiResources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiScopeClaims]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiScopeClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiScopeId] [int] NOT NULL,
	[Type] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ApiScopeClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiScopes]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiScopes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[DisplayName] [nvarchar](200) NULL,
	[Emphasize] [bit] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Required] [bit] NOT NULL,
	[ShowInDiscoveryDocument] [bit] NOT NULL,
 CONSTRAINT [PK_ApiScopes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiSecrets]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiSecrets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApiResourceId] [int] NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Expiration] [datetime2](7) NULL,
	[Type] [nvarchar](250) NULL,
	[Value] [nvarchar](2000) NULL,
 CONSTRAINT [PK_ApiSecrets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[BC_Address] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientClaims]    Script Date: 17/12/2018 23:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Type] [nvarchar](250) NOT NULL,
	[Value] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ClientClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientCorsOrigins]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientCorsOrigins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Origin] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ClientCorsOrigins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientGrantTypes]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientGrantTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[GrantType] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ClientGrantTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientIdPRestrictions]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientIdPRestrictions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Provider] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ClientIdPRestrictions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientPostLogoutRedirectUris]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientPostLogoutRedirectUris](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[PostLogoutRedirectUri] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_ClientPostLogoutRedirectUris] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientProperties]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientProperties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Key] [nvarchar](250) NOT NULL,
	[Value] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_ClientProperties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientRedirectUris]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientRedirectUris](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[RedirectUri] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_ClientRedirectUris] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AbsoluteRefreshTokenLifetime] [int] NOT NULL,
	[AccessTokenLifetime] [int] NOT NULL,
	[AccessTokenType] [int] NOT NULL,
	[AllowAccessTokensViaBrowser] [bit] NOT NULL,
	[AllowOfflineAccess] [bit] NOT NULL,
	[AllowPlainTextPkce] [bit] NOT NULL,
	[AllowRememberConsent] [bit] NOT NULL,
	[AlwaysIncludeUserClaimsInIdToken] [bit] NOT NULL,
	[AlwaysSendClientClaims] [bit] NOT NULL,
	[AuthorizationCodeLifetime] [int] NOT NULL,
	[BackChannelLogoutSessionRequired] [bit] NOT NULL,
	[BackChannelLogoutUri] [nvarchar](2000) NULL,
	[ClientClaimsPrefix] [nvarchar](200) NULL,
	[ClientId] [nvarchar](200) NOT NULL,
	[ClientName] [nvarchar](200) NULL,
	[ClientUri] [nvarchar](2000) NULL,
	[ConsentLifetime] [int] NULL,
	[Description] [nvarchar](1000) NULL,
	[EnableLocalLogin] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[FrontChannelLogoutSessionRequired] [bit] NOT NULL,
	[FrontChannelLogoutUri] [nvarchar](2000) NULL,
	[IdentityTokenLifetime] [int] NOT NULL,
	[IncludeJwtId] [bit] NOT NULL,
	[LogoUri] [nvarchar](2000) NULL,
	[PairWiseSubjectSalt] [nvarchar](200) NULL,
	[ProtocolType] [nvarchar](200) NOT NULL,
	[RefreshTokenExpiration] [int] NOT NULL,
	[RefreshTokenUsage] [int] NOT NULL,
	[RequireClientSecret] [bit] NOT NULL,
	[RequireConsent] [bit] NOT NULL,
	[RequirePkce] [bit] NOT NULL,
	[SlidingRefreshTokenLifetime] [int] NOT NULL,
	[UpdateAccessTokenClaimsOnRefresh] [bit] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientScopes]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientScopes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Scope] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ClientScopes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientSecrets]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientSecrets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[Expiration] [datetime2](7) NULL,
	[Type] [nvarchar](250) NULL,
	[Value] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_ClientSecrets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityClaims]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityResourceId] [int] NOT NULL,
	[Type] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_IdentityClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityResources]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityResources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[DisplayName] [nvarchar](200) NULL,
	[Emphasize] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Required] [bit] NOT NULL,
	[ShowInDiscoveryDocument] [bit] NOT NULL,
 CONSTRAINT [PK_IdentityResources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersistedGrants]    Script Date: 17/12/2018 23:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersistedGrants](
	[Key] [nvarchar](200) NOT NULL,
	[ClientId] [nvarchar](200) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Expiration] [datetime2](7) NULL,
	[SubjectId] [nvarchar](200) NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PersistedGrants] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180618102153_appDbMig', N'2.0.3-rtm-10026')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180618102307_confmig', N'2.0.3-rtm-10026')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180618102359_persistedgrntmig', N'2.0.3-rtm-10026')
SET IDENTITY_INSERT [dbo].[ApiClaims] ON 

INSERT [dbo].[ApiClaims] ([Id], [ApiResourceId], [Type]) VALUES (1, 1, N'name')
INSERT [dbo].[ApiClaims] ([Id], [ApiResourceId], [Type]) VALUES (2, 1, N'email')
INSERT [dbo].[ApiClaims] ([Id], [ApiResourceId], [Type]) VALUES (3, 1, N'openid')
SET IDENTITY_INSERT [dbo].[ApiClaims] OFF
SET IDENTITY_INSERT [dbo].[ApiResources] ON 

INSERT [dbo].[ApiResources] ([Id], [Description], [DisplayName], [Enabled], [Name]) VALUES (1, NULL, N'api1', 1, N'api1')
SET IDENTITY_INSERT [dbo].[ApiResources] OFF
SET IDENTITY_INSERT [dbo].[ApiScopes] ON 

INSERT [dbo].[ApiScopes] ([Id], [ApiResourceId], [Description], [DisplayName], [Emphasize], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (1, 1, NULL, N'api1.fullaccess', 0, N'api1.fullaccess', 0, 1)
INSERT [dbo].[ApiScopes] ([Id], [ApiResourceId], [Description], [DisplayName], [Emphasize], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (2, 1, NULL, N'api1.readonlyaccess', 0, N'api1.readonlyaccess', 0, 1)
INSERT [dbo].[ApiScopes] ([Id], [ApiResourceId], [Description], [DisplayName], [Emphasize], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (3, 1, NULL, N'api1', 0, N'api1', 1, 1)
SET IDENTITY_INSERT [dbo].[ApiScopes] OFF
SET IDENTITY_INSERT [dbo].[ApiSecrets] ON 

INSERT [dbo].[ApiSecrets] ([Id], [ApiResourceId], [Description], [Expiration], [Type], [Value]) VALUES (1, 1, NULL, NULL, N'SharedSecret', N'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=')
SET IDENTITY_INSERT [dbo].[ApiSecrets] OFF
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 

INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (1, N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name', N'account00', N'ac223ef5-cc4c-4802-9a61-6b416752caf2')
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (4, N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/webpage', N'http://www.pomiager.com', N'ac223ef5-cc4c-4802-9a61-6b416752caf2')
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (5, N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name', N'account01', N'4f532e9a-7a02-4d1c-9a7b-d48cc08276a6')
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (6, N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/webpage', N'http://www.pomiager.com', N'4f532e9a-7a02-4d1c-9a7b-d48cc08276a6')
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (7, N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name', N'account03', N'282c235b-dbbe-47aa-8a75-9127b6775e38')
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (8, N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/webpage', N'http://www.pomiager.com', N'282c235b-dbbe-47aa-8a75-9127b6775e38')
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (9, N'actor', N'0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a', N'ac223ef5-cc4c-4802-9a61-6b416752caf2')
INSERT [dbo].[AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId]) VALUES (14, N'BC_Address', N'0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a', N'ac223ef5-cc4c-4802-9a61-6b416752caf2')
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [BC_Address], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'0ed552e0-525e-47bb-b212-4c94df63793e', 0, N'0xa06e833966d1B13113De66F1c5ea7C6592e12522', N'18e2bc68-66c6-4331-b730-891b29bafd78', N'account07@pomiager.com', 0, 1, NULL, N'ACCOUNT07@POMIAGER.COM', N'ACCOUNT07@POMIAGER.COM', N'AQAAAAEAACcQAAAAEAzQqgRUTnFSMYvyCXeA+9kWvWsfxRZ550EGicki335k7T0mPbcPRgrA0rj6BzfGZg==', NULL, 0, N'227e59df-0969-4eea-a74d-26edf437563e', 0, N'account07@pomiager.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [BC_Address], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'282c235b-dbbe-47aa-8a75-9127b6775e38', 0, N'0x17bd4Bc4cf6BE0F368Bb74e23e969A773A3dD187', N'ddbfb62f-7b8f-4910-8749-b0ce2e4846c2', N'account03@pomiager.com', 0, 1, NULL, N'ACCOUNT03@POMIAGER.COM', N'ACCOUNT03@POMIAGER.COM', N'AQAAAAEAACcQAAAAEIOR4rngQcBE5fqHmQaJ97L7xWD0GrWUshYuAadNffCVXH+fvF5lyNjDIrllxuxVVg==', NULL, 0, N'08ab6541-8688-4b26-bc9e-0ab4f71357ef', 0, N'account03@pomiager.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [BC_Address], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'4f532e9a-7a02-4d1c-9a7b-d48cc08276a6', 0, N'0x9cB947b649E8e302dD2C9c2fdDd3875B7F93bC3a', N'18786933-f2a2-47de-8be9-6ea7c7be5436', N'account01@pomiager.com', 0, 1, NULL, N'ACCOUNT01@POMIAGER.COM', N'ACCOUNT01@POMIAGER.COM', N'AQAAAAEAACcQAAAAEPw0Z+mNvh5zU9kXtPZDRwv3FcIXK0e8di4Q08CbeRPROSouFmtzkGYyj2RxkOB37A==', NULL, 0, N'78527e4e-69ca-4908-ab9a-97256c0368d2', 0, N'account01@pomiager.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [BC_Address], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'6f8a91e8-812b-47a4-96e5-3eedc95e151d', 0, N'0x33977B2a6Aa39daD4bf49c0861Caa8eED666562B', N'5c52eaab-7834-4830-9318-fd80ee95cdad', N'account09@pomiager.com', 0, 1, NULL, N'ACCOUNT09@POMIAGER.COM', N'ACCOUNT09@POMIAGER.COM', N'AQAAAAEAACcQAAAAEOIwdX0BeJDhgAnsl6/ECJhgHpSAkbbBumX9/gYipHgMlQeBHoA7WXi4qreksFD+gw==', NULL, 0, N'9a3e890e-6468-4f8d-9efb-a8de78a3e9b8', 0, N'account09@pomiager.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [BC_Address], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'ac223ef5-cc4c-4802-9a61-6b416752caf2', 0, N'0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a', N'db0e5caa-23bc-4368-b044-eccdd1a9dceb', N'account00@pomiager.com', 0, 1, NULL, N'ACCOUNT00@POMIAGER.COM', N'ACCOUNT00@POMIAGER.COM', N'AQAAAAEAACcQAAAAEMC7rvPwMD2XemA5mGmcgulojkpAtcgPDt7HDQS8jsNpDlY+HbxDlMeKYiiD3IYIMQ==', NULL, 0, N'96e6f5c3-ce22-4114-b619-4cf79ff75cfa', 0, N'account00@pomiager.com')
SET IDENTITY_INSERT [dbo].[ClientGrantTypes] ON 

INSERT [dbo].[ClientGrantTypes] ([Id], [ClientId], [GrantType]) VALUES (1, 1, N'hybrid')
INSERT [dbo].[ClientGrantTypes] ([Id], [ClientId], [GrantType]) VALUES (2, 1, N'client_credentials')
SET IDENTITY_INSERT [dbo].[ClientGrantTypes] OFF
SET IDENTITY_INSERT [dbo].[ClientPostLogoutRedirectUris] ON 

INSERT [dbo].[ClientPostLogoutRedirectUris] ([Id], [ClientId], [PostLogoutRedirectUri]) VALUES (1, 1, N'http://localhost:63008/signout-callback-oidc')
SET IDENTITY_INSERT [dbo].[ClientPostLogoutRedirectUris] OFF
SET IDENTITY_INSERT [dbo].[ClientRedirectUris] ON 

INSERT [dbo].[ClientRedirectUris] ([Id], [ClientId], [RedirectUri]) VALUES (1, 1, N'http://localhost:63008/signin-oidc')
SET IDENTITY_INSERT [dbo].[ClientRedirectUris] OFF
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [AbsoluteRefreshTokenLifetime], [AccessTokenLifetime], [AccessTokenType], [AllowAccessTokensViaBrowser], [AllowOfflineAccess], [AllowPlainTextPkce], [AllowRememberConsent], [AlwaysIncludeUserClaimsInIdToken], [AlwaysSendClientClaims], [AuthorizationCodeLifetime], [BackChannelLogoutSessionRequired], [BackChannelLogoutUri], [ClientClaimsPrefix], [ClientId], [ClientName], [ClientUri], [ConsentLifetime], [Description], [EnableLocalLogin], [Enabled], [FrontChannelLogoutSessionRequired], [FrontChannelLogoutUri], [IdentityTokenLifetime], [IncludeJwtId], [LogoUri], [PairWiseSubjectSalt], [ProtocolType], [RefreshTokenExpiration], [RefreshTokenUsage], [RequireClientSecret], [RequireConsent], [RequirePkce], [SlidingRefreshTokenLifetime], [UpdateAccessTokenClaimsOnRefresh]) VALUES (1, 2592000, 24000, 0, 1, 1, 1, 1, 1, 1, 300, 1, N'1', N'client_', N'mvc', N'MVC Client', NULL, NULL, NULL, 1, 1, 1, NULL, 300, 0, NULL, NULL, N'oidc', 1, 1, 1, 1, 0, 1296000, 0)
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[ClientScopes] ON 

INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (1, 1, N'openid')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (3, 1, N'api1')
INSERT [dbo].[ClientScopes] ([Id], [ClientId], [Scope]) VALUES (4, 1, N'profile')
SET IDENTITY_INSERT [dbo].[ClientScopes] OFF
SET IDENTITY_INSERT [dbo].[ClientSecrets] ON 

INSERT [dbo].[ClientSecrets] ([Id], [ClientId], [Description], [Expiration], [Type], [Value]) VALUES (1, 1, NULL, NULL, N'SharedSecret', N'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=')
SET IDENTITY_INSERT [dbo].[ClientSecrets] OFF
SET IDENTITY_INSERT [dbo].[IdentityClaims] ON 

INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (1, 1, N'openid')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (2, 2, N'profile')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (3, 3, N'actor')
INSERT [dbo].[IdentityClaims] ([Id], [IdentityResourceId], [Type]) VALUES (4, 4, N'BC_Address')
SET IDENTITY_INSERT [dbo].[IdentityClaims] OFF
SET IDENTITY_INSERT [dbo].[IdentityResources] ON 

INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (1, N'openid', N'openid', 1, 1, N'openid', 1, 1)
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (2, N'profile', N'profile', 1, 1, N'profile', 1, 1)
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (3, N'actor', N'actor', 1, 1, N'actor', 1, 1)
INSERT [dbo].[IdentityResources] ([Id], [Description], [DisplayName], [Emphasize], [Enabled], [Name], [Required], [ShowInDiscoveryDocument]) VALUES (4, N'BC_Address', N'BC_Address', 1, 1, N'BC_Address', 1, 1)
SET IDENTITY_INSERT [dbo].[IdentityResources] OFF
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'0x7CPCcKNYIY3enrfKOGlsKGJeSxIWx3Rqxo3NzW/qw=', N'mvc', CAST(N'2018-11-27T14:03:03.0000000' AS DateTime2), N'{"CreationTime":"2018-11-27T14:03:03Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-27T14:03:03Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543327381","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-27T14:03:03.0000000' AS DateTime2), N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'4tQnLSfPNGTS3eyQub6QzIKNBnG9fIYGeq8EBQ2T6pc=', N'mvc', CAST(N'2018-11-24T14:30:15.0000000' AS DateTime2), N'{"CreationTime":"2018-11-24T14:30:15Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-24T14:30:15Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543069811","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-24T14:30:15.0000000' AS DateTime2), N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'9JRr9sKs4Ub3+/KjWWUwrcWPiFScrpPjDbNGa/XCODg=', N'mvc', CAST(N'2018-11-28T14:21:41.0000000' AS DateTime2), N'{"CreationTime":"2018-11-28T14:21:41Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-28T14:21:41Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543414899","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-28T14:21:41.0000000' AS DateTime2), N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'amnozh1IxSjzvWpbFo5g6yRw8nj1sCBsg2x2rVJQDnw=', N'mvc', CAST(N'2018-11-27T14:05:19.0000000' AS DateTime2), N'{"CreationTime":"2018-11-27T14:05:19Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-27T14:05:19Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"282c235b-dbbe-47aa-8a75-9127b6775e38","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543327504","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account03@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account03@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account03@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account03@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x17bd4Bc4cf6BE0F368Bb74e23e969A773A3dD187","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-27T14:05:19.0000000' AS DateTime2), N'282c235b-dbbe-47aa-8a75-9127b6775e38', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'C01KBZdRTrk3ptBppbw2HA4GoG4GYkYOHvDJBsS8Sus=', N'mvc', CAST(N'2018-12-14T11:04:51.0000000' AS DateTime2), N'{"CreationTime":"2018-12-14T11:04:51Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-12-14T11:04:51Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1544785488","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2019-01-13T11:04:51.0000000' AS DateTime2), N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'frpA2YCs7v2K6ztz3SSOXnbkpD9q8K8HglFmjA19x3U=', N'mvc', CAST(N'2018-12-14T09:41:12.0000000' AS DateTime2), N'{"CreationTime":"2018-12-14T09:41:12Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-12-14T09:41:12Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1544780468","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2019-01-13T09:41:12.0000000' AS DateTime2), N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'g/j8FcW2IXTg7oEDirvpEeXh7dbPQ7oO0cYZSP0TqHw=', N'mvc', CAST(N'2018-11-26T10:48:42.0000000' AS DateTime2), N'{"CreationTime":"2018-11-26T10:48:42Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-26T10:48:42Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543229319","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-26T10:48:42.0000000' AS DateTime2), N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'gjIu8uqg+ytJPRcwiQXvzt9cyoNBLhZnS7hnRPW85N8=', N'mvc', CAST(N'2018-11-26T10:43:07.0000000' AS DateTime2), N'{"CreationTime":"2018-11-26T10:43:07Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-26T10:43:07Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543228984","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-26T10:43:07.0000000' AS DateTime2), N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'GldXSxJkHhIhKe2aZYpCYwYIJhUXwaYgPI98O5KVew0=', N'mvc', CAST(N'2018-11-26T12:35:59.0000000' AS DateTime2), N'{"CreationTime":"2018-11-26T12:35:59Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-26T12:35:59Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"6f8a91e8-812b-47a4-96e5-3eedc95e151d","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543235755","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x33977B2a6Aa39daD4bf49c0861Caa8eED666562B","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-26T12:35:59.0000000' AS DateTime2), N'6f8a91e8-812b-47a4-96e5-3eedc95e151d', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'GpoVZZ2aOs1/QhzwpVu0gvYQVUAsNzK4tJXJ9e2jMng=', N'mvc', CAST(N'2018-11-28T14:27:30.0000000' AS DateTime2), N'{"SubjectId":"6f8a91e8-812b-47a4-96e5-3eedc95e151d","ClientId":"mvc","Scopes":["openid","profile","api1","offline_access"],"CreationTime":"2018-11-28T14:27:30Z","Expiration":null}', NULL, N'6f8a91e8-812b-47a4-96e5-3eedc95e151d', N'user_consent')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'Nez5CIre8+Yz++UX1368LmtVYVoAl7LsyyEr4szLjow=', N'mvc', CAST(N'2018-11-27T14:07:00.0000000' AS DateTime2), N'{"CreationTime":"2018-11-27T14:07:00Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-27T14:07:00Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"6f8a91e8-812b-47a4-96e5-3eedc95e151d","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543327618","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x33977B2a6Aa39daD4bf49c0861Caa8eED666562B","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-27T14:07:00.0000000' AS DateTime2), N'6f8a91e8-812b-47a4-96e5-3eedc95e151d', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'tgAWz/Ft7Ruhv7gSeURCLOo2MWzpAS01kyR2tAonGqk=', N'mvc', CAST(N'2018-11-28T09:52:28.0000000' AS DateTime2), N'{"CreationTime":"2018-11-28T09:52:28Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-28T09:52:28Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543398745","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account00@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x4531a0548363f04ACf1CDbccf97cB41e7E1f831a","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-28T09:52:28.0000000' AS DateTime2), N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'tZvnkqUOGdiVpTn+kt6MF87iPaOQhMqxhaPhOGqsPL8=', N'mvc', CAST(N'2018-11-28T14:27:30.0000000' AS DateTime2), N'{"CreationTime":"2018-11-28T14:27:30Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-28T14:27:30Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"6f8a91e8-812b-47a4-96e5-3eedc95e151d","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543415249","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account09@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x33977B2a6Aa39daD4bf49c0861Caa8eED666562B","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-28T14:27:30.0000000' AS DateTime2), N'6f8a91e8-812b-47a4-96e5-3eedc95e151d', N'refresh_token')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'V1ax0b8Xq6UfB45pQbOcW0zl0hpu08B5nhUWahj39NI=', N'mvc', CAST(N'2018-12-14T11:04:50.0000000' AS DateTime2), N'{"SubjectId":"ac223ef5-cc4c-4802-9a61-6b416752caf2","ClientId":"mvc","Scopes":["openid","profile","api1","offline_access"],"CreationTime":"2018-12-14T11:04:50Z","Expiration":null}', NULL, N'ac223ef5-cc4c-4802-9a61-6b416752caf2', N'user_consent')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'WNEOk38zPazJADG5y+aGrcz5Ll5DrYlQdD35iixOS6s=', N'mvc', CAST(N'2018-11-27T14:05:19.0000000' AS DateTime2), N'{"SubjectId":"282c235b-dbbe-47aa-8a75-9127b6775e38","ClientId":"mvc","Scopes":["openid","profile","api1","offline_access"],"CreationTime":"2018-11-27T14:05:19Z","Expiration":null}', NULL, N'282c235b-dbbe-47aa-8a75-9127b6775e38', N'user_consent')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'x+IRbBOJe527LeQp6I19QrphKkXMe9UiKqjLoKJDJyM=', N'mvc', CAST(N'2018-06-24T18:06:02.0000000' AS DateTime2), N'{"SubjectId":"4f532e9a-7a02-4d1c-9a7b-d48cc08276a6","ClientId":"mvc","Scopes":["openid","profile","api1","offline_access"],"CreationTime":"2018-06-24T18:06:02Z","Expiration":null}', NULL, N'4f532e9a-7a02-4d1c-9a7b-d48cc08276a6', N'user_consent')
INSERT [dbo].[PersistedGrants] ([Key], [ClientId], [CreationTime], [Data], [Expiration], [SubjectId], [Type]) VALUES (N'xVT+xa/ixbDGKjS3KLcs20BYFLocHKmanGRTqX/6roc=', N'mvc', CAST(N'2018-11-26T12:33:50.0000000' AS DateTime2), N'{"CreationTime":"2018-11-26T12:33:50Z","Lifetime":2592000,"AccessToken":{"Audiences":["https://localhost:44341/resources","api1"],"Issuer":"https://localhost:44341","CreationTime":"2018-11-26T12:33:50Z","Lifetime":24000,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"282c235b-dbbe-47aa-8a75-9127b6775e38","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1543235628","ValueType":"http://www.w3.org/2001/XMLSchema#integer"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"pwd","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"account03@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account03@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"given_name","Value":"account03@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"email","Value":"account03@pomiager.com","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"BC_Address","Value":"0x17bd4Bc4cf6BE0F368Bb74e23e969A773A3dD187","ValueType":"http://www.w3.org/2001/XMLSchema#string"}],"Version":4},"Version":4}', CAST(N'2018-12-26T12:33:50.0000000' AS DateTime2), N'282c235b-dbbe-47aa-8a75-9127b6775e38', N'refresh_token')
/****** Object:  Index [IX_ApiClaims_ApiResourceId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ApiClaims_ApiResourceId] ON [dbo].[ApiClaims]
(
	[ApiResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApiResources_Name]    Script Date: 17/12/2018 23:21:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ApiResources_Name] ON [dbo].[ApiResources]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ApiScopeClaims_ApiScopeId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ApiScopeClaims_ApiScopeId] ON [dbo].[ApiScopeClaims]
(
	[ApiScopeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ApiScopes_ApiResourceId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ApiScopes_ApiResourceId] ON [dbo].[ApiScopes]
(
	[ApiResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApiScopes_Name]    Script Date: 17/12/2018 23:21:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ApiScopes_Name] ON [dbo].[ApiScopes]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ApiSecrets_ApiResourceId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ApiSecrets_ApiResourceId] ON [dbo].[ApiSecrets]
(
	[ApiResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 17/12/2018 23:21:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 17/12/2018 23:21:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientClaims_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientClaims_ClientId] ON [dbo].[ClientClaims]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientCorsOrigins_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientCorsOrigins_ClientId] ON [dbo].[ClientCorsOrigins]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientGrantTypes_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientGrantTypes_ClientId] ON [dbo].[ClientGrantTypes]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientIdPRestrictions_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientIdPRestrictions_ClientId] ON [dbo].[ClientIdPRestrictions]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientPostLogoutRedirectUris_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientPostLogoutRedirectUris_ClientId] ON [dbo].[ClientPostLogoutRedirectUris]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientProperties_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientProperties_ClientId] ON [dbo].[ClientProperties]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientRedirectUris_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientRedirectUris_ClientId] ON [dbo].[ClientRedirectUris]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Clients_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clients_ClientId] ON [dbo].[Clients]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientScopes_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientScopes_ClientId] ON [dbo].[ClientScopes]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientSecrets_ClientId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_ClientSecrets_ClientId] ON [dbo].[ClientSecrets]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdentityClaims_IdentityResourceId]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_IdentityClaims_IdentityResourceId] ON [dbo].[IdentityClaims]
(
	[IdentityResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityResources_Name]    Script Date: 17/12/2018 23:21:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IdentityResources_Name] ON [dbo].[IdentityResources]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PersistedGrants_SubjectId_ClientId_Type]    Script Date: 17/12/2018 23:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_SubjectId_ClientId_Type] ON [dbo].[PersistedGrants]
(
	[SubjectId] ASC,
	[ClientId] ASC,
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApiClaims]  WITH CHECK ADD  CONSTRAINT [FK_ApiClaims_ApiResources_ApiResourceId] FOREIGN KEY([ApiResourceId])
REFERENCES [dbo].[ApiResources] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApiClaims] CHECK CONSTRAINT [FK_ApiClaims_ApiResources_ApiResourceId]
GO
ALTER TABLE [dbo].[ApiScopeClaims]  WITH CHECK ADD  CONSTRAINT [FK_ApiScopeClaims_ApiScopes_ApiScopeId] FOREIGN KEY([ApiScopeId])
REFERENCES [dbo].[ApiScopes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApiScopeClaims] CHECK CONSTRAINT [FK_ApiScopeClaims_ApiScopes_ApiScopeId]
GO
ALTER TABLE [dbo].[ApiScopes]  WITH CHECK ADD  CONSTRAINT [FK_ApiScopes_ApiResources_ApiResourceId] FOREIGN KEY([ApiResourceId])
REFERENCES [dbo].[ApiResources] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApiScopes] CHECK CONSTRAINT [FK_ApiScopes_ApiResources_ApiResourceId]
GO
ALTER TABLE [dbo].[ApiSecrets]  WITH CHECK ADD  CONSTRAINT [FK_ApiSecrets_ApiResources_ApiResourceId] FOREIGN KEY([ApiResourceId])
REFERENCES [dbo].[ApiResources] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApiSecrets] CHECK CONSTRAINT [FK_ApiSecrets_ApiResources_ApiResourceId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ClientClaims]  WITH CHECK ADD  CONSTRAINT [FK_ClientClaims_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientClaims] CHECK CONSTRAINT [FK_ClientClaims_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientCorsOrigins]  WITH CHECK ADD  CONSTRAINT [FK_ClientCorsOrigins_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientCorsOrigins] CHECK CONSTRAINT [FK_ClientCorsOrigins_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientGrantTypes]  WITH CHECK ADD  CONSTRAINT [FK_ClientGrantTypes_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientGrantTypes] CHECK CONSTRAINT [FK_ClientGrantTypes_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientIdPRestrictions]  WITH CHECK ADD  CONSTRAINT [FK_ClientIdPRestrictions_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientIdPRestrictions] CHECK CONSTRAINT [FK_ClientIdPRestrictions_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientPostLogoutRedirectUris]  WITH CHECK ADD  CONSTRAINT [FK_ClientPostLogoutRedirectUris_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientPostLogoutRedirectUris] CHECK CONSTRAINT [FK_ClientPostLogoutRedirectUris_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientProperties]  WITH CHECK ADD  CONSTRAINT [FK_ClientProperties_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientProperties] CHECK CONSTRAINT [FK_ClientProperties_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientRedirectUris]  WITH CHECK ADD  CONSTRAINT [FK_ClientRedirectUris_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientRedirectUris] CHECK CONSTRAINT [FK_ClientRedirectUris_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientScopes]  WITH CHECK ADD  CONSTRAINT [FK_ClientScopes_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientScopes] CHECK CONSTRAINT [FK_ClientScopes_Clients_ClientId]
GO
ALTER TABLE [dbo].[ClientSecrets]  WITH CHECK ADD  CONSTRAINT [FK_ClientSecrets_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientSecrets] CHECK CONSTRAINT [FK_ClientSecrets_Clients_ClientId]
GO
ALTER TABLE [dbo].[IdentityClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityClaims_IdentityResources_IdentityResourceId] FOREIGN KEY([IdentityResourceId])
REFERENCES [dbo].[IdentityResources] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityClaims] CHECK CONSTRAINT [FK_IdentityClaims_IdentityResources_IdentityResourceId]
GO
USE [master]
GO
ALTER DATABASE [SCTSDB] SET  READ_WRITE 
GO
