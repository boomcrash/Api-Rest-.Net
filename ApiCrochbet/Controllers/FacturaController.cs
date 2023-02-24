using ApiCrochbet.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCrochbet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        [HttpPost("[action]")]
        //[Route("verififact")]
        public async Task<ActionResult> createFactura([FromBody] modelos.factura fact)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPcrearFactura;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(fact);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPFactura, cadenaConexion, nameProcedure, xml.ToString());

                if (dsResultado.Tables[0].Rows.Count > 0)
                {
                    string JSONstring = string.Empty;
                    JSONstring = JsonConvert.SerializeObject(true);
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
        //[Route("verififact")]
        public async Task<ActionResult> getFacturas([FromBody] modelos.factura fact)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPconsultarFacturas;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(fact);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPFactura, cadenaConexion, nameProcedure, xml.ToString());

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
        //[Route("verififact")]
        public async Task<ActionResult> getFacturasItemsByCar([FromBody] modelos.factura fact)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPgetFacturaByCar;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(fact);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPFactura, cadenaConexion, nameProcedure, xml.ToString());

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
        //[Route("verififact")]
        public async Task<ActionResult> getFacturaByClient([FromBody] modelos.cliente fact)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPgetFacturaByClient;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(fact);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPFactura, cadenaConexion, nameProcedure, xml.ToString());

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


    }
}
