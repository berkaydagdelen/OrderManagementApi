-- Sipariþ Yönetim Sistemi Database Scripts
-- Database: IbemWebMainDB

USE IbemWebMainDB;
GO

-- Products Tablosu
CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL DEFAULT 0,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME2 NULL
);
GO

-- Orders Tablosu
CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    ShippingAddress NVARCHAR(200) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    Status INT NOT NULL DEFAULT 0, -- 0: Pending, 1: Confirmed, 2: Shipped, 3: Delivered, 4: Cancelled
    OrderDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    ShippedDate DATETIME2 NULL,
    DeliveredDate DATETIME2 NULL
);
GO

-- OrderItems Tablosu
CREATE TABLE OrderItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    TotalPrice DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Orders(Id) ON DELETE CASCADE,
    CONSTRAINT FK_OrderItems_Products FOREIGN KEY (ProductId) REFERENCES Products(Id) ON DELETE RESTRICT
);
GO

-- Indexes
CREATE INDEX IX_Orders_UserId ON Orders(UserId);
CREATE INDEX IX_Orders_Status ON Orders(Status);
CREATE INDEX IX_Orders_OrderDate ON Orders(OrderDate);
CREATE INDEX IX_OrderItems_OrderId ON OrderItems(OrderId);
CREATE INDEX IX_OrderItems_ProductId ON OrderItems(ProductId);
GO

-- Sample Data
INSERT INTO Products (Name, Description, Price, StockQuantity) VALUES
('iPhone 15 Pro', 'Apple iPhone 15 Pro 128GB Titanium', 999.99, 50),
('Samsung Galaxy S24', 'Samsung Galaxy S24 Ultra 256GB', 1199.99, 30),
('MacBook Air M2', 'Apple MacBook Air 13-inch M2 Chip', 1299.99, 25),
('Dell XPS 13', 'Dell XPS 13 Laptop Intel Core i7', 1099.99, 20),
('AirPods Pro', 'Apple AirPods Pro 2nd Generation', 249.99, 100);
GO

-- Order Status Enum için View
CREATE VIEW OrderStatusEnum AS
SELECT 0 AS Id, 'Pending' AS Name
UNION ALL
SELECT 1, 'Confirmed'
UNION ALL
SELECT 2, 'Shipped'
UNION ALL
SELECT 3, 'Delivered'
UNION ALL
SELECT 4, 'Cancelled';
GO 