ALTER PROCEDURE [dbo].[spCDRData_UpdateAll]
	@Id UNIQUEIDENTIFIER,
	@CallingNumber NVARCHAR(50),
	@CalledNumber NVARCHAR(50),
	@Country NVARCHAR(50),
	@CallType NVARCHAR(50),
	@Duration INT,
	@DateCreated NVARCHAR(50),
	@Cost MONEY
AS
BEGIN
	UPDATE dbo.CDRData
	SET Id = @Id, 
        CallingNumber = @CallingNumber, 
        CalledNumber = @CalledNumber, 
        Country = @Country, 
        CallType = @CallType, 
        Duration = @Duration, 
        Cost = @Cost
END