-- Changes the username for @OldUserName to @NewUserName (in application @ApplicationName) 
-- Returns: 
--	0 if success 
-- 1 if @OldUserName not found 
-- 2 if @NewUserName is already taken 

CREATE PROCEDURE dbo.usp_ChangeUsername 
   @ApplicationName    nvarchar(256), 
   @OldUserName       nvarchar(256), 
   @NewUserName       nvarchar(256) 
AS 
BEGIN 

-- Get the UserId and ApplicationId for the user 
   DECLARE @UserId uniqueidentifier, @ApplicationId uniqueidentifier 
   SELECT @UserId = NULL 
    
   SELECT @UserId = u.UserId, @ApplicationId = a.ApplicationId 
   FROM   dbo.aspnet_Users u, dbo.aspnet_Applications a 
   WHERE LoweredUserName = LOWER(@OldUserName) AND 
         u.ApplicationId = a.ApplicationId AND 
         LOWER(@ApplicationName) = a.LoweredApplicationName 

   IF (@UserId IS NULL) 
      RETURN(1) 


   -- Ensure that @NewUserName is not in use 
   IF (EXISTS(SELECT 1 FROM aspnet_Users WHERE LoweredUserName = LOWER(@NewUserName) AND ApplicationId = @ApplicationId)) 
      RETURN(2) 


   -- Change the username 
   UPDATE aspnet_Users SET 
        UserName = @NewUserName, 
        LoweredUserName = LOWER(@NewUserName) 
   WHERE UserId = @UserId AND ApplicationId = @ApplicationId 

   RETURN(0) 
END