USE master
GO

--
-- als de database al bestaat wordt deze gedropped
--

IF EXISTS(select * from sys.databases where name='gh4_sqlserver')
DROP DATABASE gh4_sqlserver
GO

--
-- maakt de database aan
--

CREATE DATABASE gh4_sqlserver
GO

--
-- gebruik de database gh4_sqlserver om daarin tabellen aan te maken
--

USE [gh4_sqlserver]
GO
/****** Object:  Table [dbo].[company] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

--
-- maakt de tabel dbo.company aan
--

CREATE TABLE [dbo].[company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[Zipcode] [int] NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
 CONSTRAINT [pk_company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[contract] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- maakt de tabel dbo.contract aan
--

CREATE TABLE [dbo].[contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ContractFormulaId] [int] NOT NULL,
 CONSTRAINT [PK_contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[contractformula]    Script Date: 2/05/2014 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- maakt de tabel dbo.contractformula aan
--

CREATE TABLE [dbo].[contractformula](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [text] NOT NULL,
	[MaxUsageHoursPerPeriod] [int] NULL,
	[PeriodInMonths] [int] NOT NULL,
	[NoticePeriodInMonths] [int] NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [pk_contractformula] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[location]    Script Date: 2/05/2014 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

--
-- maakt de tabel dbo.location aan
--

CREATE TABLE [dbo].[location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reservation]    Script Date: 2/05/2014 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- maakt de tabel dbo.reservation aan
--

CREATE TABLE [dbo].[reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_reservation_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[company] ON 

--
-- toevoegen van gegevens in dbo.company
--

INSERT [dbo].[company] ([Id], [Name], [Street], [Zipcode], [City], [Country], [Email], [Phone]) VALUES (1, N'Test', N'Test', 3500, N'Test', N'Test', N'Test@test.com', N'0486123456')
INSERT [dbo].[company] ([Id], [Name], [Street], [Zipcode], [City], [Country], [Email], [Phone]) VALUES (2, N'Tom & Co', N'Boomhutlaan 75', 3500, N'Hasselt', N'Belgie', N'tom_co@hotmail.com', N'0486111222')
INSERT [dbo].[company] ([Id], [Name], [Street], [Zipcode], [City], [Country], [Email], [Phone]) VALUES (3, N'MC Donalds', N'Frietlaan 2', 3500, N'Hasselt', N'Belgie', N'mc_donalds@hotmail.com', N'0486223344')
INSERT [dbo].[company] ([Id], [Name], [Street], [Zipcode], [City], [Country], [Email], [Phone]) VALUES (4, N'Carrefour', N'Boomkenslaan 15', 3600, N'Genk', N'Belgie', N'carrefour@hotmail.com', N'0486777666')
INSERT [dbo].[company] ([Id], [Name], [Street], [Zipcode], [City], [Country], [Email], [Phone]) VALUES (5, N'Media Markt', N'Medialaan 24', 3511, N'Kuringen', N'Belgie', N'media_markt@hotmail.com', N'0486454545')
SET IDENTITY_INSERT [dbo].[company] OFF
SET IDENTITY_INSERT [dbo].[contract] ON 

--
-- toevoegen van gegevens in dbo.contract
--

INSERT [dbo].[contract] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [ContractFormulaId]) VALUES (1, 1, CAST(0x0000A28700000000 AS DateTime), CAST(0x0000A2A500000000 AS DateTime), 1, 1)
INSERT [dbo].[contract] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [ContractFormulaId]) VALUES (2, 2, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A35A00000000 AS DateTime), 1, 5)
INSERT [dbo].[contract] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [ContractFormulaId]) VALUES (3, 3, CAST(0x0000A28700000000 AS DateTime), CAST(0x0000A2C400000000 AS DateTime), 2, 4)
SET IDENTITY_INSERT [dbo].[contract] OFF
SET IDENTITY_INSERT [dbo].[contractformula] ON 

--
-- toevoegen van gegevens in dbo.contractformula
--

INSERT [dbo].[contractformula] ([Id], [Description], [MaxUsageHoursPerPeriod], [PeriodInMonths], [NoticePeriodInMonths], [Price]) VALUES (1, N'Limit: 20h p/m - Period: 1m - Notice: x', 20, 1, NULL, CAST(100 AS Decimal(18, 0)))
INSERT [dbo].[contractformula] ([Id], [Description], [MaxUsageHoursPerPeriod], [PeriodInMonths], [NoticePeriodInMonths], [Price]) VALUES (2, N'Limit: 80h p/m - Period: 1m - Notice: x', 80, 1, NULL, CAST(200 AS Decimal(18, 0)))
INSERT [dbo].[contractformula] ([Id], [Description], [MaxUsageHoursPerPeriod], [PeriodInMonths], [NoticePeriodInMonths], [Price]) VALUES (3, N'Limit: x - Period: 1m - Notice: x', NULL, 1, NULL, CAST(500 AS Decimal(18, 0)))
INSERT [dbo].[contractformula] ([Id], [Description], [MaxUsageHoursPerPeriod], [PeriodInMonths], [NoticePeriodInMonths], [Price]) VALUES (4, N'Limit: x - Period: 2m - Notice: 1m', NULL, 2, 1, CAST(800 AS Decimal(18, 0)))
INSERT [dbo].[contractformula] ([Id], [Description], [MaxUsageHoursPerPeriod], [PeriodInMonths], [NoticePeriodInMonths], [Price]) VALUES (5, N'Limit: x - Period: 6m - Notice: 2m', NULL, 6, 2, CAST(1200 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[contractformula] OFF
SET IDENTITY_INSERT [dbo].[location] ON 

--
-- toevoegen van gegevens in dbo.location
--

INSERT [dbo].[location] ([Id], [Name]) VALUES (1, N'Room 1')
INSERT [dbo].[location] ([Id], [Name]) VALUES (2, N'Room 2')
SET IDENTITY_INSERT [dbo].[location] OFF
SET IDENTITY_INSERT [dbo].[reservation] ON 

--
-- toevoegen van gegevens in dbo.reservation
--

INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (1, 1, CAST(0x0000A29800A4CB80 AS DateTime), CAST(0x0000A29800B54640 AS DateTime), 1, 1, CAST(0x0000A31F011510CC AS DateTime))
INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (2, 2, CAST(0x0000A28800DE7920 AS DateTime), CAST(0x0000A28800EEF3E0 AS DateTime), 1, 2, CAST(0x0000A31F01162E62 AS DateTime))
INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (3, 3, CAST(0x0000A29800E6B680 AS DateTime), CAST(0x0000A298011826C0 AS DateTime), 1, 2, CAST(0x0000A31F0116555F AS DateTime))
INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (4, 4, CAST(0x0000A29900C5C100 AS DateTime), CAST(0x0000A29900F73140 AS DateTime), 1, 1, CAST(0x0000A31F0116724C AS DateTime))
INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (5, 5, CAST(0x0000A29A009450C0 AS DateTime), CAST(0x0000A29A01206420 AS DateTime), 1, 2, CAST(0x0000A31F01168E04 AS DateTime))
INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (6, 6, CAST(0x0000A27F00BD83A0 AS DateTime), CAST(0x0000A27F00CDFE60 AS DateTime), 1, 1, CAST(0x0000A31F0116AC55 AS DateTime))
INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (7, 7, CAST(0x0000A29F00C5C100 AS DateTime), CAST(0x0000A29F00D63BC0 AS DateTime), 1, 2, CAST(0x0000A31F0116C7A3 AS DateTime))
INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (8, 8, CAST(0x0000A2A1008C1360 AS DateTime), CAST(0x0000A2A100AD08E0 AS DateTime), 1, 1, CAST(0x0000A31F0116DDC6 AS DateTime))
INSERT [dbo].[reservation] ([Id], [Number], [StartDate], [EndDate], [CompanyId], [LocationId], [CreateDate]) VALUES (10, 9, CAST(0x0000A2A000EC34C0 AS DateTime), CAST(0x0000A2A000F47220 AS DateTime), 1, 1, CAST(0x0000A31F0116F8CD AS DateTime))
SET IDENTITY_INSERT [dbo].[reservation] OFF

ALTER TABLE [dbo].[reservation] ADD  CONSTRAINT [DF_reservation_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[contract]  WITH CHECK ADD  CONSTRAINT [fk_contract_company_id] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[company] ([Id])
GO
ALTER TABLE [dbo].[contract] CHECK CONSTRAINT [fk_contract_company_id]
GO
ALTER TABLE [dbo].[contract]  WITH CHECK ADD  CONSTRAINT [fk_contract_contractformula_id] FOREIGN KEY([ContractFormulaId])
REFERENCES [dbo].[contractformula] ([Id])
GO
ALTER TABLE [dbo].[contract] CHECK CONSTRAINT [fk_contract_contractformula_id]
GO
ALTER TABLE [dbo].[reservation]  WITH CHECK ADD  CONSTRAINT [fk_reservation_company_id] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[company] ([Id])
GO
ALTER TABLE [dbo].[reservation] CHECK CONSTRAINT [fk_reservation_company_id]
GO
ALTER TABLE [dbo].[reservation]  WITH CHECK ADD  CONSTRAINT [fk_reservation_location_id] FOREIGN KEY([LocationId])
REFERENCES [dbo].[location] ([Id])
GO
ALTER TABLE [dbo].[reservation] CHECK CONSTRAINT [fk_reservation_location_id]
GO
ALTER TABLE [dbo].[company]  WITH CHECK ADD  CONSTRAINT [chk_company_id] CHECK  (([Id]>(0)))
GO
ALTER TABLE [dbo].[company] CHECK CONSTRAINT [chk_company_id]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'company id > 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'company', @level2type=N'CONSTRAINT',@level2name=N'chk_company_id'
GO
