using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Entidades
{
    public class ProveeMateObra
    {
        public string Recibio { get; set; }
        public string Entrega { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEntre { get; set; }
        public double Precio { get; set; }
        public int idobra { get; set; }
        public int idmaterial { get; set; }
        public int idproveedor { get; set; }
    }
}
