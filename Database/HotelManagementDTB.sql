USE [master]
GO
/****** Object:  Database [HotelManagement]    Script Date: 7/10/2022 12:46:25 AM ******/
CREATE DATABASE [HotelManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.FANNABY\MSSQL\DATA\HotelManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.FANNABY\MSSQL\DATA\HotelManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelManagement] SET  MULTI_USER 
GO
ALTER DATABASE [HotelManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelManagement', N'ON'
GO
ALTER DATABASE [HotelManagement] SET QUERY_STORE = OFF
GO
USE [HotelManagement]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/10/2022 12:46:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[datecheckout] [datetime] NOT NULL,
	[datecheckin] [datetime] NOT NULL,
	[idRoom] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/10/2022 12:46:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[detailid] [int] IDENTITY(1,1) NOT NULL,
	[roomid] [int] NOT NULL,
	[orderid] [int] NOT NULL,
	[serviceid] [int] NOT NULL,
	[totalprice] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[detailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 7/10/2022 12:46:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomid] [int] IDENTITY(1,1) NOT NULL,
	[roomname] [nvarchar](max) NULL,
	[categoryid] [int] NOT NULL,
	[status] [nvarchar](max) NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roomid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomCategory]    Script Date: 7/10/2022 12:46:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomCategory](
	[categoryid] [int] IDENTITY(1,1) NOT NULL,
	[categoryname] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 7/10/2022 12:46:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[serviceid] [int] IDENTITY(1,1) NOT NULL,
	[servicename] [nvarchar](max) NOT NULL,
	[price] [float] NOT NULL,
	[date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[serviceid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [datecheckin]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT ((0)) FOR [totalprice]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (N'Chua dat ten') FOR [roomname]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[RoomCategory] ADD  DEFAULT (N'Chua dat ten') FOR [categoryname]
GO
ALTER TABLE [dbo].[Service] ADD  DEFAULT (N'Chua co ten') FOR [servicename]
GO
ALTER TABLE [dbo].[Service] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([orderid])
REFERENCES [dbo].[Order] ([orderid])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([roomid])
REFERENCES [dbo].[Room] ([roomid])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([serviceid])
REFERENCES [dbo].[Service] ([serviceid])
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([categoryid])
REFERENCES [dbo].[RoomCategory] ([categoryid])
GO
USE [master]
GO
ALTER DATABASE [HotelManagement] SET  READ_WRITE 
GO
