using ENT;

namespace DAL
{
    public class clsMetodosPersonasDAL
    {
        /// <summary>
        /// Listado de personas
        /// </summary>
        public static List<clsPersona> listaPersonas = new List<clsPersona> {
            new clsPersona(1, "Eduardo", "Arnesto Blaba", "147852369", "Mi casa, 1", "https://foto.png", new DateTime(1998, 7, 10), 1),
            new clsPersona(2, "Rubén", "Ruíz Castaño", "987654321", "Mi casa, 2", "https://foto.png", new DateTime(1975, 5, 30), 2),
            new clsPersona(3, "Amaro", "Suárez Villegas", "123456789", "Mi casa, 3", "https://foto.png", new DateTime(2004, 8, 12), 3),
            new clsPersona(4, "Héctor", "Arias Blebe", "741258963", "Mi casa, 4", "https://foto.png", new DateTime(1984, 4, 4), 4),
            new clsPersona(5, "Raúl", "Romera Blibi", "963258741", "Mi casa, 5", "https://foto.png", new DateTime(1999, 12, 12), 1),
            new clsPersona(6, "Marcos", "Holguín Blobo", "321654987", "Mi casa, 6", "https://foto.png", new DateTime(1985, 11, 5), 2),
            new clsPersona(7, "Lorenzo", "Bellido Blubu", "789456123", "Mi casa, 7", "https://foto.png", new DateTime(2001, 10, 7), 3),
            new clsPersona(8, "Pablo", "Carbonero Chileno", "258741369", "Mi casa, 8", "https://foto.png", new DateTime(1968, 3, 15), 4),
            new clsPersona(9, "José Enrique", "Muñoz Galloso", "852369741", "Mi casa, 9", "https://foto.png", new DateTime(1967, 10, 1), 1),
            new clsPersona(10, "Antonio", "Vizarraga Vizarraga", "569874123", "Mi casa, 10", "https://foto.png", new DateTime(1992, 12, 24), 2),
            new clsPersona(11, "Jose Luis", "Mejorada Calvo", "547896321", "Mi casa, 11", "https://foto.png", new DateTime(2002, 9, 4), 3),
            new clsPersona(12, "Pedro", "Ramón Díaz", "698741235", "Mi casa, 12", "https://foto.png", new DateTime(1983, 6, 6), 4),
        };

        /// <summary>
        /// Función que obtiene todas las personas <br>
        /// Pre: Ninguno </br>
        /// Post: Ninguno
        /// </summary>
        /// <returns>Listado de todas las personas</returns>
        public static List<clsPersona> obtenerPersonasDAL()
        {
            return listaPersonas;
        }

        /// <summary>
        /// Función que obtiene todas las personas de un departamento <br>
        /// Pre: El id del departamento debe ser mayor que 0</br>
        /// Post: Puede devolver nulo si no se encuentra el departamento
        /// </summary>
        /// <param name="idDepartamento">Id del departamento</param>
        /// <returns>Listado con personas de un mismo departamento</returns>
        public static List<clsPersona> obtenerPersonasPorDepartamentoDAL(int idDepartamento)
        {
            return listaPersonas.FindAll(p => p.IdDepartamento == idDepartamento);
        }

        /// <summary>
        /// Función que obtiene una persona por su id <br>
        /// Pre: El id de la persona debe ser mayor que 0</br>
        /// Post: Puede devolver nulo si no se encuentra a la persona
        /// </summary>
        /// <param name="idPersona">Id de la persona a buscar</param>
        /// <returns>Persona con dicho ID</returns>
        public static clsPersona obtenerPersonaPorIdDAL(int idPersona)
        {
            return listaPersonas.Find(p => p.Id == idPersona);
        }
    }
}
