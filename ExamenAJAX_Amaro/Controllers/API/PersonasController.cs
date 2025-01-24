using BL;
using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenAJAX_Amaro.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        /// <summary>
        /// Método GET que devuelve todas las personas<br>
        /// Pre: ninguno</br>
        /// Post: ninguno
        /// </summary>
        /// <returns>Listado de personas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> listaPersonas = new List<clsPersona>();

            try
            {
                listaPersonas = clsMetodosPersonasBL.obtenerPersonasBL();

                if (listaPersonas.Count > 0 )
                {
                    salida = Ok(listaPersonas);
                }
                else
                {
                    salida = NoContent();
                }
            } catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        // GET api/<PersonasController>/5
        /// <summary>
        /// Método GET que devuelve una persona por su ID<br>
        /// Pre: El id de la persona debe ser mayor que 0</br>
        /// Post: Puede no devolver nada si no se encuentra una persona
        /// </summary>
        /// <param name="id">ID de la persona a buscar</param>
        /// <returns>Persona con dicho ID</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsPersona persona;

            try
            {
                persona = clsMetodosPersonasBL.obtenerPersonaPorIdBL(id);

                if (persona != null)
                {
                    salida = Ok(persona);
                } else
                {
                    salida = NoContent();
                }
            } catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        //// POST api/<PersonasController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PersonasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PersonasController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
