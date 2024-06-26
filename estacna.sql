USE [EsTacna-Cs2]
GO
/****** Object:  Table [dbo].[Busqueda]    Script Date: 25/05/2024 08:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Busqueda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_id] [int] NOT NULL,
	[termino_busqueda] [varchar](255) NOT NULL,
	[fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eps]    Script Date: 25/05/2024 08:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eps](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eps_EstablecimientoSalud]    Script Date: 25/05/2024 08:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eps_EstablecimientoSalud](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[eps_id] [int] NOT NULL,
	[establecimiento_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstablecimientoSalud]    Script Date: 25/05/2024 08:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstablecimientoSalud](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[ciudad] [varchar](50) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[longitud] [decimal](12, 8) NOT NULL,
	[latitud] [decimal](12, 8) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[imagen] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/05/2024 08:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[contrasena] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valoracion]    Script Date: 25/05/2024 08:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valoracion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[establecimiento_id] [int] NOT NULL,
	[usuario_id] [int] NOT NULL,
	[comentario] [varchar](255) NULL,
	[calificacion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Busqueda] ON 

INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1, 1, N'LA POSITIVA odontologia', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (2, 2, N'LA POSITIVA laboratorio clinico', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (3, 3, N'LA POSITIVA emergencia', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (4, 4, N'RIMAC maternidad', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (5, 5, N'RIMAC maternidad', CAST(N'2023-05-19T02:13:05.633' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (6, 6, N'PACIFICO hospitalizacion', CAST(N'2023-05-19T02:20:31.757' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (7, 7, N'PACIFICO rayos x', CAST(N'2023-05-19T02:21:59.097' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (8, 8, N'SANITAS emergencia', CAST(N'2023-05-19T02:23:55.310' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (9, 9, N'SANITAS farmacia', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (10, 10, N'MAPFRE odontologia', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (11, 11, N'MAPFRE hospitalizacion', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (12, 12, N'MAPFRE maternidad', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (13, 1, N'LA POSITIVA odontologia', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (14, 1, N'LA POSITIVA odontologia', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (15, 1, N'LA POSITIVA centro de imagenes', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (16, 1, N'LA POSITIVA centro de imagenes', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (17, 1, N'LA POSITIVA centro de imagenes', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (18, 1, N'LA POSITIVA centro de imagenes', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (19, 1, N'LA POSITIVA rayos x digital', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (20, 1, N'LA POSITIVA rayos x digital', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (21, 1, N'LA POSITIVA rayos x digital', CAST(N'2023-05-19T01:11:30.700' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (22, 2, N'LA POSITIVA chequeo preventivo', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (23, 2, N'LA POSITIVA chequeo preventivo', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (24, 2, N'LA POSITIVA centro de imagenes', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (25, 2, N'LA POSITIVA centro de imagenes', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (26, 2, N'LA POSITIVA centro de imagenes', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (27, 2, N'LA POSITIVA chequeo preventivo', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (28, 2, N'LA POSITIVA laboratorio clinico', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (29, 2, N'LA POSITIVA laboratorio clinico', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (30, 2, N'LA POSITIVA laboratorio clinico', CAST(N'2023-05-19T01:19:53.667' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (31, 3, N'LA POSITIVA ambulatoria', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (32, 3, N'LA POSITIVA hospitalizacion', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (33, 3, N'LA POSITIVA odontologia', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (34, 3, N'LA POSITIVA chequeo preventivo', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (35, 3, N'LA POSITIVA centro de imagenes', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (36, 3, N'LA POSITIVA laboratorio clinico', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (37, 3, N'LA POSITIVA rayos x digital', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (38, 3, N'LA POSITIVA tomografia', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (39, 3, N'LA POSITIVA ecografia', CAST(N'2023-05-19T01:38:45.860' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (40, 4, N'RIMAC ambulatoria', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (41, 4, N'RIMAC hospitalizacion', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (42, 4, N'RIMAC odontologia', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (43, 4, N'RIMAC chequeo preventivo', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (44, 4, N'RIMAC centro de imagenes', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (45, 4, N'RIMAC laboratorio clinico', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (46, 4, N'RIMAC rayos x digital', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (47, 4, N'RIMAC tomografia', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (48, 4, N'RIMAC ecografia', CAST(N'2023-05-19T02:12:01.210' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (49, 5, N'RIMAC ambulatoria', CAST(N'2023-05-19T02:13:05.633' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (50, 5, N'RIMAC hospitalizacion', CAST(N'2023-05-19T02:13:05.633' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (51, 5, N'RIMAC maternidad', CAST(N'2023-05-19T02:13:05.633' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (52, 5, N'RIMAC odontologia', CAST(N'2023-05-19T02:13:05.633' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (53, 5, N'RIMAC chequeo preventivo', CAST(N'2023-05-19T02:13:05.633' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (54, 5, N'RIMAC emergencia', CAST(N'2023-05-19T02:13:05.633' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (55, 6, N'PACIFICO ambulatoria', CAST(N'2023-05-19T02:20:31.757' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (56, 6, N'PACIFICO hospitalizacion', CAST(N'2023-05-19T02:20:31.757' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (57, 6, N'PACIFICO maternidad', CAST(N'2023-05-19T02:20:31.757' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (58, 6, N'PACIFICO odontologia', CAST(N'2023-05-19T02:20:31.757' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (59, 6, N'PACIFICO chequeo preventivo', CAST(N'2023-05-19T02:20:31.757' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (60, 6, N'PACIFICO emergencia', CAST(N'2023-05-19T02:20:31.757' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (61, 7, N'PACIFICO ambulatoria', CAST(N'2023-05-19T02:21:59.097' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (62, 7, N'PACIFICO hospitalizacion', CAST(N'2023-05-19T02:21:59.097' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (63, 7, N'PACIFICO maternidad', CAST(N'2023-05-19T02:21:59.097' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (64, 7, N'PACIFICO odontologia', CAST(N'2023-05-19T02:21:59.097' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (65, 7, N'PACIFICO chequeo preventivo', CAST(N'2023-05-19T02:21:59.097' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (66, 7, N'PACIFICO emergencia', CAST(N'2023-05-19T02:21:59.097' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (67, 8, N'SANITAS ambulatoria', CAST(N'2023-05-19T02:23:55.310' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (68, 8, N'SANITAS hospitalizacion', CAST(N'2023-05-19T02:23:55.310' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (69, 8, N'SANITAS maternidad', CAST(N'2023-05-19T02:23:55.310' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (70, 8, N'SANITAS odontologia', CAST(N'2023-05-19T02:23:55.310' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (71, 8, N'SANITAS chequeo preventivo', CAST(N'2023-05-19T02:23:55.310' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (72, 8, N'SANITAS emergencia', CAST(N'2023-05-19T02:23:55.310' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (73, 9, N'SANITAS ambulatoria', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (74, 9, N'SANITAS hospitalizacion', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (75, 9, N'SANITAS maternidad', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (76, 9, N'SANITAS odontologia', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (77, 9, N'SANITAS chequeo preventivo', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (78, 9, N'SANITAS emergencia', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (79, 9, N'SANITAS centro de imagenes', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (80, 9, N'SANITAS laboratorio clinico', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (81, 9, N'SANITAS tomografia', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (82, 9, N'SANITAS ecografia', CAST(N'2023-05-19T02:25:30.100' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (83, 10, N'MAPFRE ambulatoria', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (84, 10, N'MAPFRE hospitalizacion', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (85, 10, N'MAPFRE maternidad', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (86, 10, N'MAPFRE odontologia', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (87, 10, N'MAPFRE chequeo preventivo', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (88, 10, N'MAPFRE emergencia', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (89, 10, N'MAPFRE centro de imagenes', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (90, 10, N'MAPFRE laboratorio clinico', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (91, 10, N'MAPFRE tomografia', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (92, 10, N'MAPFRE ecografia', CAST(N'2023-05-19T02:38:29.533' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (93, 11, N'MAPFRE ambulatoria', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (94, 11, N'MAPFRE hospitalizacion', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (95, 11, N'MAPFRE maternidad', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (96, 11, N'MAPFRE odontologia', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (97, 11, N'MAPFRE chequeo preventivo', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (98, 11, N'MAPFRE emergencia', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (99, 11, N'MAPFRE centro de imagenes', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
GO
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (100, 11, N'MAPFRE laboratorio clinico', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (101, 11, N'MAPFRE tomografia', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (102, 11, N'MAPFRE ecografia', CAST(N'2023-05-19T02:40:06.930' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (103, 12, N'MAPFRE ambulatoria', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (104, 12, N'MAPFRE hospitalizacion', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (105, 12, N'MAPFRE maternidad', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (106, 12, N'MAPFRE odontologia', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (107, 12, N'MAPFRE chequeo preventivo', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (108, 12, N'MAPFRE emergencia', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (109, 12, N'MAPFRE centro de imagenes', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (110, 12, N'MAPFRE laboratorio clinico', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (111, 12, N'MAPFRE tomografia', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (112, 12, N'MAPFRE ecografia', CAST(N'2023-05-19T02:50:18.060' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (113, 2, N'LA POSITIVA odontologia', CAST(N'2023-05-24T20:36:29.920' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (114, 2, N'LA POSITIVA imagenes', CAST(N'2023-05-24T20:37:30.743' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (115, 2, N'LA POSITIVA CLINICA PROMEDIC', CAST(N'2023-06-16T15:00:09.737' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (116, 2, N'LA POSITIVA CLINICA PROMEDIC', CAST(N'2023-06-16T16:02:42.367' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (117, 2, N'LA POSITIVA centro', CAST(N'2023-06-18T17:02:28.517' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (118, 1, N'LA POSITIVA Centro de imagenes', CAST(N'2023-06-18T17:04:16.693' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (119, 2, N'LA POSITIVA Centro de imagenes', CAST(N'2023-06-18T17:05:03.923' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (120, 1, N'LA POSITIVA Centro de imagenes', CAST(N'2023-06-18T17:09:52.787' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (121, 2, N'LA POSITIVA Centro de imagenes', CAST(N'2023-06-18T17:10:22.587' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (122, 1, N'LA POSITIVA Centro de imagenes', CAST(N'2023-06-18T17:12:51.080' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (123, 1, N'LA POSITIVA Centro de imagenes', CAST(N'2023-06-18T17:14:42.520' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (124, 1, N'Término de búsqueda', CAST(N'2023-06-18T18:19:08.940' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (125, 1, N'Término de búsqueda', CAST(N'2023-06-18T18:24:39.833' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (126, 2, N'LA POSITIVA odontologia', CAST(N'2023-06-18T19:50:34.017' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (127, 1, N'Término de búsqueda', CAST(N'2023-06-18T20:03:55.663' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (128, 2, N'LA POSITIVA odontologia', CAST(N'2024-03-27T19:55:00.303' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (129, 2, N'LA POSITIVA odontologia', CAST(N'2024-03-27T20:01:40.380' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (130, 1, N'PACIFICO Luz', CAST(N'2024-03-27T20:02:22.800' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (131, 2, N'PACIFICO Luz', CAST(N'2024-03-27T20:03:17.377' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1128, 1, N'PACIFICO odontologia', CAST(N'2024-04-04T14:38:53.390' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1129, 1, N'PACIFICO odontologia', CAST(N'2024-04-04T14:43:05.480' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1130, 1, N'LA POSITIVA ', CAST(N'2024-04-04T15:17:21.600' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1131, 1, N'PACIFICO ', CAST(N'2024-04-04T15:17:46.363' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1132, 1, N'RIMAC ', CAST(N'2024-04-04T15:18:12.457' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1133, 1, N'SANITAS ', CAST(N'2024-04-04T15:18:41.813' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1134, 1, N'LA POSITIVA ', CAST(N'2024-04-04T15:21:51.680' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1135, 1, N'LA POSITIVA ', CAST(N'2024-04-04T15:26:44.723' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1136, 2, N'LA POSITIVA la luz', CAST(N'2024-04-04T15:31:57.833' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1137, 1, N'LA POSITIVA ', CAST(N'2024-04-04T22:46:55.463' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1138, 1, N'LA POSITIVA ', CAST(N'2024-04-04T22:48:34.353' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1139, 1, N'LA POSITIVA ', CAST(N'2024-04-04T22:54:23.480' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1140, 1, N'LA POSITIVA ', CAST(N'2024-04-04T22:58:54.820' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1141, 2, N'LA POSITIVA ambulatoria', CAST(N'2024-04-10T17:05:30.840' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1142, 2, N'LA POSITIVA ambulatoria', CAST(N'2024-04-10T17:08:24.330' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (1143, 2, N'LA POSITIVA ambulatoria', CAST(N'2024-04-10T17:20:05.837' AS DateTime))
INSERT [dbo].[Busqueda] ([id], [usuario_id], [termino_busqueda], [fecha]) VALUES (2141, 2, N'LA POSITIVA remasur', CAST(N'2024-04-12T23:41:09.880' AS DateTime))
SET IDENTITY_INSERT [dbo].[Busqueda] OFF
GO
SET IDENTITY_INSERT [dbo].[Eps] ON 

INSERT [dbo].[Eps] ([id], [nombre]) VALUES (1, N'LA POSITIVA')
INSERT [dbo].[Eps] ([id], [nombre]) VALUES (2, N'MAPFRE')
INSERT [dbo].[Eps] ([id], [nombre]) VALUES (3, N'PACIFICO')
INSERT [dbo].[Eps] ([id], [nombre]) VALUES (4, N'RIMAC')
INSERT [dbo].[Eps] ([id], [nombre]) VALUES (5, N'SANITAS')
SET IDENTITY_INSERT [dbo].[Eps] OFF
GO
SET IDENTITY_INSERT [dbo].[Eps_EstablecimientoSalud] ON 

INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (1, 1, 1)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (2, 2, 1)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (3, 3, 1)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (4, 4, 1)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (5, 5, 1)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (6, 1, 2)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (7, 2, 2)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (8, 4, 2)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (9, 1, 3)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (10, 5, 3)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (11, 1, 4)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (12, 3, 4)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (13, 5, 4)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (14, 1, 5)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (15, 2, 5)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (16, 3, 5)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (17, 4, 5)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (18, 5, 5)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (19, 1, 6)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (20, 2, 6)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (21, 3, 6)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (22, 4, 6)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (23, 5, 6)
INSERT [dbo].[Eps_EstablecimientoSalud] ([id], [eps_id], [establecimiento_id]) VALUES (24, 2, 7)
SET IDENTITY_INSERT [dbo].[Eps_EstablecimientoSalud] OFF
GO
SET IDENTITY_INSERT [dbo].[EstablecimientoSalud] ON 

INSERT [dbo].[EstablecimientoSalud] ([id], [nombre], [ciudad], [direccion], [longitud], [latitud], [descripcion], [imagen]) VALUES (1, N'CLINICA PROMEDIC', N'TACNA', N'CL. BLONDELL Nº 425', CAST(-70.25700929 AS Decimal(12, 8)), CAST(-18.01720624 AS Decimal(12, 8)), N'AMBULATORIA, HOSPITALIZACION, MATERNIDAD, ODONTOLOGIA, CHEQUEO PREVENTIVO', N'https://pbs.twimg.com/profile_images/1462498390/Logotipo_Promedic_400x400.png')
INSERT [dbo].[EstablecimientoSalud] ([id], [nombre], [ciudad], [direccion], [longitud], [latitud], [descripcion], [imagen]) VALUES (2, N'CENTRO MEDICO SAN PEDRO', N'TACNA', N'CL. ARICA Nº 246', CAST(-70.25005418 AS Decimal(12, 8)), CAST(-18.01804337 AS Decimal(12, 8)), N'AMBULATORIA', N'https://www.freepnglogos.com/uploads/medicine-logo-png-1.png')
INSERT [dbo].[EstablecimientoSalud] ([id], [nombre], [ciudad], [direccion], [longitud], [latitud], [descripcion], [imagen]) VALUES (3, N'REMASUR', N'TACNA', N'PROL. DANIEL ALCIDES CARRION Nº 360, CERCADO', CAST(-70.25959212 AS Decimal(12, 8)), CAST(-18.01473001 AS Decimal(12, 8)), N'CENTRO DE IMAGENES', N'https://i2.wp.com/remasurperu.com/wp-content/uploads/2019/04/logo0.png?fit=2038%2C1375&ssl=1')
INSERT [dbo].[EstablecimientoSalud] ([id], [nombre], [ciudad], [direccion], [longitud], [latitud], [descripcion], [imagen]) VALUES (4, N'CLINICA LA LUZ', N'TACNA', N'AV. MANUEL A. ODRIA Nº 702', CAST(-70.25903352 AS Decimal(12, 8)), CAST(-18.02277723 AS Decimal(12, 8)), N'EMERGENCIA, LABORATORIO CLINICO, RAYOS X DIGITAL, TOMOGRAFIA, ECOGRAFIA, SALA DE OPRACIONES, SALA DE PARTOS, UCI, FARMACIA', N'https://clinicalaluz.pe/wp-content/uploads/2019/03/clinica-la-luz-sedes-tacna-main.jpg')
INSERT [dbo].[EstablecimientoSalud] ([id], [nombre], [ciudad], [direccion], [longitud], [latitud], [descripcion], [imagen]) VALUES (5, N'CLINICA ISABEL', N'TACNA', N'CL. ARICA Nº 151', CAST(-70.25067577 AS Decimal(12, 8)), CAST(-18.01744854 AS Decimal(12, 8)), N'AMBULATORIA, HOSPITALIZACION, MATERNIDAD, CHEQUEO PREVENTIVO, EMERGENCIA', N'https://lh3.googleusercontent.com/p/AF1QipNRH0pXJCYC95RQILeCtEJtd52RcLFOQHqXkF5c=s1600-w1600')
INSERT [dbo].[EstablecimientoSalud] ([id], [nombre], [ciudad], [direccion], [longitud], [latitud], [descripcion], [imagen]) VALUES (6, N'CENTRO ODONTOLOGICO AMERICANO', N'TACNA', N'CL. BILLINGHURST Nº 358', CAST(-70.24670685 AS Decimal(12, 8)), CAST(-18.01789086 AS Decimal(12, 8)), N'ODONTOLOGIA', N'https://sin-intereses-peru.s3.amazonaws.com/stores/2039_centro-odontolgico-americano/main/centro-odontologico-americano.jpg')
INSERT [dbo].[EstablecimientoSalud] ([id], [nombre], [ciudad], [direccion], [longitud], [latitud], [descripcion], [imagen]) VALUES (7, N'CONSORCIO DENTAL SUIZA', N'TACNA', N'CL. MILLER 50-2DO PISO', CAST(-70.24763036 AS Decimal(12, 8)), CAST(-18.01353332 AS Decimal(12, 8)), N'ODONTOLOGIA', N'https://imgs.deperu.com/lugares/medico_consultorio.jpg')
SET IDENTITY_INSERT [dbo].[EstablecimientoSalud] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (1, N'ANONIMO', N'ANON', N'anonimo@anonimo.pe', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (2, N'ALEJANDRA MARIA', N'VALDIVIA GUZMAN', N'alevaldiviag@upt.pe', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (3, N'JUANA MARIA', N'PEREZ MAMANI', N'juaperezm@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (4, N'CARLOS ALBERTO', N'QUISPE GONZALEZ', N'carquispeg@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (5, N'JOHAN ANTHONY', N'ALVAREZ PARINA', N'johalvarez@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (6, N'FERNANDO JAVIER ', N'BALLON ESTACIO', N'fballonestacio@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (7, N'STEPHANY DE FATIMA', N'CABALLERO PACHECO', N'stepcaballero@hotmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (8, N'YESENIA MERLINDA', N'CARHUACHIN SIANCAS ', N'yesenia.carhuachin@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (9, N'ANGIE LIZETT ', N'BERMUDEZ RODRIGUEZ', N'abermudez92.2@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (10, N'FRANCO LUCIO', N'CASTILLO CARDENAS', N'flcastillo1011@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (11, N'KARINA YOLANDA', N'LOPEZ LIMACHE', N'lopezlimachekarinayolanda@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (12, N'ALDO JAIR', N'LOPEZ FERNANDEZ', N'aldolopez578@gmail.com', N'123456')
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [email], [contrasena]) VALUES (13, N'Test', N'Test', N'Test@test.pe', N'Test')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Valoracion] ON 

INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (1, 3, 3, N'Es el medio por el cual los medicos te enganchan para luego citarte en su consultorio particular. Me toco vivirlo en dermatologia.', 1)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (2, 3, 2, N'Pesima atención esos doctores vienen a la hora que quieren irresponsables', 1)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (3, 4, 3, N'No recomendado. Nunca me avisaron que cancelaron mi cita médica y la señorita de recepción no soluciona nada.', 1)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (4, 4, 4, N'Atención desde las 7:30 am  es un clínica moderna , equipos nuevos', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (5, 4, 5, N'Las mejores instalaciones de la ciudad de Tacna, la atención es muy buena, muy bien capacitados el personal de atencion, los doctores se toman muy en serio su trabajo.', 4)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (6, 4, 6, N'Es muy buen lugar para atenderse, ademas cuenta con una pagina de facebook activa  para saber todas sus campanas', 4)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (7, 4, 7, N'Muy completa la atencion desde consulta medica, examenes y analisis por parte del medico', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (8, 4, 8, N'podrian mejorar el tema de recepcion,ya que se llama y llama y casi nunca responden el telefono', 2)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (9, 4, 9, N'Satisfecho con sus servicios', 4)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (10, 4, 10, N'Buena atencion sobre todo en odontologia', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (11, 1, 11, N'La atencion excelente, yo soy de Lima y tuve un pequeno accidente , me enyesaron en el seguro essalud y para sacarme el yeso  me recomendaron la clinica . Muy satisfecha.', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (12, 1, 12, N'La atencion es muy buena y los especialistas que tienen tambien. Aunque el costo de consultas y recetas es un poco elevado.', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (13, 1, 3, N'Excelente atención en este establecimiento. El personal es amable y competente. Los doctores son muy profesionales.', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (14, 1, 3, N'Siempre recibo un servicio de calidad en este establecimiento. Los doctores son muy atentos y se preocupan por mi salud.', 4)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (15, 1, 3, N'El personal de este establecimiento es muy dedicado y se nota que les importa el bienestar de los pacientes.', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (16, 3, 3, N'La atención en este establecimiento deja mucho que desear. Los doctores son poco profesionales y no se preocupan.', 2)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (17, 3, 3, N'No recomendaría este establecimiento. La atención es deficiente y el personal es descortés.', 1)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (18, 6, 3, N'Estoy muy satisfecho con la atención que he recibido en este establecimiento. El personal es amable y servicial.', 4)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (19, 6, 3, N'Los doctores en este establecimiento son realmente excepcionales. Siempre me brindan un excelente cuidado médico.', 4)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (20, 6, 3, N'Recomiendo encarecidamente este establecimiento. La calidad de la atención es insuperable.', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (21, 1, 2, N'La atención en este establecimiento es maravillosa. Los doctores son muy amables y siempre me hacen sentir bienvenido.', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (22, 1, 2, N'Me encanta este establecimiento. El personal es profesional y los doctores son expertos en su campo.', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (23, 1, 2, N'La calidad de la atención en este establecimiento es sobresaliente. No tengo quejas en absoluto.', 4)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (24, 5, 2, N'Los doctores en este establecimiento son muy poco confiables. Siempre llegan tarde y la atención es deficiente.', 1)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (25, 5, 2, N'No recomendaría este establecimiento. Los doctores son incompetentes y no se toman en serio su trabajo.', 2)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (26, 3, 2, N'La atención en este establecimiento es de primera clase. Los doctores son muy conocedores y me hacen sentir cómodo.', 3)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (27, 3, 2, N'Me siento muy agradecido por el trato que he recibido en este establecimiento. El personal es amable y eficiente.', 3)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (28, 3, 2, N'Este establecimiento es excepcional. Recibo una atención de calidad y me siento en buenas manos.', 4)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (29, 5, 4, N'Este es un comentario de prueba', 5)
INSERT [dbo].[Valoracion] ([id], [establecimiento_id], [usuario_id], [comentario], [calificacion]) VALUES (30, 5, 4, N'Este es un comentario de prueba', 5)
SET IDENTITY_INSERT [dbo].[Valoracion] OFF
GO
ALTER TABLE [dbo].[Busqueda]  WITH CHECK ADD FOREIGN KEY([usuario_id])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Eps_EstablecimientoSalud]  WITH CHECK ADD FOREIGN KEY([eps_id])
REFERENCES [dbo].[Eps] ([id])
GO
ALTER TABLE [dbo].[Eps_EstablecimientoSalud]  WITH CHECK ADD FOREIGN KEY([establecimiento_id])
REFERENCES [dbo].[EstablecimientoSalud] ([id])
GO
ALTER TABLE [dbo].[Valoracion]  WITH CHECK ADD FOREIGN KEY([establecimiento_id])
REFERENCES [dbo].[EstablecimientoSalud] ([id])
GO
ALTER TABLE [dbo].[Valoracion]  WITH CHECK ADD FOREIGN KEY([usuario_id])
REFERENCES [dbo].[Usuario] ([id])
GO
