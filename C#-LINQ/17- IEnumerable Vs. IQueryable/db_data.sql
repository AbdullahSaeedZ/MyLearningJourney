USE master;
GO

CREATE DATABASE bookstore;
GO

USE bookstore;
GO

CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(150) NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);
GO

INSERT INTO Books (Title, Author, Price)
VALUES
    (N'Clean Code', N'Robert C. Martin', 45.00),
    (N'The Pragmatic Programmer', N'Andrew Hunt', 55.00),
    (N'CLR via C#', N'Jeffrey Richter', 60.00),
    (N'Design Patterns', N'Erich Gamma', 52.00),
    (N'C# in Depth', N'Jon Skeet', 48.00),
    (N'Refactoring', N'Martin Fowler', 58.00),
    (N'Domain-Driven Design', N'Eric Evans', 65.00),
    (N'You Don''t Know JS', N'Kyle Simpson', 35.00),
    (N'Working Effectively with Legacy Code', N'Michael Feathers', 42.00),
    (N'Head First Design Patterns', N'Eric Freeman', 40.00);
GO

