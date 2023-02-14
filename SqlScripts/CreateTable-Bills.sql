USE [ItemsDb]
GO

/****** Object:  Table [dbo].[Bills]    Script Date: 2/15/2023 5:49:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bills](
	[Id] [uniqueidentifier] NOT NULL,
	[DateTime] [datetime] NULL,
	[SubTotal] [float] NULL,
	[Discount] [float] NULL,
	[GrandTotal] [float] NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


