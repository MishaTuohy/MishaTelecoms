CREATE PROCEDURE [dbo].[spCDRData_GetByCountry]
	@Country NVARCHAR(50)
AS
BEGIN
	SELECT *
	FROM dbo.CDRData
	WHERE (Country = @Country OR @Country = '')
END