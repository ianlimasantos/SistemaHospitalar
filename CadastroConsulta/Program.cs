using Cadastro.Infra.IoC;
using Cadastro.Infra.Data.EF.Extensions;

namespace CadastroConsulta
{
    public class Program
    {
        public static void Main(string[] args)

        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEFConfiguration(builder.Configuration.GetConnectionString("connection"));
            builder.Services.ConfigureDependencies();
            builder.Services.ConfigureApplicationServices();
            

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
