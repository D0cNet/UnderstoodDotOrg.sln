USE [Understood.org.DEV.membership]
GO

/****** Object:  Trigger [dbo].[trg_InsteadOfInsert_MemberToJourney]    Script Date: 06/04/2014 17:15:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Brett Garnier>
-- Create date: <5/21/2014>
-- Description:	<This trigger keeps entity from breaking things. Collisions are avoided and updates are made by deleting rows and then inserting>
-- =============================================
ALTER TRIGGER [dbo].[trg_InsteadOfInsert_MemberToJourney]
   ON  [dbo].[MemberToJourney] 
   INSTEAD OF INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	-- **************************************************************
	-- 1. If this insert statement is an insert of duplicate data, let it exit
	DECLARE @ExistingMemberJourneyPair UNIQUEIDENTIFIER
	SELECT  @ExistingMemberJourneyPair  = MemberId
		From MemberToJourney
		Where MemberToJourney.Journeyid= (Select MemberId from Inserted)
			and MemberToJourney.JourneyId= (Select JourneyId from Inserted)
	   
	IF (@ExistingMemberJourneyPair IS NOT NULL)
		BEGIN
			RETURN -- DO NOTHING. THIS ROW ALREADY EXISTS
		END 
     -- **************************************************************
	 -- 2. If this insert statement is actually trying to update an existing child's grade
	 --    delete the existing record and then enter the new record
	 Declare @MemberToUpdate UNIQUEIDENTIFIER
	 SELECT @MemberToUpdate = MemberId
		From MemberToJourney 
		Where MemberToJourney.MemberId = (Select MemberId from Inserted)
		
		if (@MemberToUpdate IS NOT NULL)
		BEGIN
			-- Delete existing row, insert new row	
			BEGIN
				Delete from MemberToJourney Where MemberToJourney.MemberId = (Select MemberId from Inserted)
			END
			-- now insert a new row
			BEGIN
				INSERT INTO MemberToJourney (MemberId, JourneyId)
				 Select i.MemberId,  i.JourneyId From Inserted i
				RETURN 
			END
		END
	  -- **************************************************************
	  -- 3. If this is totally new just insert the stuff and be done with it
	  IF (@ExistingMemberJourneyPair IS NULL)
	  -- Insert The new row
		BEGIN
			INSERT INTO MemberToJourney (MemberId, JourneyId)
			 Select i.MemberId,  i.JourneyId from Inserted i
			RETURN 
		END
END


GO

