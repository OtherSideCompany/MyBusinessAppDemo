CREATE OR ALTER VIEW vw_ContactSearchResult AS
SELECT
    ct.Id AS DomainObjectId,
    ct.BusinessPartnerId AS ParentId,
    bp.Name AS ParentName,
    ct.Name,
    ct.IsActive
FROM Contacts ct
LEFT JOIN BusinessPartners bp ON ct.BusinessPartnerId = bp.Id;