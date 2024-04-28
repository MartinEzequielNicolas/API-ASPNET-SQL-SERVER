using app.Models;
using app.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddDbContext<productosContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddScoped<ProductRepository>();
var app = builder.Build();


app.MapControllers();



app.Run();
