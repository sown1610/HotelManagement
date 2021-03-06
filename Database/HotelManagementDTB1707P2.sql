USE [master]
GO
/****** Object:  Database [HotelManagement]    Script Date: 7/17/2022 4:39:37 PM ******/
CREATE DATABASE [HotelManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HotelManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HotelManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 7/17/2022 4:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/17/2022 4:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [nvarchar](100) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[displayname] [nvarchar](max) NOT NULL,
	[type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/17/2022 4:39:37 PM ******/
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
	[totalPrice] [float] NULL,
 CONSTRAINT [PK__Order__080E3775F26594BC] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  Table [dbo].[Room]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  Table [dbo].[RoomCategory]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  Table [dbo].[Service]    Script Date: 7/17/2022 4:39:37 PM ******/
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
INSERT [dbo].[Account] ([username], [password], [displayname], [type]) VALUES (N'sa', N'sa', N'sa', 1)
INSERT [dbo].[Account] ([username], [password], [displayname], [type]) VALUES (N'staff', N'0', N'staff', 0)
INSERT [dbo].[Account] ([username], [password], [displayname], [type]) VALUES (N'staff1', N'0', N'staffxyz', 0)
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount], [totalPrice]) VALUES (71, CAST(N'2022-07-14T23:39:24.247' AS DateTime), CAST(N'2022-07-14T23:39:37.387' AS DateTime), 5, 1, 0, 15850000)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount], [totalPrice]) VALUES (72, CAST(N'2022-07-14T23:39:26.587' AS DateTime), CAST(N'2022-07-14T23:39:54.557' AS DateTime), 6, 1, 10, 16380000)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount], [totalPrice]) VALUES (73, CAST(N'2022-07-14T23:39:28.277' AS DateTime), CAST(N'2022-07-14T23:39:49.957' AS DateTime), 3, 1, 10, 8280000)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount], [totalPrice]) VALUES (74, CAST(N'2022-07-15T00:17:39.463' AS DateTime), CAST(N'2022-07-15T00:17:41.270' AS DateTime), 3, 1, 0, 9700000)
INSERT [dbo].[Order] ([orderid], [datecheckin], [datecheckout], [idRoom], [status], [discount], [totalPrice]) VALUES (75, CAST(N'2022-07-16T20:51:25.647' AS DateTime), NULL, 6, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (140, 72, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (141, 72, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (142, 73, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (143, 73, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (144, 71, 4)
INSERT [dbo].[OrderDetail] ([detailid], [orderid], [serviceid]) VALUES (145, 71, 3)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (1, N'Phòng 101', 1, N'Trống', 3500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (3, N'Phòng 102', 2, N'Trống', 4500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (5, N'Phòng 103', 3, N'Trống', 5000000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (6, N'Phòng 104', 4, N'Có người', 9000000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (8, N'Phòng 201', 1, N'Trống', 3500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (9, N'Phòng 202', 2, N'Trống', 4500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (16, N'Phòng 333', 4, N'0', 3500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (18, N'Phòng 999', 4, N'0', 3500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (19, N'Phongf ty', 4, N'0', 3500000)
INSERT [dbo].[Room] ([roomid], [roomname], [categoryid], [status], [roomprice]) VALUES (21, N'abc', 1, N'0', 0)
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

INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (2, N'Xe đưa đón sân bay', 700000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (3, N'Thuê xe máy tự lái', 400000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (4, N'Thu đổi ngoại tệ', 100000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (5, N'Dịch vụ Spa', 550000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (6, N'Check in room', 100000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (14, N'Giặt ủi quần áo', 350000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (15, N'Giặt ủi quần áo as', 350000)
INSERT [dbo].[Service] ([serviceid], [servicename], [serviceprice]) VALUES (23, N'Đá trứng cút', 6900000)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [password]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [type]
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
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_GetListOrderByDate]    Script Date: 7/17/2022 4:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetListOrderByDate]
@checkIn date, @checkOut date
as
begin

select r.roomname as [Tên bàn], o.totalPrice as [Tổng tiền], datecheckin as [Ngày vào], datecheckout as [Ngày ra], discount [Giảm giá]
from [Order] as o, Room as r, OrderDetail as od, Service as s where datecheckin >= @checkIn and datecheckout <= @checkOut and o.status = 1 
and r.roomid = o.idRoom and od.orderid = o.orderid and od.serviceid = s.serviceid

end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetRoomList]    Script Date: 7/17/2022 4:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetRoomList]
as	select * from Room
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_InsertOrder]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_InsertOrderDetail]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_SwitchRoom1]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 7/17/2022 4:39:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE username = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE username = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE username = @userName
	end
END
GO
/****** Object:  Trigger [dbo].[UTG_UpdateOrder]    Script Date: 7/17/2022 4:39:37 PM ******/
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
/****** Object:  Trigger [dbo].[UTG_UpdateOrderDetail]    Script Date: 7/17/2022 4:39:38 PM ******/
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
