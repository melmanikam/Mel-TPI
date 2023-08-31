SELECT
    T.[TeacherID] AS [ID],
    T.[FirstName] AS [FirstName],
    T.[LastName] AS [LastName],
    COUNT(*) AS [LessonCount]
FROM 
Lesson AS L
INNER JOIN Teacher AS T ON L.[TeacherID] = T.[TeacherID]
GROUP BY T.[TeacherID], T.[FirstName], T.[LastName]

UNION ALL

SELECT
    S.[StudentID] AS [ID],
    S.[FirstName] AS [FirstName],
    S.[LastName] AS [LastName],
    COUNT(*) AS [LessonCount]
FROM 
Lesson AS L
INNER JOIN Student AS S ON L.[StudentID] = S.[StudentID]
GROUP BY S.[StudentID], S.[FirstName], S.[LastName];
