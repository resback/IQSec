using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IQSec_PT.Models
{
    public class Vehiculo
    {

        public int vehiculoID { get; set; }

        [Display(Name = "Placas")]
        public string placas { get; set; }

     
    }
}
