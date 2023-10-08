# Programación avanzada II - UNLaM 2023
## TP Principal Grupo 4

#### Tecnologías utilizadas:
- ASP.NET 6 Web API
- Entity Framework Core 7
- SQL Server 2022

La aplicación es una API REST que consiste en un ABM de animales de un refugio. A continuación se listan todas las operaciones que se pueden realizar:

1. **Crear animal ->** POST https://localhost:7167/api/animales
2. **Editar animal ->** PUT https://localhost:7167/api/animales/{id}
3. **Borrar animal ->** DELETE https://localhost:7167/api/animales/{id}
4. **Listar animales ->** GET https://localhost:7167/api/animales
5. **Visualizar animal ->** GET https://localhost:7167/api/animales/{id}
6. **Buscar animales por color y/o especie ->** GET https://localhost:7167/api/animales/buscar?color={color}&especie={especie}
7. **Listar razas ->** GET https://localhost:7167/api/animales/razas (registros precargados)
8. **Listar refugios ->** GET https://localhost:7167/api/refugios (registros precargados)
