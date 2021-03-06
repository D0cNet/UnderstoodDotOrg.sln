/*
   Monday, July 07, 20141:21:22 PM
   User: understood_org
   Server: 162.209.22.3
   Database: Understood.org.DEV.membership
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.Members
	DROP CONSTRAINT DF_Members_emailSubscription
GO
ALTER TABLE dbo.Members
	DROP CONSTRAINT DF_Members_isFacebookUser
GO
ALTER TABLE dbo.Members
	DROP CONSTRAINT DF_Members_DateModified
GO
ALTER TABLE dbo.Members
	DROP CONSTRAINT DF_Members_PreferedLanguage
GO
ALTER TABLE dbo.Members
	DROP CONSTRAINT DF_Members_AgreedToTerms
GO
ALTER TABLE dbo.Members
	DROP CONSTRAINT DF_Members_Subscribed_DailyDigest
GO
ALTER TABLE dbo.Members
	DROP CONSTRAINT DF_Members_Subscribed_WeeklyDigest
GO
CREATE TABLE dbo.Tmp_Members
	(
	MemberId uniqueidentifier NOT NULL,
	UserId uniqueidentifier NOT NULL,
	SalesforceId varchar(18) NULL,
	ScreenName nchar(20) NULL,
	FirstName nchar(20) NULL,
	LastName nchar(20) NULL,
	ZipCode nchar(20) NULL,
	allowConnections bit NOT NULL,
	allowNewsletter bit NOT NULL,
	isPrivate bit NOT NULL,
	hasOtherChildren bit NOT NULL,
	PersonalityType uniqueidentifier NOT NULL,
	Role uniqueidentifier NOT NULL,
	Phone int NULL,
	emailSubscription bit NOT NULL,
	isFacebookUser bit NOT NULL,
	DateModified datetime NOT NULL,
	PreferedLanguage uniqueidentifier NOT NULL,
	AgreedToSignUpTerms bit NOT NULL,
	MobilePhoneNumber nchar(15) NULL,
	Subscribed_DailyDigest bit NULL,
	Subscribed_WeeklyDigest bit NULL,
	GeoLoc geography NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Members SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Members ADD CONSTRAINT
	DF_Members_emailSubscription DEFAULT ((0)) FOR emailSubscription
GO
ALTER TABLE dbo.Tmp_Members ADD CONSTRAINT
	DF_Members_isFacebookUser DEFAULT ((0)) FOR isFacebookUser
GO
ALTER TABLE dbo.Tmp_Members ADD CONSTRAINT
	DF_Members_DateModified DEFAULT (getdate()) FOR DateModified
GO
ALTER TABLE dbo.Tmp_Members ADD CONSTRAINT
	DF_Members_PreferedLanguage DEFAULT (N'AF584191-45C9-4201-8740-5409F4CF8BDD') FOR PreferedLanguage
GO
ALTER TABLE dbo.Tmp_Members ADD CONSTRAINT
	DF_Members_AgreedToTerms DEFAULT ((0)) FOR AgreedToSignUpTerms
GO
ALTER TABLE dbo.Tmp_Members ADD CONSTRAINT
	DF_Members_Subscribed_DailyDigest DEFAULT ((0)) FOR Subscribed_DailyDigest
GO
ALTER TABLE dbo.Tmp_Members ADD CONSTRAINT
	DF_Members_Subscribed_WeeklyDigest DEFAULT ((0)) FOR Subscribed_WeeklyDigest
GO
IF EXISTS(SELECT * FROM dbo.Members)
	 EXEC('INSERT INTO dbo.Tmp_Members (MemberId, UserId, ScreenName, FirstName, LastName, ZipCode, allowConnections, allowNewsletter, isPrivate, hasOtherChildren, PersonalityType, Role, Phone, emailSubscription, isFacebookUser, DateModified, PreferedLanguage, AgreedToSignUpTerms, MobilePhoneNumber, Subscribed_DailyDigest, Subscribed_WeeklyDigest, GeoLoc)
		SELECT MemberId, UserId, ScreenName, FirstName, LastName, ZipCode, allowConnections, allowNewsletter, isPrivate, hasOtherChildren, PersonalityType, Role, Phone, emailSubscription, isFacebookUser, DateModified, PreferedLanguage, AgreedToSignUpTerms, MobilePhoneNumber, Subscribed_DailyDigest, Subscribed_WeeklyDigest, GeoLoc FROM dbo.Members WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.QuizResults
	DROP CONSTRAINT FK_QuizResults_Members
GO
ALTER TABLE dbo.MemberSubscriptions
	DROP CONSTRAINT FK_MemberSubscriptions_Members
GO
ALTER TABLE dbo.MemberAlertPreferences
	DROP CONSTRAINT FK_MemberAlertPreferences_Members
GO
ALTER TABLE dbo.CSMUserReviews
	DROP CONSTRAINT FK_CSMUserReviews_Members
GO
ALTER TABLE dbo.MemberToJourney
	DROP CONSTRAINT FK_MemberToJourney_Members
GO
ALTER TABLE dbo.MemberToChild
	DROP CONSTRAINT FK_MemberToChild_Members
GO
ALTER TABLE dbo.MemberActivity
	DROP CONSTRAINT FK_MemberActivity_Members
GO
ALTER TABLE dbo.MemberToInterests
	DROP CONSTRAINT FK_MemberToInterests_Members
GO
DROP TABLE dbo.Members
GO
EXECUTE sp_rename N'dbo.Tmp_Members', N'Members', 'OBJECT' 
GO
ALTER TABLE dbo.Members ADD CONSTRAINT
	PK_Members PRIMARY KEY CLUSTERED 
	(
	MemberId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE TRIGGER [dbo].[trg_Members_UpdateDateModified]
ON dbo.Members		
AFTER UPDATE
AS
    UPDATE dbo.Members
    SET DateModified = GETDATE()
    WHERE MemberId IN (SELECT DISTINCT MemberId FROM Inserted)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MemberToInterests ADD CONSTRAINT
	FK_MemberToInterests_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MemberToInterests SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MemberActivity ADD CONSTRAINT
	FK_MemberActivity_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
DECLARE @v sql_variant 
SET @v = N'Voodoo'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberActivity', N'CONSTRAINT', N'FK_MemberActivity_Members'
GO
ALTER TABLE dbo.MemberActivity SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MemberToChild ADD CONSTRAINT
	FK_MemberToChild_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MemberToChild SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MemberToJourney ADD CONSTRAINT
	FK_MemberToJourney_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MemberToJourney SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CSMUserReviews ADD CONSTRAINT
	FK_CSMUserReviews_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CSMUserReviews SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MemberAlertPreferences ADD CONSTRAINT
	FK_MemberAlertPreferences_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MemberAlertPreferences SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MemberSubscriptions ADD CONSTRAINT
	FK_MemberSubscriptions_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MemberSubscriptions SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.QuizResults ADD CONSTRAINT
	FK_QuizResults_Members FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Members
	(
	MemberId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.QuizResults SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
