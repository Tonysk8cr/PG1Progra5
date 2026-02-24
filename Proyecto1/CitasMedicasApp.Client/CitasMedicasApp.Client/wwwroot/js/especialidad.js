const baseUrl = "http://localhost:5003/api/Especialidades";

document.addEventListener("DOMContentLoaded", () => {
    cargarEspecialidades();
});

async function cargarEspecialidades() {
    const response = await fetch(`${baseUrl}/Listar`);
    const data = await response.json();

    const tbody = document.querySelector("#tablaEspecialidades tbody");
    tbody.innerHTML = "";

    data.forEach(e => {
        tbody.innerHTML += `
            <tr>
                <td>${e.especialidadId}</td>
                <td>${e.nombre}</td>
            </tr>
        `;
    });
}

    cargarEspecialidades();
