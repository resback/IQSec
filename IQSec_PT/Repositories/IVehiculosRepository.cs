using IQSec_PT.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IQSec_PT.Repositories
{
    public interface IVehiculosRepository
    {

        Task<IEnumerable<Vehiculo>> ObtenerVehiculos();
        Task<Vehiculo> ObtenerVehiculo(string placas);
        Task AltaVehiculo(Vehiculo vehiculo);
    }
}
