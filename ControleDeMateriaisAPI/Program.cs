using ControleDeMateriaisAPI.Data;
using ControleDeMateriaisAPI.Interfaces;
using ControleDeMateriaisAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ControleDeMateriaisContext>
    (options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DBSolicitacaoMateriais").Value));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEstoqueRepositorio, EstoqueRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IServicoRepositorio, ServicoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
{
    app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

