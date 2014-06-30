USE [Understood.org.DEV.membership]
GO

/****** Object:  Table [dbo].[CSMUserReviewSkills]    Script Date: 06/30/2014 11:51:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CSMUserReviewSkills](
	[SkillId] [uniqueidentifier] NOT NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_CSMUserReviewSkills] PRIMARY KEY CLUSTERED 
(
	[SkillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CSMUserReviewSkills] ADD  CONSTRAINT [DF_CSMUserReviewSkills_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

