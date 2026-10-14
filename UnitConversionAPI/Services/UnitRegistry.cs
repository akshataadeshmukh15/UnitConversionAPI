using UnitConversionAPI.Models;

namespace UnitConversionApi.Services;

public sealed class UnitRegistry
{
    private readonly Dictionary<string, UnitDefinition> _units;

    public UnitRegistry()
    {
        var units = new[]
        {
            // Length: base unit = meter
            new UnitDefinition("Meter", "Length", 1),
            new UnitDefinition("Kilometer", "Length", 1000),
            new UnitDefinition("Centimeter", "Length", 0.01),
            new UnitDefinition("Millimeter", "Length", 0.001),
            new UnitDefinition("Mile", "Length", 1609.344),
            new UnitDefinition("Foot", "Length", 0.3048),
            new UnitDefinition("Inch", "Length", 0.0254),
            new UnitDefinition("Yard", "Length", 0.9144),

            // Temperature: base unit = Celsius
            new UnitDefinition("Celsius", "Temperature", 1),
            new UnitDefinition("Fahrenheit", "Temperature",
                5.0 / 9.0, -32.0 * 5.0 / 9.0),
            new UnitDefinition("Kelvin", "Temperature", 1, -273.15),

            // Mass: base unit = kilogram
            new UnitDefinition("Kilogram", "Mass", 1),
            new UnitDefinition("Gram", "Mass", 0.001),
            new UnitDefinition("Milligram", "Mass", 0.000001),
            new UnitDefinition("MetricTon", "Mass", 1000),
            new UnitDefinition("Pound", "Mass", 0.45359237),
            new UnitDefinition("Ounce", "Mass", 0.028349523125),

            // Time: base unit = second
            new UnitDefinition("Second", "Time", 1),
            new UnitDefinition("Millisecond", "Time", 0.001),
            new UnitDefinition("Minute", "Time", 60),
            new UnitDefinition("Hour", "Time", 3600),
            new UnitDefinition("Day", "Time", 86400)
        };

        _units = units.ToDictionary(
            unit => unit.Name,
            StringComparer.OrdinalIgnoreCase);
    }

    public bool TryGetUnit(
        string name,
        out UnitDefinition unit)
    {
        return _units.TryGetValue(name, out unit!);
    }

    public IReadOnlyCollection<UnitDefinition> GetAllUnits()
    {
        return _units.Values.ToArray();
    }
}