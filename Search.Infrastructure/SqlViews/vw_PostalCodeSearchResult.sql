CREATE OR ALTER VIEW vw_PostalCodeSearchResult AS
SELECT
    pc.Id AS DomainObjectId,
    pc.Code,
    pc.City,
    c.Alpha2Code as CountryAlpha2Code
FROM PostalCodes pc
LEFT JOIN Countries c ON c.Id = pc.CountryId;