using CatalogRetroCars.Models;

namespace CatalogRetroCars.Services;

public interface IRetroCarRepository
{
    IReadOnlyCollection<RetroCar> GetAll();
    RetroCar? GetById(int id);
    void Add(RetroCar car);
    bool Update(RetroCar car);
    bool Delete(int id);
}
