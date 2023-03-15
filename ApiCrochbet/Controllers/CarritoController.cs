using ApiCrochbet.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modelos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Xml.Linq;

namespace ApiCrochbet.Controllers
{
    public class CarritoController : Controller
    {
        [HttpPost("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult> createCarrito([FromBody] modelos.carrito car)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPcrearCarrito;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(car);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCarrito, cadenaConexion, nameProcedure, xml.ToString());

                if (dsResultado.Tables.Count >= 1 || dsResultado.Tables[1].Rows.Count >= 1)
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(dsResultado.Tables[1]);
                    JArray jsonArray = JArray.Parse(JSONstring);
                    string column1Value = jsonArray[0]["Column1"].ToString();
                    bool value = bool.Parse(column1Value);
                    return Ok(value);
                }
                else
                {
                    return Ok(false);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(false);
            }
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<modelos.cliente>> getCarritoByClientId([FromBody]modelos.cliente client)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                nameProcedure = NameStoreProcedure.SPgetCarritoByClientId;


                XDocument xml = Shared.DBXmlMethods.GetXml(client);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCarrito, cadenaConexion, nameProcedure, xml.ToString());

                if (dsResultado.Tables[0].Rows.Count > 0)
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(dsResultado.Tables[0]);
                    return Ok(JSONstring);
                }
                else
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(false);
                    return Ok(JSONstring);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }

        }


        [HttpPost("[action]")]
        public async Task<ActionResult<modelos.carrito>> getTotalCarrito([FromBody] modelos.carrito car)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                nameProcedure = NameStoreProcedure.SPconsultarTotalCarrito;

                XDocument xml = Shared.DBXmlMethods.GetXml(car);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCarrito, cadenaConexion, nameProcedure, xml.ToString());

                if (dsResultado.Tables.Count >= 0 || dsResultado.Tables[0].Rows.Count >= 0)
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(dsResultado.Tables[0]);
                    JArray jsonArray = JArray.Parse(JSONstring);
                    string value = jsonArray[0]["total"].ToString();
                    return Ok(value);
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }

        }


        [HttpPost("[action]")]
        public async Task<ActionResult<modelos.carrito>> getItemsCarrito([FromBody]modelos.carrito car)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                nameProcedure = NameStoreProcedure.SPconsultarItems;

                XDocument xml = Shared.DBXmlMethods.GetXml(car);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCarrito, cadenaConexion, nameProcedure, xml.ToString());

                if (dsResultado.Tables.Count >= 0 || dsResultado.Tables[0].Rows.Count >= 0)
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(dsResultado.Tables[0]);
                    return Ok(JSONstring);
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }

        }

        [HttpPost("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult> addItems([FromBody] modelos.CarritoHasProducto car)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPinsertarItems;
               
                XDocument xml = Shared.DBXmlMethods.GetXml(car);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCarrito, cadenaConexion, nameProcedure, xml.ToString());


                if (dsResultado.Tables.Count >= 1 || dsResultado.Tables[1].Rows.Count >= 1)
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(dsResultado.Tables[1]);
                    JArray jsonArray = JArray.Parse(JSONstring);
                    string column1Value = jsonArray[0]["Column1"].ToString();
                    bool value = bool.Parse(column1Value);
                    return Ok(value);
                }
                else
                {
                    return Ok(false);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(false);
            }
        }



        [HttpPost("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult> deleteOneItem([FromBody] modelos.CarritoHasProducto car)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPsacarItems;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(car);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCarrito, cadenaConexion, nameProcedure, xml.ToString());

                if (dsResultado.Tables.Count >= 1 || dsResultado.Tables[1].Rows.Count >= 1)
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(dsResultado.Tables[1]);
                    JArray jsonArray = JArray.Parse(JSONstring);
                    string column1Value = jsonArray[0]["Column1"].ToString();
                    bool value = bool.Parse(column1Value);
                    return Ok(value);
                }
                else
                {
                    return Ok(false);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(false);
            }
        }




        [HttpDelete("[action]/{id}")]
        //[Route("verificar")]
        public async Task<ActionResult> deleteAllItems(int id)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPborrarCarrito;
                CarritoHasProducto car = new CarritoHasProducto();
                car.carritoId=id;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(car);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCarrito, cadenaConexion, nameProcedure, xml.ToString());

                if (dsResultado.Tables.Count >= 1 || dsResultado.Tables[1].Rows.Count >= 1)
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(dsResultado.Tables[1]);
                    JArray jsonArray = JArray.Parse(JSONstring);
                    string column1Value = jsonArray[0]["Column1"].ToString();
                    bool value = bool.Parse(column1Value);
                    return Ok(value);
                }
                else
                {
                    return Ok(false);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(false);
            }
        }
    }
}
