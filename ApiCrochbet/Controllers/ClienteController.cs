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
    public class ClienteController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<modelos.cliente>> getUserBd(modelos.cliente user)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";
                nameProcedure = NameStoreProcedure.SPconsultarClientes;

                //user.idUsuario = id.ToString(); -- PARAMETRO
                XDocument xml = Shared.DBXmlMethods.GetXml(user);
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
    }
}
