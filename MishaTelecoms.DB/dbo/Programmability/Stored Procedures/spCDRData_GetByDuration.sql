CREATE PROCEDURE [dbo].[spCDRData_GetByDuration]
	@Duration INT
AS
BEGIN
	SELECT *
	FROM dbo.CDRData
	WHERE Duration = @Duration
END