IF NOT EXISTS( SELECT TOP 1 1 FROM sys.tables WHERE [name] = 'todo' )
BEGIN
	CREATE TABLE [todo] (
		[id_todo] INT IDENTITY(1,1) CONSTRAINT PK_todo PRIMARY KEY,
		[title] NVARCHAR(MAX) NOT NULL,
		[is_done] BIT NOT NULL
	)
END