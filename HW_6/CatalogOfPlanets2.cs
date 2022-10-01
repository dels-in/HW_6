namespace HW_6;

public class CatalogOfPlanets2
{
    private Planet _venus;
    private Planet _earth;
    private Planet _mars;
    private List<Planet> _planetList;
    private int _count;

    public CatalogOfPlanets2()
    {
        _venus = new("Венера", 2, 38025, null);
        _earth = new("Земля", 3, 40075, _venus);
        _mars = new("Марс", 4, 21344, _earth);
        _planetList = new List<Planet>(new[] { _venus, _earth, _mars });
    }

    public (int? id, int? length, string? error) GetPlanet2(string name, PlanetValidatorDelegate validator)
    {
        if (validator(name) == null)
        {
            foreach (var planet in _planetList)
            {
                if (name.ToLower() == planet.Name.ToLower())
                {
                    Console.WriteLine($"Название планеты: {planet.Name}\n" +
                                      $"Порядковый номер: {planet.Id}, \n" +
                                      $"Длина экватора: {planet.Length}");
                    return (id: planet.Id, length: planet.Length, error: null);
                }
            }

            return (id: null, length: null, error: "Планету найти не удалось");
        }

        return (id: null, length: null, error: validator(name));
    }

    public delegate string? PlanetValidatorDelegate(string name);
}