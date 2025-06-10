Use appDb
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductName VARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10,2)
);
BEGIN TRY
    BEGIN TRANSACTION;

    -- Insert into Orders
    INSERT INTO Orders (CustomerName)
    VALUES ('John Doe');

    -- Get the last inserted OrderID
    DECLARE @OrderID INT = SCOPE_IDENTITY();

    -- Insert multiple OrderItems for the order
    INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
    VALUES 
        (@OrderID, 'Laptop', 1, 80000.00),
        (@OrderID, 'Mouse', 2, 500.00),
        (@OrderID, 'Keyboard', 1, 1500.00);

    -- Commit if everything is successful
    COMMIT TRANSACTION;
    PRINT 'Transaction committed successfully.';
END TRY
BEGIN CATCH
    -- Rollback if any error occurs
    ROLLBACK TRANSACTION;

    PRINT 'Transaction failed. Error: ' + ERROR_MESSAGE();
END CATCH;
SELECT * FROM Orders;
SELECT * FROM OrderItems;
