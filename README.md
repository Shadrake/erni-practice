# ERNI Practice – ASP.NET Core API

Proyecto de práctica personal para reforzar los fundamentos de desarrollo backend con **ASP.NET Core**, enfocado a la preparación de entrevistas técnicas para un puesto **junior**.

El objetivo principal no es construir una aplicación compleja, sino **demostrar comprensión de los conceptos base**, buenas prácticas y capacidad de aprendizaje.

---

## Objetivos del proyecto

- Repasar fundamentos de C# y ASP.NET Core
- Construir una API REST sencilla y bien estructurada
- Aplicar buenas prácticas básicas de backend
- Introducir Entity Framework Core y acceso a datos
- Aprender nociones básicas de testing
- Practicar una forma de trabajo incremental (Agile mindset)

---

## Descripción funcional

La aplicación es una **API REST de gestión de tareas** (*Task Management*).

Permite:
- Crear tareas
- Consultar tareas
- Actualizar su estado y prioridad
- Eliminar tareas

Es un dominio sencillo y neutro, pensado para centrarse en la **arquitectura y el proceso**, no en la complejidad del negocio.

---

## Tecnologías utilizadas

- .NET / ASP.NET Core
- C#
- Entity Framework Core
- Swagger (OpenAPI)
- SQLite (para desarrollo)
- xUnit (testing)
- GitHub Codespaces

---

## Cómo ejecutar el proyecto

1. Clonar el repositorio
2. Abrir en GitHub Codespaces
3. Ejecutar:

```bash
dotnet run --urls "http://0.0.0.0:5164"
