# Contact Manager
A simple and scalable Contact Manager project

## Design
The solution was divided into four main projects:

- **ContactManager**. The Web api. Contains the controller, the endpoints and the configuration for the app.
- **Providers**. Contains the business logic, the database access objects, the connection factory class and the database context.
- **Domain**. Contains the Contact and Address models as well as the Contact DTO.
- **Tests**. Contains the unit tests for the GetContact endpoint.

Swagger is implemented to test the Web Api through the UI. Sample requests and responses are provided as well as documentation for the api methods, and the domain.

A Data Access Layer is added, containing the Contacts DAO and a Factory for returning a single DatabaseContext each time its called. The Dao inherits the BaseDao abstract class with the Factory, and implement the IContactsDao interface. 

The Controller inherits the CatchException function for database exceptions handling from the BaseApiController.

## Development practices

- No unnecesary code or leftover code blocks.
- Tests only for present methods.
- Reusable code and methods.
- Exception handling (Basic)
- Unit tests cover multiple code paths and scenarios.
- Good naming practices and comment lines.
- Methods no longer than 30 lines of code (Not counting line spaces).
- Modules no longer than 500 lines (For a small project).
- Tightly scoped unit tests. Test one result at a time.

## Dessign Patterns
- Factory used when creating the database session.
- DBContext is (Almost) a singleton and can (And should) only be instanciated from the Session Factory.

## How to run the tests

### 1. Inside Visual Studio
1. Download the solution from github
2. Open the solution in Visual Studio
3. Open the Test Explorer.
4. Click on "Run All" or select the tests to run and right click "Run selected tests"

### 2. Nunit Console Runner
1. Download `NUnit.Console-*.msi` from https://github.com/nunit/nunit-console/releases
2. Add to system `PATH` variable this: `C:\Program Files (x86)\NUnit.org\nunit-console`
3. Open Command Line
4. Change the directory to the test project path Ej: `cd ContactManager\ContactManager.Tests\bin\Debug`
5. Type 
    `$ nunit3-console test.dll`
