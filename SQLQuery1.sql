﻿DECLARE @StartDate DATETIME2 = '2023-08-01 00:00:00.000';
DECLARE @EndDate DATETIME2 = '2023-09-01 23:59:59.999';

SELECT 
*
FROM 
Lesson
WHERE 
Date BETWEEN @StartDate AND @EndDate
AND Type = 'Piano' 
ORDER BY 
Date;
