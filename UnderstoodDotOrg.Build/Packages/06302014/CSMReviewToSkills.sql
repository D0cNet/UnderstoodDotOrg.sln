USE [Understood.org.DEV.membership]
GO

/****** Object:  Table [dbo].[CSMReviewsToSkills]    Script Date: 06/30/2014 11:51:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CSMReviewsToSkills](
	[RowId] [uniqueidentifier] NOT NULL,
	[ReviewId] [uniqueidentifier] NOT NULL,
	[SkillId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CSMReviewsToSkills] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CSMReviewsToSkills]  WITH CHECK ADD  CONSTRAINT [FK_CSMReviewsToSkills_CSMUserReviews] FOREIGN KEY([ReviewId])
REFERENCES [dbo].[CSMUserReviews] ([ReviewId])
GO

ALTER TABLE [dbo].[CSMReviewsToSkills] CHECK CONSTRAINT [FK_CSMReviewsToSkills_CSMUserReviews]
GO

ALTER TABLE [dbo].[CSMReviewsToSkills]  WITH CHECK ADD  CONSTRAINT [FK_CSMReviewsToSkills_CSMUserReviewSkills] FOREIGN KEY([SkillId])
REFERENCES [dbo].[CSMUserReviewSkills] ([SkillId])
GO

ALTER TABLE [dbo].[CSMReviewsToSkills] CHECK CONSTRAINT [FK_CSMReviewsToSkills_CSMUserReviewSkills]
GO

ALTER TABLE [dbo].[CSMReviewsToSkills] ADD  CONSTRAINT [DF_CSMReviewsToSkills_RowId]  DEFAULT (newid()) FOR [RowId]
GO

