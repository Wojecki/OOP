CREATE DATABASE FlowerMatic;
GO

USE FlowerMatic;
GO

CREATE TABLE Flowers (
    ID INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Quantity INT CHECK (Quantity <= 500),
    Price DECIMAL(18,2) NOT NULL
);

CREATE TABLE Operators (
    ID INT PRIMARY KEY,
    Login VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(50) NOT NULL
);

CREATE TABLE Deliveries (
    ID INT PRIMARY KEY,
    Operator_Id INT NOT NULL,
    data_dostawy DATETIME NOT NULL,
    FOREIGN KEY (Operator_Id) REFERENCES Operators(ID)
);

CREATE TABLE DeliveryDetails (
    Flower_ID INT NOT NULL,
    Delivery_ID INT NOT NULL,
    Quantity INT CHECK (Quantity <= 400),
    PRIMARY KEY (Flower_ID, Delivery_ID),
    FOREIGN KEY (Flower_ID) REFERENCES Flowers(ID),
    FOREIGN KEY (Delivery_ID) REFERENCES Deliveries(ID)
);

CREATE TABLE Orders (
    ID INT PRIMARY KEY,
    Order_Date DATETIME NOT NULL,
    Flower_ID INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (Flower_ID) REFERENCES Flowers(ID)
);
