CREATE TABLE [dbo].[Supplier] (
    [SupplierId] INT NOT NULL IDENTITY,
    [SupplierName] VARCHAR (50)  NULL,
    [ContactName]  VARCHAR (50)  NULL,
    [ContactNo]    VARCHAR (50)  NULL,
    [Email]        VARCHAR (50)  NULL,
    [Address]      VARCHAR (300) NULL,
    PRIMARY KEY CLUSTERED ([SupplierId] ASC)
);

