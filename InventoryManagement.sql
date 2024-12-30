-- Create the database
CREATE DATABASE InventoryManagement;
GO

-- Use the database
USE InventoryManagement;
GO

-- 1. USERS table for managing system users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Manager', 'Staff')),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

-- 2. SUPPLIERS table for managing suppliers
CREATE TABLE Suppliers (
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100) NOT NULL,
    ContactNumber NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

-- 3. PRODUCTS table for managing inventory items
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50),
    Quantity INT DEFAULT 0 CHECK (Quantity >= 0),
    UnitPrice DECIMAL(10, 2) NOT NULL CHECK (UnitPrice >= 0),
    SupplierID INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID) ON DELETE SET NULL
);

-- 4. INVENTORY_TRANSACTIONS table for managing stock changes
CREATE TABLE InventoryTransactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    TransactionType NVARCHAR(20) NOT NULL CHECK (TransactionType IN ('Purchase', 'Sale', 'Adjustment')),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    TransactionDate DATETIME DEFAULT GETDATE(),
    UserID INT,
    Notes NVARCHAR(MAX),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE SET NULL
);

-- 5. ORDERS table for customer orders
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10, 2) DEFAULT 0 CHECK (TotalAmount >= 0),
    OrderStatus NVARCHAR(20) NOT NULL CHECK (OrderStatus IN ('Pending', 'Shipped', 'Completed')),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

-- 6. ORDER_DETAILS table for managing products in each order
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(10, 2) NOT NULL CHECK (Price >= 0),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE NO ACTION
);

-- 7. Add Indexes for Performance
CREATE INDEX idx_supplier_id ON Products(SupplierID);
CREATE INDEX idx_product_id ON InventoryTransactions(ProductID);
CREATE INDEX idx_user_id ON InventoryTransactions(UserID);
CREATE INDEX idx_order_id ON OrderDetails(OrderID);
CREATE INDEX idx_product_order ON OrderDetails(ProductID);

-- Confirm creation
SELECT 'Database and Tables Created Successfully!' AS Status;
