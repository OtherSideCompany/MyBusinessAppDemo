CREATE OR ALTER VIEW vw_AdressSearchResult AS
SELECT
    a.Id AS DomainObjectId,
    a.Label,
    a.AdressDescription,
    bp.Name AS ParentName,
    pc.City,
    pc.Code AS PostalCode,
    c.Alpha2Code as CountryAlpha2Code
FROM Adresses a
LEFT JOIN BusinessPartners bp ON a.BusinessPartnerId = bp.Id
LEFT JOIN PostalCodes pc ON a.PostalCodeId = pc.Id
LEFT JOIN Countries c ON c.Id = pc.CountryId;
