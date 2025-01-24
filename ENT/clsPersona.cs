﻿namespace ENT
{
    public class clsPersona
    {
        #region Atributos
        private int id;
        private String nombre;
        private String apellidos;
        private String telefono;
        private String direccion;
        private String foto;
        private DateTime fechaNacimiento;
        private int idDepartamento;
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0)
                {
                    id = value;
                }
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
            }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    apellidos = value;
                }
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 9 && value.All(char.IsDigit))
                {
                    telefono = value;
                }
            }
        }
        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    direccion = value;
                }
            }
        }
        public string Foto
        {
            get { return foto; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    foto = value;
                }
            }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set
            {
                if (value.Year >= 1800)
                {
                    fechaNacimiento = value;
                }
            }
        }
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set
            {
                if (value > 0)
                {
                    idDepartamento = value;
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public clsPersona() { }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellidos">Apellidos de la persona</param>
        /// <param name="telefono">Telefono de la persona</param>
        /// <param name="direccion">Direccion de la persona</param>
        /// <param name="foto">Foto de la persona</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento de la persona</param>
        /// <param name="idDepartamento">Id del departamento de la persona</param>
        public clsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            if (id > 0)
            {
                this.id = id;
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                this.nombre = nombre;
            }

            if (!String.IsNullOrEmpty(apellidos))
            {
                this.apellidos = apellidos;
            }

            // Compruebo que el telefono no sea nulo, que sea 9 de largo y que todo sean números
            if (!string.IsNullOrEmpty(telefono) && telefono.Length == 9 && telefono.All(char.IsDigit))
            {
                this.telefono = telefono;
            }

            if (!string.IsNullOrEmpty(direccion))
            {
                this.direccion = direccion;
            }

            if (!string.IsNullOrEmpty(foto))
            {
                this.foto = foto;
            }

            if (fechaNacimiento.Year >= 1800)
            {
                this.fechaNacimiento = fechaNacimiento;
            }

            if (idDepartamento > 0)
            {
                this.idDepartamento = idDepartamento;
            }
        }
        #endregion
    }
}
