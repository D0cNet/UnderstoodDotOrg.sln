BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Members ADD
	PreferedLanguage uniqueidentifier  NULL
GO
ALTER TABLE dbo.Members ADD CONSTRAINT
	PreferedLanguage DEFAULT (N'AF584191-45C9-4201-8740-5409F4CF8BDD') FOR PreferedLanguage
go
ALTER TABLE dbo.Members ADD
	AgreedToSignUpTerms bit  NULL
GO
ALTER TABLE dbo.Members ADD CONSTRAINT
	AgreedToSignUpTerms DEFAULT 0 FOR AgreedToSignUpTerms
GO
ALTER TABLE dbo.Members ADD
	MobilePhoneNumber nchar(15)  NULL
GO
ALTER TABLE dbo.Members ADD
	Subscribed_DailyDigest bit  NULL
GO
ALTER TABLE dbo.Members ADD CONSTRAINT
	Subscribed_DailyDigest DEFAULT 0 FOR Subscribed_DailyDigest
GO
ALTER TABLE dbo.Members ADD
	Subscribed_WeeklyDigest bit  NULL
GO
ALTER TABLE dbo.Members ADD CONSTRAINT
	Subscribed_WeeklyDigest DEFAULT 0 FOR Subscribed_WeeklyDigest
GO

ALTER TABLE dbo.Members SET (LOCK_ESCALATION = TABLE)
GO



COMMIT