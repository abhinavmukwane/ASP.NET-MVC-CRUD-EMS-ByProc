create table Employeesnew(
EmpID NUMBER NOT NULL,
FirstName varchar2(50),
LastName varchar2(50),
DOB DATE,
Email varchar2(50),
Mobile number(10),
Department varchar2(50),
Designation varchar2(50),
Salary number(6),
CONSTRAINT PK_Employeesnew PRIMARY KEY(EmpID),
CONSTRAINT email_unique UNIQUE (Email));


	

CREATE SEQUENCE Emp_id_seq;



CREATE OR REPLACE TRIGGER Emp_bi
BEFORE INSERT ON Employeesnew
FOR EACH ROW
BEGIN
  SELECT Emp_id_seq.nextval
  INTO :new.EmpID
  FROM dual;
END;
/



INSERT INTO Employeesnew
(FirstName, LastName, DOB, Email, Mobile, Department, Designation, Salary)
VALUES
('Abhi', 'Mukwane', DATE '1996-05-08', 'abhi@admin.com', 8888888888, 'IT', 'Engineer', 20000);