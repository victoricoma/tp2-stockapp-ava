-- Script para criar a tabela Products
CREATE TABLE Products (
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
    Cost DECIMAL(10, 2) -- Custo unitário do produto
);

-- Exemplo de inserção de dados na tabela Products (opcional)
INSERT INTO Products (Id, Name, Cost) VALUES
(1, 'Product A', 10.00),
(2, 'Product B', 15.50),
(3, 'Product C', 20.00);

-- Script para criar a tabela Orders
CREATE TABLE Orders (
    Id INT PRIMARY KEY,
    ProductId INT,
    Quantity INT,
    Price DECIMAL(10, 2), -- Preço de venda unitário do produto
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- Exemplo de inserção de dados na tabela Orders (opcional)
INSERT INTO Orders (Id, ProductId, Quantity, Price) VALUES
(1, 1, 5, 25.00),    -- Pedido de 5 unidades de Product A vendidas a $25 cada
(2, 2, 3, 40.00),    -- Pedido de 3 unidades de Product B vendidas a $40 cada
(3, 1, 2, 30.00),    -- Pedido de 2 unidades de Product A vendidas a $30 cada
(4, 3, 4, 50.00);    -- Pedido de 4 unidades de Product C vendidas a $50 cada
