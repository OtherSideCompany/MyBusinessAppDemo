CREATE OR ALTER VIEW vw_BusinessPartnerSearchResult AS
SELECT
    bp.Id AS DomainObjectId,
    bp.Name,
    bp.VatNumber,
    bp.ClientNumber,
    bp.ProviderNumber
FROM BusinessPartners bp