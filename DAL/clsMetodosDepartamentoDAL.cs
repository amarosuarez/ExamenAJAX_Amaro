using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsMetodosDepartamentoDAL
    {
        /// <summary>
        /// Listado de todos los departamentos
        /// </summary>
        public static List<clsDepartamento> listaDepartamentos = new List<clsDepartamento>
        {
            new clsDepartamento(1, "Recursos Humanos"),
            new clsDepartamento(2, "Marketing"),
            new clsDepartamento(3, "Ventas"),
            new clsDepartamento(4, "Comercial")
        };

        /// <summary>
        /// Función que obtiene todos los departamentos
        /// </summary>
        /// <returns>Listado de todos los departamentos</returns>
        public static List<clsDepartamento> obtenerDepartamentosDAL()
        {
            return listaDepartamentos;
        }

        /// <summary>
        /// Función que obtiene un departamento por su id
        /// </summary>
        /// <param name="id">Id del departamento a buscar</param>
        /// <returns>Departamento con dicho id</returns>
        public static clsDepartamento obtenerDepartamentoPorIdDAL(int id)
        {
            return listaDepartamentos.Find(d => d.Id == id);
        }
    }
}
