CREATE OR ALTER VIEW vw_NoteSearchResult AS
SELECT
    n.Id AS DomainObjectId,
    n.[Text],
    n.HistoryInfo_CreatedByName as CreatedByName
FROM Notes n