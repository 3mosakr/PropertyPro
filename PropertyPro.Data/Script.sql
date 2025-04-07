CREATE FUNCTION dbo.ComputeAddress(
    @GovernorateName NVARCHAR(60),
    @CityName NVARCHAR(50),
    @AreaName NVARCHAR(50),
    @CompoundName NVARCHAR(100),
    @StreetName NVARCHAR(100)
)  
RETURNS NVARCHAR(300)  
AS  
BEGIN  
    RETURN CONCAT(
        @GovernorateName, ', ', 
        @CityName, ', ', 
        @AreaName, ', ', 
        COALESCE(@CompoundName, @StreetName, '')
    );  
END;
go

CREATE TRIGGER trg_UpdateAddress
ON Units
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE u
    SET u.Address = dbo.ComputeAddress(
        g.GovernorateName, 
        c.CityName, 
        a.AreaName, 
        i.CompoundName, 
        i.StreetName
    )
    FROM Units u
    INNER JOIN inserted i ON u.Id = i.Id
    INNER JOIN Governorates g ON i.GovernorateId = g.Id
    INNER JOIN Cities c ON i.CityId = c.Id
    INNER JOIN Areas a ON i.AreaId = a.Id;
END;