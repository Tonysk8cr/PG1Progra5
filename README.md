# Repositorio del Grupo 1 – Programación 5

Repositorio del curso de **Programación 5**  
**Universidad Hispanoamericana** | I Cuatrimestre 2026

---

## Guía de inicio

Para poder trabajar localmente con los archivos de este repositorio, es necesario tener **Git** instalado en su computadora.


### Instalación de Git

Para iniciar y obtener acceso local a los archivos del repositorio, es necesario contar con Git instalado.

#### ¿Cómo instalar Git?
Para instalar Git, simplemente seguí los pasos indicados en la página oficial:

https://git-scm.com/install/


### Configuración de Git y vinculación con GitHub

Una vez instalado Git, se debe proceder a vincular la cuenta de GitHub mediante la terminal (CMD).  
Para ello, podés seguir la guía oficial:

https://docs.github.com/en/get-started/git-basics/set-up-git



### Uso de GitHub Desktop (opcional)

Si no se tiene experiencia utilizando el CMD y se está trabajando en una computadora con **Windows**, se recomienda utilizar **GitHub Desktop**, el cual proporciona una interfaz gráfica más sencilla:

https://desktop.github.com/download/



### Clonar el repositorio desde CMD

**Importante:**  
Antes de ejecutar el siguiente comando, asegurate de estar ubicado en la carpeta correcta, ya que el repositorio se clonará en la ruta desde donde se ejecute el CMD.

```bash
git clone https://github.com/Tonysk8cr/PG1Progra5.git
```

---

## Configuracion especifica del proyecto 1

El Proyecto 1 corresponde a la aplicación de citas médicas.

Debido a que el proyecto fue desarrollado inicialmente de manera local, existen algunas configuraciones que deben ajustarse, principalmente relacionadas con la base de datos.

### Configuración de la base de datos

1. Dentro del subfolder Proyecto 1, se encuentra el script de base de datos llamado SQLInicial.
2. Abrí el archivo con doble clic.
3. El sistema te pedirá seleccionar el motor de base de datos:
    * Elegí Microsoft SQL Server Management Studio.
4. Ejecutá el script completo.
    * Este script crea todas las tablas necesarias.
    * También incluye la creación de un usuario para la base de datos.

### Credenciales creadas por el script

* Usuario: `adminCitas`
* Contraseña: `grupo1progra5uh`

Estas credenciales ya están configuradas en el archivo de configuración del proyecto.

### Modificación del string de conexión

Como cada integrante trabaja en una máquina distinta, es necesario modificar el servidor del string de conexión:

1. Abrí el archivo appsettings.json.
2. Este archivo se encuentra en la capa de cliente.
3. Buscá la sección de conexión a la base de datos.
4. Modificá el valor del servidor:

```bash
    SERVER=TU_SERVIDOR_AQUÍ
```
Reemplazá `TU_SERVIDOR_AQUÍ` por el nombre o instancia de SQL Server de tu computadora.

---

## Integrantes
* Durán Díaz Dilan Alexis
* Fallas Calderón Yudi Mariel
* Fonseca Chinchilla Santiago [@Siggy1604](https://github.com/Siggy1604)
* Rodríguez Coronado Camila de los Ángeles
* Villalobos Hidalgo Anthony Emanuel [@Tonysk8cr](https://github.com/Tonysk8cr)

## Profesor a cargo

Salgado Vega Jonathan

## Universidad
Universidad Hispanoamericana – Costa Rica -> https://uh.ac.cr/
