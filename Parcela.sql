USE [teste]
GO

/****** Object:  Table [dbo].[Parcela]    Script Date: 10/10/2019 17:03:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parcela](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrcamentoId] [int] NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
	[Data] [datetime] NOT NULL,
 CONSTRAINT [PK_Parcela] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Parcela]  WITH CHECK ADD  CONSTRAINT [FK_Parcela_Orcamento] FOREIGN KEY([OrcamentoId])
REFERENCES [dbo].[Orcamento] ([Id])
GO

ALTER TABLE [dbo].[Parcela] CHECK CONSTRAINT [FK_Parcela_Orcamento]
GO

