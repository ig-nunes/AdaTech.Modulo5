
using DadosSistema;
using DadosSistema.Models;
using DadosSistema.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi.Filters;


namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Com minimal API:

            //var builder = WebApplication.CreateBuilder(args);
            //var app = builder.Build();
            //const string url = "/imoveis";

            //var imoveis = new List<Imovel>();

            //app.MapGet($"{url}", () =>
            //{
            //    return Results.Ok(imoveis);
            //});

            //app.MapGet($"{url}/{{id}}", (string id) =>
            //{
            //    var imovel = imoveis.FirstOrDefault(x => x.Id == id);
            //    if (imovel == null)
            //    {
            //        return Results.NotFound();
            //    }
            //    return Results.Ok(imovel);
            //});

            //app.MapPost(url, (CreateImovel imovelRequest) =>
            //{
            //    if (imovelRequest == null || imovelRequest.Endereco == null || imovelRequest.Proprietario == null)
            //    {
            //        return Results.BadRequest();
            //    }
            //    var imovel = new Imovel()
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Endereco = imovelRequest.Endereco,
            //        Proprietario = imovelRequest.Proprietario
            //    };
            //    imoveis.Add(imovel);
            //    return Results.Ok(imovel);
            //});

            //app.MapPut($"{url}/{{id}}", (string id, CreateImovel imovelAtualizado) =>
            //{
            //    var imovel = imoveis.FirstOrDefault(i => i.Id == id);
            //    if (imovel == null)
            //    {
            //        return Results.NotFound();
            //    }
            //    if (imovelAtualizado == null || (string.IsNullOrEmpty(imovelAtualizado.Endereco) && string.IsNullOrEmpty(imovelAtualizado.Proprietario)))
            //    {
            //        return Results.BadRequest();
            //    }
            //    if (!string.IsNullOrEmpty(imovelAtualizado.Endereco))
            //    {
            //        imovel.Endereco = imovelAtualizado.Endereco;
            //    }
            //    if (!string.IsNullOrEmpty(imovelAtualizado.Proprietario))
            //    {
            //        imovel.Proprietario = imovelAtualizado.Proprietario;
            //    }

            //    return Results.Ok(imovel);
            //});

            //app.MapDelete($"{url}/{{id}}", (string id) =>
            //{
            //    var imovel = imoveis.FirstOrDefault(i => i.Id == id);
            //    if (imovel == null)
            //    {
            //        return Results.NotFound();
            //    }
            //    imoveis.Remove(imovel);
            //    return Results.Ok(imovel);
            //});
            //app.MapGet($"{url}", () => "This is a GET");

            //app.Run();




            // Com Controllers:

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IRepositorio<Venda>, VendasRepositorioInMemory>();
            builder.Services.AddSingleton<IRepositorio<Devolucao>, DevolucaoRepositorioInMemory>();
            builder.Services.AddSingleton<IRepositorio<Troca>, TrocaRepositorioInMemory>();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<FiltroExcecao>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Loja de Roupas API",
                        Description = "Api para atender a demanda de sistema de vendas para loja de roupas",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Example Contact",
                            Url = new Uri("https://example.com/contact")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Example License",
                            Url = new Uri("https://example.com/license")
                        }
                    });
                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
