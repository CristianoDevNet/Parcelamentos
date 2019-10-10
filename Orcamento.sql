USE [teste]
GO

/****** Object:  Table [dbo].[Orcamento]    Script Date: 10/10/2019 17:03:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orcamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProdutoId] [int] NOT NULL,
	[ValorBase] [decimal](10, 2) NOT NULL,
	[JurosMes] [decimal](10, 4) NOT NULL,
 CONSTRAINT [PK_Orcamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orcamento]  WITH CHECK ADD  CONSTRAINT [FK_Orcamento_Produto] FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([Id])
GO

ALTER TABLE [dbo].[Orcamento] CHECK CONSTRAINT [FK_Orcamento_Produto]
GO

