using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenAJAX_Amaro.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        // GET: api/<DepartamentosController>
        /// <summary>
        /// Método GET que devuelve todos los departamentos<br>
        /// Pre: Ninguno</br>
        /// Post: Ninguno
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsDepartamento> listaDepartamentos = new List<clsDepartamento>();

            try
            {
                listaDepartamentos = clsMetodosDepartamentosBL.obtenerDepartamentoBL();

                if (listaDepartamentos.Count > 0)
                {
                    salida = Ok(listaDepartamentos);
                }
                else
                {
                    salida = NoContent();
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        // GET api/<DepartamentosController>/5
        /// <summary>
        /// Método GET que devuelve un departamento por su ID<br>
        /// Pre: El id del departamento debe ser mayor que 0</br>
        /// Post: Puede no devolver nada si no se encuentra un departamento
        /// </summary>
        /// <param name="id">ID del departamento a buscar</param>
        /// <returns>Departamento con dicho ID</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsDepartamento departamento;

            try
            {
                departamento = clsMetodosDepartamentosBL.obtenerDepartamentoPorIdBL(id);

                if (departamento != null)
                {
                    salida = Ok(departamento);
                }
                else
                {
                    salida = NoContent();
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }
        // para que se te quite el error no puedes tener dos veces HttpGet[{id}]
        // si quieres coger las personas pon HttpGet[{id}/personas]

        /// <summary>
        /// Método GET que devuelve las personas de un departamento<br>
        /// Pre: El id del departamento debe ser mayor que 0</br>
        /// Post: Puede no devolver nada si no se encuentran personas o el departamento
        /// </summary>
        /// <param name="id">Id del departamento</param>
        /// <returns>Lista de personas que pertenecen al departamento</returns>
        [HttpGet("{id}/personas")]
        public IActionResult GetPersonas(int id)
        {
            IActionResult salida;
            List<clsPersona> listaPersonas = new List<clsPersona>();

            try
            {
                listaPersonas = clsMetodosPersonasBL.obtenerPersonasPorDepartamentoBL(id);

                if (listaPersonas != null)
                {
                    salida = Ok(listaPersonas);
                }
                else
                {
                    salida = NoContent();
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        //// POST api/<DepartamentosController>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<DepartamentosController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<DepartamentosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
