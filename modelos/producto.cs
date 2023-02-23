using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelos
{
    public class producto
    {
        public int ? idProducto { get; set; }
        public string? titulo { get; set; }
        public float? precio { get; set; }
        public string? imagen { get; set; }
        public string? descripcion { get; set; }
        public string? categoria { get; set; }
        public int? proveedorId { get; set; }

    }
}
