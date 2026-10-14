
namespace UnitConversionApi.Services;

public sealed class ConversionService
{
    private readonly UnitRegistry _registry;

    public ConversionService(UnitRegistry registry)
    {
        _registry = registry;
    }

    public ConversionResult Convert(
        double value,
        string fromUnit,
        string toUnit)
    {
        if (!double.IsFinite(value))
        {
            throw new ArgumentException(
                "Value must be a finite number.");
        }

        if (!_registry.TryGetUnit(fromUnit, out var source))
        {
            throw new ArgumentException(
                $"Unknown source unit: {fromUnit}");
        }

        if (!_registry.TryGetUnit(toUnit, out var target))
        {
            throw new ArgumentException(
                $"Unknown target unit: {toUnit}");
        }

        if (!string.Equals(
            source.Category,
            target.Category,
            StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException(
                "Source and target units must belong " +
                "to the same category.");
        }

        // Convert the source value into the base unit.
        var baseValue = value * source.Factor
                        + source.Offset;

        // Convert the base value into the target unit.
        var result = (baseValue - target.Offset)
                     / target.Factor;

        if (!double.IsFinite(result))
        {
            throw new ArgumentException(
                "The converted value is outside the supported range.");
        }

        return new ConversionResult(
            value,
            source.Name,
            target.Name,
            result,
            source.Category);
    }
}

public sealed record ConversionResult(
    double OriginalValue,
    string FromUnit,
    string ToUnit,
    double ConvertedValue,
    string Category);
