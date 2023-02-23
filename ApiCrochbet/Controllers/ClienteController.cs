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
    public class ClienteController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<modelos.cliente>> getClientBd(modelos.cliente client)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                nameProcedure = NameStoreProcedure.SPconsultarClientes;

                
                XDocument xml = Shared.DBXmlMethods.GetXml(client);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCliente, cadenaConexion, nameProcedure, xml.ToString());

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
        public async Task<ActionResult> addClientes([FromBody] modelos.cliente client)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPinsertarCliente;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(client);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCliente, cadenaConexion, nameProcedure, xml.ToString());

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
        public async Task<ActionResult> editClientes([FromBody] modelos.cliente client)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPeditarCliente;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(client);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCliente, cadenaConexion, nameProcedure, xml.ToString());

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




        [HttpDelete("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult> deleteClientes([FromBody] modelos.cliente client)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPborrarCliente;
                //product.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(client);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPCliente, cadenaConexion, nameProcedure, xml.ToString());

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
