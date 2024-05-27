# Backend Empleo Empresarial

## Instrucciones

Para comenzar, sigue estos pasos:

1. Clona este repositorio en tu máquina local.

## Nota

Este proyecto utiliza SQL Server 2016 como base de datos. A continuación, se detallan algunas instrucciones importantes:

- **Backup de la Base de Datos**: En la ruta `BackendEmpleoEmpressarial\Utils\CopiaEmpleoEmpresarial.bak`, encontrarás una copia de seguridad de la base de datos.

- **Script de Generación de la Base de Datos**: Si por alguna razón la restauración de la base de datos falla, puedes utilizar el script en `BackendEmpleoEmpressarial\Utils\scriptEmpleoEmpresarial.sql` para generar la base de datos desde cero.

Asegúrate de seguir estos pasos para evitar problemas:

1. Configura la cadena de conexión con el nombre de tu servidor.
2. La base de datos debe llamarse "EmpleoEmpresarial" para garantizar la coherencia entre los modelos creados.

# Información de Registros en la Base de Datos

## Usuarios Tipo Empresa

1. **EmpresaUno**
   - **Contraseña:** admin
   - **Ofertas Publicadas:** 2

2. **EmpresaDos**
   - **Contraseña:** admin
   - **Ofertas Publicadas:** 1

## Usuarios Tipo Persona

1. **PersonaUno**
   - **Contraseña:** admin

2. **PersonaDos**
   - **Contraseña:** admin

Cada usuario puede ver las 3 ofertas laborales.

Además, hay registros de tablas maestras.


# Características Funcionales

1. Utiliza .NET 8.0
2. Utiliza Entity Framework
3. Estructura por capas
4. Uso de rollback
5. Control de excepciones

