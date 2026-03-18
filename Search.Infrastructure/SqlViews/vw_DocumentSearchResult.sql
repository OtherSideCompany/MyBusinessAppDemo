CREATE OR ALTER VIEW vw_DocumentSearchResult AS
SELECT
    d.Id AS DomainObjectId,
    d.[FileName],
    d.HistoryInfo_CreatedByName as CreatedByName,
    d.ContentType,
    d.ByteSize
FROM Documents d