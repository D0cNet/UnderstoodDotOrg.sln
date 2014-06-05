USE [Understood.org.DEV.membership]
GO

/****** Object:  Table [dbo].[MemberAlertPreferences]    Script Date: 06/05/2014 14:18:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MemberAlertPreferences](
	[rowId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
	[SupportPlanReminders] [bit] NOT NULL,
	[ObservationLogReminders] [bit] NOT NULL,
	[EventReminders] [bit] NOT NULL,
	[ContentReminders] [bit] NOT NULL,
	[AdvocacyAlerts] [bit] NOT NULL,
	[PrivateMessageAlerts] [bit] NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_MemberAlertPreferences] PRIMARY KEY CLUSTERED 
(
	[rowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MemberAlertPreferences]  WITH CHECK ADD  CONSTRAINT [FK_MemberAlertPreferences_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO

ALTER TABLE [dbo].[MemberAlertPreferences] CHECK CONSTRAINT [FK_MemberAlertPreferences_Members]
GO

ALTER TABLE [dbo].[MemberAlertPreferences] ADD  CONSTRAINT [DF_MemberAlertPreferences_rowId]  DEFAULT (newid()) FOR [rowId]
GO

ALTER TABLE [dbo].[MemberAlertPreferences] ADD  CONSTRAINT [DF_MemberAlertPreferences_SupportPlanReminders]  DEFAULT ((0)) FOR [SupportPlanReminders]
GO

ALTER TABLE [dbo].[MemberAlertPreferences] ADD  CONSTRAINT [DF_MemberAlertPreferences_ObservationLogReminders]  DEFAULT ((0)) FOR [ObservationLogReminders]
GO

ALTER TABLE [dbo].[MemberAlertPreferences] ADD  CONSTRAINT [DF_MemberAlertPreferences_EventReminders]  DEFAULT ((0)) FOR [EventReminders]
GO

ALTER TABLE [dbo].[MemberAlertPreferences] ADD  CONSTRAINT [DF_MemberAlertPreferences_ContentReminders]  DEFAULT ((0)) FOR [ContentReminders]
GO

ALTER TABLE [dbo].[MemberAlertPreferences] ADD  CONSTRAINT [DF_MemberAlertPreferences_AdvocacyAlerts]  DEFAULT ((0)) FOR [AdvocacyAlerts]
GO

ALTER TABLE [dbo].[MemberAlertPreferences] ADD  CONSTRAINT [DF_MemberAlertPreferences_PrivateMessageAlerts]  DEFAULT ((0)) FOR [PrivateMessageAlerts]
GO

ALTER TABLE [dbo].[MemberAlertPreferences] ADD  CONSTRAINT [DF_MemberAlertPreferences_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO

