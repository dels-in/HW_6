namespace HW_6;

public class CatalogOfPlanets
{
        private Planet _venus;
        private Planet _earth;
        private Planet _mars;
        private List<Planet> _planetList;
        private int _count;

        public CatalogOfPlanets()
        {
                _venus = new("Венера", 2, 38025, null);
                _earth = new("Земля", 3, 40075, _venus);
                _mars = new("Марс", 4, 21344, _earth);
                _planetList = new List<Planet>(new []{_venus, _earth, _mars});
        }

        //лично для меня было бы проще не кортежем эту задачу решить, а использовать void метод,
        //потому что читаемого варианта я не смог найти  
        public (int? id, int? length, string? error) GetPlanet(string name)
        {
                _count++;
                if (_count % 3 == 0)
                {
                        return (id: null, length: null, error:"Вы спрашиваете слишком часто");
                }

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
}

