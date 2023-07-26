USE [Mel TPI]
GO

/****** Object: Table [dbo].[Student] Script Date: 27/07/2023 10:58:00 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student] (
    [StudentID]   INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (MAX) NOT NULL,
    [LastName]    NVARCHAR (MAX) NOT NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [PhoneNumber] NVARCHAR (MAX) NOT NULL
);

SELECT
first_name,
last_name 

FROM 
students 

ORDER BY
first_name;