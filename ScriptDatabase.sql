USE [master]
GO
/****** Object:  Database [FengShuiKoiDB]    Script Date: 11/20/2024 10:31:54 PM ******/
CREATE DATABASE [FengShuiKoiDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FengShuiKoiDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FengShuiKoiDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FengShuiKoiDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FengShuiKoiDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FengShuiKoiDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FengShuiKoiDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FengShuiKoiDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FengShuiKoiDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FengShuiKoiDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FengShuiKoiDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FengShuiKoiDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FengShuiKoiDB] SET  MULTI_USER 
GO
ALTER DATABASE [FengShuiKoiDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FengShuiKoiDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FengShuiKoiDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FengShuiKoiDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FengShuiKoiDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FengShuiKoiDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FengShuiKoiDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [FengShuiKoiDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FengShuiKoiDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/20/2024 10:31:55 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[UserRoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RecommendationID] [int] NULL,
	[CommentText] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultation]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultation](
	[ConsultID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[KoiID] [int] NULL,
	[PondID] [int] NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ConsultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiFish]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiFish](
	[KoiID] [int] IDENTITY(1,1) NOT NULL,
	[KoiName] [nvarchar](100) NOT NULL,
	[Color] [nvarchar](50) NULL,
	[SizeCM] [decimal](5, 2) NULL,
	[FengShuiMeaning] [nvarchar](255) NULL,
	[SuitableElement] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[KoiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiOwnership]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiOwnership](
	[OwnershipID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PondID] [int] NULL,
	[KoiID] [int] NULL,
	[Quantity] [int] NOT NULL,
	[PurchaseDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[OwnershipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiSpecies]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiSpecies](
	[KoiID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[SuitableElement] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageURL] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[KoiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentHistory]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentHistory](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PaymentAmount] [decimal](10, 2) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PondDetails]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PondDetails](
	[PondID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Location] [nvarchar](255) NULL,
	[WidthCM] [decimal](6, 2) NULL,
	[LengthCM] [decimal](6, 2) NULL,
	[DepthCM] [decimal](6, 2) NULL,
	[Shape] [nvarchar](50) NULL,
	[Direction] [nvarchar](50) NULL,
	[PondScore] [int] NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PondID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PondFeatures]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PondFeatures](
	[PondID] [int] IDENTITY(1,1) NOT NULL,
	[Shape] [nvarchar](50) NULL,
	[SuitableElement] [nvarchar](50) NULL,
	[Direction] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PondID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PondMaintenance]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PondMaintenance](
	[MaintenanceID] [int] IDENTITY(1,1) NOT NULL,
	[PondID] [int] NULL,
	[MaintenanceDate] [date] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[NextScheduledDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaintenanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recommendations]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recommendations](
	[RecommendationID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PondID] [int] NULL,
	[KoiID] [int] NULL,
	[RecommendationText] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RecommendationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/20/2024 10:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[BirthYear] [date] NOT NULL,
	[Element] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Consultation] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[PaymentHistory] ADD  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[PondDetails] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Recommendations] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_UserRoles] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRoles] ([RoleID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_UserRoles]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Recommendation] FOREIGN KEY([RecommendationID])
REFERENCES [dbo].[Recommendations] ([RecommendationID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comment_Recommendation]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD FOREIGN KEY([KoiID])
REFERENCES [dbo].[KoiSpecies] ([KoiID])
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD FOREIGN KEY([PondID])
REFERENCES [dbo].[PondFeatures] ([PondID])
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[KoiOwnership]  WITH CHECK ADD  CONSTRAINT [FK_Ownership_Koi] FOREIGN KEY([KoiID])
REFERENCES [dbo].[KoiFish] ([KoiID])
GO
ALTER TABLE [dbo].[KoiOwnership] CHECK CONSTRAINT [FK_Ownership_Koi]
GO
ALTER TABLE [dbo].[KoiOwnership]  WITH CHECK ADD  CONSTRAINT [FK_Ownership_Pond] FOREIGN KEY([PondID])
REFERENCES [dbo].[PondDetails] ([PondID])
GO
ALTER TABLE [dbo].[KoiOwnership] CHECK CONSTRAINT [FK_Ownership_Pond]
GO
ALTER TABLE [dbo].[KoiOwnership]  WITH CHECK ADD  CONSTRAINT [FK_Ownership_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[KoiOwnership] CHECK CONSTRAINT [FK_Ownership_User]
GO
ALTER TABLE [dbo].[PaymentHistory]  WITH CHECK ADD  CONSTRAINT [FK_Payment_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PaymentHistory] CHECK CONSTRAINT [FK_Payment_User]
GO
ALTER TABLE [dbo].[PondDetails]  WITH CHECK ADD  CONSTRAINT [FK_Pond_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PondDetails] CHECK CONSTRAINT [FK_Pond_User]
GO
ALTER TABLE [dbo].[PondMaintenance]  WITH CHECK ADD  CONSTRAINT [FK_Maintenance_Pond] FOREIGN KEY([PondID])
REFERENCES [dbo].[PondDetails] ([PondID])
GO
ALTER TABLE [dbo].[PondMaintenance] CHECK CONSTRAINT [FK_Maintenance_Pond]
GO
ALTER TABLE [dbo].[Recommendations]  WITH CHECK ADD  CONSTRAINT [FK_Recommendation_Koi] FOREIGN KEY([KoiID])
REFERENCES [dbo].[KoiFish] ([KoiID])
GO
ALTER TABLE [dbo].[Recommendations] CHECK CONSTRAINT [FK_Recommendation_Koi]
GO
ALTER TABLE [dbo].[Recommendations]  WITH CHECK ADD  CONSTRAINT [FK_Recommendation_Pond] FOREIGN KEY([PondID])
REFERENCES [dbo].[PondDetails] ([PondID])
GO
ALTER TABLE [dbo].[Recommendations] CHECK CONSTRAINT [FK_Recommendation_Pond]
GO
ALTER TABLE [dbo].[Recommendations]  WITH CHECK ADD  CONSTRAINT [FK_Recommendation_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Recommendations] CHECK CONSTRAINT [FK_Recommendation_User]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[UserRoles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO
USE [master]
GO
ALTER DATABASE [FengShuiKoiDB] SET  READ_WRITE 
GO

USE FengShuiKoiDB;
SET IDENTITY_INSERT PondFeatures ON;
INSERT INTO PondFeatures(PondID, Shape, SuitableElement, Direction, Description) VALUES
(1, N'Hình tròn', N'Kim', N'Tây', N'Hình tròn tượng trưng cho sự hoàn hảo và bền vững.'),
(2, N'Hình chữ nhật', N'Mộc', N'Đông', N'Hình chữ nhật biểu trưng cho sự phát triển và ổn định.'),
(3, N'Hình vuông', N'Thổ', N'Trung tâm', N'Hình vuông thể hiện sự kiên cố và mạnh mẽ.'),
(4, N'Hình tam giác', N'Hỏa', N'Nam', N'Hình tam giác đại diện cho năng lượng và sức mạnh.'),
(5, N'Hình oval', N'Kim', N'Tây Bắc', N'Hình oval mềm mại và uyển chuyển, hợp với sự hài hòa.'),
(6, N'Hình lục giác', N'Thổ', N'Trung tâm', N'Hình lục giác tượng trưng cho sự cân bằng và hòa hợp.'),
(7, N'Hình ngũ giác', N'Mộc', N'Đông Nam', N'Hình ngũ giác đại diện cho sự sáng tạo và đổi mới.'),
(8, N'Hình bán nguyệt', N'Thủy', N'Bắc', N'Hình bán nguyệt tượng trưng cho dòng chảy tự nhiên.'),
(9, N'Hình elip', N'Kim', N'Tây Nam', N'Hình elip đại diện cho sự ổn định và hài hòa.'),
(10, N'Hình trái tim', N'Hỏa', N'Nam', N'Hình trái tim biểu trưng cho tình cảm và sự ấm áp.'),
(11, N'Hình ngôi sao', N'Hỏa', N'Đông Bắc', N'Hình ngôi sao tượng trưng cho sự sáng tạo và nổi bật.'),
(12, N'Hình lượn sóng', N'Thủy', N'Bắc', N'Hình lượn sóng biểu hiện dòng chảy và sự linh hoạt.'),
(13, N'Hình bát giác', N'Thổ', N'Trung tâm', N'Hình bát giác thể hiện sự bảo vệ và ổn định.'),
(14, N'Hình giọt nước', N'Thủy', N'Đông Nam', N'Hình giọt nước mang ý nghĩa của sự sống và tươi mới.'),
(15, N'Hình tam giác ngược', N'Mộc', N'Tây', N'Hình tam giác ngược tượng trưng cho sự đổi mới và sức mạnh.'),
(16, N'Hình kim cương', N'Kim', N'Tây Nam', N'Hình kim cương biểu tượng cho sự quý giá và vững chắc.'),
(17, N'Hình chữ thập', N'Thổ', N'Trung tâm', N'Hình chữ thập đại diện cho sự kết nối và cân bằng.'),
(18, N'Hình lưỡi liềm', N'Thủy', N'Bắc', N'Hình lưỡi liềm tượng trưng cho chu kỳ và sự phát triển.'),
(19, N'Hình mũi tên', N'Hỏa', N'Nam', N'Hình mũi tên biểu hiện sự hướng tới và tiến bộ.'),
(20, N'Hình bánh xe', N'Kim', N'Tây Bắc', N'Hình bánh xe đại diện cho sự vận động và tuần hoàn.');
SET IDENTITY_INSERT PondFeatures OFF;

SET IDENTITY_INSERT KoiSpecies ON;
INSERT INTO KoiSpecies (KoiID, Name, SuitableElement, Description, ImageURL) VALUES
(1, N'Tancho', N'Thủy', N'Cá Tancho chỉ có một đốm đỏ trên đầu, tượng trưng cho quốc kỳ Nhật Bản và mang lại may mắn.', 'https://example.com/images/tancho.jpg'),
(2, N'Ginrin', N'Kim', N'Cá Ginrin có vảy lấp lánh như bạc hoặc vàng, tượng trưng cho sự giàu sang và thịnh vượng.', 'https://example.com/images/ginrin.jpg'),
(3, N'Doitsu', N'Mộc', N'Cá Doitsu không có vảy trên thân, biểu tượng cho sự khác biệt và cá tính.', 'https://example.com/images/doitsu.jpg'),
(4, N'Benigoi', N'Hỏa', N'Cá Benigoi có màu đỏ toàn thân, mang ý nghĩa về tình yêu và lòng nhiệt huyết.', 'https://example.com/images/benigoi.jpg'),
(5, N'Kikusui', N'Kim', N'Cá Kikusui có màu bạc với những vệt màu đỏ, biểu tượng cho sự sáng tạo và thành công.', 'https://example.com/images/kikusui.jpg'),
(6, N'Midori', N'Mộc', N'Cá Midori có màu xanh lá cây nhạt, thể hiện sự mới mẻ và hòa hợp với thiên nhiên.', 'https://example.com/images/midori.jpg'),
(7, N'Ogon', N'Kim', N'Cá Ogon có màu vàng hoặc bạc, tượng trưng cho sự phú quý và thành đạt.', 'https://example.com/images/ogon.jpg'),
(8, N'Hariwake', N'Thủy', N'Cá Hariwake có hai màu bạc và vàng, biểu tượng cho sự hài hòa và cân bằng.', 'https://example.com/images/hariwake.jpg'),
(9, N'Matsuba', N'Thổ', N'Cá Matsuba có hoa văn giống mạng lưới trên thân, tượng trưng cho sự bền vững.', 'https://example.com/images/matsuba.jpg'),
(10, N'Yamabuki', N'Hỏa', N'Cá Yamabuki có màu vàng tươi sáng, mang lại may mắn và năng lượng tích cực.', 'https://example.com/images/yamabuki.jpg'),
(11, N'Aka Matsuba', N'Kim', N'Cá Aka Matsuba có màu đỏ với vảy hình lưới, thể hiện sức mạnh và quyết tâm.', 'https://example.com/images/aka-matsuba.jpg'),
(12, N'Koromo', N'Hỏa', N'Cá Koromo có các vảy lồng màu trên thân, tượng trưng cho sự phức tạp và chiều sâu.', 'https://example.com/images/koromo.jpg'),
(13, N'Kumonryu Showa', N'Không khí', N'Cá Kumonryu Showa có màu đen và trắng, với những đốm đỏ, tượng trưng cho sự thay đổi.', 'https://example.com/images/kumonryu-showa.jpg'),
(14, N'Ki Utsuri', N'Mộc', N'Cá Ki Utsuri có màu vàng và đen, thể hiện sự cân bằng giữa ánh sáng và bóng tối.', 'https://example.com/images/ki-utsuri.jpg'),
(15, N'Shiro Bekko', N'Thủy', N'Cá Shiro Bekko có màu trắng với những đốm đen, biểu tượng cho sự thanh lịch.', 'https://example.com/images/shiro-bekko.jpg'),
(16, N'Kohaku Showa', N'Hỏa', N'Cá Kohaku Showa có ba màu chủ đạo: trắng, đỏ và đen, biểu tượng cho sự may mắn và hòa hợp.', 'https://example.com/images/kohaku-showa.jpg'),
(17, N'Beni Kikokuryu', N'Kim', N'Cá Beni Kikokuryu có màu bạc với các vệt đỏ, tượng trưng cho sự tinh khiết và may mắn.', 'https://example.com/images/beni-kikokuryu.jpg'),
(18, N'Aka Sanke', N'Hỏa', N'Cá Aka Sanke có màu đỏ với các đốm trắng và đen, biểu tượng cho lòng trung thành.', 'https://example.com/images/aka-sanke.jpg'),
(19, N'Maruten', N'Mộc', N'Cá Maruten có đốm tròn trên đầu và màu sắc tươi sáng, thể hiện sự may mắn và thành công.', 'https://example.com/images/maruten.jpg'),
(20, N'Hi Utsuri', N'Thổ', N'Cá Hi Utsuri có màu đỏ và đen, tượng trưng cho sức mạnh và sự bền bỉ.', 'https://example.com/images/hi-utsuri.jpg'),
(21, N'Kohaku', N'Thủy', N'Cá Kohaku là biểu tượng của sự thuần khiết và may mắn.', 'https://example.com/images/kohaku.jpg'),
(22, N'Sanke', N'Hỏa', N'Cá Sanke có ba màu sắc: trắng, đỏ và đen, tượng trưng cho sự hòa hợp.', 'https://example.com/images/sanke.jpg'),
(23, N'Showa', N'Hỏa', N'Cá Showa có ba màu chủ đạo là đen, đỏ và trắng, biểu tượng cho sự cân bằng.', 'https://example.com/images/showa.jpg'),
(24, N'Shiro Utsuri', N'Thổ', N'Cá Shiro Utsuri có hai màu trắng và đen, mang ý nghĩa về sự ổn định.', 'https://example.com/images/shiro-utsuri.jpg'),
(25, N'Asagi', N'Không khí', N'Cá Asagi có màu xanh dương nhạt, thể hiện sự hòa bình và thanh tịnh.', 'https://example.com/images/asagi.jpg'),
(26, N'Bekko', N'Kim', N'Cá Bekko là loài cá có màu sắc chủ đạo là đen với những đốm màu khác, tượng trưng cho sự bền bỉ.', 'https://example.com/images/bekko.jpg'),
(27, N'Chagoi', N'Mộc', N'Cá Chagoi có màu nâu hoặc xanh nhạt, biểu tượng cho sự thân thiện và may mắn.', 'https://example.com/images/chagoi.jpg'),
(28, N'Goshiki', N'Thủy', N'Cá Goshiki có màu sắc đa dạng với năm màu chủ đạo, biểu trưng cho sự phong phú.', 'https://example.com/images/goshiki.jpg'),
(29, N'Platinum Ogon', N'Kim', N'Cá Platinum Ogon là loài cá có màu trắng bạc, biểu tượng cho sự giàu có.', 'https://example.com/images/platinum-ogon.jpg'),
(30, N'Kumonryu', N'Không khí', N'Cá Kumonryu có màu đen và trắng, mang ý nghĩa của sự thay đổi.', 'https://example.com/images/kumonryu.jpg');
SET IDENTITY_INSERT KoiSpecies OFF;

SET IDENTITY_INSERT Accounts ON;

INSERT INTO Accounts (AccountId, FullName, Email, Password, UserRoleId)
VALUES (11, N'Nguyễn Đức Thịnh', N'thinhzz571@gmail.com', N'123123', 3);
SET IDENTITY_INSERT Accounts OFF;


