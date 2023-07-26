create table [dbo].[Employees](
[EmpID] [int] IDENTITY(1,1) NOT NULL,
[FirstName] [varchar](50),
[LastName] [varchar](50),
[DOB] [datetime],
[Email] [varchar](50),
[Mobile] [numeric](18,0),
[Department] [varchar](50),
[Designation] [varchar](50),
[Salary] [numeric](18,0)
CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED
(
[EmpID] ASC
))ON [PRIMARY]
GO

	
