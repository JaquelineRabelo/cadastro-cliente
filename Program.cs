var builder = WebApplication.CreateBuilder(args);

// Defina uma porta específica (ex: 5002)
builder.WebHost.UseUrls("http://localhost:5002");

// Adicione serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Adicione o suporte para controllers

var app = builder.Build();

// Configure o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Permite servir arquivos estáticos da pasta wwwroot
app.UseStaticFiles();

// Adiciona o suporte ao FileServer
app.UseFileServer();

// Configure o redirecionamento HTTPS (se necessário)
// Se não for usar HTTPS, pode comentar ou remover a linha abaixo
app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia os controllers
app.MapControllers();

// Inicia o aplicativo
app.Run();
