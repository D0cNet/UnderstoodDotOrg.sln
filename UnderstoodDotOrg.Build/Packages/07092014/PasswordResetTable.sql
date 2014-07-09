/****** Object:  Table [dbo].[PasswordResetTickets]    Script Date: 07/09/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PasswordResetTickets](
	[ResetKey] [uniqueidentifier] NOT NULL,
	[UID] [uniqueidentifier] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[UsedAction] [bit] NOT NULL,
	[IPofUser] [varchar](40) NULL,
 CONSTRAINT [PK_PasswordResetTickets] PRIMARY KEY CLUSTERED 
(
	[ResetKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

