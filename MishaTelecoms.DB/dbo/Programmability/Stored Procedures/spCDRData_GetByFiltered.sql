CREATE PROCEDURE [dbo].[spCDRData_GetByfiltered]
	@Country NVARCHAR (50),
	@CallType NVARCHAR(50),
	@Duration INT
AS
BEGIN
	SELECT *
	FROM dbo.CDRData
	WHERE (Country = @Country AND CallType = @CallType AND Duration = @Duration)
END