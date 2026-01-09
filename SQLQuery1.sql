WITH CHildCategory
AS
(
    SELECT ID,Name,ParentCategoryID, 0 as Lvl FROM Categories WHERE ParentCategoryId IS NULL AND Name='Beverages' 
    UNION ALL
    SELECT C.ID,C.Name,C.ParentCategoryID, CC.lvl+1 as Lvl FROM Categories C INNER JOIN CHildCategory CC ON C.ParentCategoryId=CC.Id
    
)
SELECT * FROM CHildCategory