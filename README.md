# ToDoListAPI
API REST para gestionar usuarios y sus tareas, hecha con ASP.NET Core y SQL Server.

## Tecnologías

- C# y .NET 10
- ASP.NET Core Web API
- SQL Server, con acceso a datos mediante Microsoft.Data.SqlClient
- Swagger para documentar y probar la API
- Inyección de dependencias con interfaces para los repositorios

## Estructura del proyecto

El proyecto está separado en capas:

- Controllers: reciben las peticiones HTTP y devuelven las respuestas.
- Services: contienen la lógica de la aplicación
- Repositories: acceden a la base de datos
- DTOs: objetos que se usan para recibir y enviar datos por la API.
- Models: entidades que representan los datos.

## Endpoints

Al ejecutar el proyecto, Swagger lista todos los endpoints disponibles en `/swagger`.


| Método  |          Ruta             |       Descripción                          |
|---------|---------------------------|--------------------------------------------|
|GET      | /api/ToDoItem/GetAllTasks | Obtener todas las tareas                   | 
|GET      | /api/ToDoItem/GetTaskUser | Obtener las tareas de un usuario específico|
|GET      | /api/ToDoItem/GetToDoItem | Obtener una tarea específica               |
|POST     | /api/ToDoItem/PostTask    | Crear nueva tarea                          |
|GET      | /api/User/GetUser         | Obtener todos los usuarios                 |
|GET      | /api/User/GetUserById     | Obtener un usuario en específico           |
|POST     | /api/User/PostUser        | Crear un nuevo usuario                     |

## Cómo ejecutarlo

Requisitos: .NET 10 SDK y una instancia de SQL Server.

1. Clonar el repositorio.
2. Crear la base de datos `ToDoAppDB` y sus tablas (ver la sección siguiente).
3. Configurar la cadena de conexión en `appsettings.json`, reemplazando `TU_SERVIDOR_SQL` por tu servidor:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=TU_SERVIDOR_SQL;Initial Catalog=ToDoAppDB;Integrated Security=True;Trust Server Certificate=True"
   }
   ```

4. Ejecutar el proyecto y abrir Swagger en `/swagger` para probar los endpoints.

## Base de datos

Script SQL de las tablas: pendiente.

