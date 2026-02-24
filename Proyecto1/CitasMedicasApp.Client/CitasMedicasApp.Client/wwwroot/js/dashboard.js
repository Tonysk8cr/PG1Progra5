document.addEventListener("DOMContentLoaded", () => {
    cargarTotales();
});

async function cargarTotales() {
    try {

        // Se realizan las peticiones a cada endpoint para obtener los datos y luego se actualizan los elementos del dashboard
        const pacientes = await fetch("http://localhost:5003/api/Pacientes/Listar");
        const pacientesData = await pacientes.json();
        document.getElementById("totalPacientes").innerText = pacientesData.length;

        //En doctores se obtiene la lista de doctores y se actualiza el total de doctores en el dashboard
        const doctores = await fetch("http://localhost:5003/api/Doctores/Listar");
        const doctoresData = await doctores.json();
        document.getElementById("totalDoctores").innerText = doctoresData.length;

        // En especialidades se obtiene la lista de especialidades y se actualiza el total de especialidades en el dashboard
        const especialidades = await fetch("http://localhost:5003/api/Especialidades/Listar");
        const especialidadesData = await especialidades.json();
        document.getElementById("totalEspecialidades").innerText = especialidadesData.length;

        // En ciatas se obtiene la lista de citas, se filtran las citas del día actual y se actualiza el total de citas del día en el dashboard
        const citas = await fetch("http://localhost:5003/api/Citas/Listar");
        const citasData = await citas.json();

        // Total de todas las citas
        document.getElementById("totalCitasHoy").innerText = citasData.length;
    }
    catch (error) {
        console.error("Error cargando dashboard:", error);
    }
}