USE [Understood.org.DEV.membership]
GO

/****** Object:  Table [dbo].[MemberActivity]    Script Date: 05/23/2014 10:47:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MemberActivity](
	[rowId] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
	[Key] [uniqueidentifier] NULL,
	[Value] [nvarchar](max) NULL,
	[ActivityType] [int] NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_MemberActivity] PRIMARY KEY CLUSTERED 
(
	[rowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[MemberActivity]  WITH CHECK ADD  CONSTRAINT [FK_MemberActivity_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO

ALTER TABLE [dbo].[MemberActivity] CHECK CONSTRAINT [FK_MemberActivity_Members]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Voodoo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberActivity', @level2type=N'CONSTRAINT',@level2name=N'FK_MemberActivity_Members'
GO

ALTER TABLE [dbo].[MemberActivity] ADD  CONSTRAINT [DF_MemberActivity_ActivityId]  DEFAULT (newid()) FOR [rowId]
GO

ALTER TABLE [dbo].[MemberActivity] ADD  CONSTRAINT [DF_MemberActivity_ActivityType]  DEFAULT ((0)) FOR [ActivityType]
GO

ALTER TABLE [dbo].[MemberActivity] ADD  CONSTRAINT [DF_MemberActivity_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO


