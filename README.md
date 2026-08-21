MyFirstWebAPI
=================

This project is a minimal ASP.NET Core Web API that implements production-ready CRUD endpoints for Product entities and exposes Swagger UI for interactive documentation.

Run
----
1. Restore and build:
   dotnet restore
   dotnet build

2. Run the app (ports are fixed to 5001/5000):
   dotnet run --urls "https://localhost:5001;http://localhost:5000"

3. Open the Swagger UI in your browser:
   - HTTPS: https://localhost:5001/swagger
   - HTTP:  http://localhost:5000/swagger

API Endpoints
-------------
Base path: /api/products

- GET /api/products
  - Returns list of products.

- GET /api/products/{id}
  - Returns a single product by id. 404 if not found.

- POST /api/products
  - Create a product.
  - Body (application/json): { "name": "Item", "price": 100 }
  - Returns 201 Created with Location header.

- PUT /api/products/{id}
  - Update product. Body same as POST. Returns 204 No Content on success.

- DELETE /api/products/{id}
  - Deletes a product. Returns 204 No Content on success.

Examples (curl)
---------------
Create:
curl -X POST https://localhost:5001/api/products -H "Content-Type: application/json" -d "{ \"name\": \"New Item\", \"price\": 123 }" -k

Get all:
curl https://localhost:5001/api/products -k

Get one:
curl https://localhost:5001/api/products/1 -k

Update:
curl -X PUT https://localhost:5001/api/products/1 -H "Content-Type: application/json" -d "{ \"name\": \"Updated\", \"price\": 150 }" -k

Delete:
curl -X DELETE https://localhost:5001/api/products/1 -k

Notes
-----
- The project uses an in-memory thread-safe repository (InMemoryProductRepository). Replace it with a database-backed implementation (EF Core) for persistence.
- DTOs with validation attributes are used for input models.
- Swagger UI is enabled and includes XML comments from code.
- For production: configure real persistence, authentication/authorization, HTTPS certificate, and proper logging/monitoring.
