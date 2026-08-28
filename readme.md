# ERP Stock Management
ERP Stock Management

## Features
1. System with Stock and cart. /
2. Mockup Item and Stock no need to implement insert service./
3. Item data include itemId, Name,price ect./
4. Show item data.
5. Out Of Stock.
6. Cart can add, increase/decrease, remove,clear and work with stock.
7. Calculate total price and deduct item froma a stock.

## API Contract Summary

Core REST endpoints exposed by the .NET backend API:

| Method | Endpoint | Description |
| --- | --- | --- |
| `GET` | `/api/products` | Get all Products |
| `GET` | `/api/stock` | Get all stock |
| `GET` | `/api/products/{id}` | Get product by id |
| `PATCH` | `/api/cart/increase` | Add to Cart |
| `PATCH` | `/api/cart/increase` | Add to Cart |
| `PATCH` | `/api/cart/decrease` | Remove from Cart |
| `PATCH` | `/api/cart/clear/{id}` | Clear Cart |
| `POST` | `/api/cart/checkout/{id}` | Checkout Cart |
| `GET` | `/api/cart/{id}` | Get Cart Items |



