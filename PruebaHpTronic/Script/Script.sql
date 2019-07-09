USE [Finanzas]
GO
/****** Object:  Table [dbo].[Bancos]    Script Date: 9/7/2019 2:01:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bancos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NULL,
	[Cuenta] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacciones]    Script Date: 9/7/2019 2:01:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Banco] [int] NULL,
	[Tipo] [varchar](15) NULL,
	[Fecha] [date] NULL,
	[Detalle] [varchar](30) NULL,
	[Monto] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bancos] ON 
GO
INSERT [dbo].[Bancos] ([Id], [Nombre], [Cuenta]) VALUES (1, N'Popular', N'111112')
GO
INSERT [dbo].[Bancos] ([Id], [Nombre], [Cuenta]) VALUES (4, N'BHD', N'12312313')
GO
SET IDENTITY_INSERT [dbo].[Bancos] OFF
GO
SET IDENTITY_INSERT [dbo].[Transacciones] ON 
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (1, 1, N'Deposito', CAST(N'2019-02-02' AS Date), N'Prueba', CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (2, 1, N'Deposito', CAST(N'2019-02-02' AS Date), N'Prueba', CAST(10000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (3, 1, N'Retiro', CAST(N'2019-02-02' AS Date), N'Prueba12', CAST(-2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (5, 1, N'Retiro', CAST(N'2019-07-08' AS Date), N'tttt', CAST(-1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (6, 4, N'Deposito', CAST(N'2019-02-02' AS Date), N'prueba', CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (7, 4, N'Deposito', CAST(N'2019-02-02' AS Date), N'prueba', CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (8, 4, N'Deposito', CAST(N'2019-02-02' AS Date), N'prueba', CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (9, 4, N'Deposito', CAST(N'2019-02-02' AS Date), N'prueba', CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (10, 4, N'Deposito', CAST(N'2019-02-02' AS Date), N'prueba', CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Transacciones] ([Id], [Id_Banco], [Tipo], [Fecha], [Detalle], [Monto]) VALUES (11, 4, N'Deposito', CAST(N'2019-02-02' AS Date), N'prueba', CAST(500 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Transacciones] OFF
GO
/****** Object:  StoredProcedure [dbo].[EliminarBanco]    Script Date: 9/7/2019 2:01:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Albert Lopez
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[EliminarBanco] 
	-- Add the parameters for the stored procedure here
	@Id int = 0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete Bancos Where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarTransaccion]    Script Date: 9/7/2019 2:01:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Albert Lopez
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[EliminarTransaccion] 
	-- Add the parameters for the stored procedure here
	@Id int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE Transacciones Where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarBanco]    Script Date: 9/7/2019 2:01:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Albert Lopez
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[InsertarBanco] 
	-- Add the parameters for the stored procedure here
	@Nombre varchar(30) = 0, 
	@Cuenta varchar(30) = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT Into Bancos (Nombre,Cuenta) Values(@Nombre,@Cuenta);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarTransaccion]    Script Date: 9/7/2019 2:01:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Albert Lopez
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[InsertarTransaccion] 
	-- Add the parameters for the stored procedure here
	@Id_banco int = 0, 
	@Tipo varchar(15),
	@Fecha date,
	@Detalle varchar(30),
	@Monto decimal
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Transacciones VALUES(@Id_banco,@Tipo,@Fecha,@Detalle,@Monto);
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarBancos]    Script Date: 9/7/2019 2:01:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Albert Lopez
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[ModificarBancos] 
	-- Add the parameters for the stored procedure here
	@id int, 
	@Nombre varchar(30),
	@Cuenta varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Bancos set Nombre = @Nombre, Cuenta = @Cuenta where Id = @id; 
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarTransaccion]    Script Date: 9/7/2019 2:01:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Albert Lopez
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[ModificarTransaccion] 
	-- Add the parameters for the stored procedure here
	@Id int = 0, 
	@Id_Banco int = 0,
	@Tipo varchar(15),
	@Fecha date,
	@Detalle varchar(30),
	@Monto decimal
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Transacciones set Id_Banco = @Id_Banco,Tipo = @Tipo,Fecha=@Fecha,Detalle = @Detalle,Monto = @Monto where Id = @Id; 
END
GO
/****** Object:  StoredProcedure [dbo].[OperacionTransacciones]    Script Date: 9/7/2019 2:01:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Albert Lopez
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[OperacionTransacciones] 
	-- Add the parameters for the stored procedure here
	@Id int = 0, 
	@Id_Banco int = 0,
	@Tipo varchar(15),
	@Fecha date,
	@Detalle varchar(30),
	@Monto decimal
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF(@Id = 0)
		BEGIN
			INSERT INTO Transacciones VALUES(@Id_banco,@Tipo,@Fecha,@Detalle,@Monto);
		END
	ELSE
		BEGIN
			update Transacciones set Id_Banco = @Id_Banco,Tipo = @Tipo,Fecha=@Fecha,Detalle = @Detalle,Monto = @Monto where Id = @Id; 
		END

END
GO
