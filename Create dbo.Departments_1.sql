create procedure DepartmentsSp(
@DepartmentId int,
@DepartmentName varchar(30),
@DepartmentDescription  varchar(30))
As 
Begin 
Insert Into Departments(DepartmentId,DepartmentName,DepartmentDescription) values(@DepartmentId,@DepartmentName,@DepartmentDescription)
End