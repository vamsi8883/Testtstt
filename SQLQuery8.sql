create procedure DeleteDepartment
(@DepartmentId int
)
As
Begin
Delete from Departments where DepartmentId = @DepartmentId
End
exec DeleteDepartment 2
