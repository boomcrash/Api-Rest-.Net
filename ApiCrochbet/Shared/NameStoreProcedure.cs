namespace ApiCrochbet.Shared
{
    public class NameStoreProcedure
    {
        //usuarios
        public const string SPUsuario = "usuarios";
        public const string SPconsultarUsuarios = "consultarUsuarios";
        public const string SPverificarUsuario = "verificarUsuario";
        public const string SPverificarUsuarioId = "verificarUsuarioId";
        public const string SPinsertarUsuario = "insertarUsuario";
        public const string SPeditarUsuario = "editarUsuario";
        public const string SPborrarUsuario = "borrarUsuario";
        
        //proveedores
        public const string SPProveedor = "proveedores";
        public const string SPconsultarProveedores = "consultarProveedores";
        public const string SPverificarProveedor = "verificarProveedor";
        public const string SPinsertarProveedor = "insertarProveedor";
        public const string SPeditarProveedor = "editarProveedor";
        public const string SPborrarProveedor = "borrarProveedor";

        //clientes
        public const string SPCliente = "clientes";
        public const string SPconsultarClientes = "consultarClientes";
        public const string SPgetClienteByUserId = "consultarClienteByUserId";
        public const string SPinsertarCliente = "insertarCliente";
        public const string SPeditarCliente = "editarCliente";
        public const string SPborrarCliente = "borrarCliente";

        //productos
        public const string SPProducto = "productos";
        public const string SPconsultarProductos = "consultarProducto";
        public const string SPconsultarProductoCategorias = "consultarProductoCategorias";
        public const string SPverificarProductos = "verificarProductos";
        public const string SPverificarProductoId = "verificarProductoId";
        public const string SPinsertarProducto = "insertarProducto";
        public const string SPeditarProducto = "editarProducto";
        public const string SPborrarProducto = "borrarProducto";
        public const string SPverificarProveedorId = "verificarProveedorId";

        //resenas
        public const string SPResena = "resenas";
        public const string SPconsultarResenas = "consultarResenas";
        public const string SPinsertarResena = "insertarResena";
        public const string SPeditarResena = "editarResena";
        public const string SPborrarResena = "borrarResena";


        //carrito
        public const string SPCarrito= "carritos";
        public const string SPconsultarItems = "consultarItemsCarrito";
        public const string SPconsultarTotalCarrito = "consultarTotalCarrito";
        public const string SPinsertarItems = "insertarItemCarrito";
        public const string SPsacarItems = "sacarItemCarrito";
        public const string SPcrearCarrito = "crearCarrito";
        public const string SPborrarCarrito = "borrarCarrito";
        public const string SPgetCarritoByClientId = "consultarCarritoByClientId";



        //factura
        public const string SPFactura = "facturas";
        public const string SPconsultarFacturas = "consultarFacturas";
        public const string SPcrearFactura = "crearFactura";
        public const string SPgetFacturaByClient = "consultarFacturasByClientId";
        public const string SPgetFacturaByCar = "consultarItemsFacturaByCarritoId";

    }
}

