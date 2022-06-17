USE [master]
GO
/****** Object:  Database [Veterinaria]    Script Date: 5/28/2022 7:23:39 PM ******/
CREATE DATABASE [Veterinaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Veterinaria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVERDEV\MSSQL\DATA\Veterinaria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Veterinaria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVERDEV\MSSQL\DATA\Veterinaria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Veterinaria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Veterinaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Veterinaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Veterinaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Veterinaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Veterinaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Veterinaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Veterinaria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Veterinaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Veterinaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Veterinaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Veterinaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Veterinaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Veterinaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Veterinaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Veterinaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Veterinaria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Veterinaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Veterinaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Veterinaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Veterinaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Veterinaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Veterinaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Veterinaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Veterinaria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Veterinaria] SET  MULTI_USER 
GO
ALTER DATABASE [Veterinaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Veterinaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Veterinaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Veterinaria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Veterinaria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Veterinaria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Veterinaria] SET QUERY_STORE = OFF
GO
USE [Veterinaria]
GO
/****** Object:  Table [dbo].[tbcirugia]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbcirugia](
	[cod_cirugia] [int] NOT NULL,
	[cod_paciente] [int] NOT NULL,
	[duracion_minutos] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[anestesia] [varchar](2) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
 CONSTRAINT [tbcirugia_pk] PRIMARY KEY CLUSTERED 
(
	[cod_cirugia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbCita]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCita](
	[cod_cita] [int] IDENTITY(1,1) NOT NULL,
	[fecha_cita] [date] NOT NULL,
	[hora_cita] [int] NOT NULL,
	[cod_paciente] [int] NOT NULL,
	[descrip_cita] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[cod_medico] [int] NOT NULL,
 CONSTRAINT [tbcita_pk] PRIMARY KEY CLUSTERED 
(
	[cod_cita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbDUENO]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDUENO](
	[cod_dueno] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NOT NULL,
	[apellido] [varchar](25) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[DNI] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_dueno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbEmpleado]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEmpleado](
	[cod_empleado] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](25) NOT NULL,
	[APELLIDO] [varchar](25) NOT NULL,
	[DIRECCION] [varchar](50) NOT NULL,
	[DNI] [varchar](15) NOT NULL,
	[fecha_ing] [date] NOT NULL,
	[cod_puesto] [int] NOT NULL,
 CONSTRAINT [tbempleado_fk] PRIMARY KEY CLUSTERED 
(
	[cod_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbenfermedad]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbenfermedad](
	[cod_enfermedad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[descripcion] [varchar](60) NOT NULL,
 CONSTRAINT [tbenfermedad_pk] PRIMARY KEY CLUSTERED 
(
	[cod_enfermedad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbenferXRaza]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbenferXRaza](
	[cod_raza] [int] NOT NULL,
	[cod_enfermedad] [int] NOT NULL,
 CONSTRAINT [tbenferxraza_pk] PRIMARY KEY CLUSTERED 
(
	[cod_raza] ASC,
	[cod_enfermedad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbespecie]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbespecie](
	[cod_especie] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[cod_familia] [int] NOT NULL,
 CONSTRAINT [tbespecie_pk] PRIMARY KEY CLUSTERED 
(
	[cod_especie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbfamilia]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbfamilia](
	[cod_familia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](29) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [tbfamilia_pk] PRIMARY KEY CLUSTERED 
(
	[cod_familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbmedicina]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbmedicina](
	[cod_medicina] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[descripcion] [varchar](40) NOT NULL,
	[dosis] [int] NOT NULL,
	[uomdosis] [varchar](3) NOT NULL,
	[frecuencia] [int] NOT NULL,
	[uom_frecuencia] [varchar](3) NOT NULL,
 CONSTRAINT [tbmedicina_pk] PRIMARY KEY CLUSTERED 
(
	[cod_medicina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbmedixenfer]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbmedixenfer](
	[cod_medicina] [int] NOT NULL,
	[cod_enfermedad] [int] NOT NULL,
 CONSTRAINT [tbmedixenfer_pk] PRIMARY KEY CLUSTERED 
(
	[cod_medicina] ASC,
	[cod_enfermedad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbmedixreceta]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbmedixreceta](
	[cod_receta] [int] NOT NULL,
	[cod_medicina] [int] NOT NULL,
 CONSTRAINT [tbmedixreceta_pk] PRIMARY KEY CLUSTERED 
(
	[cod_receta] ASC,
	[cod_medicina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbpaciente]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbpaciente](
	[cod_paciente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[fecha_nac] [date] NULL,
	[cod_especie] [int] NOT NULL,
	[cod_dueno] [int] NOT NULL,
	[cod_medico] [int] NOT NULL,
 CONSTRAINT [tbpaciente_pk] PRIMARY KEY CLUSTERED 
(
	[cod_paciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbPuesto]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPuesto](
	[cod_puesto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_puesto] [varchar](30) NOT NULL,
	[salario] [money] NOT NULL,
 CONSTRAINT [tbpuesto_pk] PRIMARY KEY CLUSTERED 
(
	[cod_puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbraza]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbraza](
	[cod_raza] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[longevidad] [int] NULL,
	[cod_especie] [int] NOT NULL,
 CONSTRAINT [tbraza_pk] PRIMARY KEY CLUSTERED 
(
	[cod_raza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbReceta]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbReceta](
	[cod_receta] [int] IDENTITY(1,1) NOT NULL,
	[cod_paciente] [int] NOT NULL,
	[duracion] [int] NULL,
 CONSTRAINT [tbreceta_pk] PRIMARY KEY CLUSTERED 
(
	[cod_receta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbTelefonoDueno]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbTelefonoDueno](
	[cod_dueno] [int] IDENTITY(1,1) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
 CONSTRAINT [tbtelefonodueno_pk] PRIMARY KEY CLUSTERED 
(
	[cod_dueno] ASC,
	[telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTelEmpleado]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTelEmpleado](
	[cod_empleado] [int] IDENTITY(1,1) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
 CONSTRAINT [TbTelEmpleado_pk] PRIMARY KEY CLUSTERED 
(
	[cod_empleado] ASC,
	[telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbtiporiesgc]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbtiporiesgc](
	[cod_cirugia] [int] NOT NULL,
	[riesgo] [varchar](30) NOT NULL,
 CONSTRAINT [tbtiporiesgc_pk] PRIMARY KEY CLUSTERED 
(
	[cod_cirugia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTurno]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTurno](
	[cod_turno] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[hora_inicio] [int] NOT NULL,
	[hora_fin] [int] NOT NULL,
 CONSTRAINT [tbturno_pk] PRIMARY KEY CLUSTERED 
(
	[cod_turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbturnoxempleado]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbturnoxempleado](
	[cod_turno] [int] NOT NULL,
	[cod_empleado] [int] NOT NULL,
 CONSTRAINT [tbturnoxempleado_pk] PRIMARY KEY CLUSTERED 
(
	[cod_turno] ASC,
	[cod_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbusuario]    Script Date: 5/28/2022 7:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbusuario](
	[cod_emp] [int] NULL,
	[cod_user] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NULL,
	[contrasena] [varchar](30) NULL,
 CONSTRAINT [tbusuario_pk] PRIMARY KEY CLUSTERED 
(
	[cod_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbDUENO] ON 
GO
INSERT [dbo].[tbDUENO] ([cod_dueno], [nombre], [apellido], [direccion], [DNI]) VALUES (1, N'Arnulfo', N'Ramirez', N'San Pedro SUla', N'1990239400932')
GO
INSERT [dbo].[tbDUENO] ([cod_dueno], [nombre], [apellido], [direccion], [DNI]) VALUES (2, N'Paola', N'Velasquez', N'Tegus', N'193828392829')
GO
SET IDENTITY_INSERT [dbo].[tbDUENO] OFF
GO
SET IDENTITY_INSERT [dbo].[tbEmpleado] ON 
GO
INSERT [dbo].[tbEmpleado] ([cod_empleado], [NOMBRE], [APELLIDO], [DIRECCION], [DNI], [fecha_ing], [cod_puesto]) VALUES (1, N'Willian', N'Caceres', N'Col Vista Hermosa, Sps', N'1983920399202', CAST(N'2021-12-12' AS Date), 1)
GO
INSERT [dbo].[tbEmpleado] ([cod_empleado], [NOMBRE], [APELLIDO], [DIRECCION], [DNI], [fecha_ing], [cod_puesto]) VALUES (2, N'Paola', N'Canahuati', N'Tegucigalpa', N'1919929292929', CAST(N'2021-12-12' AS Date), 2)
GO
INSERT [dbo].[tbEmpleado] ([cod_empleado], [NOMBRE], [APELLIDO], [DIRECCION], [DNI], [fecha_ing], [cod_puesto]) VALUES (3, N'Arnulfo', N'Ramirez', N'Tegucigalpa', N'191938473728', CAST(N'2021-12-12' AS Date), 1)
GO
INSERT [dbo].[tbEmpleado] ([cod_empleado], [NOMBRE], [APELLIDO], [DIRECCION], [DNI], [fecha_ing], [cod_puesto]) VALUES (4, N'Blanca', N'Pineda', N'San Pedro Sula', N'1999282911', CAST(N'2021-12-12' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[tbEmpleado] OFF
GO
SET IDENTITY_INSERT [dbo].[tbespecie] ON 
GO
INSERT [dbo].[tbespecie] ([cod_especie], [nombre], [descripcion], [cod_familia]) VALUES (1, N'Mamiferos', N'Animales carnivoros', 1)
GO
INSERT [dbo].[tbespecie] ([cod_especie], [nombre], [descripcion], [cod_familia]) VALUES (2, N'Carnivoro', N'Animal que come carne', 1)
GO
SET IDENTITY_INSERT [dbo].[tbespecie] OFF
GO
SET IDENTITY_INSERT [dbo].[tbfamilia] ON 
GO
INSERT [dbo].[tbfamilia] ([cod_familia], [nombre], [descripcion]) VALUES (1, N'Mamifero', N'Animales mamiferos')
GO
SET IDENTITY_INSERT [dbo].[tbfamilia] OFF
GO
SET IDENTITY_INSERT [dbo].[tbPuesto] ON 
GO
INSERT [dbo].[tbPuesto] ([cod_puesto], [nombre_puesto], [salario]) VALUES (1, N'Asistente Medico', 12000.0000)
GO
INSERT [dbo].[tbPuesto] ([cod_puesto], [nombre_puesto], [salario]) VALUES (2, N'Doctor', 30000.0000)
GO
SET IDENTITY_INSERT [dbo].[tbPuesto] OFF
GO
SET IDENTITY_INSERT [dbo].[tbTurno] ON 
GO
INSERT [dbo].[tbTurno] ([cod_turno], [nombre], [hora_inicio], [hora_fin]) VALUES (1, N'Nocturno', 21, 5)
GO
SET IDENTITY_INSERT [dbo].[tbTurno] OFF
GO
SET IDENTITY_INSERT [dbo].[tbusuario] ON 
GO
INSERT [dbo].[tbusuario] ([cod_emp], [cod_user], [nombre], [contrasena]) VALUES (1, 1, N'wil', N'1234')
GO
SET IDENTITY_INSERT [dbo].[tbusuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbDUENO__C035B8DD56DA0A78]    Script Date: 5/28/2022 7:23:40 PM ******/
ALTER TABLE [dbo].[tbDUENO] ADD UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbEmplea__C035B8DD0BDD87ED]    Script Date: 5/28/2022 7:23:40 PM ******/
ALTER TABLE [dbo].[tbEmpleado] ADD UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbcirugia]  WITH CHECK ADD  CONSTRAINT [tbcirugia_tbpaciente_fk] FOREIGN KEY([cod_paciente])
REFERENCES [dbo].[Tbpaciente] ([cod_paciente])
GO
ALTER TABLE [dbo].[tbcirugia] CHECK CONSTRAINT [tbcirugia_tbpaciente_fk]
GO
ALTER TABLE [dbo].[tbCita]  WITH CHECK ADD  CONSTRAINT [tbcita_tbempleado_fk] FOREIGN KEY([cod_medico])
REFERENCES [dbo].[tbEmpleado] ([cod_empleado])
GO
ALTER TABLE [dbo].[tbCita] CHECK CONSTRAINT [tbcita_tbempleado_fk]
GO
ALTER TABLE [dbo].[tbCita]  WITH CHECK ADD  CONSTRAINT [tbcita_tbpaciente_fk] FOREIGN KEY([cod_paciente])
REFERENCES [dbo].[Tbpaciente] ([cod_paciente])
GO
ALTER TABLE [dbo].[tbCita] CHECK CONSTRAINT [tbcita_tbpaciente_fk]
GO
ALTER TABLE [dbo].[tbEmpleado]  WITH CHECK ADD  CONSTRAINT [tbEmpleado_tbpuesto_fk] FOREIGN KEY([cod_puesto])
REFERENCES [dbo].[tbPuesto] ([cod_puesto])
GO
ALTER TABLE [dbo].[tbEmpleado] CHECK CONSTRAINT [tbEmpleado_tbpuesto_fk]
GO
ALTER TABLE [dbo].[tbenferXRaza]  WITH CHECK ADD  CONSTRAINT [tbenferxraza_tbenfermedad_fk] FOREIGN KEY([cod_enfermedad])
REFERENCES [dbo].[tbenfermedad] ([cod_enfermedad])
GO
ALTER TABLE [dbo].[tbenferXRaza] CHECK CONSTRAINT [tbenferxraza_tbenfermedad_fk]
GO
ALTER TABLE [dbo].[tbenferXRaza]  WITH CHECK ADD  CONSTRAINT [tbenferxraza_tbraza_fk] FOREIGN KEY([cod_raza])
REFERENCES [dbo].[tbraza] ([cod_raza])
GO
ALTER TABLE [dbo].[tbenferXRaza] CHECK CONSTRAINT [tbenferxraza_tbraza_fk]
GO
ALTER TABLE [dbo].[tbespecie]  WITH CHECK ADD  CONSTRAINT [tbespecie_tbfamilia_fk] FOREIGN KEY([cod_familia])
REFERENCES [dbo].[tbfamilia] ([cod_familia])
GO
ALTER TABLE [dbo].[tbespecie] CHECK CONSTRAINT [tbespecie_tbfamilia_fk]
GO
ALTER TABLE [dbo].[tbmedixenfer]  WITH CHECK ADD  CONSTRAINT [tbmedixenfer_tbenfermedad_fk] FOREIGN KEY([cod_enfermedad])
REFERENCES [dbo].[tbenfermedad] ([cod_enfermedad])
GO
ALTER TABLE [dbo].[tbmedixenfer] CHECK CONSTRAINT [tbmedixenfer_tbenfermedad_fk]
GO
ALTER TABLE [dbo].[tbmedixenfer]  WITH CHECK ADD  CONSTRAINT [tbmedixenfer_tbmedicina_fk] FOREIGN KEY([cod_medicina])
REFERENCES [dbo].[tbmedicina] ([cod_medicina])
GO
ALTER TABLE [dbo].[tbmedixenfer] CHECK CONSTRAINT [tbmedixenfer_tbmedicina_fk]
GO
ALTER TABLE [dbo].[tbmedixreceta]  WITH CHECK ADD  CONSTRAINT [tbmedixreceta_tbmedicina_fk] FOREIGN KEY([cod_medicina])
REFERENCES [dbo].[tbmedicina] ([cod_medicina])
GO
ALTER TABLE [dbo].[tbmedixreceta] CHECK CONSTRAINT [tbmedixreceta_tbmedicina_fk]
GO
ALTER TABLE [dbo].[tbmedixreceta]  WITH CHECK ADD  CONSTRAINT [tbmedixreceta_tbreceta_fk] FOREIGN KEY([cod_receta])
REFERENCES [dbo].[tbReceta] ([cod_receta])
GO
ALTER TABLE [dbo].[tbmedixreceta] CHECK CONSTRAINT [tbmedixreceta_tbreceta_fk]
GO
ALTER TABLE [dbo].[Tbpaciente]  WITH CHECK ADD  CONSTRAINT [tbpaciente_tbdueno_fk] FOREIGN KEY([cod_dueno])
REFERENCES [dbo].[tbDUENO] ([cod_dueno])
GO
ALTER TABLE [dbo].[Tbpaciente] CHECK CONSTRAINT [tbpaciente_tbdueno_fk]
GO
ALTER TABLE [dbo].[Tbpaciente]  WITH CHECK ADD  CONSTRAINT [tbpaciente_tbempleado_fk] FOREIGN KEY([cod_medico])
REFERENCES [dbo].[tbEmpleado] ([cod_empleado])
GO
ALTER TABLE [dbo].[Tbpaciente] CHECK CONSTRAINT [tbpaciente_tbempleado_fk]
GO
ALTER TABLE [dbo].[Tbpaciente]  WITH CHECK ADD  CONSTRAINT [tbpaciente_tbespecie_fk] FOREIGN KEY([cod_especie])
REFERENCES [dbo].[tbespecie] ([cod_especie])
GO
ALTER TABLE [dbo].[Tbpaciente] CHECK CONSTRAINT [tbpaciente_tbespecie_fk]
GO
ALTER TABLE [dbo].[tbraza]  WITH CHECK ADD  CONSTRAINT [tbraza_tbespecie_fk] FOREIGN KEY([cod_especie])
REFERENCES [dbo].[tbespecie] ([cod_especie])
GO
ALTER TABLE [dbo].[tbraza] CHECK CONSTRAINT [tbraza_tbespecie_fk]
GO
ALTER TABLE [dbo].[tbReceta]  WITH CHECK ADD  CONSTRAINT [tbreceta_tbpaciente_fk] FOREIGN KEY([cod_paciente])
REFERENCES [dbo].[Tbpaciente] ([cod_paciente])
GO
ALTER TABLE [dbo].[tbReceta] CHECK CONSTRAINT [tbreceta_tbpaciente_fk]
GO
ALTER TABLE [dbo].[TbTelefonoDueno]  WITH CHECK ADD  CONSTRAINT [tbtelefonoDueno_tbdueno_fk] FOREIGN KEY([cod_dueno])
REFERENCES [dbo].[tbDUENO] ([cod_dueno])
GO
ALTER TABLE [dbo].[TbTelefonoDueno] CHECK CONSTRAINT [tbtelefonoDueno_tbdueno_fk]
GO
ALTER TABLE [dbo].[tbTelEmpleado]  WITH CHECK ADD  CONSTRAINT [tbTelEmpleado_TBEMPLEADO_fk] FOREIGN KEY([cod_empleado])
REFERENCES [dbo].[tbEmpleado] ([cod_empleado])
GO
ALTER TABLE [dbo].[tbTelEmpleado] CHECK CONSTRAINT [tbTelEmpleado_TBEMPLEADO_fk]
GO
ALTER TABLE [dbo].[tbtiporiesgc]  WITH CHECK ADD  CONSTRAINT [tbtiporiesgc_tbcirugia] FOREIGN KEY([cod_cirugia])
REFERENCES [dbo].[tbcirugia] ([cod_cirugia])
GO
ALTER TABLE [dbo].[tbtiporiesgc] CHECK CONSTRAINT [tbtiporiesgc_tbcirugia]
GO
ALTER TABLE [dbo].[tbturnoxempleado]  WITH CHECK ADD  CONSTRAINT [tbturnoXempleado_tbempleado_fk] FOREIGN KEY([cod_empleado])
REFERENCES [dbo].[tbEmpleado] ([cod_empleado])
GO
ALTER TABLE [dbo].[tbturnoxempleado] CHECK CONSTRAINT [tbturnoXempleado_tbempleado_fk]
GO
ALTER TABLE [dbo].[tbturnoxempleado]  WITH CHECK ADD  CONSTRAINT [tbturnoXempleado_tbturno_fk] FOREIGN KEY([cod_turno])
REFERENCES [dbo].[tbTurno] ([cod_turno])
GO
ALTER TABLE [dbo].[tbturnoxempleado] CHECK CONSTRAINT [tbturnoXempleado_tbturno_fk]
GO
ALTER TABLE [dbo].[tbusuario]  WITH CHECK ADD  CONSTRAINT [tbuser_tbempleado_fk] FOREIGN KEY([cod_emp])
REFERENCES [dbo].[tbEmpleado] ([cod_empleado])
GO
ALTER TABLE [dbo].[tbusuario] CHECK CONSTRAINT [tbuser_tbempleado_fk]
GO
USE [master]
GO
ALTER DATABASE [Veterinaria] SET  READ_WRITE 
GO
