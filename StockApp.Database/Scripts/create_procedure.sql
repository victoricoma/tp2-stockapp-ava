
CREATE PROCEDURE GetProfitReport();
BEGIN
    SELECT p.Name, SUM(o.Quantity * (o.Price - p.Cost)) AS TotalProfit
    FROM Orders o
    JOIN Products p ON o.ProductId = p.Id
    GROUP BY p.Name;
END 




