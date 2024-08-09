using HttpPatchWithAutoMapper._Helpers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers()
        .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureServices();

//Habilita o Swagger
builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Ativa a Swagger-ui
app.UseOpenApi();
app.UseSwaggerUi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
