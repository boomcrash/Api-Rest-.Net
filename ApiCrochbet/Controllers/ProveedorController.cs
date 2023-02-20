using ApiCrochbet.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Xml.Linq;

namespace ApiCrochbet.Controllers
{
    [Route("api/[controller]")]
    public class ProveedorController : Controller
    {

        [HttpPost("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult<modelos.proveedor>> getResenas(modelos.proveedor prov)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPconsultarProveedores;
                //user.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(prov);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProveedor, cadenaConexion, nameProcedure, xml.ToString());

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
