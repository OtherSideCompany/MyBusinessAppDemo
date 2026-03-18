CREATE OR ALTER VIEW vw_BusinessPartnerTypeSearchResult AS
SELECT
    bpt.Id AS DomainObjectId,
    bpt.Name
FROM BusinessPartnerTypes bpt