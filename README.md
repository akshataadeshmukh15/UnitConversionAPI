# Unit Conversion API

## Overview

The **Unit Conversion API** is an ASP.NET Core Web API designed to convert numerical values between different units of measurement. It uses C# and .NET to provide conversion functionality through REST endpoints.

The project starts with hardcoded conversion factors and is structured to support additional units and conversion categories as it evolves.

## Features

- **Length Conversion:** Convert between supported units such as meters, kilometers, centimeters, feet, and inches.
- **Weight and Mass Conversion:** Convert between supported units such as kilograms, grams, and pounds.
- **Temperature Conversion:** Convert between Celsius, Fahrenheit, and Kelvin.
- **RESTful API:** Expose conversion functionality through HTTP endpoints.
- **Input Validation:** Handle unsupported units and invalid conversion requests.
- **Extensible Design:** Make it easier to add new conversion categories and rules.

*Note: The supported units depend on the current implementation.*

## Technology Stack

- C#
- ASP.NET Core Web API
- .NET
- REST APIs
- Git and GitHub

## Project Structure

```text
UnitConversionAPI/
├── Models/
├── Services/
├── Properties/
├── appsettings.json
├── Program.cs
├── UnitConversionAPI.http
├── UnitConversionAPI.csproj
└── README.md
```

The project uses `Program.cs` for application startup and API endpoint configuration. The `Models` and `Services` folders organize request models and conversion logic.

*Adjust the structure if your actual files differ.*

## Getting Started

Follow these instructions to run the project locally.

### Prerequisites

Install the following tools:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) with the ASP.NET and web development workload, or Visual Studio Code
- [Git](https://git-scm.com/downloads)
- Postman or another HTTP client for API testing (optional)

Verify that .NET and Git are installed:

```bash
dotnet --version
git --version
```

### 1. Clone the Repository

Open a terminal and run:

```bash
git clone https://github.com/akshataadeshmukh15/UnitConversionApi.git
cd UnitConversionApi
```

### 2. Open the Project

Open `UnitConversionAPI.sln` in Visual Studio if the solution file is available.

Alternatively, open `UnitConversionAPI.csproj` directly in Visual Studio or navigate to the folder containing the `.csproj` file in your terminal.

### 3. Restore Dependencies

Run the following command from the project directory:

```bash
dotnet restore
```

This restores the NuGet packages required by the application.

### 4. Build the Project

Compile the application:

```bash
dotnet build
```

Resolve any build errors before proceeding.

### 5. Run the API

Start the application:

```bash
dotnet run
```

The terminal will display the local URLs where the API is listening. For example:

```text
http://localhost:5xxx
https://localhost:7xxx
```

These are example URLs. Use the actual URLs and port numbers displayed in your terminal.

Keep the terminal open while testing the API.

### 6. Test the API

**Option A: Visual Studio HTTP file**

1. Open `UnitConversionAPI.http` in Visual Studio.
2. Start the API.
3. Review the available requests and update their URLs or payloads if needed.
4. Select **Send Request** to execute a request.

**Option B: Postman**

1. Open Postman and create a new HTTP request.
2. Enter the endpoint URL defined in your application.
3. Select the HTTP method used by the endpoint.
4. If the endpoint accepts JSON, select **Body → raw → JSON** and enter the request payload.
5. Send the request and review the response.

Example request:

```json
{
  "value": 100,
  "fromUnit": "Meter",
  "toUnit": "Kilometer"
}
```

Example response:

```json
{
  "originalValue": 100,
  "fromUnit": "Meter",
  "toUnit": "Kilometer",
  "convertedValue": 0.1
}
```

The request and response above are illustrative examples. Confirm that the property names, endpoint, HTTP method, and response structure match the actual implementation.

## Conversion Logic

The conversion approach depends on the measurement category:

- **Length and mass:** Use conversion factors between compatible units.
- **Temperature:** Apply mathematical formulas because temperature conversions require more than simple multiplication.
- **Validation:** Reject unsupported units and incompatible conversion requests.

Examples:

- 1 kilometer = 1,000 meters
- 1 kilogram = 1,000 grams
- Celsius to Fahrenheit = `(Celsius × 9/5) + 32`

## Future Improvements

- Add more measurement categories, such as area, volume, speed, and time.
- Centralize conversion definitions to support additional units.
- Add automated unit tests for conversion formulas and edge cases.
- Add Swagger/OpenAPI documentation.
- Implement structured logging and centralized exception handling.
- Set up CI/CD pipelines using Azure DevOps.
- Add automated build and test validation.

## Version Control

This project uses Git for source control and GitHub for repository hosting.

To commit and push future changes:

```bash
git add .
git commit -m "Describe your changes"
git push
```

## License

This project is intended for learning, practice, and interview preparation. Add a license if you plan to distribute it publicly.
