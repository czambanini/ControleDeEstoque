
using Application.Filters;
using ControleDeEstoque.Services;
using Domain.Repositories;
using Domain.Requests;
using Infraestructure;
using Infraestructure.Repository;
using Services;
using Services.Interfaces;

namespace ControleDeEstoqueAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<FiltroExcecao>();
            });


            builder.Services.AddSingleton<ControladorDeEstoqueContext>();
            builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddSingleton<ILoteRepository, LoteRepository>();
            builder.Services.AddSingleton<IEntradaService, EntradaService>();
            builder.Services.AddSingleton<IRetiradaService, RetiradaService>();
            builder.Services.AddSingleton<IDescartarVencidos, DescartarVencidos>();

            //teste para usar logger no código do domain
            builder.Services.AddLogging(builder => { builder.AddConsole(); });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var descartarVencidosService = app.Services.GetRequiredService<IDescartarVencidos>();
            descartarVencidosService.DescartarVencidosAsync();

            app.MapControllers();

            app.Run();
        }
    }
}
