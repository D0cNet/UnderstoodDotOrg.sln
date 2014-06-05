-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brett Garnier>
-- Create date: <6/5/2014>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER dbo.trg_MemberAlertPreferences_UpdateDateModified
   ON  [dbo].[MemberAlertPreferences]
  AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
    UPDATE [dbo].[MemberAlertPreferences]
    SET DateModified = GETDATE()
    WHERE MemberId IN (SELECT DISTINCT MemberId FROM Inserted)

END
GO
