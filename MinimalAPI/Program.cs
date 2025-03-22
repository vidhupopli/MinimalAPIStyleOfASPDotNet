namespace MinimalAPISolution
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers(); //You need this Service for app.MapControllers() to work.

            // We want the output of Console.WriteLine()
            builder.Logging
                .AddConsole()
                .AddDebug();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // If you were doing minimal API completely, then instead of app.MapControllers(), you would be creating spec for individual routes here.
            app.MapControllers(); // Individual mapping individual method and route here, utilize controllers.
            app.Run();
        }
    }
}
