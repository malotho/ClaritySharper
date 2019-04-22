
create table [dbo].[Person] (
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL
	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED
	(
		[ID] ASC
	)
) ON [PRIMARY]
