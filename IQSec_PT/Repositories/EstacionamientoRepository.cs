using Dapper;
using IQSec_PT.DBContext;
using static IQSec_PT.Repositories.VehiculoRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using IQSec_PT.Models;

namespace IQSec_PT.Repositories
{
 

        public class EstacionamientoRepository : IEstacionamientoRepository
    {
            private readonly DapperContext context;

            public EstacionamientoRepository(DapperContext context)
            {
                this.context = context;
            }

            public async Task Entrada(string placas)
            {
                var query = "INSERT INTO estacionamiento (placas, entrada) VALUES(@placas, @entrada)";

                var parameters = new DynamicParameters();
                parameters.Add("placas", placas, DbType.String);
                parameters.Add("entrada", DateTime.Now, DbType.DateTime);


                using (var connection = context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
        }

            public async Task Salida(int estacionamientoID)
            {
                var query = "UPDATE estacionamiento SET salida = @salida WHERE estacionamientoID = @estacionamientoID";

            var parameters = new DynamicParameters();
            parameters.Add("estacionamientoID", estacionamientoID, DbType.Int32);

            parameters.Add("salida", DateTime.Now, DbType.DateTime);
            
            using (var connection = context.CreateConnection())
                {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        public async Task<IEnumerable<Estacionamiento>> Registros()
        {
            var query = "SELECT * FROM estacionamiento";

            using (var connection = context.CreateConnection())
            {
                var estacionamientos = await connection.QueryAsync<Estacionamiento>(query);
                return estacionamientos.ToList();
            }
        }

        public async Task<Estacionamiento> Registro(int estacionamientoID)
        {
            var query = "SELECT * FROM estacionamiento WHERE estacionamientoID = @estacionamientoID";
            var parameters = new DynamicParameters();
            parameters.Add("estacionamientoID", estacionamientoID, DbType.Int32);

            using (var connection = context.CreateConnection())
            {
                var estacionamiento = await connection.QuerySingleOrDefaultAsync<Estacionamiento>(query,parameters);
                return estacionamiento;
            }
        }

    }
    
}
