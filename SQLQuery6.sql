Create Procedure UpdateDepartment
(@DepartmentId int,
@DepartmentName varchar(30),
@DepartmentDescription varchar(30)
)
As
Begin
Update Departments Set DepartmentName=@DepartmentName,DepartmentDescription=@DepartmentDescription where DepartmentId=@DepartmentId
End