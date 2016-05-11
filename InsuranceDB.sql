/* Check if database already exists and delete it if it does exist*/


DROP DATABASE IF EXISTS InsuranceDB;

CREATE DATABASE IF NOT EXISTS InsuranceDB;

USE InsuranceDB;

-- This table will hold all the user 
CREATE TABLE Users(
	Username		varchar(20) PRIMARY KEY 	NOT NULL COMMENT' Username to represent a customer or sales person ',
	Password 		varchar(50) 				NOT NULL COMMENT ' HASHED password value for user ' ,
	FirstName		varchar(25) 				NOT NULL COMMENT ' Users first name ' ,
	LastName 		varchar(25) 				NOT NULL COMMENT ' Users last name' ,
	Address			varchar(75) 				NULL COMMENT ' Current Address for user' ,
	ZipCode			char(5) 					NULL COMMENT ' Current 5 digit Zip of customer ' ,
	PolicyName 		varchar(50)             	NOT NULL COMMENT ' The Policies Name  ' ,
	RoleID 			int  					  	NOT NULL COMMENT ' Role ID to differentiate roles, Some roles may have the same name but different functions',
	SocialSecurity 	char(8) 					NULL COMMENT ' Current Social Security of customre ' 
) COMMENT 'Table to represent Users of our System.';

-- this table will holds all the roles 
CREATE TABLE Roles(
	RoleID 			int  PRIMARY KEY  NOT NULL COMMENT ' Role ID to differentiate roles, Some roles may have the same name but different functions',
	RoleName 		varchar(50)  NOT NULL COMMENT ' Name of role ' ,
	RoleDescription varchar(75)  NOT NULL COMMENT ' A Description of what the role will be used for ' 
)COMMENT ' Table to represent all of our roles in the system ';

-- this table will holds all the policies in the system
CREATE TABLE Policies(	
	PolicyName 			varchar(50) PRIMARY KEY 	NOT NULL COMMENT ' The Policies Name  ' ,
	PolicyDescription	varchar(100)				NOT NULL COMMENT ' The description of what the policy offers ',
	PolicyType			char(4)						NOT NULL COMMENT ' The type of policy (auto, home, life ) '
) COMMENT ' Table to represent all of our policies';

-- this table will join users with polices 
CREATE TABLE UserPolicies(
	Username		varchar(20) 	 NOT NULL COMMENT 'Username from users table',
	PolicyName		varchar(50) 	 NOT NULL COMMENT 'Policy Name from the Policies table'
)COMMENT ' TABLE TO ASSOCIATE A USER WITH ONE OR MORE POLICIES ';

-- this table will joins users with roles
CREATE TABLE UserRoles(
	Username		varchar(20)  NOT NULL COMMENT 'Username from users table',
	RoleID			int				 NOT NULL COMMENT ' Role ID from Roles table '
)COMMENT ' TABLE TO ASSOCIATE A USER WITH ONE OR MORE ROLES ' ;

/* ********************** Foriegn Keys *********************/


ALTER TABLE Users ADD FOREIGN KEY (PolicyName) REFERENCES Policies (PolicyName);				
ALTER TABLE Users ADD FOREIGN KEY (RoleID) REFERENCES Roles (RoleID);				

/* ********************** STORED PROCEDURES *********************/

CREATE PROCEDURE SP_GetUser_By_Username()
BEGIN
	SELECT
		 Users.Username
		, Users.FirstName
		, Users.LastName
		, Users.Address
        , Users.ZipCode
        , Policies.PolicyName
        , Roles.RoleID
	FROM Users
	LEFT OUTER JOIN PolicyName 
	ON Users.PolicyName = Policies.PolicyName;

END $$

/*

CREATE PROCEDURE SP_AddUser
	@FirstName	varchar(100),
	@Username	varchar(25),
	@LastName	varchar(100),
	@Phone		varchar(10),
	@SocialID	char(8),
	@Password 	varchar(50)
AS
	BEGIN
		INSERT INTO Users(FirstName,LastName,Username,Phone,SocialID,Password)
		VALUES(@FirstName,@LastName,@Username,@Phone,@SocialID,@Password)
	END;




CREATE PROCEDURE SP_AddPolicyForUser
	@Username	varchar(20),
	@PolicyName varchar(50) */
