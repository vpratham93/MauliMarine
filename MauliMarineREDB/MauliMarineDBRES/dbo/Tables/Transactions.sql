CREATE TABLE [dbo].[Transactions]
(
	[TicketNo] INT NOT NULL PRIMARY KEY IDENTITY,
	[UnitId]       INT             NULL,
    [VeichleId]    INT   NULL,
    [LoadedWeight] DECIMAL (10, 2) NULL,
    [EmptyWeight]  DECIMAL (10, 2) NULL,
    [NetWeight]    DECIMAL (10, 2) NULL, 
    [SupplierId] INT NULL, 
	[MaterialId] INT NULL,
    [RecievedAmt] DECIMAL(18, 2) NULL, 
    [Tdate] DATETIME NULL, 
    CONSTRAINT [FK_Transactions_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Units] ([UnitId]),
	CONSTRAINT [FK_Transactions_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([SupplierId]),
	CONSTRAINT [FK_Transactions_Material] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[Material] ([MaterialId]),
	CONSTRAINT [FK_Transactions_VeichleEntry] FOREIGN KEY ([VeichleId]) REFERENCES [dbo].[VeichleEntry] ([VeichleId])
)
