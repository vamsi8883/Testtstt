CREATE PROCEDURE GetDEpartmentDetails
	@DepartmentId int,
	@DepartmentName varchar(20),
	@DepartmentDescription varchar(20)
AS
	SELECT @DepartmentId, @DepartmentName,@DepartmentDescription
RETURN 
