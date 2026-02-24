document.addEventListener("DOMContentLoaded", () => {
    cargarTotales();
});

async function cargarTotales() {
    try {

        // PACIENTES
        const pacientes = await fetch("http://localhost:5003/api/Pacientes/Listar");
        const pacientesData = await pacientes.json();
        document.getElementById("totalPacientes").innerText = pacientesData.length;

        // DOCTORES
        const doctores = await fetch("http://localhost:5003/api/Doctores/Listar");
        const doctoresData = await doctores.json();
        document.getElementById("totalDoctores").innerText = doctoresData.length;

        // ESPECIALIDADES
        const especialidades = await fetch("http://localhost:5003/api/Especialidades/Listar");
        const especialidadesData = await especialidades.json();
        document.getElementById("totalEspecialidades").innerText = especialidadesData.length;

        // CITAS HOY
        const citas = await fetch("http://localhost:5003/api/Citas/Listar");
        const citasData = await citas.json();

        const hoy = new Date().toISOString().split("T")[0];

        const citasHoy = citasData.filter(c => c.fechaCita === hoy);

        document.getElementById("totalCitasHoy").innerText = citasHoy.length;

    }
    catch (error) {
        console.error("Error cargando dashboard:", error);
    }
    }