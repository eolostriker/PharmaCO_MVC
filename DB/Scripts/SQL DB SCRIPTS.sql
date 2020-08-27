USE master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PharmaCO')
BEGIN
    DROP DATABASE PharmaCO;  
END;
CREATE DATABASE PharmaCO;
GO
USE [PharmaCO]
GO
If exists (select name from sysobjects where name = 'Usuarios')
BEGIN
	DROP TABLE Usuarios;
END;
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/08/2020 23:28:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Idade] [int] NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Senha] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [PharmaCO]
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SelectUsuario')
    BEGIN
        DROP Procedure SelectUsuario
    END
 GO
/****** Object:  StoredProcedure [dbo].[SelectUsuario]    Script Date: 26/08/2020 23:31:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectUsuario] @UsuarioId int
AS
BEGIN
	SELECT * FROM Usuarios WHERE UsuarioId = @UsuarioId
END
GO
USE [PharmaCO]
GO
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUsuario')
    BEGIN
        DROP Procedure InsertUsuario
    END
 GO
/****** Object:  StoredProcedure [dbo].[InsertUsuario]    Script Date: 26/08/2020 23:34:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUsuario] 
		@Nome [nvarchar](50),
		@Idade [int],
		@Usuario [nvarchar](50),
		@Senha [nvarchar](50),
		@Email [nvarchar](100)
AS
BEGIN
INSERT INTO Usuarios VALUES (@Nome, @Idade, @Usuario, @Senha, @Email)
END
GO



