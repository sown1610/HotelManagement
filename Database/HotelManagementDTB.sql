USE [master]
GO
/****** Object:  Database [HotelManagement]    Script Date: 7/14/2022 1:35:16 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [nvarchar](100) NOT NULL,
	[phone] [int] NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[displayname] [nvarchar](max) NOT NULL,
	[type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[datecheckin] [datetime] NOT NULL,
	[datecheckout] [datetime] NULL,
	[idRoom] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK__Order__080E3775F26594BC] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[detailid] [int] IDENTITY(1,1) NOT NULL,
	[orderid] [int] NOT NULL,
	[serviceid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[detailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomid] [int] IDENTITY(1,1) NOT NULL,
	[roomname] [nvarchar](max) NULL,
	[categoryid] [int] NOT NULL,
	[status] [nvarchar](max) NOT NULL,
	[roomprice] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roomid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomCategory]    Script Date: 7/14/2022 1:35:16 PM ******/
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
/****** Object:  Table [dbo].[Service]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[serviceid] [int] IDENTITY(1,1) NOT NULL,
	[servicename] [nvarchar](max) NOT NULL,
	[serviceprice] [float] NOT NULL,
 CONSTRAINT [PK__Service__45516CA726CE1960] PRIMARY KEY CLUSTERED 
(
	[serviceid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Account] ([username], [phone], [password], [displayname], [type]) VALUES (N'sa', 0, N'sa', N'sa', 1)
INSERT [dbo].[Account] ([username], [phone], [password], [displayname], [type]) VALUES (N'staff', 0, N'staff', N'staff', 1)
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status]) VALUES (22, CAST(N'2022-07-14T10:43:51.913' AS DateTime), NULL, 1, 1)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status]) VALUES (23, CAST(N'2022-07-14T10:48:27.920' AS DateTime), NULL, 6, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status]) VALUES (24, CAST(N'2022-07-14T13:00:32.200' AS DateTime), NULL, 9, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status]) VALUES (25, CAST(N'2022-07-14T13:16:24.390' AS DateTime), NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (54, 22, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (57, 22, 5)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (58, 22, 2)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (1, N'Phòng 101', 1, N'Trống', 3500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (3, N'Phòng 102', 2, N'Trống', 4500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (5, N'Phòng 103', 3, N'Có người', 5000000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (6, N'Phòng 104', 4, N'Trống', 9000000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (8, N'Phòng 201', 1, N'Trống', 3500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (9, N'Phòng 202', 2, N'Trống', 4500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (11, N'Phòng 203', 3, N'Trống', 5000000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (12, N'Phòng 204', 4, N'Trống', 9000000)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomCategory] ON 

INSERT [dbo].[RoomCategory] ([categoryid], [categoryname]) VALUES (1, N'Phòng đơn')
INSERT [dbo].[RoomCategory] ([categoryid], [categoryname]) VALUES (2, N'Phòng dorm')
INSERT [dbo].[RoomCategory] ([categoryid], [categoryname]) VALUES (3, N'Phòng gia đình')
INSERT [dbo].[RoomCategory] ([categoryid], [categoryname]) VALUES (4, N'Phòng đôi')
SET IDENTITY_INSERT [dbo].[RoomCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (1, N'Giặt ủi quần áo', 350000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (2, N'Xe đưa đón sân bay', 700000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (3, N'Thuê xe máy tự lái', 400000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (4, N'Thu đổi ngoại tệ', 100000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (5, N'Dịch vụ Spa', 550000)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF__Order__datecheck__2C3393D0]  DEFAULT (getdate()) FOR [datecheckin]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF__Order__status__2D27B809]  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (N'Chua dat ten') FOR [roomname]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[RoomCategory] ADD  DEFAULT (N'Chua dat ten') FOR [categoryname]
GO
ALTER TABLE [dbo].[Service] ADD  CONSTRAINT [DF__Service__service__31EC6D26]  DEFAULT (N'Chua co ten') FOR [servicename]
GO
ALTER TABLE [dbo].[Service] ADD  CONSTRAINT [DF__Service__price__32E0915F]  DEFAULT ((0)) FOR [serviceprice]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__order__33D4B598] FOREIGN KEY([orderid])
REFERENCES [dbo].[Order] ([orderid])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__order__33D4B598]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__servi__35BCFE0A] FOREIGN KEY([serviceid])
REFERENCES [dbo].[Service] ([serviceid])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__servi__35BCFE0A]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([categoryid])
REFERENCES [dbo].[RoomCategory] ([categoryid])
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetAccountByUserName]
@username nvarchar(100)
as
begin
	select * from Account where username = @username
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetRoomList]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetRoomList]
as	select * from Room
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
@idRoom INT
AS
BEGIN
    INSERT dbo.[Order]
    (
        datecheckin,
        datecheckout,
        idRoom,
        status      
    )
    VALUES
    (   GETDATE(), -- datecheckin - datetime
        GETDATE(), -- datecheckout - datetime
        0,         -- idRoom - int
        0         -- status - int       
        )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertOrder]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertOrder]
@idRoom INT
AS 
BEGIN
	INSERT dbo.[Order]
	(
	    datecheckin,
	    datecheckout,
	    idRoom,
	    status
	)
	VALUES
	(   GETDATE(), -- datecheckin - datetime
	    null, -- datecheckout - datetime
	    @idRoom,         -- idRoom - int
	    0          -- status - int
	    )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertOrderDetail]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertOrderDetail]
 @orderid INT, @serviceid INT
 AS
 BEGIN
     INSERT dbo.OrderDetail
     (      
         orderid,
         serviceid
     )
     VALUES
     (   
         @orderid, -- orderid - int
         @serviceid  -- serviceid - int
         )
 END
 select * from [Order] where idRoom = 1 and status = 0
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 7/14/2022 1:35:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login]
@username nvarchar(100), @password nvarchar(100)
as
begin
	select * from Account where username = @username and password = @password
end
GO
USE [master]
GO
ALTER DATABASE [HotelManagement] SET  READ_WRITE 
GO
