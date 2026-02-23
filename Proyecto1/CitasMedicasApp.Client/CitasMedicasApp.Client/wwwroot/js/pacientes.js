
const baseUrl = "http://localhost:5003/api/pacientes";

// 👇 ESTE BLOQUE VA AQUÍ
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


// ================== LISTAR ==================
async function cargarPacientes() {
    try {
        const response = await fetch(`${baseUrl}/Listar`);
        const data = await response.json();

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


// ================== CREAR ==================
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


// ================== ELIMINAR ==================
async function eliminar(id) {
    if (!confirm("¿Seguro que desea eliminar este paciente?")) return;

    await fetch(`${baseUrl}/Eliminar?id=${id}`, {
        method: "DELETE"
    });

    cargarPacientes();
}


// ================== EDITAR ==================
function editar(id) {
    window.location.href = `/Pacientes/Editar?id=${id}`;
}


// ================== CARGAR PACIENTE EDITAR ==================
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


// ================== ACTUALIZAR ==================
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