
/****** Object:  StoredProcedure [dbo].[member_GetNewsletterSubscribers]    Script Date: 07/29/2014 08:36:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[member_GetNewsletterSubscribers] 
	-- Add the parameters for the stored procedure here
	@DefaultName Varchar(50)= 'Parent'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
			SELECT  aspnet_Membership.Email,
					MemberName =
						CASE IsNull(Members.FirstName, '') 
							WHEN '' THEN  @DefaultName
							ELSE members.FirstName
						END,
					PercentComplete = 0,
					Members.MemberId
			FROM  Members INNER JOIN
						   aspnet_Membership ON Members.MemberId = aspnet_Membership.UserId
			where allowNewsletter=1
			ORDER BY Members.DateModified DESC
END

GO


