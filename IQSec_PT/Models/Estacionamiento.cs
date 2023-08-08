using MessagePack;

namespace IQSec_PT.Models
{
    public class Estacionamiento
    {

     
        public int estacionamientoID { get; set; }
        public string placas { get; set; }
        public DateTime entrada { get; set; }
        public DateTime? salida { get; set; }
    }
}
