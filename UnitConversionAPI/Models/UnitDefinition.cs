namespace UnitConversionAPI.Models
{
    public sealed record UnitDefinition(
    string Name,
    string Category,
    double Factor,
    double Offset = 0
);
}
