using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_Learning_1.Models;

namespace ASP_Learning_1.Controllers;

[ApiController]
[Route("[controller]")]
public class TableController : Controller
{
    private readonly ILogger<TableController> _logger;
    private static int _maxId = 0;
    private static readonly List<Product> _products = new()
        {
            new Product() { Id = 1, Title = "книга", Description = "Война и Мир", Price = 500, Quantity = 2 },
            new Product() { Id = 2, Title = "журнал", Description = "Мурзилка", Price = 300, Quantity = 5 },
            new Product() { Id = 3, Title = "газета", Description = "Известия", Price = 50, Quantity = 25 },
        };
    
    public TableController(ILogger<TableController> logger)
    {
        _maxId = _maxId != 0? _maxId : _products.Select(product => product.Id).Prepend(0).Max();
        _logger = logger;
    }

    public IActionResult Table()
    {
        var model = new IndexModel
        {
            Products = _products,
        };
        return View(model);
    }
    
    [HttpPost("create-product")]
    public IActionResult CreateProduct([FromForm] Product newProduct)
    {
        newProduct.Id = ++_maxId;
        _products.Add(newProduct);
        return RedirectToAction("Table", "Table");
    }
    
    [HttpGet("update-product/{id}")]
    public IActionResult UpdateProduct([FromRoute] int id)
    {
        foreach (var model in _products.Where(model => model.Id == id))
        {
            return View(model);
        }

        return RedirectToAction("Table", "Table");
    }
    
    [HttpPost("update")]
    public IActionResult Update([FromForm]Product product)
    {
        for (var i = 0; i < _products.Count; i++)
        {
            if (_products[i].Id == product.Id)
            {
                _products[i] = product;
                break;
            }
        }

        return RedirectToAction("Table", "Table");
    }
    
    [HttpGet("delete/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        foreach (var product in _products.Where(product => product.Id == id))
        {
            _products.Remove(product);
            break;
        }

        return RedirectToAction("Table", "Table");
    }
    
}