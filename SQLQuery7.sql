create procedure GetDepartmentDetail
(@DepartmentId int
)
As 
Begin 
Select * from Departments where DepartmentId=@DepartmentId
End
exec GetDepartmentDetail 2
