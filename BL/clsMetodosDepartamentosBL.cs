using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsMetodosDepartamentosBL
    {
        /// <summary>
        /// Función que obtiene todos los departamentos
        /// </summary>
        /// <returns>Listado de todos los departamentos</returns>
        public static List<clsDepartamento> obtenerDepartamentoBL()
        {
            return clsMetodosDepartamentoDAL.obtenerDepartamentosDAL();
        }

        /// <summary>
        /// Función que obtiene un departamento por su id
        /// </summary>
        /// <param name="id">Id del departamento a buscar</param>
        /// <returns>Departamento con dicho id</returns>
        public static clsDepartamento obtenerDepartamentoPorIdBL(int id)
        {
            return clsMetodosDepartamentoDAL.obtenerDepartamentoPorIdDAL(id);
        }
    }
}
