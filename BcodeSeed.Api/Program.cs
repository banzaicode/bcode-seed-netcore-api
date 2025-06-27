var builder = WebApplication.CreateBuilder(args);

var urls = builder.Configuration["Urls"] ?? builder.Configuration["URLS"];
if (!string.IsNullOrWhiteSpace(urls))
{
    builder.WebHost.UseUrls(urls);
}
else if (builder.Configuration.GetValue<int?>("PORT") is { } port)
{
    builder.WebHost.UseUrls($"http://*:{port}");
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var hasHttps = urls?.Split(';', StringSplitOptions.RemoveEmptyEntries)
                   .Any(u => u.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) ?? false;
if (hasHttps)
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Map("/error", () => Results.Problem())
   .ExcludeFromDescription();

app.Run();

public partial class Program { }
