USE AdventureWorks;
GO
SELECT   
	ProductNumber
,   CASE ProductLine
         WHEN 'R' THEN 'Road'
         WHEN 'M' THEN 'Mountain'
         WHEN 'T' THEN 'Touring'
         WHEN 'S' THEN 'Other sale items'
         ELSE 'Not for sale'
    END Category
,   Name
FROM	Production.Product
ORDER BY ProductNumber;
GO