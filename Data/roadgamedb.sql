USE [master]
GO
/****** Object:  Database [RoadGame]    Script Date: 3/21/2017 6:38:57 PM ******/
CREATE DATABASE [RoadGame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoadGame', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RoadGame.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RoadGame_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RoadGame_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RoadGame] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoadGame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RoadGame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RoadGame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RoadGame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RoadGame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RoadGame] SET ARITHABORT OFF 
GO
ALTER DATABASE [RoadGame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RoadGame] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [RoadGame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RoadGame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RoadGame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RoadGame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RoadGame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RoadGame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RoadGame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RoadGame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RoadGame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RoadGame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RoadGame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RoadGame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RoadGame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RoadGame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RoadGame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RoadGame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RoadGame] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RoadGame] SET  MULTI_USER 
GO
ALTER DATABASE [RoadGame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RoadGame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RoadGame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RoadGame] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [RoadGame]
GO
/****** Object:  StoredProcedure [dbo].[spAddClub]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddClub] 
	@Id int out,
	@Name varchar(75),
	@City varchar(75),
	@StateId int,
	@TeamId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [TblClub]
			   ([Name]
			   ,[City]
			   ,[StateId]
			   ,[TeamId])
		 VALUES
			   (@Name
			   ,@City
			   ,@StateId
			   ,@TeamId)

	SET @Id = SCOPE_IDENTITY()

END


GO
/****** Object:  StoredProcedure [dbo].[spAddFan]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddFan]
	@Id INT OUT,
	@FirstName VARCHAR(75),
	@MiddleInitialId INT = null,
	@LastName VARCHAR(75),
	@SuffixId INT = null,
	@Email VARCHAR(100),
	@Password VARCHAR(15),
	@Mobile VARCHAR(20)
AS
BEGIN
	INSERT INTO [dbo].[TblFan]
		([FirstName]
		,[MiddleInitialId]
		,[LastName]
		,[SuffixId]
		,[Email]
		,[Password]
		,[Mobile])
	VALUES
		(@FirstName
		,@MiddleInitialId
		,@LastName
		,@SuffixId
		,@Email
		,@Password
		,@Mobile)

	SET @Id = SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[spAddFollow]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddFollow]
	@Id int OUT,
	@FanId int,
	@FollowerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[XFanFollow]
		([FanId]
		,[FollowerId])
	VALUES
		(@FanId
		,@FollowerId)

	Set @Id = SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[spAddPost]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddPost] 
	@Id int out,
	@Text varchar(200),
	@FanId int,
	@ParentId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	INSERT INTO [dbo].[TblPost]
		([Text]
		,[FanId]
		,[ParentId])
	VALUES
		(@Text
		,@FanId
		,@ParentId)

	Set @Id = SCOPE_IDENTITY()

END


GO
/****** Object:  StoredProcedure [dbo].[spDeletePost]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeletePost] 
	@Id int,
	@RowsAffected int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE [TblPost]
	SET [Active] = 0
	WHERE Id = @Id

	SET @RowsAffected = @@ROWCOUNT

END

GO
/****** Object:  StoredProcedure [dbo].[spEditClub]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEditClub]

	@Id int,
	@Name varchar(75),
	@City varchar(75),
	@StateId int = NULL,
	@TeamId int,
	@RowsAffected int out

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE [TblClub]
	   SET [Name] = @Name
		  ,[City] = @City
		  ,[StateId] = @StateId
		  ,[TeamId] = @TeamId
	 WHERE Id = @Id

	 SET @RowsAffected = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[spEditFan]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEditFan] 

	@Id int,
	@FirstName varchar(75),
	@MiddleInitialId int = NULL,
	@LastName varchar(75),
	@SuffixId int = NULL,
	@Email varchar(100),
	@Password varchar(15),
	@Mobile varchar(20),
	@RowsAffected int out

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	UPDATE [TblFan]
	SET [FirstName] = @FirstName
		,[MiddleInitialId] = @MiddleInitialId
		,[LastName] = @LastName
		,[SuffixId] = @SuffixId
		,[Email] = @Email
		,[Password] = @Password
		,[Mobile] = @Mobile
	WHERE Id = @Id

	SET @RowsAffected = @@ROWCOUNT

END
GO
/****** Object:  StoredProcedure [dbo].[spGetClub]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetClub] 
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [Id]
		,[Name]
		,[City]
		,[StateId]
		,[TeamId]
	FROM [TblClub]
	WHERE ID = @Id

END

GO
/****** Object:  StoredProcedure [dbo].[spGetFan]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetFan]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [Id]
		  ,[FirstName]
		  ,[MiddleInitialId]
		  ,[LastName]
		  ,[SuffixId]
		  ,[Email]
		  ,[Password]
		  ,[Mobile]
	FROM [dbo].[TblFan]
	WHERE ID = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[spGetFollowerCount]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetFollowerCount]
	@FanId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT COUNT(*) Followers 
	FROM [XFanFollow] 
	WHERE [FanId] = @FanId AND Following = 1
END

GO
/****** Object:  StoredProcedure [dbo].[spGetFollowers]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetFollowers]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT F.[Id]
		  ,[FirstName]
		  ,[MiddleInitialId]
		  ,[LastName]
		  ,[SuffixId]
		  ,[Email]
		  ,[Password]
		  ,[Mobile]
		  ,M.MiddleInitial
		  ,S.Suffix
	FROM [dbo].[TblFan] F
		LEFT JOIN RMiddleInitial M ON
			F.MiddleInitialId = M.Id
		LEFT JOIN [RSuffix] S ON
			F.SuffixId = S.Id
	WHERE F.ID IN (	
		SELECT [FollowerId]
		FROM [TblFan] F
			LEFT JOIN [XFanFollow] XF
				ON F.Id = XF.[FanId]
		WHERE F.Id = @Id
	)
END

GO
/****** Object:  StoredProcedure [dbo].[spLogError]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spLogError]
	@Id int out,
	@Message varchar(max),
	@Method varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [TblLog]
			   ([Message]
			   ,[Method])
	VALUES
		(@Message
		,@Method)

	SELECT @Id = SCOPE_IDENTITY()

END


GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spLogin] 
	@Email varchar(100),
	@Password varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Id FROM [dbo].[TblFan] WHERE Email = @Email and Password = @password
	
END

GO
/****** Object:  StoredProcedure [dbo].[spUnFollow]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUnFollow]
	@FanId int,
	@FollowerId int,
	@RowsAffected int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE [dbo].[XFanFollow]
	SET [UnfollowDate] = GetDate()
		,[Following] = 0
	 WHERE FanId = @FanId

	 Set @RowsAffected = @@ROWCOUNT
END

GO
/****** Object:  Table [dbo].[RMiddleInitial]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RMiddleInitial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MiddleInitial] [varchar](1) NULL,
 CONSTRAINT [PK_RMiddleInitial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RNumberType]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RNumberType](
	[NumberTypeId] [int] IDENTITY(1,1) NOT NULL,
	[NumberType] [varchar](50) NULL,
 CONSTRAINT [PK_TblNumberType] PRIMARY KEY CLUSTERED 
(
	[NumberTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RSport]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RSport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sport] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_RSport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RState]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RState](
	[stateID] [int] IDENTITY(1,1) NOT NULL,
	[stateCode] [nchar](2) NOT NULL,
	[stateName] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_state] PRIMARY KEY CLUSTERED 
(
	[stateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RSuffix]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RSuffix](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Suffix] [varchar](20) NULL,
 CONSTRAINT [PK_RSuffix] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RTeam]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SportId] [int] NOT NULL,
 CONSTRAINT [PK_RTeam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblClub]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblClub](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](75) NOT NULL,
	[City] [varchar](75) NOT NULL,
	[StateId] [int] NOT NULL,
	[TeamId] [int] NULL,
 CONSTRAINT [PK_TblClub] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblFan]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblFan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](75) NOT NULL,
	[MiddleInitialId] [int] NULL,
	[LastName] [varchar](75) NOT NULL,
	[SuffixId] [int] NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](15) NOT NULL,
	[Mobile] [varchar](20) NOT NULL,
	[Pic] [image] NULL,
	[NickName] [varchar](75) NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_TblFan_Active]  DEFAULT ((1)),
 CONSTRAINT [PK_TblFan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblLog]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](100) NULL,
	[Method] [varchar](max) NULL,
	[LogDate] [datetime] NULL CONSTRAINT [DF_TblLog_LogDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_TblLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblPost]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[PostDate] [datetime] NOT NULL CONSTRAINT [DF_TblPost_PostDate]  DEFAULT (getdate()),
	[Active] [bit] NOT NULL CONSTRAINT [DF_TblPost_Active]  DEFAULT ((1)),
	[FanId] [int] NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_TblPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[XFanFollow]    Script Date: 3/21/2017 6:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XFanFollow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FanId] [int] NOT NULL,
	[FollowerId] [int] NULL,
	[FollowDate] [datetime] NOT NULL CONSTRAINT [DF_XFanFollow_FollowDate]  DEFAULT (getdate()),
	[UnfollowDate] [datetime] NULL,
	[Following] [bit] NOT NULL CONSTRAINT [DF_XFanFollow_Following]  DEFAULT ((1)),
 CONSTRAINT [PK_XFanFollow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[RMiddleInitial] ON 

INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (1, N'A')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (2, N'B')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (3, N'C')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (4, N'D')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (5, N'E')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (6, N'F')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (7, N'G')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (8, N'H')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (9, N'I')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (10, N'J')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (11, N'K')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (12, N'L')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (13, N'M')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (14, N'N')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (15, N'O')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (16, N'P')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (17, N'Q')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (18, N'R')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (19, N'S')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (20, N'T')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (21, N'U')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (22, N'V')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (23, N'W')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (24, N'X')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (25, N'Y')
INSERT [dbo].[RMiddleInitial] ([Id], [MiddleInitial]) VALUES (26, N'Z')
SET IDENTITY_INSERT [dbo].[RMiddleInitial] OFF
SET IDENTITY_INSERT [dbo].[RNumberType] ON 

INSERT [dbo].[RNumberType] ([NumberTypeId], [NumberType]) VALUES (1, N'Mobile')
INSERT [dbo].[RNumberType] ([NumberTypeId], [NumberType]) VALUES (2, N'Office')
INSERT [dbo].[RNumberType] ([NumberTypeId], [NumberType]) VALUES (3, N'Home')
INSERT [dbo].[RNumberType] ([NumberTypeId], [NumberType]) VALUES (4, N'Fax')
SET IDENTITY_INSERT [dbo].[RNumberType] OFF
SET IDENTITY_INSERT [dbo].[RSport] ON 

INSERT [dbo].[RSport] ([Id], [Sport], [Description]) VALUES (1, N'NFL', N'National Football League')
INSERT [dbo].[RSport] ([Id], [Sport], [Description]) VALUES (2, N'CFB', N'College Football')
INSERT [dbo].[RSport] ([Id], [Sport], [Description]) VALUES (3, N'NBA', N'National Basketball Association')
INSERT [dbo].[RSport] ([Id], [Sport], [Description]) VALUES (4, N'NHL', N'National Hockey League')
INSERT [dbo].[RSport] ([Id], [Sport], [Description]) VALUES (5, N'MLB', N'Major League Baseball')
INSERT [dbo].[RSport] ([Id], [Sport], [Description]) VALUES (6, N'NCAAB', N'NCAA Basketball (Men)')
SET IDENTITY_INSERT [dbo].[RSport] OFF
SET IDENTITY_INSERT [dbo].[RState] ON 

INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (1, N'AL', N'Alabama')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (2, N'AK', N'Alaska')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (3, N'AZ', N'Arizona')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (4, N'AR', N'Arkansas')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (5, N'CA', N'California')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (6, N'CO', N'Colorado')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (7, N'CT', N'Connecticut')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (8, N'DE', N'Delaware')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (9, N'DC', N'District of Columbia')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (10, N'FL', N'Florida')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (11, N'GA', N'Georgia')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (12, N'HI', N'Hawaii')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (13, N'ID', N'Idaho')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (14, N'IL', N'Illinois')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (15, N'IN', N'Indiana')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (16, N'IA', N'Iowa')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (17, N'KS', N'Kansas')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (18, N'KY', N'Kentucky')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (19, N'LA', N'Louisiana')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (20, N'ME', N'Maine')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (21, N'MD', N'Maryland')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (22, N'MA', N'Massachusetts')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (23, N'MI', N'Michigan')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (24, N'MN', N'Minnesota')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (25, N'MS', N'Mississippi')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (26, N'MO', N'Missouri')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (27, N'MT', N'Montana')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (28, N'NE', N'Nebraska')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (29, N'NV', N'Nevada')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (30, N'NH', N'New Hampshire')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (31, N'NJ', N'New Jersey')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (32, N'NM', N'New Mexico')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (33, N'NY', N'New York')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (34, N'NC', N'North Carolina')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (35, N'ND', N'North Dakota')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (36, N'OH', N'Ohio')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (37, N'OK', N'Oklahoma')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (38, N'OR', N'Oregon')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (39, N'PA', N'Pennsylvania')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (40, N'PR', N'Puerto Rico')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (41, N'RI', N'Rhode Island')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (42, N'SC', N'South Carolina')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (43, N'SD', N'South Dakota')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (44, N'TN', N'Tennessee')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (45, N'TX', N'Texas')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (46, N'UT', N'Utah')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (47, N'VT', N'Vermont')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (48, N'VA', N'Virginia')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (49, N'WA', N'Washington')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (50, N'WV', N'West Virginia')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (51, N'WI', N'Wisconsin')
INSERT [dbo].[RState] ([stateID], [stateCode], [stateName]) VALUES (52, N'WY', N'Wyoming')
SET IDENTITY_INSERT [dbo].[RState] OFF
SET IDENTITY_INSERT [dbo].[RSuffix] ON 

INSERT [dbo].[RSuffix] ([Id], [Suffix]) VALUES (1, N'Sr.')
INSERT [dbo].[RSuffix] ([Id], [Suffix]) VALUES (2, N'Jr.')
INSERT [dbo].[RSuffix] ([Id], [Suffix]) VALUES (3, N'II')
INSERT [dbo].[RSuffix] ([Id], [Suffix]) VALUES (4, N'III')
INSERT [dbo].[RSuffix] ([Id], [Suffix]) VALUES (5, N'IV')
INSERT [dbo].[RSuffix] ([Id], [Suffix]) VALUES (6, N'V')
INSERT [dbo].[RSuffix] ([Id], [Suffix]) VALUES (7, N'I')
SET IDENTITY_INSERT [dbo].[RSuffix] OFF
SET IDENTITY_INSERT [dbo].[RTeam] ON 

INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (1, N'Arizona Cardinals', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (2, N'Atlanta Falcons', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (3, N'Baltimore Ravens', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (5, N'Buffalo Bills', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (6, N'Carolina Panthers', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (7, N'Chicago Bears', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (8, N'Cincinnati Bengals', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (9, N'Cleveland Browns', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (10, N'Dallas Cowboys', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (11, N'Denver Broncos', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (12, N'Detroit Lions', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (13, N'Green Bay Packers', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (15, N'Houston Texans', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (16, N'Indianapolis Colts', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (17, N'Jacksonville Jaguars', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (18, N'Kansas City Chiefs', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (19, N'Miami Dolphins', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (20, N'Minnesota Vikings', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (21, N'New England Patriots', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (22, N'New Orleans Saints', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (23, N'New York Giants', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (25, N'New York Jets', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (26, N'Oakland Raiders', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (27, N'Philadelphia Eagles', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (28, N'Pittsburgh Steelers', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (29, N'San Diego Chargers', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (30, N'San Francisco 49ers', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (31, N'Seattle Seahawks', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (32, N'St. Louis Rams', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (33, N'Tampa Bay Buccaneers', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (34, N'Tennessee Titans', 1)
INSERT [dbo].[RTeam] ([Id], [Name], [SportId]) VALUES (35, N'Washington Redskins', 1)
SET IDENTITY_INSERT [dbo].[RTeam] OFF
SET IDENTITY_INSERT [dbo].[TblClub] ON 

INSERT [dbo].[TblClub] ([Id], [Name], [City], [StateId], [TeamId]) VALUES (3, N'Fish Boys SC', N'Greenville', 42, 19)
SET IDENTITY_INSERT [dbo].[TblClub] OFF
SET IDENTITY_INSERT [dbo].[TblFan] ON 

INSERT [dbo].[TblFan] ([Id], [FirstName], [MiddleInitialId], [LastName], [SuffixId], [Email], [Password], [Mobile], [Pic], [NickName], [Active]) VALUES (1, N'Andrew', 1, N'Jones', NULL, N'pauljonessoftware@gmail.com', N'purple1!', N'(803) 873-6472', NULL, NULL, 1)
INSERT [dbo].[TblFan] ([Id], [FirstName], [MiddleInitialId], [LastName], [SuffixId], [Email], [Password], [Mobile], [Pic], [NickName], [Active]) VALUES (2, N'John', 4, N'Austin', NULL, N'jaustin2@gmail.com', N'purple1!', N'(803) 873-6472', NULL, NULL, 1)
INSERT [dbo].[TblFan] ([Id], [FirstName], [MiddleInitialId], [LastName], [SuffixId], [Email], [Password], [Mobile], [Pic], [NickName], [Active]) VALUES (3, N'Thomas', NULL, N'Myers', NULL, N'tmyers@gmail.com', N'purple1!', N'(803) 873-6472', NULL, NULL, 1)
INSERT [dbo].[TblFan] ([Id], [FirstName], [MiddleInitialId], [LastName], [SuffixId], [Email], [Password], [Mobile], [Pic], [NickName], [Active]) VALUES (4, N'Thomas', NULL, N'Myers', NULL, N'tmyers@gmail.com', N'purple1!', N'(803) 873-6472', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TblFan] OFF
SET IDENTITY_INSERT [dbo].[TblLog] ON 

INSERT [dbo].[TblLog] ([Id], [Message], [Method], [LogDate]) VALUES (1, N'Procedure or function ''spAddFan'' expects parameter ''@MiddleInitialId'', which was not supplied.', N'AddFan', CAST(N'2016-09-28 21:41:12.260' AS DateTime))
INSERT [dbo].[TblLog] ([Id], [Message], [Method], [LogDate]) VALUES (2, N'Could not find stored procedure ''spAddFollow''.', N'AddFollow', CAST(N'2016-10-01 15:07:48.157' AS DateTime))
INSERT [dbo].[TblLog] ([Id], [Message], [Method], [LogDate]) VALUES (5, N'An SqlParameter with ParameterName ''@Id'' is not contained by this SqlParameterCollection.', N'UnFollow', CAST(N'2016-10-01 15:31:20.160' AS DateTime))
INSERT [dbo].[TblLog] ([Id], [Message], [Method], [LogDate]) VALUES (6, N'An SqlParameter with ParameterName ''@Id'' is not contained by this SqlParameterCollection.', N'UnFollow', CAST(N'2016-10-01 15:31:45.147' AS DateTime))
SET IDENTITY_INSERT [dbo].[TblLog] OFF
SET IDENTITY_INSERT [dbo].[TblPost] ON 

INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (1, N'The Dolphins Suck!', CAST(N'2016-09-29 22:27:59.150' AS DateTime), 0, 1, NULL)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (2, N'Damn Miami''s Bad! Awful team.', CAST(N'2016-09-29 22:30:15.513' AS DateTime), 1, 1, NULL)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (3, N'Fede is a shithead!', CAST(N'2016-09-29 22:31:04.327' AS DateTime), 1, 1, NULL)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (4, N'Football season is already over in Miami. Dolphins make me cry.', CAST(N'2016-09-29 22:49:59.680' AS DateTime), 1, 1, NULL)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (5, N'Football season is already over in Miami. Dolphins make me cry.', CAST(N'2016-10-01 00:18:00.283' AS DateTime), 1, 1, NULL)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (6, N'Football season is already over in Miami. Dolphins make me cry.', CAST(N'2016-10-01 00:22:24.143' AS DateTime), 1, 1, 2)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (7, N'The Huskies are for real!', CAST(N'2016-10-01 00:23:47.130' AS DateTime), 1, 2, 0)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (8, N'Stanford got beat like a rented mule', CAST(N'2016-10-01 00:25:26.270' AS DateTime), 1, 2, NULL)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (9, N'Yes, Miami does indeed stink', CAST(N'2016-10-01 00:55:46.320' AS DateTime), 1, 2, 2)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (10, N'Duh! Bring back Bob Griese!', CAST(N'2016-10-01 00:57:49.483' AS DateTime), 1, 3, 2)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (11, N'Griese? I''d settle for Woodley', CAST(N'2016-10-01 00:58:29.630' AS DateTime), 1, 3, 2)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (12, N'Dallas Sucks!', CAST(N'2016-10-06 21:59:59.333' AS DateTime), 1, 1, NULL)
INSERT [dbo].[TblPost] ([Id], [Text], [PostDate], [Active], [FanId], [ParentId]) VALUES (13, N'''Ahh hell nah!', CAST(N'2016-10-06 22:01:05.763' AS DateTime), 1, 2, 12)
SET IDENTITY_INSERT [dbo].[TblPost] OFF
SET IDENTITY_INSERT [dbo].[XFanFollow] ON 

INSERT [dbo].[XFanFollow] ([Id], [FanId], [FollowerId], [FollowDate], [UnfollowDate], [Following]) VALUES (1, 1, 2, CAST(N'2016-10-05 20:31:21.190' AS DateTime), NULL, 1)
INSERT [dbo].[XFanFollow] ([Id], [FanId], [FollowerId], [FollowDate], [UnfollowDate], [Following]) VALUES (2, 1, 3, CAST(N'2016-10-05 20:36:08.650' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[XFanFollow] OFF
USE [master]
GO
ALTER DATABASE [RoadGame] SET  READ_WRITE 
GO
