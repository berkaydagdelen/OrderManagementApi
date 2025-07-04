USE [OrderManagement]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2.07.2025 00:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedById] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedById] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__Orders__3214EC074CA95333] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 2.07.2025 00:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](10, 2) NOT NULL,
	[TotalPrice] [decimal](10, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedById] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedById] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__OrderIte__3214EC0720116238] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2.07.2025 00:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedById] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedById] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__Products__3214EC07B48CC353] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2.07.2025 00:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[Password] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedById] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedById] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__Users__3214EC07C2ABCEA2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [UserId], [OrderDate], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (1, 1, CAST(N'2025-06-28T00:00:00.000' AS DateTime), CAST(N'2025-06-28T21:59:11.280' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Order] ([Id], [UserId], [OrderDate], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (2, 2, CAST(N'2025-06-28T00:00:00.000' AS DateTime), CAST(N'2025-06-28T21:59:16.637' AS DateTime), 1, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [TotalPrice], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (1, 1, 1, 2, CAST(15000.00 AS Decimal(10, 2)), CAST(30000.00 AS Decimal(10, 2)), CAST(N'2025-06-28T22:00:11.090' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[OrderItem] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [TotalPrice], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (2, 1, 3, 2, CAST(10000.00 AS Decimal(10, 2)), CAST(20000.00 AS Decimal(10, 2)), CAST(N'2025-06-28T22:00:23.230' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[OrderItem] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [TotalPrice], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (3, 2, 4, 4, CAST(14000.00 AS Decimal(10, 2)), CAST(56000.00 AS Decimal(10, 2)), CAST(N'2025-06-28T22:00:50.917' AS DateTime), 1, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [Stock], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (1, N'BİLGİSAYAR', CAST(15000.00 AS Decimal(10, 2)), 98, CAST(N'2025-06-28T21:57:52.190' AS DateTime), 1, CAST(N'2025-06-28T22:00:11.060' AS DateTime), 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Stock], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (2, N'TELEFON', CAST(50000.00 AS Decimal(10, 2)), 50, CAST(N'2025-06-28T21:58:06.497' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Stock], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (3, N'TABLET', CAST(10000.00 AS Decimal(10, 2)), 23, CAST(N'2025-06-28T21:58:19.673' AS DateTime), 1, CAST(N'2025-06-28T22:00:23.220' AS DateTime), 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Stock], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (4, N'BUZDOLABI', CAST(14000.00 AS Decimal(10, 2)), 36, CAST(N'2025-06-28T21:58:31.443' AS DateTime), 1, CAST(N'2025-06-28T22:00:50.897' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [Email], [Username], [Password], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (1, N'BERKAY', N'DAĞDELEN', N'berkay.dagdelen@outlook.com', N'admin', N'1234', CAST(N'2025-06-28T21:56:15.267' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Email], [Username], [Password], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (2, N'MERT', N'KAYA', N'mert.kaya@outlook.com', N'mert', N'mert1234', CAST(N'2025-06-28T21:56:41.477' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Email], [Username], [Password], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (3, N'BAŞAK', N'DAĞDELEN', N'basak.dagdelen@outlook.com', N'basak', N'basak1234', CAST(N'2025-06-28T21:57:04.657' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Email], [Username], [Password], [CreatedDate], [CreatedById], [ModifiedDate], [ModifiedById], [IsActive]) VALUES (4, N'HATİCE', N'BAYDEMİR', N'hatice.baydemir@outlook.com', N'hatice', N'1234', CAST(N'2025-06-28T21:57:20.617' AS DateTime), 1, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D105347C0CFF3B]    Script Date: 2.07.2025 00:38:39 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__Users__A9D105347C0CFF3B] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Orders__UserId__5FB337D6] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Orders__UserId__5FB337D6]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__Order__628FA481] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK__OrderItem__Order__628FA481]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__Produ__6383C8BA] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK__OrderItem__Produ__6383C8BA]
GO
