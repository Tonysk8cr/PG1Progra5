
const baseUrl = "http://localhost:5003/api/pacientes";

document.addEventListener("DOMContentLoaded", () => {

    // Si existe la tabla → estamos en Index
    if (document.querySelector("#tablaPacientes")) {
        cargarPacientes();
    }

    // Si existe el input oculto → estamos en Editar
    if (document.getElementById("pacienteId")) {
        cargarPaciente();
    }

});


// Lista los pacientes en la tabla de Index y se llama al cargar la página
async function cargarPacientes() {
    try {
        const response = await fetch(`${baseUrl}/Listar`);
        const data = await response.json();

        //Si obtiene respuesta llena la tablaPacientes justo en el tbody
        const tbody = document.querySelector("#tablaPacientes tbody");
        tbody.innerHTML = "";

        data.forEach(p => {
            tbody.innerHTML += `
                <tr>
                    <td>${p.nombre}</td>
                    <td>${p.edad}</td>
                    <td>${p.telefono ?? ""}</td>
                    <td>${p.email ?? ""}</td>
                    <td>
                        <button class="btn btn-warning btn-sm" onclick="editar(${p.pacienteId})">Editar</button>
                        <button class="btn btn-danger btn-sm" onclick="eliminar(${p.pacienteId})">Eliminar</button>
                    </td>
                </tr>
            `;
        });

    } catch (error) {
        console.error("Error cargando pacientes:", error);
    }
}


// Crea un nuevo paciente con los datos del formulario de Create y se llama al hacer submit
async function guardar() {

    const data = {
        nombre: document.getElementById("nombre").value,
        edad: parseInt(document.getElementById("edad").value),
        telefono: document.getElementById("telefono").value,
        email: document.getElementById("email").value
    };

    await fetch(`${baseUrl}/Crear`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    window.location.href = "/Pacientes";
}


// Elimina un paciente al hacer click en el botón Eliminar de la tabla de Index
async function eliminar(id) {
    if (!confirm("¿Seguro que desea eliminar este paciente?")) return;

    await fetch(`${baseUrl}/Eliminar?id=${id}`, {
        method: "DELETE"
    });

    cargarPacientes();
}


// Editar un paciente al hacer click en el botón Editar de la tabla de Index redirige a la página Editar con el id en query string
function editar(id) {
    window.location.href = `/Pacientes/Editar?id=${id}`;
}


// Carga los datos de un paciente
async function cargarPaciente() {

    const idInput = document.getElementById("pacienteId");
    if (!idInput) return;

    const id = idInput.value;

    const response = await fetch(`${baseUrl}/Buscar?id=${id}`);
    const p = await response.json();

    document.getElementById("nombre").value = p.nombre;
    document.getElementById("edad").value = p.edad;
    document.getElementById("telefono").value = p.telefono ?? "";
    document.getElementById("email").value = p.email ?? "";
}


// Actualiza un paciente con los datos del formulario de Editar
async function actualizar() {

    const id = document.getElementById("pacienteId").value;

    const data = {
        nombre: document.getElementById("nombre").value,
        edad: parseInt(document.getElementById("edad").value),
        telefono: document.getElementById("telefono").value,
        email: document.getElementById("email").value
    };

    await fetch(`${baseUrl}/Actualizar?id=${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    window.location.href = "/Pacientes";
}


//Busca un paciente por ID al hacer click en el botón Buscar de la página Index y muestra solo ese paciente en la tabla
async function buscarPorId() {

    const id = document.getElementById("buscarId").value;

    //Si no coloca id envia una alerta
    if (!id) {
        alert("Ingrese un ID");
        return;
    }

    //Realiza la busqueda en el endpoint BuscarID
    const response = await fetch(`${baseUrl}/Buscar?id=${id}`);

    //Si el id no existe envia alerta
    if (!response.ok) {
        alert(` El paciente con id ${id} no existe`);
        return;
    }

    //Si obtiene respuesta llena la tablaPacientes 
    const p = await response.json();

    const tbody = document.querySelector("#tablaPacientes tbody");
    tbody.innerHTML = "";

    tbody.innerHTML = `
        <tr>
            <td>${p.nombre}</td>
            <td>${p.edad}</td>
            <td>${p.telefono ?? ""}</td>
            <td>${p.email ?? ""}</td>
            <td>
                <button class="btn btn-warning btn-sm" onclick="editar(${p.pacienteId})">Editar</button>
                <button class="btn btn-danger btn-sm" onclick="eliminar(${p.pacienteId})">Eliminar</button>
            </td>
        </tr>
    `;
}