-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Brett Garnier>
-- Create date: <5/27/2014>
-- Description:	<flushes all member interests prior to a new insert>
-- =============================================
CREATE PROCEDURE member_ClearAllMemberInterests 
	-- Add the parameters for the stored procedure here
	@MemberId Uniqueidentifier 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete  FROM  dbo.MemberToInterests
	WHERE (MemberId = @memberid)
END
GO
