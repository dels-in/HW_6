//Задание 1

using HW_6;

var Venus = new
{
    Name = "Venus",
    Id = 2,
    Length = 38025,
    PrevPlanet = (object)null
};

var Earth = new
{
    Name = "Earth",
    Id = 3,
    Length = 40075,
    PrevPlanet = (object)Venus
};

var Mars = new
{
    Name = "Mars",
    Id = 4,
    Length = 21344,
    PrevPlanet = (object)Earth
};

var Venus2 = new
{
    Name = "Venus",
    Id = 2,
    Length = 38025,
    PrevPlanet = (object)Mars
};

Console.WriteLine("Сравниваем Землю и Венеру | " + Earth.Equals(Venus)); //false
Console.WriteLine("Сравниваем Марс и Венеру | " + Mars.Equals(Venus)); //false
Console.WriteLine("Сравниваем Венеру и Венеру | " + Venus2.Equals(Venus)); //тоже false, тк разные свойства 

//Задание 2
Console.WriteLine(new string('-', Console.WindowWidth));
var catalog = new CatalogOfPlanets();
Console.WriteLine(catalog.GetPlanet("Земля"));
Console.WriteLine(catalog.GetPlanet("Лимония"));
Console.WriteLine(catalog.GetPlanet("Марс"));
// var earth = catalog.GetPlanet("Земля");
// Console.WriteLine($"Название планеты: {earth.name}" +
//                   $"Порядковый номер: {earth.id}, " +
//                   $"Длина экватора: {earth.length}");
// var limonia = catalog.GetPlanet("Лимония");
// Console.WriteLine($"Название планеты: {limonia.name}" +
//                   $"Порядковый номер: {limonia.id}, " +
//                   $"Длина экватора: {limonia.length}");
// var mars = catalog.GetPlanet("Марс");
// Console.WriteLine($"Название планеты: {mars.name}" +
//                   $"Порядковый номер: {mars.id}, " +
//                   $"Длина экватора: {mars.length}");

// Задание 3
//перестало выдавать ошибку при вызове Console.WriteLine(catalog2.GetPlanet2("Земля",  validator: PlanetValidator));
//только когда перенес метод в этот класс, даже если я его делал публичным. Не совсем понятно, почему
// var counts = new int[4];
var counts = new int[4];
for (var i = 0; i< counts.Length; i++)
{
    counts[i] = 0;
}

string? PlanetValidator(string name)
{
    switch (name)
    {
        case "Венера":
            counts[0]++;
            break;
        case "Земля":
            counts[1]++;
            break;
        case "Марс":
            counts[2]++;
            break;
        default:
            counts[3]++;
            break;
    }

    //придумывал костыли с x.counts, чтобы оставить функцию статической и думал, что именно в этом дело
    //но, видимо, дело в том, что я по логике использовал цикл foreach как for:
    // foreach (int i in x.counts)
    // {
    //     if (x.counts[i] / 3 == 1)
    //         return "Вы спрашиваете слишком часто";
    // }
    //ну это же выглядит, как белеберда)). Слава Богу я это понял (я уже почти отчаялся)
    for (var i = 0; i < counts.Length; i++)
    {
        //не знаю, как проверить вот эту делимость, при условии что 0%3=0,
        //то есть если одно из всех значений x.counts равно нулю, а на начальных парах так и происходит,
        //то в скобочках if всегда true. Есть идея создать массив со большим количеством натуральных чисел
        //и сравнивать результат деления с каждым элементом массива, но это тяжело для памяти ПК
        //PS так тоже пробовал if (x.counts[i] % 3 == 0 && x.counts[i]!=0)
        if (counts[i] / 3 == 1)
            return "Вы спрашиваете слишком часто";
    }

    return null;
}

var catalog2 = new CatalogOfPlanets2();
Console.WriteLine(new string('-', Console.WindowWidth));
Console.WriteLine(catalog2.GetPlanet2("Земля", PlanetValidator));
Console.WriteLine(catalog2.GetPlanet2("Лимония", PlanetValidator));
Console.WriteLine(catalog2.GetPlanet2("Марс", PlanetValidator));
Console.WriteLine(catalog2.GetPlanet2("Земля", PlanetValidator));
Console.WriteLine(catalog2.GetPlanet2("Земля", PlanetValidator));

//лямбды
for (var i = 0; i< counts.Length; i++)
{
    counts[i] = 0;
}

//довольно громоздко, на самом деле, выходит с моей реализацией функции 
var catalog3 = new CatalogOfPlanets2();
Console.WriteLine(new string('-', Console.WindowWidth));
Console.WriteLine(catalog3.GetPlanet2("Земля", name =>
{
    switch (name)
    {
        case "Венера":
            counts[0]++;
            break;
        case "Земля":
            counts[1]++;
            break;
        case "Марс":
            counts[2]++;
            break;
        // вроде так просили сделать в задании со звездочкой, но по сложности оказалось не "звездочной",
        // если я правильно понял задание
        case "Лимония":
            return "Это запретная планета";
        default:
            counts[3]++;
            break;
    }

    foreach (var i in counts)
    {
        if (i / 3 == 1)
            return "Вы спрашиваете слишком часто";
    }

    return null;
}));
Console.WriteLine(catalog3.GetPlanet2("Лимония", name =>
{
    switch (name)
    {
        case "Венера":
            counts[0]++;
            break;
        case "Земля":
            counts[1]++;
            break;
        case "Марс":
            counts[2]++;
            break;
        case "Лимония":
            return "Это запретная планета";
        default:
            counts[3]++;
            break;
    }

    foreach (var i in counts)
    {
        if (i / 3 == 1)
            return "Вы спрашиваете слишком часто";
    }

    return null;
}));
Console.WriteLine(catalog3.GetPlanet2("Марс", name =>
{
    switch (name)
    {
        case "Венера":
            counts[0]++;
            break;
        case "Земля":
            counts[1]++;
            break;
        case "Марс":
            counts[2]++;
            break;
        case "Лимония":
            return "Это запретная планета";
        default:
            counts[3]++;
            break;
    }

    foreach (var i in counts)
    {
        if (i / 3 == 1)
            return "Вы спрашиваете слишком часто";
    }

    return null;
}));