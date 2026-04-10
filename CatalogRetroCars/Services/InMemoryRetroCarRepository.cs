using CatalogRetroCars.Models;

namespace CatalogRetroCars.Services;

public class InMemoryRetroCarRepository : IRetroCarRepository
{
    private readonly List<RetroCar> _cars =
    [
        new RetroCar
        {
            Id = 1,
            Brand = "Volkswagen",
            Model = "Beetle",
            Year = 1967,
            Country = "Германия",
            HorsePower = 53,
            Description = "Един от най-разпознаваемите ретро автомобили в света."
        },
        new RetroCar
        {
            Id = 2,
            Brand = "Lada",
            Model = "2101",
            Year = 1973,
            Country = "СССР",
            HorsePower = 60,
            Description = "Популярен модел в Източна Европа, базиран на Fiat 124."
        },
        new RetroCar
        {
            Id = 3,
            Brand = "Ford",
            Model = "Mustang",
            Year = 1969,
            Country = "САЩ",
            HorsePower = 220,
            Description = "Класически американски muscle car с емблематичен дизайн."
        }
    ];

    public IReadOnlyCollection<RetroCar> GetAll() => _cars.OrderBy(c => c.Brand).ThenBy(c => c.Model).ToList();

    public RetroCar? GetById(int id) => _cars.FirstOrDefault(c => c.Id == id);

    public void Add(RetroCar car)
    {
        car.Id = _cars.Count == 0 ? 1 : _cars.Max(c => c.Id) + 1;
        _cars.Add(car);
    }

    public bool Update(RetroCar car)
    {
        var existing = GetById(car.Id);
        if (existing is null)
        {
            return false;
        }

        existing.Brand = car.Brand;
        existing.Model = car.Model;
        existing.Year = car.Year;
        existing.Country = car.Country;
        existing.HorsePower = car.HorsePower;
        existing.Description = car.Description;

        return true;
    }

    public bool Delete(int id)
    {
        var car = GetById(id);
        if (car is null)
        {
            return false;
        }

        _cars.Remove(car);
        return true;
    }
}
