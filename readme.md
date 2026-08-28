# ERP Stock Management
ERP Stock Management

## Features
1. System with Stock and cart. /
2. Mockup Item and Stock no need to implement insert service.
3. Item data include itemId, Name,price ect./
4. Show item data.
5. Out Of Stock.
6. Cart can add, increase/decrease, remove,clear and work with stock.
7. Calculate total price and deduct item froma a stock.

## Tech Stack
**Backend:** .NET 10 MVC (C#)
**Frontend:** Nextjs
**Database:** Sqlite
  
## Prerequisites

-   **.NET 10.0 SDK** (or later)
    
-   **Node.js** (v24.15.0) & **npm** (12.0.2) (temp)
    
-   **Git**

## Installation & Service Configuration

### 1. Clone Repository
```
git clone https://github.com/Tanachuns/tni_test.git
cd xxx

```

### 2. Backend Service Setup (.NET API)

1.  Restore NuGet dependencies and build:
     
    ```
    cd xxxx
    dotnet restore
    dotnet build
    ```
    
2.  Apply EF Core migrations to initialize the SQLite database (`linkshortener.db`):    
    ```
    dotnet ef database update
    ```
    
3.  Configure environment settings in `appsettings.Development.json`:
    
    JSON
    
    ```
	{
		"Logging": {
			"LogLevel": {
				"Default": "Information",
				"Microsoft.AspNetCore": "Warning"
			}
		},
		"baseUrl": "https://localhost:7219",
		"ConnectionStrings": {
			"sqlite": "Data Source=C:\\Users\\User\\AppData\\Local\\linkshortener.db"
		}
	}
    
    ```
    

### 3. Frontend Service Setup (NextJs)

## Testing & Service Verification

### 1. Automated Unit Tests

Run the test suite to verify URL validation logic, base-62 encoding, and service handlers:

Bash

```
cd server/....
dotnet test --verbosity normal
```


## API Contract Summary

Core REST endpoints exposed by the .NET backend API:

| Method | Endpoint | Description |
| --- | --- | --- |
| `POST` | `/api/xxxx` | desc |
| `GET` | `/api/xxxx` | desc |


---
## Challenges & Next Steps

