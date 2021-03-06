/*
   Monday, July 07, 20141:25:42 PM
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
ALTER TABLE dbo.Children
	DROP CONSTRAINT DF_Children_DateModified
GO
CREATE TABLE dbo.Tmp_Children
	(
	ChildId uniqueidentifier NOT NULL,
	SalesforceId varchar(18) NULL,
	Nickname nchar(20) NOT NULL,
	IEPStatus uniqueidentifier NOT NULL,
	Section504Status uniqueidentifier NOT NULL,
	EvaluationStatus uniqueidentifier NOT NULL,
	DateModified datetime NOT NULL,
	Gender nvarchar(10) NOT NULL,
	HomeLife uniqueidentifier NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Children SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Children ADD CONSTRAINT
	DF_Children_DateModified DEFAULT (getdate()) FOR DateModified
GO
IF EXISTS(SELECT * FROM dbo.Children)
	 EXEC('INSERT INTO dbo.Tmp_Children (ChildId, Nickname, IEPStatus, Section504Status, EvaluationStatus, DateModified, Gender, HomeLife)
		SELECT ChildId, Nickname, IEPStatus, Section504Status, EvaluationStatus, DateModified, Gender, HomeLife FROM dbo.Children WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.ChildToDiagnosis
	DROP CONSTRAINT FK_ChildToDiagnosis_Children
GO
ALTER TABLE dbo.ChildToIssues
	DROP CONSTRAINT FK_ChildToIssues_Children
GO
ALTER TABLE dbo.MemberToChild
	DROP CONSTRAINT FK_MemberToChild_Children
GO
ALTER TABLE dbo.ChildToGrades
	DROP CONSTRAINT FK_ChildToGrades_Children
GO
ALTER TABLE dbo.PersonalizedContent
	DROP CONSTRAINT FK_PersonalizedContent_Children
GO
DROP TABLE dbo.Children
GO
EXECUTE sp_rename N'dbo.Tmp_Children', N'Children', 'OBJECT' 
GO
ALTER TABLE dbo.Children ADD CONSTRAINT
	PK_Children PRIMARY KEY CLUSTERED 
	(
	ChildId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE TRIGGER trg_Children_UpdateDateModified
ON dbo.Children		
AFTER UPDATE
AS
    UPDATE dbo.Children
    SET DateModified = GETDATE()
    WHERE ChildId IN (SELECT DISTINCT ChildId FROM Inserted)
GO
CREATE TRIGGER [dbo].[trg_Children_Insert_SeedPersonalizedContent]
ON dbo.Children		
AFTER INSERT
AS


DECLARE @intCount INT
SET @intCount = 0
WHILE (@intCount <=39)
BEGIN
	/* Insert 40 rows into the personalized content table for this child*/
    
    INSERT INTO PersonalizedContent
               (ChildId,ContentId, DisplayOrder, Type)
		VALUES ((SELECT DISTINCT ChildId FROM Inserted),
				'00000000-0000-0000-0000-000000000000', @intCount, 0)    
    SET @intCount = @intCount + 1
END
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Children', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Children', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Children', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PersonalizedContent ADD CONSTRAINT
	FK_PersonalizedContent_Children FOREIGN KEY
	(
	ChildId
	) REFERENCES dbo.Children
	(
	ChildId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PersonalizedContent SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PersonalizedContent', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PersonalizedContent', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PersonalizedContent', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChildToGrades ADD CONSTRAINT
	FK_ChildToGrades_Children FOREIGN KEY
	(
	ChildId
	) REFERENCES dbo.Children
	(
	ChildId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChildToGrades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChildToGrades', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChildToGrades', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChildToGrades', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.MemberToChild ADD CONSTRAINT
	FK_MemberToChild_Children FOREIGN KEY
	(
	ChildId
	) REFERENCES dbo.Children
	(
	ChildId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MemberToChild SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MemberToChild', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MemberToChild', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MemberToChild', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChildToIssues ADD CONSTRAINT
	FK_ChildToIssues_Children FOREIGN KEY
	(
	ChildId
	) REFERENCES dbo.Children
	(
	ChildId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChildToIssues SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChildToIssues', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChildToIssues', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChildToIssues', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChildToDiagnosis ADD CONSTRAINT
	FK_ChildToDiagnosis_Children FOREIGN KEY
	(
	ChildId
	) REFERENCES dbo.Children
	(
	ChildId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChildToDiagnosis SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChildToDiagnosis', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChildToDiagnosis', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChildToDiagnosis', 'Object', 'CONTROL') as Contr_Per 