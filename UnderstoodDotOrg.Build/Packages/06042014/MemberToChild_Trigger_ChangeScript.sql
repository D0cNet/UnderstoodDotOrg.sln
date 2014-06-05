USE [Understood.org.DEV.membership]
GO

/****** Object:  Trigger [dbo].[trg_InsteadOfInsert_MemberToChild]    Script Date: 06/04/2014 17:16:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Brett Garnier
-- Create date: 5/21/2014
-- Description:	Saving ourselves from entity eagerness
-- =============================================
ALTER TRIGGER [dbo].[trg_InsteadOfInsert_MemberToChild] 
   ON  [dbo].[MemberToChild]  
     INSTEAD OF INSERT 
  AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	-- 1. If this insert statement is an insert of duplicate data, let it exit
	DECLARE @ExistingGuidPair UNIQUEIDENTIFIER
	SELECT  @ExistingGuidPair = MemberId
		From MemberToChild
		Where MemberToChild.MemberId= (Select MemberId from Inserted)
			and MemberToChild.ChildId = (Select ChildId from Inserted)
	   
	IF (@ExistingGuidPair IS NOT NULL)
		BEGIN
			RETURN -- DO NOTHING. THIS ROW ALREADY EXISTS
		END 
		
		-- ************** OH DEAR LETS INSERT SOMETHING OK 
		
		INSERT INTO MemberToChild
               (MemberId, ChildId)
		VALUES ((Select MemberId from Inserted),
				(Select ChildId from Inserted))
END

GO

