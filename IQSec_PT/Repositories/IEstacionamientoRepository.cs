using IQSec_PT.Models;

namespace IQSec_PT.Repositories
{
    public interface IEstacionamientoRepository
    {

        Task Entrada(string placas);
        Task Salida(int estacionamientoID);
        Task<IEnumerable<Estacionamiento>> Registros();
        Task<Estacionamiento> Registro(int estacionamientoID);
    }
}
