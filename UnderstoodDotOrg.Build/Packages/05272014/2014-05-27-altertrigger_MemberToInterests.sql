USE [Understood.org.DEV.membership]
GO
/****** Object:  Trigger [dbo].[trg_InsteadOfInsert_MemberToInterests]    Script Date: 05/27/2014 13:50:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brett Garnier>
-- Create date: <5/19/2014>
-- Description:	  * Enforces and regulates data integrity while preventing errors if entity should try and insert bad data
--                * Entity was trying to insert duplicate rows, this will ignore those inersts 
--                * as it collides with our primary, unique key
-- *** any mention of InterestId in this maps to a db generated ROWID in the Intersts table, not the KEY
-- =============================================
ALTER TRIGGER [dbo].[trg_InsteadOfInsert_MemberToInterests] 
   ON [dbo].[MemberToInterests] 
  instead OF INSERT 
  AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    	-- **************************************************************
	-- 1. If this insert statement is an insert of duplicate data, let it exit
	DECLARE @ExistingMemberInterestPair UNIQUEIDENTIFIER
	SELECT  @ExistingMemberInterestPair = MemberId
		From MemberToInterests
		Where MemberToInterests.MemberId = (Select MemberId from Inserted)
			and MemberToInterests.InterestId = (Select InterestId from Inserted)
	   
	IF (@ExistingMemberInterestPair IS NOT NULL)
		BEGIN
			RETURN -- DO NOTHING. THIS ROW ALREADY EXISTS
		END 
   -- ********************************************************************
   -- if there was no duplicate discovered, insert the good pair
 Insert Into MemberToInterests (MemberId, InterestId )
		Values ((Select Memberid from inserted) , 
				 (Select InterestId from inserted))
   
 
/*
Declare @GoodInterestKey UNIQUEIDENTIFIER 
 Select @GoodInterestKey  = Interests.[Key] from Interests where rowId = (Select InterestId from inserted)
 Begin
 Insert Into MemberToInterests (MemberId, InterestId )
		Values ((Select Memberid from inserted) , 
				 @GoodInterestKey)
 End
*/


END
