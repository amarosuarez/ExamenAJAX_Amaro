/**
 * Clase persona
 */
class clsPersona {
    /**
     * Constructor con parámetros
     * @param {any} id ID de la persona
     * @param {any} nombre Nombre de la persona
     * @param {any} apellidos Apellidos de la persona
     * @param {any} telefono Telefono de la persona
     * @param {any} direccion Direccion de la persona
     * @param {any} foto Foto de la persona
     * @param {any} fechaNacimiento Fecha de nacimiento de la persona
     * @param {any} idDepartamento Id del departamento de la persona
     */
    constructor(id, nombre, apellidos, telefono, direccion, foto, fechaNacimiento, idDepartamento) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.direccion = direccion;
        this.foto = foto;
        this.fechaNacimiento = fechaNacimiento;
        this.idDepartamento = idDepartamento;
    }
}

/**
 * Clase departamento
 */
class clsDepartamento {
    /**
     * Constructor con parámetros
     * @param {any} id ID del departamento
     * @param {any} nombre Nombre del departamento
     */
    constructor(id, nombre) {
        this.id = id;
        this.nombre = nombre;
    }
}

window.onload = function () {
    /**
     * Variable global donde se guardarán los departamentos
     */
    let departamentosArray;

    /**
     * Función que obtiene los departamentos de la API y los pinta en el desplegable
     */
    function obtenerDepartamentos() {
        // Seleccionamos el desplegable
        const desplegable = document.getElementById("desplegableDepartamentos");

        // Creamos la llamada
        let miLlamada = new XMLHttpRequest();

        // Colocamos el método
        miLlamada.open("GET", "http://localhost:5197/api/departamentos");

        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {
                // Aquí colocaría un gif que indique que se está cargando pero al ser una lista estática no se va a apreciar
            } else {
                if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                    // Parseamos la respuesta
                    departamentosArray = JSON.parse(miLlamada.responseText);

                    // For each para controlar cada departamento y añadirlo al desplegable
                    departamentosArray.forEach(d => {
                        // Creamos un objeto departamento
                        const departamento = new clsDepartamento(d.id, d.nombre);

                        // Creamos el option
                        const option = document.createElement("option");

                        // Agregamos los valores
                        option.value = departamento.id;
                        option.innerText = departamento.nombre;

                        // Añadimos el option al desplegable
                        desplegable.appendChild(option);
                    });
                }
            }
        }

        // Realizamos la llamada
        miLlamada.send();
    }

    /**
     * Función que obtiene las personas que trabajan en un departamento concreto de la API
     * y las pinta en una tabla
     * @param {any} idDepartamento ID del departamento seleccionado
     */
    function obtenerPersonasDepartamento(idDepartamento) {
        // Seleccionamos el div contenedor y el div de la tabla
        const contenido = document.getElementById("contenido");
        const divTabla = document.getElementById("divTabla");

        // Creamos la llamada
        let miLlamada = new XMLHttpRequest();

        // Colocamos el método
        miLlamada.open("GET", `http://localhost:5197/api/departamentos/${idDepartamento}/personas`);

        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {
                // Aquí colocaría un gif que indique que se está cargando pero al ser una lista estática no se va a apreciar
            } else {
                if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                    // Parseamos la respuesta
                    const personasArray = JSON.parse(miLlamada.responseText);

                    // Primero limpiamos el contenido de divTabla por si ya contuviese datos
                    divTabla.innerHTML = ""

                    // Creamos la tabla y sus encabezados
                    const tabla = document.createElement("table");
                    const trEncabezado = document.createElement("tr");
                    const thNombre = document.createElement("th");
                    thNombre.innerText = "Nombre";
                    const thApellidos = document.createElement("th");
                    thApellidos.innerText = "Apellidos";

                    // Añadimos los encabezados a la tabla
                    trEncabezado.appendChild(thNombre);
                    trEncabezado.appendChild(thApellidos);
                    tabla.appendChild(trEncabezado);

                    // For each para controlar cada persona y añadirlo a la tabla
                    personasArray.forEach(p => {
                        // Creamos un objeto persona
                        const persona = new clsPersona(p.id, p.nombre, p.apellidos, p.telefono, p.direccion, p.foto, p.fechaNacimiento, p.idDepartamento);

                        // Creamos una fila
                        const tr = document.createElement("tr");

                        // Creamos dos celdas, para nombre y apellidos
                        const tdNombre = document.createElement("td");
                        tdNombre.innerText = persona.nombre;
                        const tdApellidos = document.createElement("td");
                        tdApellidos.innerText = persona.apellidos;

                        // Lo añadimos a la fila y añadimos la fila a la tabla
                        tr.appendChild(tdNombre);
                        tr.appendChild(tdApellidos);
                        tabla.appendChild(tr);

                        // Cuando pulsemos en la persona mostramos sus datos
                        tr.addEventListener("click", function () {
                            obtenerDetallesPersona(persona);
                        })
                    });

                    // Añadimos la tabla al div y al contenido
                    divTabla.appendChild(tabla);
                }
            } 
        }

        // Realizamos la llamada
        miLlamada.send();
    }

    /**
     * Función muestra los detalles de una persona
     * @param {any} persona Objeto persona a mostrar
     */
    function obtenerDetallesPersona(persona) {
        // Obtenemos los elementos
        let divDetails = document.getElementById("divDetails")
        let img = document.getElementById("imgPersona");
        let nombre = document.getElementById("nombre");
        let apellidos = document.getElementById("apellidos");
        let departamento = document.getElementById("departamento");
        let direccion = document.getElementById("direccion");
        let informacion = document.getElementById("informacion");

        // Colocamos la información
        img.src = persona.foto;
        nombre.innerText = persona.nombre;
        apellidos.innerText = persona.apellidos;
        direccion.innerText = persona.direccion;

        departamentosArray.forEach(d => {
            if (d.id == persona.idDepartamento) {
                departamento.innerText = d.nombre;
            }
        });

        const edad = calcularEdad(persona.fechaNacimiento);
        informacion.innerHTML = `Edad: <b>${edad} años</b><br>Teléfono ${persona.telefono}`;

        // Mostramos el div
        divDetails.style.visibility = "visible";
    }

    /**
     * Función que calcula la edad
     * @param {any} fechaNacimiento Fecha a calcular
     * @returns Edad calculada
     */
    function calcularEdad(fechaNacimiento) {
        const fechaYear = new Date(fechaNacimiento).getFullYear();
        const fechaMonth = new Date(fechaNacimiento).getMonth();
        const fechaDay = new Date(fechaNacimiento).getDay();
        const hoyYear = new Date().getFullYear();
        const hoyMonth = new Date().getMonth();
        const hoyDay = new Date().getDay();

        let edad = hoyYear - fechaYear;

        if ((fechaMonth > hoyMonth) ||
            (fechaMonth == hoyMonth && fechaDay > hoyDay)) {
            edad -= 1;
        }

        return edad;
    }

    // Cuando se cargue la página, cargamos los departamentos y los añadimos al desplegable
    obtenerDepartamentos();

    // Cuando se cambie la opción del desplegable, cargamos las personas de ese departamento
    document.getElementById("desplegableDepartamentos").addEventListener("change", function () {
        // Obtenemos la opción seleccionada
        const opcionSeleccionada = document.getElementById("desplegableDepartamentos").value;

        // Ocultamos los detalles de la persona por si se están mostrando
        document.getElementById("divDetails").style.visibility = "hidden";

        // Comprobamos que no sea la opción por defecto
        if (opcionSeleccionada > 0) {
            // Cargamos las personas del departamento seleccionado
            obtenerPersonasDepartamento(opcionSeleccionada);
        } else {
            // Borramos el contenido si ya hay una tabla creada
            document.getElementById("divTabla").innerHTML = "";
        }
    })
}