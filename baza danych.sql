USE [master]
GO

/****** Object:  Database [FilmyDB]    Script Date: 2021-02-17 18:45:00 ******/
CREATE DATABASE [FilmyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FilmyDB_Data', FILENAME = N'C:\Users\rawin\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\FilmyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FilmyDB_Log', FILENAME = N'C:\Users\rawin\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\FilmyDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FilmyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [FilmyDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [FilmyDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [FilmyDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [FilmyDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [FilmyDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [FilmyDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [FilmyDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [FilmyDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [FilmyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [FilmyDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [FilmyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [FilmyDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [FilmyDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [FilmyDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [FilmyDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [FilmyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [FilmyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [FilmyDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [FilmyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [FilmyDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [FilmyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [FilmyDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [FilmyDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [FilmyDB] SET  MULTI_USER 
GO

ALTER DATABASE [FilmyDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [FilmyDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [FilmyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [FilmyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [FilmyDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [FilmyDB] SET QUERY_STORE = OFF
GO

USE [FilmyDB]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [FilmyDB] SET  READ_WRITE 
GO
