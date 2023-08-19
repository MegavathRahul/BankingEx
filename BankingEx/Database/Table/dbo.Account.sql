CREATE TABLE Account
(
	Id INT IDENTITY(1, 1),
	Number VARCHAR(11) NOT NULL,
	Balance decimal(18,2) NOT NULL,
	Type BIT NOT NULL,
	CustomerId INT NOT NULL,

	CONSTRAINT PK_Account PRIMARY KEY (Id),
	CONSTRAINT FK_Account_Customer_CustomerId FOREIGN KEY (CustomerId) REFERENCES dbo.Customer(Id)
)