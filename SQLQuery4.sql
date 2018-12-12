USE [DBDepartments]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[GetDEpartmentDetails]
		@DepartmentId = NULL,
		@DepartmentName = N'',
		@DepartmentDescription = N''

SELECT	@return_value as 'Return Value'

GO
