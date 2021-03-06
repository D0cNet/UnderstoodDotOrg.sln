/*
   Wednesday, June 04, 20145:11:00 PM
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
ALTER TABLE dbo.MemberActivity ADD
	Deleted bit NULL
GO
ALTER TABLE dbo.MemberActivity ADD CONSTRAINT
	DF_MemberActivity_Deleted DEFAULT 0 FOR Deleted
GO
ALTER TABLE dbo.MemberActivity SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
