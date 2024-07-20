using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<ControleDeMateriaisContext>
    (options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DBSolicitacaoMateriais").Value));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEstoqueRepositorio, EstoqueRepositorio>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
