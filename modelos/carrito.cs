using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelos
{
    internal class carrito
    {
        float total { get; set; }

        List<producto> productos { get; set; }
        int clienteId { get; set; }
    }
}
