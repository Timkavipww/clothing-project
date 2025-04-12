var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(a => a.ListenAnyIP(3000));
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IClothingRepository, ClothingRepository>();
builder.Services.AddScoped<IClothingService, ClothingService>();
builder.Services.AddDbContext<ClothingDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();
await app.ApplyMigrations();
app.MapOpenApi();
app.MapControllers();
app.UseHttpsRedirection();
app.MapScalarApiReference();
app.MapGet("/", () => Results.Redirect("/scalar"));

app.UseRouting();
app.Run();
