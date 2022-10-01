namespace HW_6;

public class Planet
{
    public Planet(string name, int id, int length, object prevPlanet)
    {
        Name = name;
        Id = id;
        Length = length;
        PrevPlanet = prevPlanet;
    }

    public string Name { get; }
    public int Id { get; }
    public int Length { get; }
    public object PrevPlanet { get; }
}