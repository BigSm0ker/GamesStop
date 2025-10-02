using Microsoft.EntityFrameworkCore;
using Games.Infrastructure.Data;
using Gamess.Core.Entities;

namespace Games
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configurar la BD SqlServer
            // var connectionString = builder.Configuration.GetConnectionString("ConnectionSqlServer");
            // builder.Services.AddDbContext<GamesContext>(options => options.UseSqlServer(connectionString));
            #endregion

            #region Configurar la BD MySql
            var connectionString = builder.Configuration.GetConnectionString("ConnectionMySql");
            builder.Services.AddDbContext<GamesContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            #endregion

            // Agrega los servicios al contenedor.
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            var app = builder.Build();

            // Configura el pipeline de solicitudes HTTP.
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
