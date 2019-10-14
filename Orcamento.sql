USE [Commands]
GO

/****** Object:  Table [dbo].[Orcamento]    Script Date: 13/10/2019 22:44:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orcamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProdutoId] [int] NOT NULL,
	[ValorBase] [decimal](10, 2) NOT NULL,
	[JurosMes] [decimal](10, 4) NOT NULL,
	[QtdParcelas] [int] NOT NULL,
	[DataCompra] [datetime] NOT NULL,
 CONSTRAINT [PK_Orcamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orcamento]  WITH CHECK ADD  CONSTRAINT [FK_Orcamento_Produto] FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Orcamento] CHECK CONSTRAINT [FK_Orcamento_Produto]
GO

