USE [SNQHM_bangazoncli_db]
GO

ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Owner]
GO

ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF_Product_OutOfStock]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 4/11/2018 6:06:47 PM ******/
DROP TABLE [dbo].[Product]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 4/11/2018 6:06:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Price] [money] NOT NULL,
	[Owner] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[OutOfStock] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_OutOfStock]  DEFAULT ((0)) FOR [OutOfStock]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Owner] FOREIGN KEY([Owner])
REFERENCES [dbo].[Customer] ([CustomerID])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Owner]
GO

