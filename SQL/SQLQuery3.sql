--Read all employees
CREATE PROC [DBO].[get_Employees]
AS
BEGIN
SELECT EmpID, FirstName, LastName, DOB, Email, Mobile, Department, Designation, Salary FROM dbo.Employees WITH (NOLOCK)
END

--GETBYEMPID
CREATE PROC [DBO].[get_EmployeesById]
(
@EmpID INT
)
AS
BEGIN
SELECT EmpID, FirstName, LastName, DOB, Email, Mobile, Department, Designation, Salary FROM dbo.Employees WITH (NOLOCK)
Where EmpID = @EmpID 
END


--Insert
ALTER PROC [DBO].[insert_Employee]
(
	@FirstName Varchar(50), 
	@LastName  Varchar(50), 
	@DOB Datetime, 
	@Email Varchar(50), 
	@Mobile numeric(18,0), 
	@Department Varchar(50), 
	@Designation Varchar(50), 
	@Salary numeric(18,0)
)
AS
BEGIN

BEGIN TRY

BEGIN TRAN
INSERT INTO dbo.Employees(FirstName, LastName, DOB, Email, Mobile, Department, Designation, Salary) 
	VALUES(
	@FirstName , 
	@LastName , 
	@DOB, 
	@Email , 
	@Mobile , 
	@Department, 
	@Designation , 
	@Salary
	)
	COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	END CATCH
END

--Update
CREATE PROC [DBO].[update_Employee]
(
	@EmpID	int,
	@FirstName Varchar(50), 
	@LastName  Varchar(50), 
	@DOB Datetime, 
	@Email Varchar(50), 
	@Mobile numeric(18,0), 
	@Department Varchar(50), 
	@Designation Varchar(50), 
	@Salary numeric(18,0)
)
AS
BEGIN
Declare @RowCount INT = 0
	BEGIN TRY
	SET @RowCOunt = (SELECT COUNT(1) FROM dbo.Employees WITH (NOLOCK) WHERE EmpID = @EmpID)
	IF(@RowCount > 0)
	BEGIN
	 BEGIN TRAN
		UPDATE dbo.Employees
		SET
			FirstName = @FirstName
			,LastName  = @LastName
			,DOB = @DOB
			,Email = @Email
			,Mobile = @Mobile 
			,Department = @Department
			,Designation = @Designation
			,Salary = @Salary
			WHERE EmpID = @EmpID
		COMMIT TRAN
		END
END TRY

BEGIN CATCH
	ROLLBACK TRAN
END CATCH
END


--Delete
CREATE PROC [DBO].[delete_Employee]
(
	@EmpID	int
)
AS
BEGIN
Declare @RowCount INT = 0
	BEGIN TRY
	SET @RowCOunt = (SELECT COUNT(1) FROM dbo.Employees WITH (NOLOCK) WHERE EmpID = @EmpID)
	IF(@RowCount > 0)
	BEGIN
	 BEGIN TRAN
		DELETE FROM dbo.Employees
			WHERE EmpID = @EmpID
		COMMIT TRAN
		END
END TRY

BEGIN CATCH
	ROLLBACK TRAN
END CATCH
END