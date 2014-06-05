USE [Understood.org.DEV.membership]
GO

/****** Object:  Trigger [dbo].[trg_MemberToInterests_UpdateDateModified]    Script Date: 06/04/2014 17:15:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[trg_MemberToInterests_UpdateDateModified]
ON [dbo].[MemberToInterests]	
AFTER UPDATE
AS
    UPDATE dbo.MemberToInterests
    SET DateModified = GETDATE()
    WHERE MemberId IN (SELECT DISTINCT MemberId FROM Inserted) AND
     InterestId IN (SELECT DISTINCT InterestId FROM Inserted)
GO

