USE [master]
GO

/****** Object:  Database [JSChatDB]    Script Date: 01/11/2021 15:50:15 ******/
CREATE DATABASE [JSChatDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JSChatDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JSChatDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JSChatDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JSChatDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JSChatDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [JSChatDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [JSChatDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [JSChatDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [JSChatDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [JSChatDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [JSChatDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [JSChatDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [JSChatDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [JSChatDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [JSChatDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [JSChatDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [JSChatDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [JSChatDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [JSChatDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [JSChatDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [JSChatDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [JSChatDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [JSChatDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [JSChatDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [JSChatDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [JSChatDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [JSChatDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [JSChatDB] SET RECOVERY FULL 
GO

ALTER DATABASE [JSChatDB] SET  MULTI_USER 
GO

ALTER DATABASE [JSChatDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [JSChatDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [JSChatDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [JSChatDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [JSChatDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [JSChatDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [JSChatDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [JSChatDB] SET  READ_WRITE 
GO

USE [JSChatDB]
GO
/****** Object:  Table [dbo].[tMessage]    Script Date: 01/11/2021 15:54:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](150) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[MDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
