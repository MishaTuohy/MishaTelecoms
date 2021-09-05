CREATE PROCEDURE [dbo].[spCDRData_GetByCallType]
	@CallType NVARCHAR(50)
AS
BEGIN
	SELECT *
	FROM dbo.CDRData
	WHERE (CallType = @CallType OR @CallType = '')
END