CREATE TABLE Orders (
	[OrderID] INT Identity NOT NULL,
	[Name] NVARCHAR(MAX) NULL,
	[Line1] NVARCHAR(MAX) NULL,
	[Line2] NVARCHAR(MAX) NULL,
	[Line3] NVARCHAR(MAX) NULL,
	[City] NVARCHAR(MAX) NULL,
	[GiftWrap] BIT NOT NULL,
	[Dispatched] BIT NOT NULL,
	CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC)
);

CREATE TABLE OrderLines (
	[OrderLineID] INT IDENTITY NOT NULL,
	[Quantity] INT NOT NULL,
	[Drugs_DrugID] INT NULL,
	[Order_OrderID] INT NULL,
	CONSTRAINT [PK_dbo.OrderLines] PRIMARY KEY CLUSTERED ([OrderLineID] ASC),
	CONSTRAINT [FK_dbo.OrderLines_dbo.Drugs_DrugID] FOREIGN KEY
		([Drugs_DrugID]) REFERENCES [dbo].[Drugs] ([DrugID]),
	CONSTRAINT [FK_dbo.OrderLines_dbo.Order_OrderId] FOREIGN KEY
		([Order_OrderID]) REFERENCES [dbo].[Orders] ([OrderID])
);