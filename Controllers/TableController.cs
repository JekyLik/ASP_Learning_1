using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_Learning_1.Models;

namespace ASP_Learning_1.Controllers;

[ApiController]
[Route("[controller]")]
public class TableController : Controller
{
    private readonly ILogger<TableController> _logger;
    private static readonly List<Product> _products = new()
        {
            new Product() { Title = "книга", Description = "Война и Мир", Price = 500, Quantity = 2 },
            new Product() { Title = "журнал", Description = "Мурзилка", Price = 300, Quantity = 5 },
            new Product() { Title = "газета", Description = "Известия", Price = 50, Quantity = 25 },
            //new Product("книга", "Мастер и Маргарита", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("книга", "Анна Каренина", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("книга", "Преступление и наказание", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("книга", "Доктор Живаго", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("книга", "Бесы", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("книга", "Тихий Дон", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("книга", "Мёртвые души", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("книга", "Отцы и дети", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("книга", "Собачье сердце", Random.Next(100, 600), Random.Next(1, 10)),
            //new Product("журнал", "Красота и здоровье", Random.Next(50, 300), Random.Next(1, 10)),
            //new Product("журнал", "За рулем", Random.Next(50, 300), Random.Next(1, 10)),
            //new Product("журнал", "Мурзилка", Random.Next(50, 300), Random.Next(1, 10)),
            //new Product("журнал", "Вокруг света", Random.Next(50, 300), Random.Next(1, 10)),
            //new Product("журнал", "Огонек", Random.Next(50, 300), Random.Next(1, 10)),
            //new Product("газета", "Известия", Random.Next(50, 300), Random.Next(1, 10)),
            //new Product("газета", "Комсомольская правда", Random.Next(10, 100), Random.Next(1, 10)),
            //new Product("газета", "Российская газета", Random.Next(10, 100), Random.Next(1, 10)),
            //new Product("газета", "Московский комсомолец", Random.Next(10, 100), Random.Next(1, 10)),
            //new Product("газета", "Аргументы и Факты", Random.Next(10, 100), Random.Next(1, 10))
        };
        
    public TableController(ILogger<TableController> logger)
    {
        _logger = logger;
    }

    public IActionResult Table()
    {
        var model = new IndexModel
        {
            Products = _products
        };
        return View(model);
    }

    [HttpPost("create-product")]
    public IActionResult CreateProduct([FromForm] Product newProduct)
    {
        _products.Add(newProduct);
        return RedirectToAction("Table", "Table");
    }
}