using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/calculate", ([FromBody] GearData data) =>
{
    if (data.Gear1 == 0 || data.Gear2 == 0)
        return Results.BadRequest(new { error = "Ratio cannot be zero" });

    if (data.FinalDrive == 0)
        return Results.BadRequest(new { error = "Missing required parameter" });

    // Dummy calculation for the prototype
    double drop = (data.Gear1 - data.Gear2) * 1000;
    return Results.Ok(new { rpmFalloff = new[] { drop } });
});

app.Run("http://localhost:5000");

public class GearData
{
    public double Gear1 { get; set; }
    public double Gear2 { get; set; }
    public double FinalDrive { get; set; }
}