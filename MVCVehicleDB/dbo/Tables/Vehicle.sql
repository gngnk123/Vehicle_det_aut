CREATE TABLE [dbo].[Vehicle]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [CarId] INT NOT NULL,
	[Make] NVARCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL, 
    [Year] INT NOT NULL, 
    [Odo] INT NOT NULL, 
    [Color] NVARCHAR(50) NOT NULL, 
    [Engine] INT NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0
)
