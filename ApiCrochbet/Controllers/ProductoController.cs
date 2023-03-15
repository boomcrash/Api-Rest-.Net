using ApiCrochbet.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCrochbet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<modelos.producto>> getProductos(modelos.producto product)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                nameProcedure = NameStoreProcedure.SPconsultarProductos;

                //product.idUsuario = id.ToString(); -- PARAMETRO
                XDocument xml = Shared.DBXmlMethods.GetXml(product);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProducto, cadenaConexion, nameProcedure, xml.ToString());

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
        public async Task<ActionResult<modelos.producto>> getProveedorById(modelos.producto product)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                nameProcedure = NameStoreProcedure.SPverificarProveedorId;

                //product.idUsuario = id.ToString(); -- PARAMETRO
                XDocument xml = Shared.DBXmlMethods.GetXml(product);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProducto, cadenaConexion, nameProcedure, xml.ToString());

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
        public async Task<ActionResult<modelos.producto>> getProductosCategories(modelos.producto product)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                nameProcedure = NameStoreProcedure.SPconsultarProductoCategorias;

                //product.idUsuario = id.ToString(); -- PARAMETRO
                XDocument xml = Shared.DBXmlMethods.GetXml(product);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProducto, cadenaConexion, nameProcedure, xml.ToString());

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
        public async Task<ActionResult> addProductos([FromBody] modelos.producto product)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPinsertarProducto;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(product);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProducto, cadenaConexion, nameProcedure, xml.ToString());

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



        [HttpPut("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult> editProductos([FromBody] modelos.producto product)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPeditarProducto;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(product);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProducto, cadenaConexion, nameProcedure, xml.ToString());

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
        public async Task<ActionResult> deleteProductos([FromBody] modelos.producto product,int id )
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                product.idProducto = id;
                nameProcedure = NameStoreProcedure.SPborrarProducto;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(product);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProducto, cadenaConexion, nameProcedure, xml.ToString());

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
