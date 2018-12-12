USE [DBDepartments]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[DepartmentsSp]
		@DepartmentName = N'',
		@DepartmentDescription = N''

SELECT	@return_value as 'Return Value'

GO
exec DepartmentsSp 'vamsi','krishna'