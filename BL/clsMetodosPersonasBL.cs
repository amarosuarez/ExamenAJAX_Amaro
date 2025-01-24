using ENT;
using DAL;

namespace BL
{
    public class clsMetodosPersonasBL
    {
        /// <summary>
        /// Función que obtiene todas las personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<clsPersona> obtenerPersonasBL()
        {
            return clsMetodosPersonasDAL.obtenerPersonasDAL();
        }

        /// <summary>
        /// Función que obtiene todas las personas de un departamento <br>
        /// Pre: El id del departamento debe ser mayor que 0</br>
        /// Post: Puede devolver nulo si no se encuentra el departamento
        /// </summary>
        /// <param name="idDepartamento">Id del departamento</param>
        /// <returns>Listado con personas de un mismo departamento</returns>
        public static List<clsPersona> obtenerPersonasPorDepartamentoBL(int idDepartamento)
        {
            List<clsPersona> listaPersonas = clsMetodosPersonasDAL.obtenerPersonasPorDepartamentoDAL(idDepartamento);
            List<clsPersona> listaPersonasFiltrada = new List<clsPersona>();

            // Comprobamos si el departamento es recursos humanos
            if (idDepartamento == 1)
            {
                // Solo pueden mostrarse los mayores de 35 años
                foreach (clsPersona persona in listaPersonas)
                {
                    int edad = calculaEdad(persona.FechaNacimiento);

                    if (edad > 35)
                    {
                        listaPersonasFiltrada.Add(persona);
                    }
                }
            } else
            {
                // Si es otro departamento, mostramos todas
                listaPersonasFiltrada.AddRange(listaPersonas);
            }
            return listaPersonasFiltrada;
        }

        /// <summary>
        /// Función que obtiene una persona por su id <br>
        /// Pre: El id de la persona debe ser mayor que 0</br>
        /// Post: Puede devolver nulo si no se encuentra a la persona
        /// </summary>
        /// <param name="idPersona">Id de la persona a buscar</param>
        /// <returns>Persona con dicho ID</returns>
        public static clsPersona obtenerPersonaPorIdBL(int idPersona)
        {
            return clsMetodosPersonasDAL.obtenerPersonaPorIdDAL(idPersona);
        }

        /// <summary>
        /// Función que calcula la edad de una persona<br>
        /// Pre: La fecha de nacimiento debe tener un formato válido</br>
        /// Post: Ninguna
        /// </summary>
        /// <param name="fechaNacimiento">Fecha de nacimiento</param>
        /// <returns>Edad calculada</returns>
        private static int calculaEdad(DateTime fechaNacimiento)
        {
            // Calculamos la edad
            int e = DateTime.Now.Year - fechaNacimiento.Year;

            if ((fechaNacimiento.Month > DateTime.Now.Month) ||
                (fechaNacimiento.Month == DateTime.Now.Month && fechaNacimiento.Day > DateTime.Now.Day))
            {
                e -= 1;
            }

            return e;
        }
    }
}
