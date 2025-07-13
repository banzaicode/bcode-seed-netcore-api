# AGENTS.md

## 🧭 Propósito del Repositorio

Este repositorio contiene una plantilla base (`StartKit`) para construir APIs RESTful en .NET Core, siguiendo las mejores prácticas de arquitectura, automatización y despliegue. Está diseñado para ser reutilizable dentro de proyectos de Banzaicode.

---

## 🤖 Objetivos de Codex

Codex debe asistir automatizando tareas, asegurando consistencia, y mejorando el código con criterios de calidad. Sus responsabilidades incluyen:

- Mantener actualizado el `README.md` con:
  - Objetivo del proyecto.
  - Cómo iniciar localmente.
  - Endpoints públicos.
  - Ejemplos de uso de la API.
- Escribir pruebas con xUnit para cada nuevo método público.
- Proponer refactors si hay duplicación o violaciones de SOLID.
- Mantener actualizados los archivos `Dockerfile`, `docker-compose.yml` y `.env.example`.
- Generar workflows de CI/CD para testear y desplegar la API.
- Sugerir mejoras en documentación bajo `/docs`.
- Incluir ejemplos de uso de la API en Postman si no existen.
- Asegurar la posibilidad de ejecutar el proyecto:
  - De forma nativa (.NET CLI).
  - Mediante Docker.
  - Mediante `docker-compose` con una base de datos asociada (por defecto SQL Server).

---

## 🗂️ Estructura del Proyecto

- `/src`: Código fuente de la API.
- `/tests`: Pruebas unitarias usando xUnit.
- `/docs`: Documentación adicional.
- `/infrastructure`: Archivos para Docker, CI/CD y despliegue.
- `/scripts`: Scripts útiles para desarrolladores.

---

## 🧑‍💻 Directrices de Desarrollo

- Usar C# 10+.
- Aplicar principios SOLID y patrón Repository.
- Métodos públicos deben tener comentarios XML.
- Código en inglés.
- Las clases deben tener una única responsabilidad clara.
- Uso de `IServiceCollection` para inyección de dependencias.
- Evitar lógica en controladores.

---

## 🧪 Testing

- Framework: xUnit.
- Usar `Moq` para mockear dependencias.
- Seguir Given / When / Then.
- Probar lógica de negocio, no solo los endpoints.
- Incluir pruebas de integración básicas para endpoints.

---

## 🔁 Automatización esperada

- Workflow GitHub Actions:
  - Ejecutar tests.
  - Validar linting (dotnet format).
  - Desplegar imagen Docker a un registry.
- Validar commits con Conventional Commits.
- Automatizar subida de cobertura de código (Coveralls o Codecov si se configura).

---

## 🔗 Referencias externas

- [Guía de estilo de C# - Microsoft](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Guías internas de Banzaicode](https://github.com/banzaicode/banzaicode-brain/tree/main/projects/csharp-guides.md)
- [Documentación oficial de xUnit](https://xunit.net/)

---

## 📚 Glosario

- **StartKit**: Proyecto base para APIs .NET Core.
- **Codex**: Agente AI que colabora en automatización del proyecto.
- **Moq**: Librería de mocking usada en pruebas con xUnit.
- **SOLID**: Conjunto de principios de diseño orientado a objetos.
- **CI/CD**: Integración continua / Despliegue continuo.
