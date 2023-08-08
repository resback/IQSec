using Dapper;
using IQSec_PT.DBContext;
using static IQSec_PT.Repositories.VehiculoRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using IQSec_PT.Models;

namespace IQSec_PT.Repositories
{
 

        public class VehiculoRepository : IVehiculosRepository
        {
            private readonly DapperContext context;

            public VehiculoRepository(DapperContext context)
            {
                this.context = context;
            }

            public async Task<IEnumerable<Vehiculo>> ObtenerVehiculos()
            {
                var query = "SELECT * FROM vehiculos";

                using (var connection = context.CreateConnection())
                {
                    var vehiculos = await connection.QueryAsync<Vehiculo>(query);
                    return vehiculos.ToList();
                }
            }

            public async Task<Vehiculo> ObtenerVehiculo(string placas)
            {
                var query = "SELECT * FROM vehiculos WHERE placas = @placas";

                using (var connection = context.CreateConnection())
                {
                    var company = await connection.QuerySingleOrDefaultAsync<Vehiculo>(query, new { placas });
                    return company;
                }
            }

            public async Task AltaVehiculo(Vehiculo vehiculo)
            {
                var query = "INSERT INTO vehiculos (placas) VALUES (@placas)";

                var parameters = new DynamicParameters();
                parameters.Add("placas", vehiculo.placas, DbType.String);


                using (var connection = context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }

           
        }
    
}
