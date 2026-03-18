CREATE OR ALTER VIEW vw_CompanySearchResult AS
SELECT
    c.Id AS DomainObjectId,
    c.Name,
    c.VatNumber
FROM Companies c;