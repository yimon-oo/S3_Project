USE [S3_Project]
GO
/****** Object:  Table [dbo].[data]    Script Date: 2023/05/19 13:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[temperature] [int] NULL,
	[humidity] [int] NULL,
	[occupancy] [bit] NULL,
 CONSTRAINT [PK_data] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[location]    Script Date: 2023/05/19 13:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[parent_id] [int] NULL,
	[location_step_id] [int] NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[location_step]    Script Date: 2023/05/19 13:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location_step](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](max) NULL,
	[step] [int] NULL,
 CONSTRAINT [PK_location_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user]    Script Date: 2023/05/19 13:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[login_name] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[visitor_info]    Script Date: 2023/05/19 13:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[visitor_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NULL,
	[company_name] [nvarchar](max) NULL,
	[designation] [nvarchar](max) NULL,
	[mobile] [nvarchar](max) NULL,
	[license_plate] [nvarchar](max) NULL,
	[nric_fin] [nvarchar](max) NULL,
	[issh_notice] [bit] NULL,
	[isclose_contact] [bit] NULL,
	[isfever] [bit] NULL,
	[location_id] [int] NULL,
 CONSTRAINT [PK_visitor_info] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[View_Location]    Script Date: 2023/05/19 13:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view  [dbo].[View_Location] as
select loc1.id as loc1_id, loc1.name as loc1_name, loc1.parent_id as loc1_parent_id, loc1.location_step_id as loc1_location_step_id,
loc2.id as loc2_id, loc2.name as loc2_name, loc2.parent_id as loc2_parent_id, loc2.location_step_id as loc2_location_step_id,
loc3.id as loc3_id, loc3.name as loc3_name, loc3.parent_id as loc3_parent_id, loc3.location_step_id as loc3_location_step_id,
loc4.id as loc4_id, loc4.name as loc4_name, loc4.parent_id as loc4_parent_id, loc4.location_step_id as loc4_location_step_id

from location loc1
left join location loc2 on loc2.parent_id=loc1.id
left join location loc3 on loc3.parent_id=loc2.id
left join location loc4 on loc4.parent_id=loc3.id

GO
SET IDENTITY_INSERT [dbo].[data] ON 

INSERT [dbo].[data] ([id], [temperature], [humidity], [occupancy]) VALUES (1, 21, 53, 0)
INSERT [dbo].[data] ([id], [temperature], [humidity], [occupancy]) VALUES (2, 21, 53, 0)
INSERT [dbo].[data] ([id], [temperature], [humidity], [occupancy]) VALUES (3, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[data] OFF
SET IDENTITY_INSERT [dbo].[location] ON 

INSERT [dbo].[location] ([id], [name], [parent_id], [location_step_id]) VALUES (1, N'Building A', 0, 1)
INSERT [dbo].[location] ([id], [name], [parent_id], [location_step_id]) VALUES (2, N'Car Park  ', 1, 4)
INSERT [dbo].[location] ([id], [name], [parent_id], [location_step_id]) VALUES (3, N'Building B', 0, 1)
INSERT [dbo].[location] ([id], [name], [parent_id], [location_step_id]) VALUES (4, N'Car Park  ', 3, 2)
INSERT [dbo].[location] ([id], [name], [parent_id], [location_step_id]) VALUES (5, N'Level 1   ', 3, 2)
INSERT [dbo].[location] ([id], [name], [parent_id], [location_step_id]) VALUES (6, N'Room 101  ', 4, 3)
INSERT [dbo].[location] ([id], [name], [parent_id], [location_step_id]) VALUES (7, N'Room 102  ', 4, 3)
INSERT [dbo].[location] ([id], [name], [parent_id], [location_step_id]) VALUES (8, N'Lobby A   ', 6, 6)
SET IDENTITY_INSERT [dbo].[location] OFF
SET IDENTITY_INSERT [dbo].[location_step] ON 

INSERT [dbo].[location_step] ([id], [type], [step]) VALUES (1, N'Building', 1)
INSERT [dbo].[location_step] ([id], [type], [step]) VALUES (2, N'Level', 2)
INSERT [dbo].[location_step] ([id], [type], [step]) VALUES (3, N'Room', 3)
INSERT [dbo].[location_step] ([id], [type], [step]) VALUES (4, N'Car Park', 2)
INSERT [dbo].[location_step] ([id], [type], [step]) VALUES (5, N'Pantry', 3)
INSERT [dbo].[location_step] ([id], [type], [step]) VALUES (6, N'Lobby', 4)
SET IDENTITY_INSERT [dbo].[location_step] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [name], [login_name], [password]) VALUES (1, N'admin', N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[user] OFF
SET IDENTITY_INSERT [dbo].[visitor_info] ON 

INSERT [dbo].[visitor_info] ([id], [name], [email], [company_name], [designation], [mobile], [license_plate], [nric_fin], [issh_notice], [isclose_contact], [isfever], [location_id]) VALUES (3, N'Test one', N'testone@gmail.com', N'Com one', N'Test', N'0999999', N'12A', N'1234', 1, 1, 1, 0)
INSERT [dbo].[visitor_info] ([id], [name], [email], [company_name], [designation], [mobile], [license_plate], [nric_fin], [issh_notice], [isclose_contact], [isfever], [location_id]) VALUES (4, N'test', N'test', N'test', N'test', N'test', N'test', N'test', 0, 0, 0, 0)
INSERT [dbo].[visitor_info] ([id], [name], [email], [company_name], [designation], [mobile], [license_plate], [nric_fin], [issh_notice], [isclose_contact], [isfever], [location_id]) VALUES (6, N'Test two', N'testtwo@gmail.com', N'Com two', N'Test', N'0900000', N'345', N'34', 0, 1, 1, 0)
INSERT [dbo].[visitor_info] ([id], [name], [email], [company_name], [designation], [mobile], [license_plate], [nric_fin], [issh_notice], [isclose_contact], [isfever], [location_id]) VALUES (7, N'Test Three', N'testone@gmail.com', N'Com one', N'Test', N'0999999', N'12A', N'1234', 1, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[visitor_info] OFF
