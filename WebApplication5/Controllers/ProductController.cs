using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;

    public ProductController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var ProductsList = _db.Products.ToList();
        return View(ProductsList);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
            _db.Products.Add(product);
            _db.SaveChanges();
            var products = _db.Products.ToList();
            return PartialView("Index", products);
    }


    public IActionResult Edit(int? id)
    {
        var product = _db.Products.FirstOrDefault(u => u.Id == id);
        return View(product);
    }
[HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _db.Products.FirstOrDefault(u => u.Id == id);
        _db.Products.Remove(product);
        _db.SaveChanges();
        var products = _db.Products.ToList();
        return RedirectToAction("Index");
    }

    
    [HttpPost]
    public IActionResult Edit(Product product)
    {
       
        
            _db.Products.Update(product);
            _db.SaveChanges();
            var products = _db.Products.ToList();
            return PartialView("Index",products);
        
       
    }

    public IActionResult Details(int? id)
    {
        var product = _db.Products.FirstOrDefault(u => u.Id == id);
        return View(product);
    }





    [HttpPost]
    public IActionResult Clear()
    {

        _db.Products.ExecuteDelete();

        return RedirectToAction("Index");
    }
}