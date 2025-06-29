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

## Agentes de IA

- El **agente principal** se encarga de generar nuevos módulos, endpoints y handlers siguiendo las convenciones anteriores.
- El **agente secundario** genera pruebas unitarias e integración para cada nuevo feature.
- El **agente de documentación** mantiene actualizado el README y los comentarios XML.

---

## Buenas prácticas

- Siempre inicializar nuevas features como un nuevo módulo bajo `/Modules`.
- Evitar la lógica en el endpoint; delegar al handler.
- Toda excepción debe lanzar `ApiException` personalizada si es controlada.
- Los endpoints deben devolver resultados tipados (`Results.Ok(...)`, `Results.NotFound(...)`, etc).

---

## Autores y contribución

Este proyecto es mantenido por la organización [banzaicode](https://github.com/banzaicode). Para contribuir, seguir las directrices de código limpio y mantener coherencia con los módulos existentes.
