INSERT INTO Flowers (ID, Name, Quantity, Price) VALUES
(1, 'Róża czerwona', 15, 6.50),
(2, 'Tuliban', 10, 3.80),
(3, 'Goździk', 12, 2.90),
(4, 'Żonkil', 8, 4.20),
(5, 'Narcyz', 7, 4.80),
(6, 'Krokus', 5, 2.50),
(7, 'Bukiet duży róża', 5, 45.00),
(8, 'Bukiet mały róża', 3, 25.00),
(9, 'Bukiet duży MIX', 5, 55.00),
(10, 'Bukiet mały MIX', 2, 30.00);

INSERT INTO Operators (ID, Login, Password) VALUES
(1, 'wnycz', 'Qwerty123'),
(2, 'ekanie', 'Asdfgh123');

INSERT INTO Deliveries (ID, Operator_Id, data_dostawy) VALUES
(1, 1, '2025-02-01'),
(2, 2, '2025-02-05');

INSERT INTO DeliveryDetails (Flower_ID, Delivery_ID, Quantity) VALUES
(1, 1, 10),
(2, 1, 8),
(3, 2, 5),
(4, 2, 4);

INSERT INTO Orders (ID, Order_Date, Flower_ID, Price) VALUES
(1, '2025-02-10', 1, 6.50),
(2, '2025-02-11', 7, 45.00),
(3, '2025-02-12', 8, 25.00),
(4, '2025-02-13', 9, 55.00);