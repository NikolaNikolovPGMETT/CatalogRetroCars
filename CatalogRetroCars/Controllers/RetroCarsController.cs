using Microsoft.AspNetCore.Mvc;
using CatalogRetroCars.Models;
using CatalogRetroCars.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogRetroCars.Controllers;

public class RetroCarsController : Controller
{
    private readonly IRetroCarRepository _repository;

    public RetroCarsController(IRetroCarRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var cars = _repository.GetAll();
        return View(cars);
    }

    public IActionResult Details(int id)
    {
        var car = _repository.GetById(id);
        if (car is null)
        {
            return NotFound();
        }

        return View(car);
    }

    public IActionResult Create()
    {
        return View(new RetroCar());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RetroCar car)
    {
        if (!ModelState.IsValid)
        {
            return View(car);
        }

        _repository.Add(car);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var car = _repository.GetById(id);
        if (car is null)
        {
            return NotFound();
        }

        return View(car);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, RetroCar car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(car);
        }

        var updated = _repository.Update(car);
        if (!updated)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var car = _repository.GetById(id);
        if (car is null)
        {
            return NotFound();
        }

        return View(car);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
