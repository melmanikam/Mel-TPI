SET IDENTITY_INSERT [dbo].[Lesson] ON
INSERT INTO [dbo].[Lesson] ([LessonID], [TeacherID], [StudentID], [Date], [Level], [Type]) VALUES (1, 1, 1, N'2023-08-26 09:00:00', N'intermediate', N'piano')
INSERT INTO [dbo].[Lesson] ([LessonID], [TeacherID], [StudentID], [Date], [Level], [Type]) VALUES (2, 1, 3, N'2023-08-25 14:30:00', N'advanced', N'piano')
INSERT INTO [dbo].[Lesson] ([LessonID], [TeacherID], [StudentID], [Date], [Level], [Type]) VALUES (3, 2, 2, N'2023-08-26 09:30:00', N'intermediate', N'guitar')
INSERT INTO [dbo].[Lesson] ([LessonID], [TeacherID], [StudentID], [Date], [Level], [Type]) VALUES (4, 1, 5, N'2023-08-26 13:30:00', N'beginner', N'piano')
INSERT INTO [dbo].[Lesson] ([LessonID], [TeacherID], [StudentID], [Date], [Level], [Type]) VALUES (5, 2, 4, N'2023-08-25 17:00:00', N'intermediate', N'guitar')
SET IDENTITY_INSERT [dbo].[Lesson] OFF
