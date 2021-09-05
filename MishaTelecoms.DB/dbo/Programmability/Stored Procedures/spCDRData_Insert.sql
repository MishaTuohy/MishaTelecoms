CREATE PROCEDURE [dbo].[spCDRData_Insert]
	@Id uniqueidentifier,
	@CallingNumber NVARCHAR(50),
	@CalledNumber NVARCHAR(50),
	@Country NVARCHAR(50),
	@CallType NVARCHAR(50),
	@Duration NVARCHAR(50),
	@DateCreated NVARCHAR(50),
	@Cost NVARCHAR(50)
AS
BEGIN
	INSERT INTO CDRCDRData(Id, CallingNumber, CalledNumber, Country, CallType, Duration, DateCreated, Cost)
	VALUES (@Id, @CallingNumber, @CalledNumber, @Country, @CallType, @Duration, @DateCreated, @Cost)
END