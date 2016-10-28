USE [Referral]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblNotice_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblNotice] DROP CONSTRAINT [DF_TblNotice_Date]
END

GO

USE [Referral]
GO

/****** Object:  Table [dbo].[TblNotice]    Script Date: 10/28/2016 15:32:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblNotice]') AND type in (N'U'))
DROP TABLE [dbo].[TblNotice]
GO

USE [Referral]
GO

/****** Object:  Table [dbo].[TblNotice]    Script Date: 10/28/2016 15:32:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblNotice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Notice] [nchar](10) NOT NULL,
	[CandidateId] [int] NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_TblNotice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblNotice] ADD  CONSTRAINT [DF_TblNotice_Date]  DEFAULT (getdate()) FOR [Date]
GO


