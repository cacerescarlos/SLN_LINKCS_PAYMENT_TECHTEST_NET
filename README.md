# 💳 Payment Management API

API RESTful para la gestión de pagos desarrollada con .NET 8, siguiendo los principios de **Clean Architecture** y utilizando **Dapper** como micro-ORM para acceso a datos.

## 📋 Tabla de Contenidos

- [💳 Payment Management API](#-payment-management-api)
  - [📋 Tabla de Contenidos](#-tabla-de-contenidos)
  - [🎯 Descripción General](#-descripción-general)
    - [Características principales:](#características-principales)
  - [🏗️ Arquitectura](#️-arquitectura)
    - [Capas del Proyecto:](#capas-del-proyecto)
  - [🛠️ Tecnologías](#️-tecnologías)
    - [Stack Principal:](#stack-principal)
    - [Librerías Adicionales:](#librerías-adicionales)
  - [📦 Requisitos Previos](#-requisitos-previos)
    - [Verificar instalaciones:](#verificar-instalaciones)
  - [⚙️ Configuración del Entorno](#️-configuración-del-entorno)
    - [1. Clonar el Repositorio](#1-clonar-el-repositorio)
    - [2. Iniciar SQL Server en Docker](#2-iniciar-sql-server-en-docker)
    - [3. Crear la Base de Datos y Tablas](#3-crear-la-base-de-datos-y-tablas)
  - [🚀 Ejecución del Proyecto](#-ejecución-del-proyecto)
    - [Desde Visual Studio:](#desde-visual-studio)
    - [Desde CLI:](#desde-cli)
  - [📡 Endpoints de la API](#-endpoints-de-la-api)
    - [Base URL: `https://localhost:7xxx/api/payments`](#base-url-httpslocalhost7xxxapipayments)
    - [1. Crear un Pago](#1-crear-un-pago)
  - [🗄️ Base de Datos](#️-base-de-datos)
    - [Esquema de la Tabla `Payments`](#esquema-de-la-tabla-payments)
    - [Connection String](#connection-string)
  - [📜 Reglas de Negocio](#-reglas-de-negocio)
    - [Estados de Pago](#estados-de-pago)
    - [Validaciones Automáticas](#validaciones-automáticas)
    - [Estándares de Código](#estándares-de-código)
  - [📄 Licencia](#-licencia)
  - [👨‍💻 Autor](#-autor)
  - [📚 Recursos Adicionales](#-recursos-adicionales)

---

## 🎯 Descripción General

Sistema de gestión de pagos que permite registrar y consultar transacciones de clientes. La solución implementa validaciones de negocio, manejo de errores y persistencia de datos en SQL Server.

### Características principales:

- ✅ Registro de pagos con validaciones automáticas
- ✅ Consulta de pagos por cliente
- ✅ Estados de pago: Pendiente, Confirmado, Rechazado
- ✅ Validación de montos máximos (límite: 1500 BS)
- ✅ Persistencia en SQL Server con Docker
- ✅ Documentación automática con Swagger/OpenAPI

---

## 🏗️ Arquitectura

El proyecto sigue los principios de **Clean Architecture**, garantizando separación de responsabilidades, independencia de frameworks y facilidad de testing.


### Capas del Proyecto:

| Capa | Responsabilidad | Dependencias |
|------|----------------|--------------|
| **Domain** | Entidades de negocio, enums, reglas de dominio | Ninguna |
| **Application** | Lógica de aplicación, casos de uso, DTOs | Domain |
| **Infrastructure** | Acceso a datos, repositorios, Dapper | Domain, Application |
| **Presentation** | API REST, controladores, configuración | Application, Infrastructure |

---

## 🛠️ Tecnologías

### Stack Principal:
- **[.NET 8](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)** - Framework principal
- **[C# 12](https://learn.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-12)** - Lenguaje de programación
- **[ASP.NET Core 8](https://learn.microsoft.com/es-es/aspnet/core/)** - Framework web
- **[Dapper](https://github.com/DapperLib/Dapper)** - Micro-ORM de alto rendimiento
- **[SQL Server 2022](https://www.microsoft.com/es-es/sql-server/sql-server-2022)** - Base de datos
- **[Docker](https://www.docker.com/)** - Contenedores para SQL Server
- **[Swagger/OpenAPI](https://swagger.io/)** - Documentación de API

### Librerías Adicionales:
- `Microsoft.Data.SqlClient` - Proveedor de datos SQL
- `Swashbuckle.AspNetCore` - Generación de documentación Swagger

---

## 📦 Requisitos Previos

Antes de comenzar, asegúrate de tener instalado:

- **[.NET 8 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)** (8.0 o superior)
- **[Docker Desktop](https://www.docker.com/products/docker-desktop/)** (para SQL Server)
- **[Visual Studio 2022](https://visualstudio.microsoft.com/es/)** o **[VS Code](https://code.visualstudio.com/)** (opcional)
- **[Git](https://git-scm.com/)** (para clonar el repositorio)

### Verificar instalaciones:
dotnet --version      # Debe mostrar 8.x.x docker --version      # Debe mostrar Docker version 20.x.x o superior


---

## ⚙️ Configuración del Entorno

### 1. Clonar el Repositorio
git clone https://github.com/tu-usuario/payment-api.git cd payment-api

### 2. Iniciar SQL Server en Docker

Desde la raíz del proyecto, ejecuta: docker-compose up -d

Esto iniciará un contenedor de SQL Server 2022 en el puerto `1433`.

### 3. Crear la Base de Datos y Tablas
| Copiar el script al contenedor
- docker cp LINKCS.PAYMENT.TECHTEST.INFRASTRUCTURE/Scripts/InitDatabase.sql sqlserver_payment:/tmp/InitDatabase.sql

| Ejecutar el script
- docker exec sqlserver_payment /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "Pass@word123" -i /tmp/InitDatabase.sql -C


---

## 🚀 Ejecución del Proyecto

### Desde Visual Studio:

1. Abrir la solución `SLN.LINKCS.PAYMENT.TECHTEST.sln`
2. Configurar `LINKCS.PAYMENT.TECHTEST.PRESENTATION` como proyecto de inicio
3. Presionar `F5` o hacer clic en el botón **▶ Run**

### Desde CLI:
cd LINKCS.PAYMENT.TECHTEST.PRESENTATION dotnet run


La API estará disponible en:
- **HTTPS**: `https://localhost:7xxx`
- **HTTP**: `http://localhost:5xxx`
- **Swagger UI**: `https://localhost:7xxx/swagger`

---

## 📡 Endpoints de la API

### Base URL: `https://localhost:7xxx/api/payments`

### 1. Crear un Pago

**POST** `/api/payments`

Registra un nuevo pago en el sistema.

**Request Body:**
{ "customerId": "CUST001", "serviceProvider": "Servicio de Luz EDELCA", "amount": 500.50 }

**Response Success (200 OK):**
"Pago guardado con éxito. ID de Pago: 3fa85f64-5717-4562-b3fc-2c963f66afa6"

---

## 🗄️ Base de Datos

### Esquema de la Tabla `Payments`

| Columna | Tipo | Constraints | Descripción |
|---------|------|-------------|-------------|
| `PaymentId` | `NVARCHAR(100)` | PRIMARY KEY | Identificador único (GUID) |
| `CustomerId` | `NVARCHAR(100)` | NOT NULL | Identificador del cliente |
| `ServiceProvider` | `NVARCHAR(200)` | NOT NULL | Nombre del proveedor de servicio |
| `Amount` | `DECIMAL(18,2)` | NOT NULL | Monto del pago en BS |
| `Status` | `NVARCHAR(20)` | NOT NULL, CHECK | Estado: `pendiente`, `confirmado`, `rechazado` |
| `CreatedAt` | `DATETIME2` | NOT NULL, DEFAULT GETUTCDATE() | Fecha de creación (UTC) |

### Connection String
{ "ConnectionStrings": { "DefaultConnection": "Server=localhost,1433;Database=PaymentDb;User Id=sa;Password=Pass@word123;TrustServerCertificate=true;MultipleActiveResultSets=true;" } }


---

## 📜 Reglas de Negocio

### Estados de Pago

| Estado | Valor Enum | Descripción |
|--------|-----------|-------------|
| `pendiente` | 0 | Estado inicial de todo pago |
| `confirmado` | 1 | Pago procesado exitosamente |
| `rechazado` | 2 | Pago rechazado por validaciones |

### Validaciones Automáticas

1. **Monto Negativo**
   - Si `amount < 0` → Estado: `rechazado`
   - Mensaje: "Pago rechazado: monto debe ser mayor que cero."

2. **Monto Excesivo**
   - Si `amount > 1500` → Estado: `rechazado`
   - Mensaje: "Pago rechazado: monto excede el límite de 1500 BS."

3. **Campos Requeridos**
   - `customerId`: Obligatorio
   - `serviceProvider`: Obligatorio
   - `amount`: Obligatorio

---


### Estándares de Código

- Seguir principios SOLID
- Mantener la arquitectura limpia
- Documentar código complejo
- Escribir tests unitarios
- Usar nombres descriptivos en inglés

---

## 📄 Licencia

Este proyecto es parte de una prueba técnica y está disponible bajo la licencia MIT.

---

## 👨‍💻 Autor

Desarrollado como parte de una prueba técnica para LINKCS.

**Contacto:**
- Email: ccaceres0461@gmail.com
- LinkedIn: [Carlos Caceres](https://linkedin.com/in/ccaceres461)
- GitHub: [@cacerescarlos](https://github.com/cacerescarlos

---

## 📚 Recursos Adicionales

- [Clean Architecture - Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Dapper Documentation](https://github.com/DapperLib/Dapper)
- [ASP.NET Core Best Practices](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/best-practices)
- [Docker SQL Server](https://learn.microsoft.com/es-es/sql/linux/quickstart-install-connect-docker)

---

⭐ Si este proyecto te fue útil, considera darle una estrella en GitHub.