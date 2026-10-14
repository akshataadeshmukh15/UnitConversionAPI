using UnitConversionApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registry is read-only after initialization.
// Singleton avoids rebuilding the unit dictionary per request.
builder.Services.AddSingleton<UnitRegistry>();
builder.Services.AddSingleton<ConversionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Convert one unit to another.
app.MapPost("/api/v1/conversions",
    (ConversionRequest request,
     ConversionService service) =>
    {
        try
        {
            var result = service.Convert(
                request.Value,
                request.FromUnit,
                request.ToUnit);

            return Results.Ok(result);
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(new
            {
                error = ex.Message
            });
        }
    });

// Retrieve all supported units, optionally by category.
app.MapGet("/api/v1/units",
    (string? category, UnitRegistry registry) =>
    {
        var units = registry.GetAllUnits();

        if (!string.IsNullOrWhiteSpace(category))
        {
            units = units
                .Where(u => string.Equals(
                    u.Category,
                    category,
                    StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        return Results.Ok(units);
    });

app.Run();

public sealed record ConversionRequest(
    double Value,
    string FromUnit,
    string ToUnit);