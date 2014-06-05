USE [Understood.org.DEV.membership]
GO

/****** Object:  Table [dbo].[QuizResults]    Script Date: 06/05/2014 17:43:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[QuizResults](
	[rowId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
	[QuizId] [uniqueidentifier] NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL,
	[AnswerValue] [varchar](50) NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_QuizResults] PRIMARY KEY CLUSTERED 
(
	[rowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[QuizResults]  WITH CHECK ADD  CONSTRAINT [FK_QuizResults_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO

ALTER TABLE [dbo].[QuizResults] CHECK CONSTRAINT [FK_QuizResults_Members]
GO

ALTER TABLE [dbo].[QuizResults] ADD  CONSTRAINT [DF_QuizResults_rowId]  DEFAULT (newid()) FOR [rowId]
GO

ALTER TABLE [dbo].[QuizResults] ADD  CONSTRAINT [DF_QuizResults_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO

