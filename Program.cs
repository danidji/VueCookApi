using Microsoft.EntityFrameworkCore;
using VueCookApi.Data;
using VueCookApi.Services;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;


var builder = WebApplication.CreateBuilder(args);

var keyVaultUrl = builder.Configuration["keyVaultUrl"];

if (!string.IsNullOrEmpty(keyVaultUrl))
{
    var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
     Console.WriteLine($"client {client}"); 
    KeyVaultSecret secret = client.GetSecret("DbConnectionString").Value;    

     Console.WriteLine($"Secret récupéré : {secret.Value}"); 
    builder.Configuration["ConnectionStrings:DefaultConnection"] = secret.Value;
}


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VueCookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<RecipeService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();

app.Run();