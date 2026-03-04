# MathJS API - Automated Test Framework

![.NET](https://img.shields.io/badge/.NET-8.0%2B-blue)
![RestSharp](https://img.shields.io/badge/RestSharp-API_Testing-brightgreen)
![NUnit](https://img.shields.io/badge/NUnit-3.0%2B-success)

## Overview
This repository contains a robust, backend-focused **API Test Automation Framework** designed to validate the public mathematical evaluation API provided by [mathjs.org](https://api.mathjs.org/). 

While UI testing ensures user journeys are intact, API testing is crucial for verifying the core business logic, performance, and security of an application. This project was built to showcase my proficiency in **Backend Quality Assurance**, RESTful service validation, and data-driven testing using C#.

## Test Strategy & Scenarios
The framework applies extensive Data-Driven Testing (DDT) to evaluate the API against a wide range of inputs, ensuring mathematical accuracy and proper error handling.

**Key Test Coverage:**
* **Core Arithmetic:** Validating basic operations (addition, subtraction, multiplication, division) using both `GET` and `POST` methods.
* **Complex Expressions:** Testing advanced mathematical functions (e.g., derivatives, matrices, trigonometry).
* **Data-Driven Execution:** Utilizing NUnit's `[TestCase]` and `[TestCaseSource]` attributes to feed multiple datasets into single test methods efficiently.
* **Negative Testing & Error Handling:** * Verifying API behavior with invalid expressions (e.g., alphabetical characters instead of numbers).
  * Validating correct HTTP Status Codes (e.g., `400 Bad Request`) and error messages.
* **Payload & Encoding Validation:** Ensuring complex math symbols (like `+`, `/`) are correctly URL-encoded in GET requests, and accurately structured in POST JSON bodies.

## Technology Stack
* **Language:** C# 12 / .NET 8
* **HTTP Client:** RestSharp (For constructing and executing REST API requests)
* **Test Runner & Assertions:** NUnit
* **Serialization:** `System.Text.Json` / `Newtonsoft.Json` (For mapping request/response payloads)

## Architecture Highlights
* **Clean API Client Abstraction:** The framework separates the HTTP client configuration (base URLs, headers) from the actual test logic, making it highly maintainable.
* **Strongly Typed Models:** JSON responses are deserialized into C# objects/records, eliminating "magic strings" and ensuring type safety during assertions.
* **Fast & Headless:** Unlike UI tests, these API tests execute in milliseconds, making them perfect for continuous integration (CI) environments.

## Getting Started

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
* An IDE such as Visual Studio 2022 or JetBrains Rider.

### Installation & Execution
1. Clone the repository:
   ```bash
   git clone [https://github.com/yourusername/MathJS-API-Tests.git](https://github.com/yourusername/MathJS-API-Tests.git)
   cd MathJS-API-Tests
   
2. Restore NuGet packages
   ```bash
   dotnet restore

3. Run all API tests
   ```bash
   dotnet test --configuration Release


Developer

Bence Bodo - QA Automation Engineer
