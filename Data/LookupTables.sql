USE [DysonSphereAssembler]
GO
SET IDENTITY_INSERT [dbo].[Machines] ON 
GO
INSERT [dbo].[Machines] ([Id], [Name], [MachineType], [ProductionModifier]) VALUES (1, N'Smelter', 1, CAST(1.0 AS Decimal(18, 1)))
GO
INSERT [dbo].[Machines] ([Id], [Name], [MachineType], [ProductionModifier]) VALUES (2, N'Assembler 1', 2, CAST(1.5 AS Decimal(18, 1)))
GO
INSERT [dbo].[Machines] ([Id], [Name], [MachineType], [ProductionModifier]) VALUES (3, N'Oil Refinery', 3, CAST(1.0 AS Decimal(18, 1)))
GO
INSERT [dbo].[Machines] ([Id], [Name], [MachineType], [ProductionModifier]) VALUES (4, N'Chemical Plant', 4, CAST(1.0 AS Decimal(18, 1)))
GO
INSERT [dbo].[Machines] ([Id], [Name], [MachineType], [ProductionModifier]) VALUES (6, N'Particle Collider', 5, CAST(1.0 AS Decimal(18, 1)))
GO
INSERT [dbo].[Machines] ([Id], [Name], [MachineType], [ProductionModifier]) VALUES (8, N'Matrix Lab', 6, CAST(1.0 AS Decimal(18, 1)))
GO
SET IDENTITY_INSERT [dbo].[Machines] OFF
GO
INSERT [dbo].[MachineTypes] ([Id], [Name]) VALUES (1, N'Smelter')
GO
INSERT [dbo].[MachineTypes] ([Id], [Name]) VALUES (2, N'Assembler')
GO
INSERT [dbo].[MachineTypes] ([Id], [Name]) VALUES (3, N'Oil Refinery')
GO
INSERT [dbo].[MachineTypes] ([Id], [Name]) VALUES (4, N'Chemical Plant')
GO
INSERT [dbo].[MachineTypes] ([Id], [Name]) VALUES (5, N'Miniature Particle Collider')
GO
INSERT [dbo].[MachineTypes] ([Id], [Name]) VALUES (6, N'Matrix Lab')
GO
