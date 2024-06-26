USE [EmpleoEmpresarial]
GO
/****** Object:  Table [dbo].[Empleo]    Script Date: 27/05/2024 11:18:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleo](
	[ID] [uniqueidentifier] NOT NULL,
	[Titulo] [varchar](255) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Salario] [decimal](18, 2) NOT NULL,
	[IdModalidadTrabajo] [uniqueidentifier] NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaHoraRegistro] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleoUsuario]    Script Date: 27/05/2024 11:18:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleoUsuario](
	[ID] [uniqueidentifier] NOT NULL,
	[IdEmpleo] [uniqueidentifier] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[IdEstadoEmpleoUsuario] [uniqueidentifier] NOT NULL,
	[Observacion] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoEmpleoUsuario]    Script Date: 27/05/2024 11:18:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoEmpleoUsuario](
	[ID] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[CodigoGrupo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModalidadTrabajo]    Script Date: 27/05/2024 11:18:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModalidadTrabajo](
	[ID] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 27/05/2024 11:18:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[TipoUsuarioID] [uniqueidentifier] NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoUsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/05/2024 11:18:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[TipoUsuarioID] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Empleo] ([ID], [Titulo], [Descripcion], [Salario], [IdModalidadTrabajo], [Activo], [FechaHoraRegistro]) VALUES (N'faad5e5e-dfaa-405f-b03d-6f52fa91637e', N'Desarrollador Junior', N'¡Únete a nuestro equipo como desarrollador de software junior! Buscamos talento apasionado por la programación para trabajar en proyectos innovadores. Conoce más y aplica ahora.', CAST(3800000.00 AS Decimal(18, 2)), N'a265c323-8678-4e85-9493-6a948de1d8b4', 1, CAST(N'2024-05-27T10:46:15.677' AS DateTime))
INSERT [dbo].[Empleo] ([ID], [Titulo], [Descripcion], [Salario], [IdModalidadTrabajo], [Activo], [FechaHoraRegistro]) VALUES (N'ca33d9f8-9d9d-45e8-a306-b79c305e5fe7', N'Desarrollador FrondEnd', N'¿Eres un apasionado del desarrollo web? ¡Esta es tu oportunidad! Buscamos un desarrollador frontend con experiencia en HTML, CSS y JavaScript. ¡Únete a nuestro equipo y haz la diferencia!', CAST(4100000.00 AS Decimal(18, 2)), N'db79b47c-a340-4e22-a815-5c7e9146aefb', 1, CAST(N'2024-05-27T10:46:57.980' AS DateTime))
INSERT [dbo].[Empleo] ([ID], [Titulo], [Descripcion], [Salario], [IdModalidadTrabajo], [Activo], [FechaHoraRegistro]) VALUES (N'c88e20f2-43d1-4927-b398-fb93508d56ab', N'Desarrollador FullStack', N'Se busca desarrollador full-stack para proyecto emocionante. Únete a un equipo dinámico y colaborativo. Experiencia en Python, JavaScript y frameworks como Django y React es imprescindible. ¡Aplica ahora!', CAST(6000000.00 AS Decimal(18, 2)), N'a7759405-6a0e-4cc1-8e31-565c70f12630', 1, CAST(N'2024-05-27T10:47:38.720' AS DateTime))
GO
INSERT [dbo].[EmpleoUsuario] ([ID], [IdEmpleo], [IdUsuario], [IdEstadoEmpleoUsuario], [Observacion]) VALUES (N'b7e779b2-5bca-4e99-ad0c-41935a593e3f', N'ca33d9f8-9d9d-45e8-a306-b79c305e5fe7', N'2895e978-43e1-4a5f-b8fa-e8c6bf51c07f', N'ee12abfa-0a26-4196-895f-d6c4d4b84384', NULL)
INSERT [dbo].[EmpleoUsuario] ([ID], [IdEmpleo], [IdUsuario], [IdEstadoEmpleoUsuario], [Observacion]) VALUES (N'87a71532-8a2b-4ff5-b955-60f8e5e8025d', N'c88e20f2-43d1-4927-b398-fb93508d56ab', N'21b1f54e-a2d2-4eb5-942d-59115493fd4d', N'ee12abfa-0a26-4196-895f-d6c4d4b84384', NULL)
INSERT [dbo].[EmpleoUsuario] ([ID], [IdEmpleo], [IdUsuario], [IdEstadoEmpleoUsuario], [Observacion]) VALUES (N'8ea29c3d-62e6-4b84-bbba-65fbdd9bff10', N'faad5e5e-dfaa-405f-b03d-6f52fa91637e', N'2895e978-43e1-4a5f-b8fa-e8c6bf51c07f', N'ee12abfa-0a26-4196-895f-d6c4d4b84384', NULL)
GO
INSERT [dbo].[EstadoEmpleoUsuario] ([ID], [Descripcion], [Codigo], [CodigoGrupo]) VALUES (N'4bd16b64-ca2e-4a3c-88f0-0c1631d95e39', N'Finalizado', N'FIN', N'APL')
INSERT [dbo].[EstadoEmpleoUsuario] ([ID], [Descripcion], [Codigo], [CodigoGrupo]) VALUES (N'ec5cacf2-7147-45be-a0d4-32bdcde8d393', N'Eliminado', N'ELI', N'OFR')
INSERT [dbo].[EstadoEmpleoUsuario] ([ID], [Descripcion], [Codigo], [CodigoGrupo]) VALUES (N'e1caad01-89ef-4315-a2a5-ca49ca56a5da', N'En Proceso', N'PRO', N'APL')
INSERT [dbo].[EstadoEmpleoUsuario] ([ID], [Descripcion], [Codigo], [CodigoGrupo]) VALUES (N'ee12abfa-0a26-4196-895f-d6c4d4b84384', N'Publicado', N'PUB', N'OFR')
INSERT [dbo].[EstadoEmpleoUsuario] ([ID], [Descripcion], [Codigo], [CodigoGrupo]) VALUES (N'7d3188ec-2fc6-46e7-8a95-dcf96edba96d', N'Pausado', N'PAU', N'OFR')
INSERT [dbo].[EstadoEmpleoUsuario] ([ID], [Descripcion], [Codigo], [CodigoGrupo]) VALUES (N'6672bf9c-c6d8-4f12-ad0a-ed3427634a6c', N'Aplicado', N'APL', N'APL')
GO
INSERT [dbo].[ModalidadTrabajo] ([ID], [Descripcion], [Codigo]) VALUES (N'a7759405-6a0e-4cc1-8e31-565c70f12630', N'Remoto', N'REM')
INSERT [dbo].[ModalidadTrabajo] ([ID], [Descripcion], [Codigo]) VALUES (N'db79b47c-a340-4e22-a815-5c7e9146aefb', N'Presencial', N'PRE')
INSERT [dbo].[ModalidadTrabajo] ([ID], [Descripcion], [Codigo]) VALUES (N'a265c323-8678-4e85-9493-6a948de1d8b4', N'Hibrido', N'HIB')
GO
INSERT [dbo].[TipoUsuario] ([TipoUsuarioID], [Codigo], [Nombre]) VALUES (N'37aa1885-05e8-4a7c-9fc5-25e28e11f963', N'PNA', N'Persona Natural')
INSERT [dbo].[TipoUsuario] ([TipoUsuarioID], [Codigo], [Nombre]) VALUES (N'13ef2f24-151e-4180-a3b1-4510561d40b6', N'EMP', N'Empresa')
GO
INSERT [dbo].[Usuario] ([UsuarioID], [Nombre], [Apellido], [Correo], [Telefono], [NombreUsuario], [Password], [TipoUsuarioID]) VALUES (N'c7384cc9-e11e-43a9-a6d5-28ec8fe551f6', N'Persona', N'Uno', N'PersonaUno@Correo.com', N'1234567890', N'PersonaUno', N'U2FsdGVkX192HGourYcpl3MUZlwsZko2//kRbY6Qk8U=', N'37aa1885-05e8-4a7c-9fc5-25e28e11f963')
INSERT [dbo].[Usuario] ([UsuarioID], [Nombre], [Apellido], [Correo], [Telefono], [NombreUsuario], [Password], [TipoUsuarioID]) VALUES (N'6c20c07c-464f-4c12-bf3f-4d91f72afb30', N'Persona', N'Dos', N'PersonaDos@correo.com', N'0123456789', N'PersonaDos', N'U2FsdGVkX18kyfP82wEJNYQnWnrDc/7x+XnVMFswMxY=', N'37aa1885-05e8-4a7c-9fc5-25e28e11f963')
INSERT [dbo].[Usuario] ([UsuarioID], [Nombre], [Apellido], [Correo], [Telefono], [NombreUsuario], [Password], [TipoUsuarioID]) VALUES (N'21b1f54e-a2d2-4eb5-942d-59115493fd4d', N'Empresa', N'Dos', N'EmpresaDos', N'1234567890', N'EmpresaDos', N'U2FsdGVkX1870TPbGbtLKhn8dj1TKBjsz51iu684L18=', N'13ef2f24-151e-4180-a3b1-4510561d40b6')
INSERT [dbo].[Usuario] ([UsuarioID], [Nombre], [Apellido], [Correo], [Telefono], [NombreUsuario], [Password], [TipoUsuarioID]) VALUES (N'2895e978-43e1-4a5f-b8fa-e8c6bf51c07f', N'Empresa', N'Uno', N'EmpresaUno@Correo.com', N'1234567890', N'EmpresaUno', N'U2FsdGVkX19pArgCzPvp8o6E+J2CHP479USBVejv90c=', N'13ef2f24-151e-4180-a3b1-4510561d40b6')
GO
ALTER TABLE [dbo].[Empleo] ADD  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Empleo] ADD  DEFAULT (getdate()) FOR [FechaHoraRegistro]
GO
ALTER TABLE [dbo].[EmpleoUsuario] ADD  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[EstadoEmpleoUsuario] ADD  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ModalidadTrabajo] ADD  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TipoUsuario] ADD  DEFAULT (newid()) FOR [TipoUsuarioID]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (newid()) FOR [UsuarioID]
GO
ALTER TABLE [dbo].[Empleo]  WITH CHECK ADD FOREIGN KEY([IdModalidadTrabajo])
REFERENCES [dbo].[ModalidadTrabajo] ([ID])
GO
ALTER TABLE [dbo].[Empleo]  WITH CHECK ADD FOREIGN KEY([IdModalidadTrabajo])
REFERENCES [dbo].[ModalidadTrabajo] ([ID])
GO
ALTER TABLE [dbo].[EmpleoUsuario]  WITH CHECK ADD FOREIGN KEY([IdEmpleo])
REFERENCES [dbo].[Empleo] ([ID])
GO
ALTER TABLE [dbo].[EmpleoUsuario]  WITH CHECK ADD FOREIGN KEY([IdEmpleo])
REFERENCES [dbo].[Empleo] ([ID])
GO
ALTER TABLE [dbo].[EmpleoUsuario]  WITH CHECK ADD FOREIGN KEY([IdEstadoEmpleoUsuario])
REFERENCES [dbo].[EstadoEmpleoUsuario] ([ID])
GO
ALTER TABLE [dbo].[EmpleoUsuario]  WITH CHECK ADD FOREIGN KEY([IdEstadoEmpleoUsuario])
REFERENCES [dbo].[EstadoEmpleoUsuario] ([ID])
GO
ALTER TABLE [dbo].[EmpleoUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[EmpleoUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([TipoUsuarioID])
REFERENCES [dbo].[TipoUsuario] ([TipoUsuarioID])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([TipoUsuarioID])
REFERENCES [dbo].[TipoUsuario] ([TipoUsuarioID])
GO
