USE master
GO

IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'StudentRegistrationSystem') 
BEGIN
	DROP DATABASE StudentRegistrationSystem
	print '' print '*** dropping database StudentRegistrationSystem'
END
GO


print '' print '*** creating database StudentRegistrationSystem'
GO
CREATE DATABASE StudentRegistrationSystem
GO


GO
print ''
USE [StudentRegistrationSystem]
GO

print '' print '*** Creating Students Table'
GO
CREATE TABLE [dbo].[Users](
	[UserID]				[int] IDENTITY(1000000, 1)		NOT NULL,
	[UserName]				[varchar](50)					NOT NULL,
	[MajorID]				[varchar](50)					NOT NULL,
	[FirstName]				[varchar](50)					NOT NULL,
	[PasswordHash]			[nvarchar](256)					NOT NULL		DEFAULT 'NEWUSER',
	[LastName]				[varchar](100)					NOT NULL,
	[Phone]					[varchar](10)					NOT NULL,
	[Address]				[varchar](100)					NOT NULL,	
	[Email]					[varchar](100)					NOT NULL,
	[Active]				[bit] DEFAULT 1					NOT NULL

	CONSTRAINT [pk_UserID] PRIMARY KEY([UserID] ASC),
	CONSTRAINT [ak_UserName] UNIQUE ([UserName] ASC)
)
GO


GO
print '' print '*** Creating Departments Table'
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID]			[varchar](50)					NOT NULL,
	[DepartmentName]		[varchar](50)					NOT NULL
	CONSTRAINT [pk_DepartmentID] PRIMARY KEY([DepartmentID] ASC)
)
GO

print '' print '*** Creating Classes Table'
GO
CREATE TABLE [dbo].[Classes](
	[ClassID]				[varchar](50)					NOT NULL,
	[DepartmentID]			[varchar](50)					NOT NULL,
	[Description]			[varchar](700)					NOT NULL,
	[NumOfSeats]			[char](3)						NOT NULL,
	[ClassName]				[varchar](50)					NOT NULL
	CONSTRAINT [pk_ClassID] PRIMARY KEY([ClassID] ASC)
)
GO


print '' print '*** Creating Sections Table'
GO
CREATE TABLE [dbo].[Sections](
	[SectionID]				[varchar](50)					NOT NULL,
	[UserID]				[int] 							NOT NULL,
	[TermID]				[varchar](50)					NOT NULL,
	[LocationID]			[varchar](50)					NOT NULL
	CONSTRAINT [pk_SectionID] PRIMARY KEY([SectionID] ASC)
)
GO

print '' print '*** Creating Locations Table'
GO
CREATE TABLE [dbo].[Locations](
	[LocationID]			[varchar](50)					NOT NULL,
	[LocationName]			[varchar](50)					NOT NULL
	CONSTRAINT [pk_LocationID] PRIMARY KEY([LocationID] ASC)
)
GO


print '' print '*** Creating Terms Table'
GO
CREATE TABLE [dbo].[Terms](
	[TermID]				[varchar](50)					NOT NULL,
	[TermName]				[varchar](50)					NOT NULL
	CONSTRAINT [pk_TermID] PRIMARY KEY([TermID] ASC)
)
GO

print '' print '*** Creating Enrolments Table'
GO
CREATE TABLE [dbo].[Enrolments](
	[EnrolmentID]			[varchar](50)					NOT NULL,
	[UserID]				[int] 							NOT NULL,
	[ClassID]				[varchar](50)					NOT NULL,
	[SectionID]				[varchar](50)					NOT NULL
	
	CONSTRAINT [pk_EnrolmentID] PRIMARY KEY([EnrolmentID] ASC)
)
GO

print '' print '*** Creating Majors Table'
GO
CREATE TABLE [dbo].[Majors](
	[MajorID]			[varchar](50)					NOT NULL,
	[MajorName]			[varchar](50)					NOT NULL
	CONSTRAINT [pk_MajorID] PRIMARY KEY([MajorID] ASC)
)
GO

print '' print '*** Creating Assignments Table'
GO
CREATE TABLE [dbo].[Assignments](
	[UserID]				[int]							NOT NULL,
	[RoleName]				[varchar](50)					NOT NULL,
	[Active]				[bit] DEFAULT 1					NOT NULL
	CONSTRAINT [pk_UserIDRoleName] PRIMARY KEY([UserID] ASC, [RoleName] ASC)
)
GO


print '' print '*** Creating Roles Table'
GO
CREATE TABLE [dbo].[Roles](
	[RoleName]				[varchar](50)					NOT NULL,
	[RoleDescription]		[varchar](165)					NOT NULL,
	CONSTRAINT [pk_RoleName] PRIMARY KEY([RoleName] ASC)
)
GO


/***** Relationships *****/

-- Foreign keys for [Users]
print '' print '*** Creating Foreign keys for Users Table'
GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
	ADD CONSTRAINT [fk_Student_MajorID] FOREIGN KEY([MajorID])
		REFERENCES [dbo].[Majors] ([MajorID])
		GO


-- Foreign key for [Classes]
print '' print '*** Creating Foreign keys for Classes Table'
GO
ALTER TABLE [dbo].[Classes] WITH NOCHECK
	ADD CONSTRAINT [fk_Classes_DepartmentID] FOREIGN KEY([DepartmentID])
		REFERENCES [dbo].[Departments] ([DepartmentID])
		GO

-- Foreign key for [Sections]
print '' print '*** Creating Foreign keys for Sections Table'
GO
ALTER TABLE [dbo].[Sections] WITH NOCHECK
	ADD CONSTRAINT [fk_Sections_UserID] FOREIGN KEY([UserID])
		REFERENCES [dbo].[Users] ([UserID])
		GO
ALTER TABLE [dbo].[Sections] WITH NOCHECK
	ADD CONSTRAINT [fk_Sections_TermID] FOREIGN KEY([TermID])
		REFERENCES [dbo].[Terms] ([TermID])
		GO
ALTER TABLE [dbo].[Sections] WITH NOCHECK
	ADD CONSTRAINT [fk_Sections_LocationID] FOREIGN KEY([LocationID])
		REFERENCES [dbo].[Locations] ([LocationID])
		GO

-- Foreign key for [Enrolment]
print '' print '*** Creating Foreign keys for Enrolments Table'
GO
ALTER TABLE [dbo].[Enrolments] WITH NOCHECK
	ADD CONSTRAINT [fk_Enrolment_UserID] FOREIGN KEY([UserID])
		REFERENCES [dbo].[Users] ([UserID])
		GO
ALTER TABLE [dbo].[Enrolments] WITH NOCHECK
	ADD CONSTRAINT [fk_Enrolmentt_SectionID] FOREIGN KEY([SectionID])
		REFERENCES [dbo].[Sections] ([SectionID])
		GO
ALTER TABLE [dbo].[Enrolments] WITH NOCHECK
	ADD CONSTRAINT [fk_Enrolments_ClassID] FOREIGN KEY([ClassID])
		REFERENCES [dbo].[Classes] ([ClassID])
		GO
/***** Indexes *****/

-- Index for [Users]
print '' print '*** Creating Index for Users Table'
GO
CREATE INDEX Students_LastName
ON Users(LastName)


-- Index for [Classes]
print '' print '*** Creating Index for Classes Table'
GO
CREATE INDEX Classes_LastName
ON Classes(ClassName)

print '' print '*** Iserting values in Majors Table'
GO
INSERT INTO [dbo].[Majors] ([MajorID],[MajorName])
VALUES('001', 'Software Development' ),
	('002', 'Software Programming' ),
	('003', 'Web Design ' );
	
GO	
print '' print '*** Iserting values in Users Table'
GO
INSERT INTO [dbo].[Users] ([MajorID] ,[UserName],[FirstName], [LastName],  [Phone],[Address], [Email],[Active])
VALUES('001','Oshar','Oliver', 'Tan',  '5154565451', '2521 Main St., Iowa City, IA', 'Sami@gmail.com', 1 ),
('002','Toppy','Samuel', 'Sam', '5154777451', '3245 Johnson St., Cedar Rapids, IA', 'Rani@gmail.com', 1 ),
('003','Nasri','Nasr', 'Oshar', '3194777451', '2212 Miller St., Hills, IA', 'Nasri@gmail.com', 1 );


print '' print '*** Iserting values in Departments Table'
GO
INSERT INTO [dbo].[Departments] ([DepartmentID],[DepartmentName])
VALUES('001', 'Business Information Technology' ),
('002', 'Math and Science' ),
('003', 'History Studies' );
GO

print '' print '*** Iserting values in Classes Table'
GO
INSERT INTO [dbo].[Classes] ([ClassID],[DepartmentID], [Description], [NumOfSeats], [ClassName])
VALUES('Java1', '001','Introduces students to basic computer programming ideas and 
foundational principles such as problem decomposition and step-wise refinement. Explores problem solving using
 well-developed programming logic derived with pseudo code, flow charts and related techniques. Focuses on translating
 student developed solutions into simple programs for testing using an instructor-selected, high-level programming 
 or scripting language. Credits: 3, Hours: (2/2/0/0), Prereq: none; Coreq: none; Arts & Sciences Elective Code: B; Comments: ',
 '20', 'Java1' ),
 ('Java2', '002','Introduces students to basic computer programming ideas and 
foundational principles such as problem decomposition and step-wise refinement. Explores problem solving using
 well-developed programming logic derived with pseudo code, flow charts and related techniques. Focuses on translating
 student developed solutions into simple programs for testing using an instructor-selected, high-level programming 
 or scripting language. Credits: 3, Hours: (2/2/0/0), Prereq: none; Coreq: none; Arts & Sciences Elective Code: B; Comments: ',
 '25', '.NET2' ),
 ('Java3', '003','Introduces students to basic computer programming ideas and 
foundational principles such as problem decomposition and step-wise refinement. Explores problem solving using
 well-developed programming logic derived with pseudo code, flow charts and related techniques. Focuses on translating
 student developed solutions into simple programs for testing using an instructor-selected, high-level programming 
 or scripting language. Credits: 3, Hours: (2/2/0/0), Prereq: none; Coreq: none; Arts & Sciences Elective Code: B; Comments: ',
 '21', 'American History' );

 GO

print '' print '*** Iserting values in Locations Table'
GO
INSERT INTO [dbo].[Locations] ([LocationID],[LocationName])
VALUES('001', 'Iowa City Campus'),
('002', 'Cedar Rapids Campus'), 
('003', 'Washnington Campus');
GO

print '' print '*** Iserting values in Terms Table'
GO
INSERT INTO [dbo].[Terms] ([TermID],[TermName])
VALUES('Spring', 'Spring'),
('Fall', 'Fall'),
('Summer', 'Summer');
GO

print '' print '*** Iserting values in Sections Table'
GO
INSERT INTO [dbo].[Sections] ([SectionID], [UserID], [TermID], [LocationID] )
VALUES('CIS-121-CRF01',  1000000, 'Spring', '001'),
('CIS-121-CRF02',  1000001, 'Fall', '002'),
('CIS-121-CRF03',  1000002, 'Summer', '003');
GO

print '' print '*** Iserting values in Enrolments Table'
GO
INSERT INTO [dbo].[Enrolments] ([EnrolmentID],[UserID],[ClassID], [SectionID])
VALUES('001', 1000000, 'Java1', 'CIS-121-CRF01'),
('002', 1000001, 'Java2',  'CIS-121-CRF02'),
('003', 1000002,  'Java3',   'CIS-121-CRF03');
GO

print '' print '*** inserting sample Roles'
GO
INSERT INTO [dbo].[Roles] (RoleName, RoleDescription)
	VALUES	('Student', 'Add, drop new classes '),
			('Registrar', 'Add, drop new classes and students');
		 
GO	


print '' print '*** inserting sample Assignments'
GO
INSERT INTO [dbo].[Assignments] (UserID, RoleName)
	VALUES	(1000000, 'Student'),
			(1000001, 'Registrar'),
			(1000002, 'Student');
		
GO

print '' print '*** Creating sp_select_user_with_username'
GO
CREATE PROCEDURE sp_select_user_with_username (
	@username varchar(25)
)
AS
BEGIN
	SELECT UserID, UserName, MajorID, FirstName, LastName, Phone, Address, Email, Active
	  
	FROM [dbo].[Users]
	WHERE UserName = @username
END
GO




print '' print '*** Creating sp_select_roles_for_userID'
GO
CREATE PROCEDURE sp_select_roles_for_userID (
	@userID int
)
AS
BEGIN
	SELECT Assignments.RoleName, RoleDescription
	FROM [dbo].[Roles], [dbo].[Assignments]
	WHERE Assignments.UserID = @userID
	AND Roles.RoleName = Assignments.RoleName
END
GO

print '' print '*** Creating sp_select_major_for_userID'
GO
CREATE PROCEDURE sp_select_major_for_userID (
	@majorID int
)
AS
BEGIN
	SELECT Majors.MajorID, Majors.MajorName
	FROM [dbo].[Majors]
	WHERE Majors.MajorID = @majorID
END
GO

print '' print '*** Creating sp_register_classes_for_userID'
GO
CREATE PROCEDURE sp_register_classes_for_userID (
	@userID int
)
AS
BEGIN
	SELECT Classes.DepartmentID, ClassName, Sections.LocationID, LocationName, 
	Sections.TermID, TermName, Users.MajorID, MajorName 
	FROM [dbo].[Classes], [dbo].[Locations], [dbo].[Sections], [dbo].[Users], [dbo].[Departments],
	[dbo].[Terms], [dbo].[Majors]
	WHERE Users.UserID = @userID
	AND Classes.DepartmentID = Departments.DepartmentID
	AND Sections.LocationID = Locations.LocationID
	AND Sections.TermID = Terms.TermID
	AND Users.MajorID = Majors.MajorID
END
GO


print '' print '*** Creating sp_validate_active_username_and_password'
GO
CREATE PROCEDURE sp_validate_active_username_and_password (
	@username varchar(25),
	@password nvarchar(256)
	)
	AS
	BEGIN
		SELECT COUNT(username)
		FROM Users
		WHERE
			UserName = @username
		AND PasswordHash = @password
		AND Active = 1
	END

GO





print '' print '*** Creating sp_update_password_for_username'
GO
CREATE PROCEDURE sp_update_password_for_username (
	@username varchar(25),
	@oldPassword nvarchar(256),
	@newPassword nvarchar(256)
	)
	AS
	BEGIN
		UPDATE Users
			SET PasswordHash = @newPassword
		WHERE
			UserName = @username
		AND PasswordHash = @oldPassword
		AND Active = 1
		RETURN @@rowcount
	END
GO

/*
print '' print '*** Creating sp_update_user_email'
GO
CREATE PROCEDURE sp_update_user_email(
	@Email varchar(100),
	@userID int
)
AS
BEGIN
	UPDATE Users SET
		Email = @Email
	WHERE
		UserID = @userID
	
	RETURN @@rowcount
END
GO */

print '' print '*** Creating sp_update_user_record'
GO
CREATE PROCEDURE sp_update_user_record(
	@userID int,
	@UserName varchar(50),
	@FirstName varchar(100),
	@LastName varchar(100),
	@Phone varchar(10),
	@Address varchar(100),
	@Email varchar(100)
	
)
AS
BEGIN
	UPDATE Users SET
		UserName = @UserName,
		FirstName = @FirstName,
		LastName = @LastName,
		Phone = @Phone,
		Address = @Address,
		Email = @Email
	
	WHERE
		UserID = @userID
	
	RETURN @@rowcount
END
GO



print '' print '*** Creating sp_delete_user_record'
GO
CREATE PROCEDURE sp_delete_user_record(
	@userID int
)
AS
BEGIN
	Delete Users 
	
	WHERE
		UserID = @userID
	
	RETURN @@rowcount
END
GO


