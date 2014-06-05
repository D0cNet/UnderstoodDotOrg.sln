USE [Understood.org.DEV.membership]
GO

/****** Object:  Trigger [dbo].[trg_InsteadOfInsert_ChildToIssues]    Script Date: 06/04/2014 17:17:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Brett Garnier>
-- Create date: <5/21/2014>
-- Description:	  * Enforces and regulates data integrity while preventing errors if entity should try and insert bad data
--                * Entity was trying to insert duplicate rows, this will ignore those inersts 
--                * as it collides with our primary, unique key. 
--                
-- =============================================
ALTER TRIGGER [dbo].[trg_InsteadOfInsert_ChildToIssues] 
   ON  [dbo].[ChildToIssues]  
     INSTEAD OF INSERT 
  AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	-- 1. If this insert statement is an insert of duplicate data, let it exit
	DECLARE @ExistingGuidPair UNIQUEIDENTIFIER
	SELECT  @ExistingGuidPair = ChildId
		From ChildToIssues
		Where ChildToIssues.ChildId = (Select ChildId from Inserted)
			and ChildToIssues.IssueId = (Select IssueId from Inserted)
	   
	IF (@ExistingGuidPair IS NOT NULL)
		BEGIN
			RETURN -- DO NOTHING. THIS ROW ALREADY EXISTS.
		END 
		
		-- **********************
		INSERT INTO ChildToIssues
               (ChildId, IssueId)
		VALUES ((Select ChildId from Inserted),
				(Select IssueId from Inserted))
END


GO

