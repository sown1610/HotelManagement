USE [master]
GO
/****** Object:  Database [HotelManagement]    Script Date: 7/14/2022 11:06:53 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 7/14/2022 11:06:54 PM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 7/14/2022 11:06:54 PM ******/
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
	[discount] [int] NULL,
 CONSTRAINT [PK__Order__080E3775F26594BC] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/14/2022 11:06:54 PM ******/
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
/****** Object:  Table [dbo].[Room]    Script Date: 7/14/2022 11:06:54 PM ******/
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
/****** Object:  Table [dbo].[RoomCategory]    Script Date: 7/14/2022 11:06:54 PM ******/
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
/****** Object:  Table [dbo].[Service]    Script Date: 7/14/2022 11:06:54 PM ******/
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

INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (33, CAST(N'2022-07-14T16:40:04.950' AS DateTime), NULL, 6, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (34, CAST(N'2022-07-14T16:40:08.433' AS DateTime), NULL, 8, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (35, CAST(N'2022-07-14T16:40:12.513' AS DateTime), NULL, 12, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (36, CAST(N'2022-07-14T16:40:50.037' AS DateTime), NULL, 5, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (37, CAST(N'2022-07-14T16:42:29.747' AS DateTime), NULL, 8, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (38, CAST(N'2022-07-14T16:45:15.280' AS DateTime), NULL, 8, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (39, CAST(N'2022-07-14T17:05:22.087' AS DateTime), NULL, 8, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (40, CAST(N'2022-07-14T17:09:41.630' AS DateTime), NULL, 5, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (41, CAST(N'2022-07-14T17:49:28.197' AS DateTime), NULL, 6, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (42, CAST(N'2022-07-14T17:56:20.790' AS DateTime), NULL, 8, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (43, CAST(N'2022-07-14T17:56:26.197' AS DateTime), NULL, 6, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (44, CAST(N'2022-07-14T17:56:32.743' AS DateTime), NULL, 5, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (45, CAST(N'2022-07-14T18:01:35.470' AS DateTime), NULL, 8, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (46, CAST(N'2022-07-14T18:01:36.593' AS DateTime), NULL, 6, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (47, CAST(N'2022-07-14T18:01:37.660' AS DateTime), NULL, 5, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (48, CAST(N'2022-07-14T18:05:00.733' AS DateTime), NULL, 6, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (49, CAST(N'2022-07-14T18:05:19.067' AS DateTime), NULL, 9, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (50, CAST(N'2022-07-14T18:05:20.440' AS DateTime), NULL, 12, 1, 50)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (51, CAST(N'2022-07-14T18:05:21.890' AS DateTime), NULL, 11, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (52, CAST(N'2022-07-14T18:05:23.360' AS DateTime), NULL, 8, 1, 50)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (53, CAST(N'2022-07-14T18:05:25.227' AS DateTime), NULL, 5, 1, 50)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (54, CAST(N'2022-07-14T18:05:26.210' AS DateTime), NULL, 3, 1, 50)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (55, CAST(N'2022-07-14T18:05:27.203' AS DateTime), NULL, 1, 1, 20)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (56, CAST(N'2022-07-14T19:25:22.467' AS DateTime), NULL, 6, 1, 20)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (57, CAST(N'2022-07-14T19:26:59.243' AS DateTime), NULL, 8, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (58, CAST(N'2022-07-14T19:27:02.980' AS DateTime), NULL, 3, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (59, CAST(N'2022-07-14T21:47:17.927' AS DateTime), NULL, 1, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (60, CAST(N'2022-07-14T22:10:43.780' AS DateTime), NULL, 3, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (61, CAST(N'2022-07-14T22:37:39.823' AS DateTime), NULL, 9, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (62, CAST(N'2022-07-14T22:38:03.843' AS DateTime), NULL, 5, 1, 0)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount]) VALUES (63, CAST(N'2022-07-14T22:38:07.197' AS DateTime), NULL, 6, 1, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (75, 33, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (76, 34, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (77, 35, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (78, 36, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (79, 36, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (80, 36, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (81, 36, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (82, 34, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (83, 37, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (84, 37, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (85, 38, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (86, 35, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (87, 33, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (88, 38, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (91, 39, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (92, 39, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (93, 33, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (94, 40, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (95, 41, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (96, 42, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (97, 43, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (98, 44, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (99, 45, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (100, 46, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (101, 47, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (102, 48, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (103, 49, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (104, 50, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (105, 51, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (106, 52, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (107, 53, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (108, 54, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (109, 55, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (110, 56, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (111, 57, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (112, 58, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (113, 59, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (114, 59, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (115, 59, 2)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (116, 59, 5)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (117, 60, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (118, 60, 1)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (119, 61, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (120, 61, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (121, 62, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (122, 63, 3)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (123, 61, 4)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (1, N'Phòng 101', 1, N'Trống', 3500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (3, N'Phòng 102', 2, N'Trống', 4500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (5, N'Phòng 103', 3, N'Trống', 5000000)
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
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (6, N'Check in room', 0)
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
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 7/14/2022 11:06:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_GetRoomList]    Script Date: 7/14/2022 11:06:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetRoomList]
as	select * from Room
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 7/14/2022 11:06:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_InsertOrder]    Script Date: 7/14/2022 11:06:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_InsertOrderDetail]    Script Date: 7/14/2022 11:06:54 PM ******/
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
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 7/14/2022 11:06:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_SwitchRoom1]    Script Date: 7/14/2022 11:06:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_SwitchRoom1]
@id1 int, @id2 int
AS
BEGIN
	DECLARE @idBill1 int
	DECLARE @idBill2 int

	SELECT @idBill1 = orderid FROM dbo.[Order] WHERE dbo.[Order].idRoom = @id1 AND STATUS = 0
	SELECT @idBill2 = orderid FROM dbo.[Order] WHERE dbo.[Order].idRoom = @id2 AND STATUS = 0

	UPDATE dbo.[Order] SET dbo.[Order].idRoom = @id2 WHERE orderid = @idBill1
	UPDATE dbo.Room	SET status = N'Trống'	WHERE @id1 = roomid
	UPDATE dbo.[Order] SET dbo.[Order].idRoom = @id1 WHERE orderid = @idBill2
	UPDATE dbo.Room	SET status = N'Có Người' WHERE @id2 = roomid
END
GO
/****** Object:  Trigger [dbo].[UTG_UpdateOrder]    Script Date: 7/14/2022 11:06:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[UTG_UpdateOrder]
ON [dbo].[Order] FOR UPDATE
AS 
BEGIN
--DECLARE @idBill INT;
--    SELECT @idBill = idBill
--    FROM inserted;

    DECLARE @orderid  INT
	SELECT @orderid = Inserted.orderid
	FROM Inserted

	DECLARE @serviceid INT
	SELECT @serviceid = serviceid
	FROM dbo.Service
	WHERE @serviceid = serviceid

	--    DECLARE @idTable INT;
--    SELECT @idTable = idTable
--    FROM dbo.Bill
--    WHERE idBill = @idBill;
	DECLARE @roomid INT
	SELECT @roomid = idRoom 
	FROM dbo.[Order]
	WHERE orderid = @orderid ;
	--	UPDATE dbo.TableCoffee SET status = N'Trống' WHERE idTable = @idTable
	UPDATE dbo.Room SET status = N'Trống' WHERE roomid = @roomid
END
GO
ALTER TABLE [dbo].[Order] ENABLE TRIGGER [UTG_UpdateOrder]
GO
/****** Object:  Trigger [dbo].[UTG_UpdateOrderDetail]    Script Date: 7/14/2022 11:06:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[UTG_UpdateOrderDetail]
ON [dbo].[OrderDetail] FOR INSERT,UPDATE
AS
BEGIN
    DECLARE @orderid INT
	 SELECT @orderid = Inserted.orderid FROM Inserted	
	DECLARE @roomid INT
	SELECT @roomid = idRoom 
	FROM dbo.[Order] 
	WHERE orderid = @orderid AND status = 0 ;
	UPDATE dbo.Room
	SET status = N'Có người'
	WHERE @roomid = roomid
END
GO
ALTER TABLE [dbo].[OrderDetail] ENABLE TRIGGER [UTG_UpdateOrderDetail]
GO
USE [master]
GO
ALTER DATABASE [HotelManagement] SET  READ_WRITE 
GO
