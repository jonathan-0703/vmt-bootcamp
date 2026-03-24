DECLARE @PAGE_NUMBER INT = 1
DECLARE @ROWS_PER_PAGE INT =3

SELECT *   FROM SalesLT.ProductCategory
ORDER BY NAME DESC
OFFSET (@PAGE_NUMBER -1) * @ROWS_PER_PAGE ROWS
FETCH NEXT @ROWS_PER_PAGE ROWS ONLY 

SELECT *FROM SalesLT.ProductCategory
ORDER BY NAME DESC


SELECT * FROM SalesLT.Customer
WHERE FirstName LIKE '%R%'


SELECT * FROM SalesLT.Customer
WHERE FirstName= 'Robert'


SELECT FirstName, LastName FROM SalesLT.Customer
WHERE ModifiedDate between '2005-08-01'AND '2007-07-01'



SELECT COUNT(*) as TOTAL_CUSTOMER FROM SalesLT.Customer

SELECT SUM(TotalDue) AS total_ventas FROM SalesLT.SalesOrderHeader


SELECT ProductCategoryID as Category_id, COUNT(ProductCategoryID) FROM SalesLT.Product
GROUP BY ProductCategoryID
ORDER BY ProductCategoryID DESC


SELECT * FROM SalesLT.Product p
INNER JOIN SalesLT.ProductCategory pc
	on p.ProductCategoryID =pc.ProductCategoryID


SELECT soh.SalesOrderID as sales_order_id ,c.FirstName as customer_first_name FROM SalesLT.SalesOrderHeader soh
INNER JOIN SalesLT.Customer c
	ON C.CustomerID= soh.CustomerID



--Ejercicios
--1.
SELECT COUNT(CustomerID) as TOTAL_CLIENTE  FROM SalesLT.Customer

--2.
DECLARE @fechaVentas DATE = '2008-06-01'

SELECT SUM(TotalDue) as Total_de_ventas FROM SalesLT.SalesOrderHeader
WHERE OrderDate = @fechaVentas

--3.

SELECT TOP 5 ProductCategoryID AS ID ,Name AS Nombre_Categoria FROM SalesLT.ProductCategory
ORDER BY Name ASC

--4. 
DECLARE @PAGE_NUMBER_FACTURA INT = 20
DECLARE @ROWS_PER_PAGE_FACTURA INT =50

SELECT DISTINCT pro.Name as NombreProducto,Ord.SalesOrderNumber AS NumeroOrden ,det.UnitPrice AS PrecioUnitario FROM SalesLT.SalesOrderDetail Det
INNER JOIN SalesLT.SalesOrderHeader Ord ON Det.SalesOrderID = Ord.SalesOrderID
LEFT JOIN SalesLT.Product pro ON Det.ProductID = pro.ProductID
ORDER BY NAME DESC
OFFSET @PAGE_NUMBER_FACTURA ROWS
FETCH NEXT @ROWS_PER_PAGE_FACTURA ROWS ONLY 

