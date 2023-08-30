SELECT
Type,
Level,
COUNT(*) AS TotalLessons
FROM
Lesson
GROUP BY
CUBE(Type, Level)
ORDER BY
Type, Level;
