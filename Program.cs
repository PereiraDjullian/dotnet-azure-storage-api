var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona suporte aos Controllers
builder.Services.AddControllers();

// 2. Configura o gerador de documentos OpenAPI/Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Adiciona o gerador do Swagger

var app = builder.Build();

// 3. Configura o Pipeline de Requisições
if (app.Environment.IsDevelopment())
{
    // Ativa o JSON do Swagger
    app.UseSwagger();
    
    // Ativa a Interface Gráfica (UI) do Swagger
    app.UseSwaggerUI(options =>
    {
        // Define o endpoint do JSON gerado
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        // Opcional: define o Swagger como página inicial (root)
        options.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();