# KYC360 Project

## Overview

The KYC360 project is a .NET Core application designed to manage Know Your Customer (KYC) entities. The project includes features such as basic CRUD operations, advanced filtering, searching, pagination, and a retry mechanism for database operations.

## Project Structure

The project is divided into the following main components:

- **KYC360.Commons**: Contains common utilities, DTOs, models, and base services.
- **KYC360.Core**: Contains the core application logic, services, and controllers.
- **KYC360.Tests**: Contains the unit tests for the project.

### Directory Structure
```
TESTKYC360/
├── KYC360.Commons/
│ ├── DTOs/
│ │ ├── AddressDTO.cs
│ │ ├── DateDTO.cs
│ │ ├── EntityDTO.cs
│ │ ├── IEntityDTO.cs
│ │ └── NameDTO.cs
│ ├── Models/
│ │ ├── IIdentifiable.cs
│ ├── Services/
│ │ ├── BaseService.cs
│ ├── Utils/
│ ├── KYC360.Commons.csproj
├── KYC360.Core/
│ ├── Controllers/
│ │ ├── EntityController.cs
│ ├── Data/
│ │ ├── GenericMockDatabase.cs
│ ├── Models/
│ │ ├── Address.cs
│ │ ├── Date.cs
│ │ ├── Entity.cs
│ │ ├── IEntity.cs
│ │ ├── Name.cs
│ ├── Services/
│ │ ├── EntityService.cs
│ ├── Properties/
│ ├── Program.cs
│ ├── Startup.cs
│ └── KYC360.Core.csproj
└── KYC360.Tests/
├── Data/
│ ├── GenericMockDatabaseTests.cs
└── KYC360.Tests.csproj
```
## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/) or any other C# IDE

### Setting Up the Project

1. Clone the repository:
    ```sh
    git clone https://github.com/erickbordam/DotNet/
    cd ./DotNet/core-mvc/TestKYC360
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Build the project:
    ```sh
    dotnet build
    ```

4. Run the project:
    ```sh
    dotnet run --project KYC360.Core
    ```

### Running Tests

To run the tests, navigate to the test project directory and run:
```sh
dotnet test
```
Project Details
---------------

### Models

*   **Entity**: Represents a KYC entity with properties such as Addresses, Dates, Names, Gender, and Deceased status.

*   **Address**: Represents the address of an entity.

*   **Date**: Represents significant dates related to an entity.

*   **Name**: Represents the names associated with an entity.


### DTOs

Data Transfer Objects (DTOs) are used to transfer data between different layers of the application. Each model has a corresponding DTO.

### Services

*   **BaseService**: Provides basic CRUD operations.

*   **EntityService**: Extends BaseService to include additional functionality such as search, filtering, pagination, and retry mechanism.


### Controllers

*   **EntityController**: Exposes endpoints for managing entities, including CRUD operations, search, filtering, and pagination.


### Retry Mechanism

The retry mechanism is implemented in the GenericMockDatabase class. It attempts to retry database operations a specified number of times with an exponential backoff strategy.

### Configuration

Configuration settings, including retry policy settings, are specified in the appsettings.json file.

### EntityService Details

The EntityService class is responsible for managing the business logic for the KYC entities. It extends the BaseService to include additional methods for searching, filtering, and pagination.

### Advanced Filtering

The EntityService supports filtering entities based on gender, start and end dates, and a list of countries. The filtering logic is implemented in the Filter method.

### Searching

The EntityService allows searching entities by various fields such as Address Country, Address Line, FirstName, MiddleName, and Surname. The search logic is implemented in the Search method.

### Pagination and Sorting

The EntityService supports pagination and sorting of the entity list. This functionality is implemented in the GetPagedAndSorted method, which paginates and sorts the result set based on the provided parameters.

### Retry Mechanism

The retry mechanism is implemented in the GenericMockDatabase class to handle transient failures during database write operations. The mechanism includes a configurable number of retry attempts and a backoff strategy to progressively increase the delay between retries.

Usage
-----

### Endpoints

*   **GET /api/entity**: Get all entities with optional pagination and sorting.

*   **GET /api/entity/search**: Search for entities based on specified criteria.

*   **POST /api/entity**: Create a new entity.

*   **PUT /api/entity/{id}**: Update an existing entity.

*   **DELETE /api/entity/{id}**: Delete an entity.


### Example Requests

**Search Request**:
```
GET /api/entity/search?search=John&gender=Male&startDate=1980-01-01&endDate=2020-12-31&countries=USA&countries=Canada&pageNumber=1&pageSize=10&sortBy=lastName&sortDesc=true   `
```
**Create Entity Request**:
```
POST /api/entity
```
Values:
```
{
  "addresses": [
    {
      "addressLine": 1,
      "city": 2,
      "country": 3
    }
  ],
  "dates": [
    {
      "dateType": "Birth",
      "dateVal": "1980-04-15T00:00:00"
    }
  ],
  "deceased": false,
  "gender": "Male",
  "id": "entity1",
  "names": [
    {
      "firstName": "John",
      "middleName": "H.",
      "surname": "Doe"
    }
  ]
}
```

Conclusion
----------

The KYC360 project is designed to provide robust KYC entity management with advanced features such as filtering, searching, pagination, and retry mechanisms. This README provides an overview of the project structure, setup instructions, and key functionalities.

For any issues or contributions, please create an issue or a pull request on the GitHub repository.

Detailed Steps and Information
------------------------------

### Step-by-Step Implementation Details

1.  **Creating Models and DTOs**:

    *   **Entity**: Represents the main KYC entity.

    *   **Address**: Represents address details.

    *   **Date**: Represents significant dates.

    *   **Name**: Represents name details.

    *   Corresponding DTOs were created for each model to transfer data between layers.

2.  **BaseService Implementation**:

    *   Contains basic CRUD operations.

    *   Uses DTOs to transfer data between layers.

3.  **EntityService Implementation**:

    *   Extends BaseService to include additional methods for searching, filtering, and pagination.

    *   Implements retry mechanism for database operations.

4.  **EntityController Implementation**:

    *   Provides endpoints for CRUD operations.

    *   Includes endpoints for searching, filtering, and pagination.

5.  **Retry Mechanism**:

    *   Implemented in GenericMockDatabase.

    *   Uses an exponential backoff strategy.

    *   Configurable via appsettings.json.


### Retry Mechanism Configuration

Settings for the retry mechanism are specified in appsettings.json:

```
{
  "RetryPolicySettings": {
    "MaxRetryAttempts": 3,
    "InitialDelay": 1000,
    "MaxDelay": 8000,
    "BackoffFactor": 2
  }
}
```

### Example Test Cases

**AddItem\_ShouldRetryAndEventuallySucceed**:

*   Simulates failures for the first two attempts and success on the third attempt.

*   Ensures that the retry mechanism correctly retries the operation.


**AddItem\_ShouldFailAfterMaxAttempts**:

*   Simulates failure for all attempts.

*   Ensures that the retry mechanism stops after the maximum number of attempts and logs the failure.


**UpdateItem\_ShouldRetryAndEventuallySucceed**:

*   Simulates failures for the first two attempts and success on the third attempt.

*   Ensures that the retry mechanism correctly retries the operation.


**DeleteItem\_ShouldRetryAndEventuallySucceed**:

*   Simulates failures for the first two attempts and success on the third attempt.

*   Ensures that the retry mechanism correctly retries the operation.
*   


Conclusion
----------

The KYC360 project is designed to provide robust KYC entity management with advanced features such as filtering, searching, pagination, and retry mechanisms. The solution follows a multi-layered architecture to separate concerns and improve maintainability. The retry mechanism ensures robustness and resilience in the face of temporary failures.

By utilizing base classes like BaseService, the project ensures code reusability and consistency across different services. The multi-layer approach, along with the separation of models and DTOs, enhances the project's scalability and ease of maintenance.

For any issues or contributions, please create an issue or a pull request on the GitHub repository.
