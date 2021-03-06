USE [Referral]
GO
/****** Object:  Table [dbo].[TblReferral]    Script Date: 10/28/2016 15:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblReferral](
	[ReferralId] [int] IDENTITY(1,1) NOT NULL,
	[ReferralDate] [datetime] NOT NULL,
	[Rate] [money] NOT NULL,
	[CandidateId] [int] NOT NULL,
	[RecruiterId] [int] NOT NULL,
	[CandidateHired] [bit] NOT NULL,
	[HireDate] [datetime] NULL,
	[Comments] [varchar](max) NULL,
 CONSTRAINT [PK_TblReferral] PRIMARY KEY CLUSTERED 
(
	[ReferralId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spLogReferral]    Script Date: 10/28/2016 15:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLogReferral]
	@Id int out,
	@Rate money,
	@CandidateId int,
	@RecruiterId int,
	@Comments varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [TblReferral]
			   ([Rate]
			   ,[CandidateId]
			   ,[RecruiterId]
			   ,[Comments])
		 VALUES
			   (@Rate
			   ,@CandidateId
			   ,@RecruiterId
			   ,@Comments)

	SET @Id = SCOPE_IDENTITY()

END
GO
/****** Object:  Default [DF_TblReferral_ReferralDate]    Script Date: 10/28/2016 15:26:22 ******/
ALTER TABLE [dbo].[TblReferral] ADD  CONSTRAINT [DF_TblReferral_ReferralDate]  DEFAULT (getdate()) FOR [ReferralDate]
GO
/****** Object:  Default [DF_TblReferral_CandidateHired]    Script Date: 10/28/2016 15:26:22 ******/
ALTER TABLE [dbo].[TblReferral] ADD  CONSTRAINT [DF_TblReferral_CandidateHired]  DEFAULT ((0)) FOR [CandidateHired]
GO
