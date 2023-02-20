using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelos
{
    public class producto
    {
        int ? IdProducto { get; set; }
        string ? titulo { get; set; }
        float ? precio { get; set; }
        string ? imagen { get; set; }
        string ? descripcion { get; set; }
        string ? categoria { get; set; }
        int ? proveedorId { get; set; }

    }
}
