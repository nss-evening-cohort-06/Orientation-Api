USE [SNQHM_bangazoncli_db]
GO

USE [SNQHM_bangazoncli_db]
GO
SET IDENTITY_INSERT [dbo].[EmployeeComputer] ON 
GO
INSERT [dbo].[EmployeeComputer] ([EmployeeComputerID], [AssignedDate], [ReturnedDate], [EmployeeID], [ComputerID]) VALUES (1, CAST(N'2005-01-22T00:00:00.000' AS DateTime), CAST(N'2005-01-22T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[EmployeeComputer] ([EmployeeComputerID], [AssignedDate], [ReturnedDate], [EmployeeID], [ComputerID]) VALUES (2, null, CAST(N'2018-04-04T00:00:00.000' AS DateTime), 2, 2)
INSERT [dbo].[EmployeeComputer] ([EmployeeComputerID], [AssignedDate], [ReturnedDate], [EmployeeID], [ComputerID]) VALUES (3, null, CAST(N'2018-04-04T00:00:00.000' AS DateTime), 3, 3)
INSERT [dbo].[EmployeeComputer] ([EmployeeComputerID], [AssignedDate], [ReturnedDate], [EmployeeID], [ComputerID]) VALUES (4, CAST(N'2005-01-22T00:00:00.000' AS DateTime), null, 4, 4)
INSERT [dbo].[EmployeeComputer] ([EmployeeComputerID], [AssignedDate], [ReturnedDate], [EmployeeID], [ComputerID]) VALUES (5, CAST(N'2005-01-22T00:00:00.000' AS DateTime), CAST(N'2018-04-04T00:00:00.000' AS DateTime), 5, 5)
SET IDENTITY_INSERT [dbo].[EmployeeComputer] OFF
GO