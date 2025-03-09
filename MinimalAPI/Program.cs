namespace MinimalAPISolution
{
class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection(); //Middleware: If HTTP port request has been recd, redirect to HTTPS port.

        app.MapGet("/shirts", () => {
            return "Returning all the shirts";
        });

        app.MapGet("/shirts/{ShirtId}", (int ShirtId) => {
            return $"Returning this shirt: {ShirtId}";
        });

        app.MapPost("/shirts", (Shirt shirt) => {
            return Results.Json(shirt);
        });

        app.MapPut("/shirts/{ShirtId}", (int ShirtId) =>
        {
            return $"Updating this shirt: {ShirtId}";
        });

        app.MapDelete("/shirts/{ShirtId}", (int ShirtId) =>
        {
            return $"Deleting this shirt: {ShirtId}";
        });

        app.Run();
    }
}

    record Shirt
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public char Size { get; set; }
    }
}
