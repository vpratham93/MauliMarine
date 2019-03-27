CREATE TABLE [dbo].[Material]
(
	[MaterialId]   INT  NOT NULL IDENTITY,
    [MaterialName] VARCHAR (50) NULL,
    [Quantity]     VARCHAR (50) NULL,
    [UnitId]       INT          NULL, 
    CONSTRAINT [PK_Material] PRIMARY KEY ([MaterialId]), 
    CONSTRAINT [FK_Material_Units] FOREIGN KEY ([UnitId]) REFERENCES [Units]([UnitId])
)
