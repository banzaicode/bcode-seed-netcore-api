# AGENTS.md

## Objetivo del proyecto

Este repositorio es una API RESTful en .NET 8 que sirve como plantilla base para nuevos desarrollos. Está diseñada para seguir principios SOLID, mantener una arquitectura limpia y desacoplada, y facilitar la extensibilidad en futuros proyectos.

---

## Convenciones de desarrollo

- Utilizar **.NET 8**.
- Usar el patrón **Minimal API**.
- Los endpoints se organizan en carpetas bajo `src/Modules/<NombreModulo>/Endpoints`.
- Cada módulo define su propio **registro de endpoints** y se registra usando `app.Register<Module>()`.

---

## Estructura del proyecto

```console
bcode-seed-netcore-api/
│
├── src/                          # Código fuente de la aplicación
│   ├── Application/             # Lógica compartida entre módulos (DTOs, interfaces, comandos)
│   ├── Infrastructure/          # Implementaciones concretas (bases de datos, servicios externos, etc.)
│   ├── Modules/                 # Cada módulo agrupa un dominio funcional
│   │   ├── <NombreModulo>/      
│   │   │   ├── Endpoints/       # Definición de endpoints HTTP del módulo y configuración de rutas.
│   │   │   ├── Handlers/        # Implementación de la lógica de negocio (comandos, queries, usualmente con MediatR).
│   │   │   ├── Validators/      # Validaciones usando FluentValidation
│   │   │   ├── Requests/        # DTOs de entrada si no están en Application
│   │   │   └── Responses/       # DTOs de salida si no están en Application
│   │   └── ...
│   ├── Shared/                  # Código utilitario común (errores, helpers, middlewares)
│   └── Program.cs               # Entrada principal del proyecto
│
├── tests/                       # Proyecto de tests
│   ├── Unit/                    # Pruebas unitarias
│   │   └── Modules/
│   │       └── <NombreModulo>/
│   │           └── <Clase>Tests.cs
│   ├── Integration/             # Pruebas de integración
│   │   ├── Fixtures/            # Fixtures reutilizables
│   │   └── <Tests>.cs
│   └── TestHelpers/             # Helpers para tests (fakes, mocks, etc.)
│
├── .editorconfig                # Reglas de estilo de código
├── .gitignore
├── AGENTS.md                    # Archivo de reglas y directivas para IA y desarrolladores
├── README.md
└── bcode-seed-netcore-api.sln  # Solución de Visual Studio
```

---

## Estilo de código

- **PascalCase** para clases, métodos, propiedades públicas y enums.
- **camelCase** para variables internas, parámetros y campos privados.
- Los nombres de archivos deben coincidir con el nombre de la clase que contienen.
- Los namespaces deben coincidir con la ruta del archivo.

---

## Reglas generales

- **Prohibido usar `Console.WriteLine`**. Usar `ILogger<T>` para loguear.
- Preferir `async/await` en todas las operaciones asíncronas.
- Agregar **comentarios XML** en métodos y clases públicas expuestas.
- Separar cada responsabilidad en su clase. Aplicar **SRP (Single Responsibility Principle)**.
- Inyectar dependencias a través de constructor o `AddScoped<>` en el módulo correspondiente.
- Validar todos los inputs con **FluentValidation**. No validar manualmente.

---

## Pruebas

- Las pruebas unitarias se ubican en `/tests/Unit`, organizadas por módulo.
- Usar **xUnit** como framework de testing.
- Nombrar las clases de prueba como `<Clase>Tests`.
- Para pruebas de integración usar `/tests/Integration` y fixtures compartidas.

---

## 📘 README.md del proyecto

El archivo `README.md` debe mantenerse siempre actualizado automáticamente o manualmente con cada nueva funcionalidad agregada.

### Estructura esperada del README:

1. **Resumen general del proyecto** (como se encuentra actualmente).
2. **Tecnologías utilizadas**.
3. **Estructura del repositorio**.
4. **Guía para desarrolladores**:
   - Cómo iniciar el proyecto.
   - Requisitos previos.
   - Variables de entorno necesarias.
   - Cómo ejecutar localmente, con Docker y Docker Compose.
5. **Funcionalidades de la API**:
   - Descripción por módulo o endpoint.
   - Responsabilidades de cada handler.
   - Validaciones esperadas.
6. **Ejemplos de uso**:
   - Cómo probar endpoints con `curl` o Postman.
   - Posibles respuestas.

---

## 🚀 Despliegue y ejecución

La API debe poder ejecutarse en cualquiera de las siguientes formas, siempre que aplique:

- ✅ **Nativamente** (`dotnet run`) desde `src/`.
- ✅ **Docker**: mediante un `Dockerfile` funcional y optimizado.
- ✅ **Docker Compose**: si la API necesita servicios externos (por ejemplo, SQL Server, PostgreSQL, Redis, Kafka, etc.), deben estar definidos en un archivo `docker-compose.yml`.

En caso de que la API agregue un nuevo componente que necesite soporte (como base de datos, cola de mensajes, etc.), **el `docker-compose.yml` debe actualizarse** para que la ejecución del proyecto siga funcionando de forma integral.

---

## Agentes de IA

- El **agente principal** genera nuevos módulos completos (handlers, endpoints, validadores).
- El **agente secundario** crea pruebas unitarias e integración para cada nuevo componente.
- El **agente de documentación** actualiza el `README.md` con la descripción, ejemplos y despliegue de cada nueva funcionalidad.
- Todos los agentes deben seguir las convenciones de estilo, estructura y arquitectura del proyecto.

---

## Buenas prácticas

- Siempre inicializar nuevas features como un nuevo módulo bajo `/Modules`.
- Evitar la lógica en el endpoint; delegar al handler.
- Toda excepción debe lanzar `ApiException` personalizada si es controlada.
- Los endpoints deben devolver resultados tipados (`Results.Ok(...)`, `Results.NotFound(...)`, etc).
- No exponer directamente las entidades de base de datos.
- No sobrecargar clases (SRP): dividir si superan las 200 líneas.
- Toda nueva funcionalidad debe venir con su correspondiente test.
- Nunca dejar endpoints sin documentación o ejemplos de uso.

---

## Autores y contribución

Este proyecto es mantenido por la organización [banzaicode](https://github.com/banzaicode). Para contribuir, seguir las directrices de código limpio y mantener coherencia con los módulos existentes.
