# MishaTelecoms | Personal Project
---
## Description
MishaTelecoms is an application that handles/manages [CDR Data](https://en.wikipedia.org/wiki/Call_detail_record).
The end goal of the app is to have a Web UI where you can log on and manage your CDR Data and the users associated with it.

This application makes use of Domain Driven Design and Microservices Architechture for handling complexity, allowing for changes to be made easily
as the application evolves along with my skills as a programmer.

## High Level View - Control Flow Diagram
![](/Images/MishaTelecoms_ControlFlow.png)

## Roadmap

1. **API - In Progress**
	- Fix CDR Data Commands
	- Implement Auth & OAuth
	- Implement Stored Procedures (unsure)
	- Build User Controller
2. **Database - In Progress**
	- Fix CDR Data monolithic table
3. **CDRDataGenerator - In Progress**
	- Fix dependency issue (IMapper)
	- Make it conform to overall Architecture
4. **SMTP Relay - Not Started**
5. **Web UI - Not Started**

## Objectives

- Apply newly learnt concepts
- Create a scalable and modular application
- Cultivate and build upon good practices and habits

## Technologies
- [Asp.Net](https://dotnet.microsoft.com/apps/aspnet) -  Web Application Framework used
- [Dapper](https://github.com/DapperLib/Dapper) - ORM used for Data Access
- [AutoMapper](http://automapper.org/) - Mapping objects between layers
- [MediatR](https://github.com/jbogard/MediatR) - Application of Mediator Pattern
- [SwashBuckle](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0) - API Documentation

## Concepts learnt/Applied so far
- DDD/Onion Architecture
- SOLID
- Patterns
  - Repository
  - Mediator ~ Uses MediatR
  - CQRS ~ Uses MediatR
  - Decorator(Wrapper)
  - Mapping ~ Uses AutoMapper

# Project Overview

## MishaTelecoms.Domain
**Eric Evans**
>Responsible for representing concepts of the business, information about the business situation and business rules.

The **Domain** of the application contains the entities and value objects classes that define behaviour throughout the application.
### Folders
- **Data**:     Contains Value Objects that define interactions with Data.
- **Entities**: Contains the Business Domain Entities.
- **Settings**: Contains Value Objects for configurations of services.

## MishaTelecoms.Application
The **Application** layer of the program defines the jobs/problems the program is meant to solve
### Folders
- **Dtos**:       Contains Data transfer objects
- **Features**:   Contains Features for the services in the application(CQRS & Mediator patterns applied)
- **Interfaces**: Contains Interfacs used throughout multiple services in the application(Repository Pattern applied)
- **Wrappers**:   Contains Wrappers(Decorator/Wrapper pattern applied)
## MishaTelecoms.Infrastructure
Provides support for higher layers in the application. Eg. Data Access
### Folders
- **Data**:        Contains classes that support Data Access
- **Persistence**: Data Access(Repository Pattern applied)
- **Utils**:       Utility class that support other classes
## MishaTelecoms.API
This API allows for the access and managing of the database for this application
### Folders
- **Controllers**: Contains controllers for receiving incoming request and defines URL routes(Mediator pattern applied)
- **Mappings**:    Mappers for the transfer of data between layers
- **Models**:      Contains Data Models(Mapping pattern)
