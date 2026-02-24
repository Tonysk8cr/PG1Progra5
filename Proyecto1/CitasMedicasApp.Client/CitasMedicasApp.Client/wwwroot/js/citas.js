const baseUrl = "http://localhost:5003/api/citas";

document.addEventListener("DOMContentLoaded", async () => {

    //Carga las citas
    if (document.querySelector("#tablaCitas")) {
        cargarCitas();
    }

    // si hay un id con fechaCita realiza los flatpickr de recha y hora 
    if (document.getElementById("fechaCita")) {

        flatpickr("#fechaCita", {
            dateFormat: "Y-m-d",
            minDate: "today" // No permite fechas antes de hoy
        });

        flatpickr("#horaCita", {
            enableTime: true,
            noCalendar: true,
            dateFormat: "H:i",
            time_24hr: true
        });

        // Llena el paciente automaticamente 
        await ComboHelper.llenarCombo(
            "http://localhost:5003/api/Pacientes/Listar",
            "pacienteId",
            "pacienteId",
            (p) => `${p.nombre} (ID: ${p.pacienteId})`
        );

        //Llena el doctor automaticamente 
        await ComboHelper.llenarCombo(
            "http://localhost:5003/api/Doctores/Listar",
            "doctorId",
            "doctorId",
            (d) => `${d.nombre} - ${d.especialidadNombre}`
        );

        // Si hay un citaId carga la cita
        if (document.getElementById("citaId")) {
            await cargarCita();
        }
    }

});

//Funcion de cargar citas, busca en /Listar
async function cargarCitas() {

    const response = await fetch(`${baseUrl}/Listar`);
    const data = await response.json();

    const tbody = document.querySelector("#tablaCitas tbody");
    tbody.innerHTML = "";

    data.forEach(c => {
        tbody.innerHTML += `
            <tr>
                <td>${c.citaId}</td>
                <td>${c.pacienteNombre} (ID: ${c.pacienteId})</td>
                <td>${c.doctorNombre} (ID: ${c.doctorId})</td>
                <td>${c.fechaCita}</td>
                <td>${c.horaCita}</td>
                <td>${c.motivo}</td>
                <td>${c.estado}</td>
                <td>
                    <button class="btn btn-warning btn-sm" onclick="editar(${c.citaId})">Editar</button>
                    <button class="btn btn-danger btn-sm" onclick="eliminar(${c.citaId})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

//Funcion para guardar una cita nueva /Crear
async function guardar() {

    const data = {
        pacienteId: parseInt(document.getElementById("pacienteId").value),
        doctorId: parseInt(document.getElementById("doctorId").value),
        fechaCita: document.getElementById("fechaCita").value,
        horaCita: document.getElementById("horaCita").value,
        motivo: document.getElementById("motivo").value
    };

    await fetch(`${baseUrl}/Crear`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    window.location.href = "/Citas";
}

//Elimina la cita por id 
async function eliminar(id) {

    if (!confirm("¿Seguro que desea eliminar esta cita?")) return;

    await fetch(`${baseUrl}/Eliminar?id=${id}`, {
        method: "DELETE"
    });

    cargarCitas();
}

//Se edita la cita por medio del ID
function editar(id) {
    window.location.href = `/Citas/Editar?id=${id}`;
}
// Se carga la cita en la vista de editar 
async function cargarCita() {

    const idInput = document.getElementById("citaId");
    if (!idInput) return;

    const id = idInput.value;

    const response = await fetch(`${baseUrl}/Buscar?id=${id}`);
    const c = await response.json();

    // Acá se envian los valores 
    document.getElementById("pacienteId").value = c.pacienteId;
    document.getElementById("doctorId").value = c.doctorId;
    document.getElementById("fechaCita").value = c.fechaCita;
    document.getElementById("horaCita").value = c.horaCita;
    document.getElementById("motivo").value = c.motivo;
    document.getElementById("estado").value = c.estado;
}

//Se actualiza la cita del formulario
async function actualizar() {

    const id = document.getElementById("citaId").value;

    const data = {
        pacienteId: parseInt(document.getElementById("pacienteId").value),
        doctorId: parseInt(document.getElementById("doctorId").value),
        fechaCita: document.getElementById("fechaCita").value,
        horaCita: document.getElementById("horaCita").value,
        motivo: document.getElementById("motivo").value,
        estado: parseInt(document.getElementById("estado").value)
    };

    await fetch(`${baseUrl}/Actualizar?id=${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    window.location.href = "/Citas";
}
// Se busca una cita por ID 
async function buscarPorId() {

    const id = document.getElementById("buscarId").value;

    if (!id) {
        alert("Ingrese un ID");
        return;
    }

    try {

        const response = await fetch(`${baseUrl}/Buscar?id=${id}`);

        if (!response.ok) {
            alert("Cita no encontrada");
            return;
        }

        const c = await response.json();

        const tbody = document.querySelector("#tablaCitas tbody");

        tbody.innerHTML = `
            <tr>
                <td>${c.citaId}</td>
                <td>
                    ${c.pacienteNombre}
                    <br><small>ID: ${c.pacienteId}</small>
                </td>
                <td>
                    ${c.doctorNombre}
                    <br><small>ID: ${c.doctorId}</small>
                </td>
                <td>${c.fechaCita}</td>
                <td>${c.horaCita}</td>
                <td>${c.motivo}</td>
                <td>${c.estado}</td>
                <td>
                    <button class="btn btn-warning btn-sm" onclick="editar(${c.citaId})">Editar</button>
                    <button class="btn btn-danger btn-sm" onclick="eliminar(${c.citaId})">Eliminar</button>
                </td>
            </tr>
        `;

    } catch (error) {
        console.error("Error buscando cita:", error);
    }
}