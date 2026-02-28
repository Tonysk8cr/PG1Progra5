# Documentación Técnica de la API - Proyecto 1


## Índice

1. [Introducción](#introducción)
2. [Endpoints](#endpoints)
   - [Citas](#citas)
   - [Doctores](#doctores)
   - [Especialidades](#especialidades)
   - [Pacientes](#pacientes)

---

## Introducción

La siguiente documentación tiene como meta desarrollar la documentación técnica de la API desarrollada para el proyecto 1 del curso de programación 5. El actual documento sirve como complemento a la documentación del repositorio de GitHub.

---

## Endpoints

### Citas

**URL Base:** `/api/citas`

#### GET - Listar todas las citas

**URL:** `/api/citas/Listar`

Endpoint encargado de obtener la lista completa de las citas registradas. Este método no recibe ningún parámetro.

**Respuesta exitosa (200):**
```json
[{
    "citaId": 1,
    "pacienteId": 35,
    "pacienteNombre": "Randy Jiménez",
    "doctorId": 2,
    "doctorNombre": "Dra. Sofía Martínez",
    "fechaCita": "2026-02-27",
    "horaCita": "08:30:00",
    "motivo": "Consulta pediátrica",
    "estado": 1
}]
```

#### GET - Buscar cita por ID

**URL:** `/api/citas/Buscar?id={id}`

Permite buscar una cita específica por su identificador.

**Parámetros:**
- `id` (integer) - Identificador de la cita

**Respuesta exitosa (200):**
```json
{
    "citaId": 5,
    "pacienteId": 11,
    "pacienteNombre": "Andrés López",
    "doctorId": 6,
    "doctorNombre": "Dra. Irene Solís",
    "fechaCita": "2026-02-25",
    "horaCita": "09:30:00",
    "motivo": "Revisión de tratamiento",
    "estado": 1
}
```

#### POST - Crear nueva cita

**URL:** `/api/citas/Crear`

Crea una nueva cita médica.

**Cuerpo (Body):**
```json
{
    "citaId": 0,
    "pacienteId": 11,
    "pacienteNombre": "Andrés López",
    "doctorId": 6,
    "doctorNombre": "Dra. Irene Solís",
    "fechaCita": "2026-02-25",
    "horaCita": "09:30:00",
    "motivo": "Revisión de tratamiento",
    "estado": 1
}
```

**Consideraciones:**
- La fecha no puede ser menor a la fecha actual
- El doctor debe existir en la base de datos

**Respuesta en caso de error (400):** Bad Request

#### PUT - Actualizar cita

**URL:** `/api/citas/Actualizar?id={id}`

Actualiza una cita existente.

**Parámetros:**
- `id` (integer) - Identificador de la cita

**Cuerpo (Body):**
```json
{
    "citaId": 0,
    "pacienteId": 11,
    "pacienteNombre": "Andrés López",
    "doctorId": 6,
    "doctorNombre": "Dra. Irene Solís",
    "fechaCita": "2026-02-25",
    "horaCita": "09:30:00",
    "motivo": "Revisión de tratamiento",
    "estado": 1
}
```

**Respuesta en caso de error (404):** Not Found

#### DELETE - Eliminar cita

**URL:** `/api/citas/Eliminar?id={id}`

Elimina una cita existente.

**Parámetros:**
- `id` (integer) - Identificador de la cita

**Respuesta exitosa (200):** Mensaje indicando que la cita fue eliminada

---

### Doctores

**URL Base:** `/api/doctores`

#### GET - Listar todos los doctores

**URL:** `/api/doctores/Listar`

Devuelve una lista con todos los doctores registrados. No requiere ningún parámetro.

**Respuesta exitosa (200):**
```json
[{
    "doctorId": 1,
    "nombre": "Dr. Álvaro Rojas",
    "especialidadId": 1,
    "especialidadNombre": "Cardiología",
    "telefono": "+506 2221-1001",
    "email": "dr.alvaro.rojas@clinicacr.com",
    "activo": true
}]
```

#### GET - Buscar doctor por ID

**URL:** `/api/doctores/Buscar?id={id}`

Devuelve un doctor específico por su identificador.

**Parámetros:**
- `id` (integer) - Identificador del doctor

**Respuesta exitosa (200):**
```json
{
    "doctorId": 2,
    "nombre": "Dra. Sofía Martínez",
    "especialidadId": 2,
    "especialidadNombre": "Pediatría",
    "telefono": "+506 2222-1002",
    "email": "dra.sofia.martinez@clinicacr.com",
    "activo": true
}
```

**Respuesta en caso de error (404):** Not Found - El doctor no existe

#### POST - Crear doctor

**URL:** `/api/doctores/Crear`

Crea un nuevo registro de doctor.

**Cuerpo (Body):**
```json
{
    "doctorId": 0,
    "nombre": "nombre",
    "especialidadId": 2,
    "especialidadNombre": "Pediatría",
    "telefono": "+506 2222-1002",
    "email": "dra.sofia.martinez@clinicacr.com",
    "activo": true
}
```

#### PUT - Actualizar doctor

**URL:** `/api/doctores/Actualizar?id={id}`

Actualiza un doctor existente.

**Parámetros:**
- `id` (integer) - Identificador del doctor

**Cuerpo (Body):**
```json
{
    "doctorId": 0,
    "nombre": "nombre",
    "especialidadId": 2,
    "especialidadNombre": "Pediatría",
    "telefono": "+506 2222-1002",
    "email": "dra.sofia.martinez@clinicacr.com",
    "activo": true
}
```

**Respuesta en caso de error (404):** Not Found - El doctor no existe

#### DELETE - Eliminar doctor

**URL:** `/api/doctores/Eliminar?id={id}`

Elimina un doctor existente.

**Parámetros:**
- `id` (integer) - Identificador del doctor

**Respuesta exitosa (200):** Mensaje indicando que el doctor fue eliminado

---

### Especialidades

**URL Base:** `/api/especialidades`

#### GET - Listar todas las especialidades

**URL:** `/api/especialidades/Listar`

Devuelve la lista completa de especialidades. No tiene parámetros.

**Respuesta exitosa (200):**
```json
[{
    "especialidadId": 1,
    "nombre": "Cardiología",
    "activo": true
}]
```

---

### Pacientes

**URL Base:** `/api/pacientes`

#### GET - Listar todos los pacientes

**URL:** `/api/pacientes/Listar`

Devuelve una lista con todos los pacientes registrados. No requiere ningún parámetro.

**Respuesta exitosa (200):**
```json
[{
    "pacienteId": 1,
    "nombre": "Juan Pérez",
    "edad": 82,
    "telefono": "+506 8881-1001",
    "email": "juan.perez@email.com",
    "activo": true
}]
```

#### GET - Buscar paciente por ID

**URL:** `/api/pacientes/Buscar?id={id}`

Devuelve un paciente específico por su identificador.

**Parámetros:**
- `id` (integer) - Identificador del paciente

**Respuesta exitosa (200):**
```json
{
    "pacienteId": 1,
    "nombre": "Juan Pérez",
    "edad": 82,
    "telefono": "+506 8881-1001",
    "email": "juan.perez@email.com",
    "activo": true
}
```

#### POST - Crear paciente

**URL:** `/api/pacientes/Crear`

Crea un nuevo registro de paciente.

**Cuerpo (Body):**
```json
{
    "pacienteId": 0,
    "nombre": "Juan Pérez",
    "edad": 82,
    "telefono": "+506 8881-1001",
    "email": "juan.perez@email.com",
    "activo": true
}
```

#### PUT - Actualizar paciente

**URL:** `/api/pacientes/Actualizar?id={id}`

Actualiza un paciente existente.

**Parámetros:**
- `id` (integer) - Identificador del paciente

**Cuerpo (Body):**
```json
{
    "pacienteId": 0,
    "nombre": "Juan Pérez",
    "edad": 82,
    "telefono": "+506 8881-1001",
    "email": "juan.perez@email.com",
    "activo": true
}
```

**Respuesta en caso de error (404):** Not Found - El paciente no existe

#### DELETE - Eliminar paciente

**URL:** `/api/pacientes/Eliminar?id={id}`

Elimina un paciente existente.

**Parámetros:**
- `id` (integer) - Identificador del paciente

**Respuesta exitosa (200):** Mensaje indicando que el paciente fue eliminado

---
