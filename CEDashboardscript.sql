USE [CEdashboard]
GO
/****** Object:  Table [dbo].[City]    Script Date: 30-10-2020 14:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] NOT NULL,
	[CityName] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[StateId] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginAttempt]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginAttempt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastLoginTimeStamp] [datetime] NULL,
	[IsSuccess] [bit] NULL,
	[UserId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IP_Addess] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoginHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualification]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QualificationName] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_User_Qualification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CountryId] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[due_date] [date] NULL,
	[IsComplete] [bit] NULL,
	[IsParent] [nchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[UserId] [int] NULL,
	[CreatedByUserId] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[TaskTypeId] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskType]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskType](
	[TaskTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TaskTypeName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TaskType] PRIMARY KEY CLUSTERED 
(
	[TaskTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Date_Of_Birth] [datetime] NULL,
	[ContactNo] [bigint] NULL,
	[Gender] [char](1) NULL,
	[QualificationId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedByUserId] [int] NULL,
 CONSTRAINT [PK_UserRegistration] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddress]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddress](
	[UserAddressId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [int] NULL,
	[State] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED 
(
	[UserAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 30-10-2020 14:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserloginId] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserloginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserQualification]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserQualification](
	[UserQualificationId] [int] IDENTITY(1,1) NOT NULL,
	[QualificationId] [int] NULL,
	[UserId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_UserQualification] PRIMARY KEY CLUSTERED 
(
	[UserQualificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User_Role] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_State]
GO
ALTER TABLE [dbo].[LoginAttempt]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistory_UserLogin] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[LoginAttempt] CHECK CONSTRAINT [FK_LoginHistory_UserLogin]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskType] FOREIGN KEY([TaskTypeId])
REFERENCES [dbo].[TaskType] ([TaskTypeId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_TaskType]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User]
GO
ALTER TABLE [dbo].[UserAddress]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_City] FOREIGN KEY([State])
REFERENCES [dbo].[City] ([CityId])
GO
ALTER TABLE [dbo].[UserAddress] CHECK CONSTRAINT [FK_UserAddress_City]
GO
ALTER TABLE [dbo].[UserAddress]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_State] FOREIGN KEY([State])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[UserAddress] CHECK CONSTRAINT [FK_UserAddress_State]
GO
ALTER TABLE [dbo].[UserAddress]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserAddress] CHECK CONSTRAINT [FK_UserAddress_User]
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_User]
GO
ALTER TABLE [dbo].[UserQualification]  WITH CHECK ADD  CONSTRAINT [FK_UserQualification_Qualification] FOREIGN KEY([QualificationId])
REFERENCES [dbo].[Qualification] ([Id])
GO
ALTER TABLE [dbo].[UserQualification] CHECK CONSTRAINT [FK_UserQualification_Qualification]
GO
ALTER TABLE [dbo].[UserQualification]  WITH CHECK ADD  CONSTRAINT [FK_UserQualification_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserQualification] CHECK CONSTRAINT [FK_UserQualification_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRole]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[DeleteRole]

@RoleId int

AS
SET NOCOUNT OFF

update [dbo].[Role] set [IsActive]=0,ModifiedDate=GETDATE() where RoleId=@RoleId

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[DeleteUser]

@UserId int

AS
SET NOCOUNT OFF

update [dbo].[User] set [IsActive]=0,ModifiedDate=GETDATE() where UserId=@UserId

GO
/****** Object:  StoredProcedure [dbo].[GetQualificationById]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GetQualificationById]

@QualificationId int

AS

Select * from [dbo].[Qualification] where Id=@QualificationId and  IsActive=1 
GO
/****** Object:  StoredProcedure [dbo].[GetUserLogin]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GetUserLogin]

@UserEmail varchar(max)

AS

--Select * from [dbo].[UserLogin] where UserEmail=@UserEmail

select u.*,r.* from [dbo].[UserLogin] u left join [dbo].[User_Role] ur on u.UserloginId=ur.UserId
left join [dbo].[Role] r on r.RoleId=ur.RoleId
 where u.UserEmail=@UserEmail and  u.IsActive=1 
GO
/****** Object:  StoredProcedure [dbo].[GetUserLoginById]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[GetUserLoginById]

@UserloginId int

AS

--Select * from [dbo].[UserLogin] where UserloginId=@UserloginId and  IsActive=1 

select u.*,r.* from [dbo].[UserLogin] u left join [dbo].[User_Role] ur on u.UserloginId=ur.UserId
left join [dbo].[Role] r on r.RoleId=ur.RoleId
 where u.UserloginId=@UserloginId and  u.IsActive=1 
GO
/****** Object:  StoredProcedure [dbo].[InsertLoginAttempt]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[InsertLoginAttempt]

@LastLoginTimeStamp datetime,
@IsSuccess bit,
@UserLoginId int,
@CreatedDate datetime,
@IP_Address varchar(50)
AS
SET NOCOUNT ON
Insert into [dbo].LoginAttempt([LastLoginTimeStamp],[IsSuccess],[UserLoginId],[CreatedDate],[IP_Addess],IsActive)values(@LastLoginTimeStamp,@IsSuccess,@UserLoginId,@CreatedDate,@IP_Address,1)
return SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[InsertQualification]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[InsertQualification]
@QualificationName nvarchar(100),
@Descritpion nvarchar(500),
@CreatedDate datetime,
@Id  int OUTPUT
AS

Insert into [dbo].[Qualification]([QualificationName],[Description],[CreatedDate],IsActive)values(@QualificationName,@Descritpion,@CreatedDate,1)

SET @Id= @@IDENTITY
Return @Id
GO
/****** Object:  StoredProcedure [dbo].[InsertRole]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[InsertRole]

@RoleName nvarchar(50),
@Descritpion nvarchar(500),
@CreatedDate datetime,
@Id  int OUTPUT
AS
SET NOCOUNT ON
Insert into [dbo].[Role]([RoleName],[Description],[CreatedDate],IsActive)values(@RoleName,@Descritpion,@CreatedDate,1)
SET @Id= @@IDENTITY
Return @Id
GO
/****** Object:  StoredProcedure [dbo].[UpdateRole]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[UpdateRole]

@RoleId int,
@RoleName nvarchar(50),
@Descritpion nvarchar(500),
@ModifiedDate datetime
AS
SET NOCOUNT OFF

update [dbo].[Role] set [RoleName]=@RoleName,[Description]=@Descritpion,ModifiedDate=@ModifiedDate where RoleId=@RoleId

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCity]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCity]

(
	@CityId int
)

AS
DELETE FROM [City]

WHERE
CityId = @CityId


/*DROP PROC dbo.usp_DeleteCity*/
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCountry]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCountry]

(
	@CountryId int
)

AS
DELETE FROM [Country]

WHERE
CountryId = @CountryId


/*DROP PROC dbo.usp_DeleteCountry*/
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteLoginAttempt]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteLoginAttempt]

(
	@Id int
)

AS
--DELETE FROM [LoginHistory]

--WHERE
--Id = @Id

update LoginAttempt set [IsActive]=0 where Id=@Id
/*DROP PROC dbo.usp_DeleteLoginHistory*/
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteQualification]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_DeleteQualification]

@QualificationId int


AS

update [dbo].[Qualification] set IsActive=0,ModifiedDate= GETDATE()  where Id=@QualificationId 
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteState]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteState]

(
	@StateId int
)

AS
DELETE FROM [State]

WHERE
StateId = @StateId


/*DROP PROC dbo.usp_DeleteState*/
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTask]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteTask]

(
	@TaskId int
)

AS
--DELETE FROM [Task]

--WHERE
--TaskId = @TaskId

update Task set IsActive=0 where TaskId=@TaskId

/*DROP PROC dbo.usp_DeleteTask*/
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTask_Item]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteTask_Item]

(
	@TaskItemId int
)

AS
--DELETE FROM [Task_Item]

--WHERE
--TaskItemId = @TaskItemId

update Task_Item set IsActive=0 where TaskItemId=@TaskItemId


/*DROP PROC dbo.usp_DeleteTask_Item*/
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTaskType]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteTaskType]

(
	@TaskTypeId int
)

AS
DELETE FROM [TaskType]

WHERE
TaskTypeId = @TaskTypeId


/*DROP PROC dbo.usp_DeleteTaskType*/
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteUserAccount]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_DeleteUserAccount]  
  
@UserId int

  
AS  
  
update [dbo].[UserLogin] set IsActive=0,ModifiedDate= GETDATE()  where UserloginId=@UserId 
GO
/****** Object:  StoredProcedure [dbo].[usp_DoLogin]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Proc [dbo].[usp_DoLogin]
@UserEmail varchar(max),
@Password varchar(max)

As


select u.*,r.* from [dbo].[UserLogin] u inner join [dbo].[User_Role] ur on u.UserloginId=ur.UserId
inner join [dbo].[Role] r on r.RoleId=ur.RoleId
 where u.UserEmail=@UserEmail and u.Password=@Password and u.IsActive=1 


GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllLoginAttempt]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_GetAllLoginAttempt]

AS

Select * from [dbo].LoginAttempt 
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllQualifications]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[usp_GetAllQualifications]

AS

Select * from [dbo].[Qualification] where IsActive=1 
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllRoles]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_GetAllRoles]

AS

Select * from [dbo].[Role] where IsActive=1 
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllUserLogins]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_GetAllUserLogins]

AS

--Select * from [dbo].[UserLogin] where IsActive=1 

select u.*,r.* from [dbo].[UserLogin] u left join [dbo].[User_Role] ur on u.UserloginId=ur.UserId
left join [dbo].[Role] r on r.RoleId=ur.RoleId
 where  u.IsActive=1 

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllUsers]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_GetAllUsers]

AS

Select u.*,ua.*,uq.* from [User] u left join [UserAddress] ua on u.[UserId]=ua.UserId
left join [dbo].[UserQualification] uq on u.[UserId]=uq.UserId
where u.IsActive=1 
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCity]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCity]
AS
SELECT * FROM [City]

/*DROP PROC dbo.usp_GetCity*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCityDetails]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCityDetails]

(
	@CityId int
)

AS
SELECT * FROM [City]

WHERE
CityId = @CityId


/*DROP PROC dbo.usp_GetCityDetails*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCountry]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCountry]
AS
SELECT * FROM [Country]

/*DROP PROC dbo.usp_GetCountry*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCountryDetails]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCountryDetails]

(
	@CountryId int
)

AS
SELECT * FROM [Country]

WHERE
CountryId = @CountryId


/*DROP PROC dbo.usp_GetCountryDetails*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetLoginAttempt]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetLoginAttempt]
AS
SELECT * FROM [LoginAttempt]

/*DROP PROC dbo.usp_GetLoginHistory*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetLoginAttemptByUserId]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_GetLoginAttemptByUserId]
@UserId int
AS

Select * from [dbo].LoginAttempt  where UserLoginId=@UserId
GO
/****** Object:  StoredProcedure [dbo].[usp_GetLoginAttemptDetails]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetLoginAttemptDetails]

(
	@Id int
)

AS
SELECT * FROM LoginAttempt

WHERE
Id = @Id


/*DROP PROC dbo.usp_GetLoginHistoryDetails*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetRoleById]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_GetRoleById]

@RoleId int

AS

Select * from [dbo].[Role] where RoleId=@RoleId and IsActive=1 
GO
/****** Object:  StoredProcedure [dbo].[usp_GetState]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetState]
AS
SELECT * FROM [State]

/*DROP PROC dbo.usp_GetState*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetStateDetails]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetStateDetails]

(
	@StateId int
)

AS
SELECT * FROM [State]

WHERE
StateId = @StateId


/*DROP PROC dbo.usp_GetStateDetails*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTask]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTask]
AS
SELECT * FROM [Task]

/*DROP PROC dbo.usp_GetTask*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTask_Item]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTask_Item]
AS
SELECT * FROM [Task_Item]

/*DROP PROC dbo.usp_GetTask_Item*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTask_ItemDetails]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTask_ItemDetails]

(
	@TaskItemId int
)

AS
SELECT * FROM [Task_Item]

WHERE
TaskItemId = @TaskItemId


/*DROP PROC dbo.usp_GetTask_ItemDetails*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTaskDetails]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTaskDetails]

(
	@TaskId int
)

AS
SELECT * FROM [Task]

WHERE
TaskId = @TaskId


/*DROP PROC dbo.usp_GetTaskDetails*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTaskItemByTaskId]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTaskItemByTaskId]

(
	@TaskId int
)

AS
SELECT * FROM [Task_Item]

WHERE
TaskId = @TaskId
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTaskType]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTaskType]
AS
SELECT * FROM [TaskType]

/*DROP PROC dbo.usp_GetTaskType*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTaskTypeDetails]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTaskTypeDetails]

(
	@TaskTypeId int
)

AS
SELECT * FROM [TaskType]

WHERE
TaskTypeId = @TaskTypeId


/*DROP PROC dbo.usp_GetTaskTypeDetails*/
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserById]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_GetUserById]  
  
@UserId int  
AS  
  

Select u.*,ua.*,uq.* from [User] u left join [UserAddress] ua on u.[UserId]=ua.UserId
left join [dbo].[UserQualification] uq on u.[UserId]=uq.UserId
where u.IsActive=1  and u.UserId=@UserId
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCity]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCity]
(
	@CityId int,
	@CityName nvarchar (MAX),
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@StateId int,
	@IsActive bit
)

AS
INSERT INTO [City]
( 
	CityId,
	CityName,
	CreatedDate,
	ModifiedDate,
	StateId,
	IsActive

)
VALUES 
(
	@CityId,
	@CityName,
	@CreatedDate,
	@ModifiedDate,
	@StateId,
	@IsActive
)
/*DROP PROC dbo.usp_InsertCity*/
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCountry]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCountry]
(
	@CountryName nvarchar (MAX),
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@IsActive bit,
	@CountryId  int OUTPUT
)

AS
INSERT INTO [Country]
( 
	CountryName,
	CreatedDate,
	ModifiedDate,
	IsActive

)
VALUES 
(
	@CountryName,
	@CreatedDate,
	@ModifiedDate,
	@IsActive
)


SET @CountryId= @@IDENTITY
 Return @CountryId
/*DROP PROC dbo.usp_InsertCountry*/
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertLoginAttempt]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertLoginAttempt]
(
	@LastLoginTimeStamp datetime,
	@IsSuccess bit,
	@UserLoginId int,
	@CreatedDate datetime,
	@IP_Addess nvarchar (MAX),
	@Id  int OUTPUT
)

AS
INSERT INTO LoginAttempt
( 
	LastLoginTimeStamp,
	IsSuccess,
	UserLoginId,
	CreatedDate,	
	IP_Addess

)
VALUES 
(
	@LastLoginTimeStamp,
	@IsSuccess,
	@UserLoginId,
	@CreatedDate,	
	@IP_Addess
)


SET @Id= @@IDENTITY
 Return @Id
/*DROP PROC dbo.usp_InsertLoginHistory*/
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertState]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertState]
(
	@StateName nvarchar (MAX),
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@CountryId int,
	@IsActive bit,
	@StateId  int OUTPUT
)

AS
INSERT INTO [State]
( 
	StateName,
	CreatedDate,
	ModifiedDate,
	CountryId,
	IsActive

)
VALUES 
(
	@StateName,
	@CreatedDate,
	@ModifiedDate,
	@CountryId,
	@IsActive
)


SET @StateId= @@IDENTITY
 Return @StateId
/*DROP PROC dbo.usp_InsertState*/
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTask]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[usp_InsertTask]  
(  
 @Description nvarchar (MAX),  
 @due_date datetime,  
 @IsComplete bit,  
 @CreatedDate datetime,  
 @UserId int, 
 @TaskTypeId int, 
 @CreatedByUserId int,  
 @TaskId  int OUTPUT  
)  
  
AS  

INSERT INTO [Task]  
(   
 Description,  
 due_date,  
 IsComplete,  
 UserId, 
 TaskTypeId, 
 CreatedByUserId,  
 CreatedDate,  
 IsActive  
  
)  
VALUES   
(  
 @Description,  
 @due_date,  
 @IsComplete,  
 @UserId,
 @TaskTypeId,  
 @CreatedByUserId,  
 @CreatedDate,  
 1  
)   
    
  
SET @TaskId= @@IDENTITY  
 Return @TaskId  
/*DROP PROC dbo.usp_InsertTask*/
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTaskItem]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertTaskItem]
(
	@TaskId int,
	@Description nvarchar (MAX),
	@IsComplete bit,
	@CreatedDate datetime,
	@UserId int,
	@CreatedByUserId int,
	@TaskItemId  int OUTPUT
)

AS
INSERT INTO [Task_Item]
( 
	TaskId,
	Description,
	IsComplete,
	CreatedDate,
	[UserId],
	CreatedByUserId,
	IsActive

)
VALUES 
(
	@TaskId,
	@Description,
	@IsComplete,	
	@CreatedDate,
	@UserId,
	@CreatedByUserId,
		1
)


SET @TaskItemId= @@IDENTITY
 Return @TaskItemId
/*DROP PROC dbo.usp_InsertTask_Item*/
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTaskType]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertTaskType]
(
	@TaskTypeName nvarchar (MAX),
	@Description nvarchar (MAX),
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@IsActive bit,
	@TaskTypeId  int OUTPUT
)

AS
INSERT INTO [TaskType]
( 
	TaskTypeName,
	Description,
	CreatedDate,
	ModifiedDate,
	IsActive

)
VALUES 
(
	@TaskTypeName,
	@Description,
	@CreatedDate,
	@ModifiedDate,
	@IsActive
)


SET @TaskTypeId= @@IDENTITY
 Return @TaskTypeId
/*DROP PROC dbo.usp_InsertTaskType*/
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertUser]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_InsertUser]  
  
@UserEmail nvarchar(max),  
@Password nvarchar(MAX),  
@UserName nvarchar(100), 
@Email nvarchar(100),
@Date_Of_Birth datetime,  
@Address nvarchar(500),  
@ContactNo bigint, 
@Gender char(1),
@QualificationId int,  
@userId int output,  
@UserLoginId int output,  
@CreatedDate datetime,
@City int,
@State int ,
@CreatedByUserId int
AS  
set nocount off  
declare @UserLogId int  
  
  
begin  
 if not exists(select * from [dbo].UserLogin where UserEmail=@UserEmail)  
 begin  

  insert into [dbo].[User]([UserName],[Email],[Date_Of_Birth],[ContactNo],[Gender],[CreatedDate],IsActive,CreatedByUserId)values(@UserName,@Email,@Date_Of_Birth,@ContactNo,@Gender,@CreatedDate,1,@CreatedByUserId)  
  set @userId=(select SCOPE_IDENTITY()) 

  insert into [dbo].[UserLogin] ([UserEmail],[Password],[UserId],IsActive,[CreatedDate])values(@UserEmail,@Password,@userId,1,@CreatedDate) 
    set @UserLogId=(select SCOPE_IDENTITY())  
  set @UserLoginId=@UserLogId  
  
   insert into [dbo].[UserQualification]([QualificationId],[UserId],CreatedDate,IsActive)values(@QualificationId,@userId,@CreatedDate,1)

insert into [dbo].[UserAddress]([Address],City,[State],CreatedDate,IsActive,[UserId])values(@Address,@City,@State,@CreatedDate,1,@userId)

    
 end  
  
else  
 set @UserLoginId=-99
    
end  
  
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCity]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateCity]
(
	@CityId int,
	@CityName nvarchar (MAX),
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@StateId int,
	@IsActive bit
)

AS
UPDATE [City] 
SET 
CityId = @CityId,
CityName = @CityName,
CreatedDate = @CreatedDate,
ModifiedDate = @ModifiedDate,
StateId = @StateId,
IsActive = @IsActive

WHERE
CityId = @CityId


/*DROP PROC dbo.usp_UpdateCity*/
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCountry]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateCountry]
(
	@CountryId int,
	@CountryName nvarchar (MAX),
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@IsActive bit
)

AS
UPDATE [Country] 
SET 
CountryName = @CountryName,
CreatedDate = @CreatedDate,
ModifiedDate = @ModifiedDate,
IsActive = @IsActive

WHERE
CountryId = @CountryId


/*DROP PROC dbo.usp_UpdateCountry*/
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateLoginAttempt]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateLoginAttempt]
(
	@Id int,
	@LastLoginTimeStamp datetime,
	@IsSuccess bit,
	@UserId int,
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@IP_Addess nvarchar (MAX)
)

AS
UPDATE [LoginAttempt] 
SET 
LastLoginTimeStamp = @LastLoginTimeStamp,
IsSuccess = @IsSuccess,
UserId = @UserId,
CreatedDate = @CreatedDate,
ModifiedDate = @ModifiedDate,
IP_Addess = @IP_Addess

WHERE
Id = @Id


/*DROP PROC dbo.usp_UpdateLoginHistory*/
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateQualification]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_UpdateQualification]

@QualificationId int,
@QualificationName nvarchar(100),
@Description nvarchar(500),
@ModifiedDate datetime

AS

update [dbo].[Qualification] set QualificationName=@QualificationName,Description=@Description,[ModifiedDate]=@ModifiedDate where Id=@QualificationId and IsActive=1
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateState]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateState]
(
	@StateId int,
	@StateName nvarchar (MAX),
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@CountryId int,
	@IsActive bit
)

AS
UPDATE [State] 
SET 
StateName = @StateName,
CreatedDate = @CreatedDate,
ModifiedDate = @ModifiedDate,
CountryId = @CountryId,
IsActive = @IsActive

WHERE
StateId = @StateId


/*DROP PROC dbo.usp_UpdateState*/
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTask]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateTask]
(
	@TaskId int,
	@Description nvarchar (MAX),
	@due_date datetime,
	@IsComplete bit,	
	@UserId int,
	@CreatedByUserId int,
	@ModifiedDate datetime	
)

AS
UPDATE [Task] 
SET 
Description = @Description,
due_date = @due_date,
IsComplete = @IsComplete,
ModifiedDate = @ModifiedDate,
UserId=	@UserId ,
CreatedByUserId=@CreatedByUserId

WHERE
TaskId = @TaskId


/*DROP PROC dbo.usp_UpdateTask*/
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTaskItem]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateTaskItem]
(
	@TaskItemId int,
	@TaskId int,
	@Description nvarchar (MAX),
	@IsComplete bit,
	@ModifiedDate datetime,
	@UserId int,
	@CreatedByUserId int

)

AS
UPDATE [Task_Item] 
SET 
TaskId = @TaskId,
Description = @Description,
IsComplete = @IsComplete,
ModifiedDate = @ModifiedDate,
UserId=	@UserId,
CreatedByUserId=@CreatedByUserId 

WHERE
TaskItemId = @TaskItemId


/*DROP PROC dbo.usp_UpdateTask_Item*/
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTaskType]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateTaskType]
(
	@TaskTypeId int,
	@TaskTypeName nvarchar (MAX),
	@Description nvarchar (MAX),
	@CreatedDate datetime,
	@ModifiedDate datetime,
	@IsActive bit
)

AS
UPDATE [TaskType] 
SET 
TaskTypeName = @TaskTypeName,
Description = @Description,
CreatedDate = @CreatedDate,
ModifiedDate = @ModifiedDate,
IsActive = @IsActive

WHERE
TaskTypeId = @TaskTypeId


/*DROP PROC dbo.usp_UpdateTaskType*/
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateUser]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_UpdateUser]
@UserId int,
@Email nvarchar(max),
@UserName nvarchar(100),
@Date_Of_Birth datetime,
@Address int,
@ContactNo bigint,
@Gender char(1),
@QualificationId int,
@ModifiedDate datetime,
@UserQualificationId int,
@City int,
@State int,
@CreatedByUserId int
AS
set nocount off

update [dbo].[User] set [UserName]=@UserName, [Date_Of_Birth]=@Date_Of_Birth,[ContactNo]=@ContactNo,
	   [QualificationId]=@QualificationId,ModifiedDate=@ModifiedDate,Gender=@Gender ,Email=@Email,CreatedByUserId=@CreatedByUserId
	   where [UserId]=@UserId

update [dbo].[UserAddress] set [Address]=@Address,[City]=@City,State=@State where [UserId]=@UserId

update [dbo].[UserQualification] set QualificationId=@QualificationId where UserId=@UserId and UserQualificationId=@UserQualificationId

		



GO
/****** Object:  StoredProcedure [dbo].[usp_updateUserPassword]    Script Date: 30-10-2020 14:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_updateUserPassword]

@UserEmail varchar(max),
@Password varchar(max),
@ModifiedDate datetime

AS

update [dbo].[UserLogin] set Password=@Password,[ModifiedDate]=@ModifiedDate where UserEmail=@UserEmail and IsActive=1 
GO
