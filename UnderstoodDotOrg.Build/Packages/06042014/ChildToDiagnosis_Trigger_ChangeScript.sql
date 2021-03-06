USE [Understood.org.DEV.membership]
GO
/****** Object:  Trigger [dbo].[trg_InsteadOfInsert_ChildToDiagnosis]    Script Date: 06/05/2014 11:13:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brett Garnier>
-- Create date: <5/20/2014>
-- Description:	  * Enforces and regulates data integrity while preventing errors if entity should try and insert bad data
--                * Entity was trying to insert duplicate rows, this will ignore those inersts 
--                * as it collides with our primary, unique key
--                
-- =============================================
ALTER TRIGGER [dbo].[trg_InsteadOfInsert_ChildToDiagnosis] 
   ON  [dbo].[ChildToDiagnosis]  
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
		From ChildToDiagnosis
		Where ChildToDiagnosis.ChildId = (Select ChildId from Inserted)
			and ChildToDiagnosis.DiagnosisId = (Select DiagnosisId from Inserted)
	   
	IF (@ExistingGuidPair IS NULL)
		-- insert if there is no existing pair
		BEGIN
		INSERT INTO ChildToDiagnosis
               (ChildId, DiagnosisId)
		VALUES ((Select ChildId from Inserted),
				(Select DiagnosisId from Inserted))
		END 
	-- **********************
		
END
