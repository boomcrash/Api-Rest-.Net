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
    [Route("api/[controller]")]
    public class ProveedorController : Controller
    {

        [HttpPost("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult<modelos.proveedor>> getProveedores(modelos.proveedor prov)
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



        [HttpPost("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult> addProveedores([FromBody] modelos.proveedor prov)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPinsertarProveedor;
                //user.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(prov);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProveedor, cadenaConexion, nameProcedure, xml.ToString());

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
        public async Task<ActionResult> editProveedores([FromBody] modelos.proveedor prov)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPeditarProveedor;
                //user.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(prov);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProveedor, cadenaConexion, nameProcedure, xml.ToString());

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
        public async Task<ActionResult> deleteProveedores(int id)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPborrarProveedor;
                //user.idUsuario = id.ToString();
                proveedor prov = new proveedor();
                prov.idProveedor = id;
                XDocument xml = Shared.DBXmlMethods.GetXml(prov);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPProveedor, cadenaConexion, nameProcedure, xml.ToString());

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
