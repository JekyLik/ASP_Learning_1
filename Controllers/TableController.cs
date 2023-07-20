using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_Learning_1.Models;

namespace ASP_Learning_1.Controllers;

[ApiController]
[Route("[controller]")]

public class TableController : Controller
{
    private static readonly Random Random = new ();
    private readonly Product[] _model = CreateListOfProducts();
    
    private readonly ILogger<TableController> _logger;

    public TableController(ILogger<TableController> logger)
    {
        _logger = logger;
    }

    private static Product[] CreateListOfProducts()
    {
        Product[] products = new[]
        {
            new Product("книга", "Война и Мир", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Мастер и Маргарита", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Анна Каренина", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Преступление и наказание", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Доктор Живаго", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Бесы", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Тихий Дон", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Мёртвые души", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Отцы и дети", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("книга", "Собачье сердце", Random.Next(100, 600), Random.Next(1, 10)),
            new Product("журнал", "Красота и здоровье", Random.Next(50, 300), Random.Next(1, 10)),
            new Product("журнал", "За рулем", Random.Next(50, 300), Random.Next(1, 10)),
            new Product("журнал", "Мурзилка", Random.Next(50, 300), Random.Next(1, 10)),
            new Product("журнал", "Вокруг света", Random.Next(50, 300), Random.Next(1, 10)),
            new Product("журнал", "Огонек", Random.Next(50, 300), Random.Next(1, 10)),
            new Product("газета", "Известия", Random.Next(50, 300), Random.Next(1, 10)),
            new Product("газета", "Комсомольская правда", Random.Next(10, 100), Random.Next(1, 10)),
            new Product("газета", "Российская газета", Random.Next(10, 100), Random.Next(1, 10)),
            new Product("газета", "Московский комсомолец", Random.Next(10, 100), Random.Next(1, 10)),
            new Product("газета", "Аргументы и Факты", Random.Next(10, 100), Random.Next(1, 10))
        };
        
        SwapElements(products);
        return products;
    }

    private static void SwapElements(Product[] books)
    {
        for (var i = 0; i < books.Length; i++)
        {
            var j = Random.Next(i + 1);
            (books[i], books[j]) = (books[j], books[i]);
        }
    }

    public IActionResult Table()
    {
        return View(_model);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}