Use EventDb;
-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    City VARCHAR(50),
    State VARCHAR(50)
);

-- Create Products table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    ListPrice DECIMAL(10,2) NOT NULL,
    ModelYear INT NOT NULL,
    CategoryID INT
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Insert sample data into Customers
INSERT INTO Customers (CustomerID, FirstName, LastName, City, State) VALUES
(1, 'Alice', 'Anderson', 'New York', 'NY'),
(2, 'Bob', 'Brown', 'Los Angeles', 'CA'),
(3, 'Charlie', 'Clark', 'Chicago', 'IL'),
(4, 'David', 'Carter', 'Houston', 'TX'),
(5, 'Eve', 'Davis', 'Phoenix', 'AZ');

-- Insert sample data into Products
INSERT INTO Products (ProductID, ProductName, ListPrice, ModelYear, CategoryID) VALUES
(101, 'Laptop', 3200.00, 2018, 1),
(102, 'Smartphone', 299.99, 2019, 1),
(103, 'Tablet', 489.99, 2020, 2),
(104, 'Monitor', 1500.00, 2018, 2),
(105, 'Desktop', 4500.00, 2017, 3),
(106, 'Smartwatch', 466.99, 2018, 3),
(107, 'Keyboard', 1899.00, 2021, 3),
(108, 'Mouse', 1999.99, 2022, 3),
(109, 'Printer', 250.00, 2023, 4);

-- Insert sample data into Orders
INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(201, 1, '2022-01-15'),
(202, 2, '2022-05-10'),
(203, 1, '2023-03-22'),
(204, 3, '2023-07-18'),
(205, 4, '2024-01-01'),
(206, 5, '2024-06-10');

-- 1. Customer list by first name in descending order
SELECT * 
FROM Customers 
ORDER BY FirstName DESC;

-- 2. First name, last name, and city of customers, sorted by city then first name
SELECT FirstName, LastName, City 
FROM Customers 
ORDER BY City, FirstName;

-- 3. Top 3 most expensive products
SELECT TOP 3 * 
FROM Products 
ORDER BY ListPrice DESC;

-- 4. Products with list price > 300 and model year = 2018
SELECT * 
FROM Products 
WHERE ListPrice > 300 AND ModelYear = 2018;

-- 5. Products with list price > 3000 or model year = 2018
SELECT * 
FROM Products 
WHERE ListPrice > 3000 OR ModelYear = 2018;

-- 6. Products with list price between 1899 and 1999.99
SELECT * 
FROM Products 
WHERE ListPrice BETWEEN 1899 AND 1999.99;

-- 7. Products with list price 299.99 or 466.99 or 489.99
SELECT * 
FROM Products 
WHERE ListPrice IN (299.99, 466.99, 489.99);

-- 8. Customers with last name starting from A to C
SELECT * 
FROM Customers 
WHERE LastName LIKE '[A-C]%';

-- 9. Customers whose first name does not start with A
SELECT * 
FROM Customers 
WHERE FirstName NOT LIKE 'A%';

-- 10. Number of customers grouped by state and city
SELECT State, City, COUNT(*) AS CustomerCount 
FROM Customers 
GROUP BY State, City;

-- 11. Number of orders placed grouped by customer ID and year
SELECT CustomerID, YEAR(OrderDate) AS OrderYear, COUNT(*) AS OrderCount 
FROM Orders 
GROUP BY CustomerID, YEAR(OrderDate);

-- 12. Max and min list price by category, filter max > 4000 or min < 500
SELECT CategoryID, MAX(ListPrice) AS MaxPrice, MIN(ListPrice) AS MinPrice 
FROM Products 
GROUP BY CategoryID 
HAVING MAX(ListPrice) > 4000 OR MIN(ListPrice) < 500;
