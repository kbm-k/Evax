# Evax

The repository is used to learn and test new technologies in practice. Evax is a simple restaurant management system.

## Getting Started

Solution is built using microservices architecture. Microservices are placed behind of API Gateway, called Web.API, it is a RESTful API service and acts as a BFF for web. API Gateway communicates with microservices using gRpc, microservices communicate with each other by asynchronous protocol. Each microservice represents a bounded context.

### Inventory

Inventory microservice is built using Clean Architecture. Simple service created using .NET 5, EF Core 5, gRpc, C# 9.

### BookingManagement

BookingManagement microservice will be built using DDD, CQRS. There will be write-only Azure SQL Database and read-only MongoDB database. 

## Built With

* [Backends For Frontends](https://samnewman.io/patterns/architectural/bff/) - Pattern: Backends For Frontends
* [API Gateway](https://microservices.io/patterns/apigateway.html) - Pattern: API Gateway / Backends for Frontends
* [The Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) - The Clean Architecture