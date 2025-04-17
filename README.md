# FlagExplorerApp

FlagExplorerApp is a full-stack web application that allows users to explore and learn about different country flags. The project consists of a **frontend** built with Angular and a **backend API** developed using .NET 8 (MVC) based on a Swagger document.

![image](https://github.com/user-attachments/assets/791c5073-7f5f-4589-b887-011e63de85e1)


---

## Prerequisites

Before setting up the application, ensure you have the following installed on your system:

- [Node.js](https://nodejs.org/) (version 18 or higher recommended)
- [Angular CLI](https://angular.io/cli) (if applicable)
- [.NET SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (version 8.0 or higher)
- [Git](https://git-scm.com/)

---

## Setup Instructions

### 1. Clone the Repository
   ```bash
   git clone git@github.com:Deltas-Lee/FlagExplorerApp.git
   cd FlagExplorerApp
   ```

---

### 2. Frontend Setup (Angular)

1. **Navigate to the Frontend Directory**  
   If the frontend code is in a subdirectory (e.g., `frontend/`), navigate to it:
   ```bash
   cd flag-explorer
   ```

2. **Install Dependencies**  
   Run the following command to install the required Node.js dependencies:
   ```bash
   npm install
   ```

3. **Run the Frontend Application**  
   Start the development server:
   ```bash
   npm start
   ```
   This will start the Angular application and serve it locally. By default, it will be available at `http://localhost:4200`.


---

### 3. Backend Setup (.NET 8 API)

1. **Navigate to the Backend Directory**  
   ```bash
   cd cd FlagExplorerApi
   ```

2. **Restore Dependencies**  
   Run the following command to restore the required .NET dependencies:
   ```bash
   dotnet restore
   ```

3. **Run the Backend API**  
   Start the backend server (check the API URL & change if it does not match with the below):
   ```bash
   dotnet run
   ```
   By default, the API will be available at `https://localhost:5001` (HTTPS) or `http://localhost:5000` (HTTP).

4. **Swagger Documentation**  
   The API includes Swagger documentation for testing and exploring endpoints. Access it at:
   ```
   https://localhost:5001/swagger or
   https://localhost:7142/swagger/index
   ```

---

### 4. Integration Between Frontend and Backend

- The frontend retrieves and displays country flags by consuming the backend API.
- The backend API is based on an OpenAPI (Swagger) document, ensuring consistent and well-documented endpoints.
- Update the frontend environment configuration (`environment.ts`) to point to the backend API URL:
  ```typescript
  export const environment = {
    production: false,
    apiUrl: 'https://localhost:5001/api'
  };
  ```

---

## Development

### Frontend
- **Linting**: Run the linter to check for code quality issues:
  ```bash
  npm run lint
  ```

- **Testing**: Run unit tests:
  ```bash
  npm test
  ```

### Backend
- **Run Unit Tests**:
  ```bash
  dotnet test
  ```

---

## Folder Structure

- `Client/`: Contains the Angular frontend code.
- `Server`: Contains the .NET 8 API backend code.
- `FlagExplorer.Tests` Contains the unit & integration tests for the api.
- `node_modules/`: Contains the installed dependencies for the frontend (excluded from version control).
- `dist/`: Contains the production build files for the frontend (excluded from version control).

---

## CI/CD Pipeline

The CI/CD pipeline is configured in the `.github/workflows/ci-cd-pipeline.yml` file. It runs automated tests, builds the application, and packages it for deployment.


## Contributing

If you'd like to contribute to this project, feel free to fork the repository and submit a pull request.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
