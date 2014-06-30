USE [Understood.org.DEV.membership]
GO

/****** Object:  Table [dbo].[CSMUserReviews]    Script Date: 06/30/2014 11:51:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CSMUserReviews](
	[ReviewId] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NULL,
	[CSMItemId] [uniqueidentifier] NULL,
	[Rating] [int] NULL,
	[RatedGradeId] [uniqueidentifier] NULL,
	[GradeAppropriateness] [int] NULL,
	[Created] [datetime] NULL,
	[LastModified] [datetime] NULL,
	[TelligentCommentId] [uniqueidentifier] NULL,
	[ReviewTitle] [varchar](1000) NULL,
	[IThinkItIs] [varchar](50) NULL,
 CONSTRAINT [PK_CSMUserReviews] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CSMUserReviews]  WITH CHECK ADD  CONSTRAINT [FK_CSMUserReviews_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO

ALTER TABLE [dbo].[CSMUserReviews] CHECK CONSTRAINT [FK_CSMUserReviews_Members]
GO

ALTER TABLE [dbo].[CSMUserReviews] ADD  CONSTRAINT [DF_CSMUserReviews_ReviewId]  DEFAULT (newid()) FOR [ReviewId]
GO

