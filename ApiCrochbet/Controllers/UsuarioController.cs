using ApiCrochbet.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCrochbet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult<modelos.usuario>> GetUsuarios(modelos.usuario user)
        {
            
            var cadenaConexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["Conexion"];

            XDocument xml = Shared.DBXmlMethods.GetXml(user);
            DataSet dsResultado = await Shared.DBXmlMethods
                .EjecutaBase(NameStoreProcedure.SPUsuario, cadenaConexion, NameStoreProcedure.SPconsultarUsuarios, xml.ToString());
            List<modelos.usuario> listData = new List<modelos.usuario>();

            string JSONstring = string.Empty;
            JSONstring = JsonConvert.SerializeObject(dsResultado.Tables[0]);
            return Ok(JSONstring);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
