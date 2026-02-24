const baseUrl = "http://localhost:5003/api/doctores";

document.addEventListener("DOMContentLoaded", () => {

    if (document.querySelector("#tablaDoctores")) {
        cargarDoctores();
    }

    if (document.getElementById("doctorId")) {
        cargarDoctor();
    }
    if (document.getElementById("especialidadId")) {
        cargarEspecialidades();
    }
});

// Carga la lista completa de doctores
async function cargarDoctores() {

    const response = await fetch(`${baseUrl}/Listar`);
    const data = await response.json();

    const tbody = document.querySelector("#tablaDoctores tbody");
    tbody.innerHTML = "";

    data.forEach(d => {
        tbody.innerHTML += `
            <tr>
                <td>${d.doctorId}</td>
                <td>${d.nombre}</td>
                <td>${d.especialidadNombre ?? ""}</td>
                <td>${d.telefono ?? ""}</td>
                <td>${d.email ?? ""}</td>
                <td>
                    <button class="btn btn-warning btn-sm" onclick="editar(${d.doctorId})">Editar</button>
                    <button class="btn btn-danger btn-sm" onclick="eliminar(${d.doctorId})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

// Realiza la busqueda del doctor por medio del id 
async function buscarPorId() {

    const id = document.getElementById("buscarId").value;

    //Aqui manda una alerta si no coloca un id 
    if (!id) {
        alert("Ingrese un ID");
        return;
    }


    const response = await fetch(`${baseUrl}/Buscar?id=${id}`);
    //Aqui manda una alerta si no encuentra el id del doctor
    if (!response.ok) {
        alert(`Doctor con el id ${id} no fue encontrado`);
        return;
    }

    const d = await response.json();

    const tbody = document.querySelector("#tablaDoctores tbody");
    tbody.innerHTML = `
        <tr>
            <td>${d.doctorId}</td>
            <td>${d.nombre}</td>
            <td>${d.especialidadNombre ?? ""}</td>
            <td>${d.telefono ?? ""}</td>
            <td>${d.email ?? ""}</td>
            <td>
                <button class="btn btn-warning btn-sm" onclick="editar(${d.doctorId})">Editar</button>
                <button class="btn btn-danger btn-sm" onclick="eliminar(${d.doctorId})">Eliminar</button>
            </td>
        </tr>
    `;
}
//Crear un nuevo doctor con los datos del formulario de Crear
async function guardar() {

    const data = {
        nombre: document.getElementById("nombre").value,
        especialidadId: parseInt(document.getElementById("especialidadId").value),
        telefono: document.getElementById("telefono").value,
        email: document.getElementById("email").value
    };

    await fetch(`${baseUrl}/Crear`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    window.location.href = "/Doctores";
}
//Elimina un doctor por medio del id al hacer click en el botón Eliminar de la tabla de doctores
async function eliminar(id) {

    if (!confirm("¿Seguro que desea eliminar este doctor?")) return;

    await fetch(`${baseUrl}/Eliminar?id=${id}`, {
        method: "DELETE"
    });

    cargarDoctores();
}

//Edita un doctor por medio del id al hacer click en el botón Editar de la tabla de doctores y redirige a la página de edición
function editar(id) {
    window.location.href = `/Doctores/Editar?id=${id}`;
}

//Carga los datos del doctor en el formulario de edición al obtener el id del doctor y realiza la consulta para llenar los campos del formulario
async function cargarDoctor() {

    const idInput = document.getElementById("doctorId");
    if (!idInput || !idInput.value) return;

    const id = idInput.value;

    const response = await fetch(`${baseUrl}/Buscar?id=${id}`);
    const d = await response.json();

    document.getElementById("nombre").value = d.nombre;
    document.getElementById("telefono").value = d.telefono ?? "";
    document.getElementById("email").value = d.email ?? "";
    document.getElementById("especialidadId").value = d.especialidadId;
}

//Actualiza un doctor por medio del id con los datos del formulario de edición y se llama al hacer submit en la página de edición, luego redirige a la página de doctores
async function actualizar() {

    const id = document.getElementById("doctorId").value;

    const data = {
        nombre: document.getElementById("nombre").value,
        especialidadId: parseInt(document.getElementById("especialidadId").value),
        telefono: document.getElementById("telefono").value,
        email: document.getElementById("email").value
    };

    await fetch(`${baseUrl}/Actualizar?id=${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    window.location.href = "/Doctores";
}

//Carga la lista de especialidades para llenar el select del formulario de creación y edición de doctores
async function cargarEspecialidades() {

    const response = await fetch("http://localhost:5003/api/Especialidades/Listar");
    const data = await response.json();

    const select = document.getElementById("especialidadId");
    if (!select) return;

    select.innerHTML = "";

    data.forEach(e => {
        select.innerHTML += `<option value="${e.especialidadId}">${e.nombre}</option>`;
    });
}