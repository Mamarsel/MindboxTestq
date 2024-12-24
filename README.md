В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

SELECT 
    p.ProductName,
    c.CategoryName
FROM 
    Products p
LEFT JOIN 
    ProductCategories pc ON p.ProductId = pc.ProductId
LEFT JOIN 
    Categories c ON pc.CategoryId = c.CategoryId
ORDER BY 
    p.ProductName, c.CategoryName;

если у продукта нет категории, то будет отображаться имя продукта, а в имени категории будет NULL.
