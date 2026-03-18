CREATE OR ALTER VIEW vw_CountrySearchResult AS
SELECT
    c.Id AS DomainObjectId,
    c.Name,
    c.Alpha2Code,
    c.Alpha3Code,
    c.NumericCode
FROM Countries c