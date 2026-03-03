using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.Middleware;
using PokemonApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PokemonDbContext>(options => options.UseSqlite("Data Source=Pokemon.db"));
builder.Services.AddScoped<PokemonService>();
builder.Services.AddScoped<OwnerService>();
builder.Services.AddScoped<AttackService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<CountyService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Convert enums to strings instead of numbers
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter()
        );
        
        // Handle circular references
        options.JsonSerializerOptions.ReferenceHandler = 
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Angular port
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PokemonDbContext>();
    var pokemonService = scope.ServiceProvider.GetRequiredService<PokemonService>();
    var ownerService = scope.ServiceProvider.GetRequiredService<OwnerService>();
    context.Database.EnsureCreated();
    DbSeed.SeedDb(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.Run();
