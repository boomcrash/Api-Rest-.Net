using ApiCrochbet.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCrochbet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       
        // POST api/<UsuarioController>
        [HttpPost("[action]/{procedimiento}")]
        public async Task<ActionResult<modelos.usuario>> GetUsuarios(string procedimiento,modelos.usuario user, int? id=null)
        {
            Console.WriteLine(procedimiento);
            string nameProcedure = "";
            var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];


            if (procedimiento == "verificarId")
            {
                nameProcedure = NameStoreProcedure.SPverificarUsuarioId;
                try
                {
                    user.idUsuario = id;
                    XDocument xml = Shared.DBXmlMethods.GetXml(user);
                    DataSet dsResultado = await Shared.DBXmlMethods
                    .EjecutaBase(NameStoreProcedure.SPUsuario, cadenaConexion, nameProcedure, xml.ToString());
                    List<modelos.usuario> listData = new List<modelos.usuario>();


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
                catch(Exception e)                      
                {
                    Console.WriteLine("error de consulta por id");
                    return Ok();
                }


            }
            else
            {
                XDocument xml = Shared.DBXmlMethods.GetXml(user);

                
                if (procedimiento == "verificar")
                {
                    nameProcedure = NameStoreProcedure.SPverificarUsuario;
                    try
                    {
                        DataSet dsResultado = await Shared.DBXmlMethods
                                        .EjecutaBase(NameStoreProcedure.SPUsuario, cadenaConexion, nameProcedure, xml.ToString());
                        List<modelos.usuario> listData = new List<modelos.usuario>();

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
                        Console.WriteLine("error de consulta ");
                        return BadRequest();
                    }
                }
                else if(procedimiento == "todos")
                {
                    nameProcedure = NameStoreProcedure.SPconsultarUsuarios;
                    try
                    {
                        DataSet dsResultado = await Shared.DBXmlMethods
                                        .EjecutaBase(NameStoreProcedure.SPUsuario, cadenaConexion, nameProcedure, xml.ToString());
                        List<modelos.usuario> listData = new List<modelos.usuario>();

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
                        Console.WriteLine("error de consulta ");
                        return Ok();
                    }

                }
                else
                {
                    return BadRequest();
                }
               

            }
           
            
        }


        [HttpPost("[action]")]
        //[Route("verificar")]
        public async Task<ActionResult> addUsuarios([FromBody] modelos.usuario user)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPinsertarUsuario;
                //user.idUsuario = id.ToString();
                XDocument xml = Shared.DBXmlMethods.GetXml(user);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPUsuario, cadenaConexion, nameProcedure, xml.ToString());

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

        // PUT api/<UsuarioController>/5
        [HttpPut("[action]")]
        public async Task<ActionResult> editUserPassword([FromBody] modelos.usuario user)
        {
            
            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPeditarUsuario;
                XDocument xml = Shared.DBXmlMethods.GetXml(user);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPUsuario, cadenaConexion, nameProcedure, xml.ToString());

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
                return BadRequest();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("[action]")]
        public async Task<ActionResult> deleteUser([FromBody] modelos.usuario user)
        {

            try
            {
                var cadenaConexion = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build().GetSection("ConnectionStrings")["Conexion"];

                string nameProcedure = "";

                nameProcedure = NameStoreProcedure.SPborrarUsuario;
                XDocument xml = Shared.DBXmlMethods.GetXml(user);
                DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPUsuario, cadenaConexion, nameProcedure, xml.ToString());

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
                return BadRequest();
            }
        }
    }
}
