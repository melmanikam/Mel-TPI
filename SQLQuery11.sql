SELECT
    [Type],
    [Level],
    [FirstName],
    [StudentName],
    COUNT(*) AS TotalLessons
FROM
    [dbo].[Lesson] L
INNER JOIN
    [dbo].[Teacher] T ON L.[TeacherID] = T.[TeacherID]
INNER JOIN
    [dbo].[Student] S ON L.[StudentID] = S.[StudentID]
GROUP BY
    CUBE([Type], [Level], [TeacherName], [StudentName])
ORDER BY
    [Type], [Level], [TeacherName], [StudentName];
