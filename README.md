
# **Restaurants APIs**

![.NET Core 8](https://img.shields.io/badge/.NET_Core-8.0-blue) ![Azure](https://img.shields.io/badge/Azure-Services-blue) ![Clean Architecture](https://img.shields.io/badge/Clean_Architecture-SOLID-green) ![Swagger](https://img.shields.io/badge/Swagger-API_Documentation-blue)

---

## **Overview**

**Restaurants APIs** is a comprehensive API project designed to manage restaurant operations. Built using **ASP.NET Core 8** and following **Clean Architecture** principles, this API is engineered for scalability, maintainability, and security. It integrates with **Azure Services** for cloud storage and database management, providing a robust and cloud-ready solution.

---

## **Key Features**

- **Cross-Platform Development**: Developed with **ASP.NET Core 8**, suitable for integration with web, mobile, and desktop applications.
- **Clean Architecture**: Ensures a well-organized, maintainable, and easily testable codebase.
-
-  ![image](https://github.com/user-attachments/assets/b84541cc-18e5-4b82-9ed2-27f4d8f1adfa)
- ![image](https://github.com/user-attachments/assets/56484e48-5861-4d79-99dc-e63830e8cefd)
- **Database Management**: Utilizes **Microsoft SQL Server** with **Entity Framework Core** for efficient data operations.
- ![image](https://github.com/user-attachments/assets/bcf20621-a1ea-4067-afdc-029a880d366d)

- **Authentication & Authorization**: Implements **ASP.NET Core Identity** with role-based access control, JWT authentication, and custom claims.
- ![image](https://github.com/user-attachments/assets/915319b0-ed03-4eb1-a686-3caf634b455b)

- **API Documentation**: Automated documentation via **Swagger** for clear API exploration.
- ![image](https://github.com/user-attachments/assets/507d3b20-2b72-4484-93d4-9471e3bcc37a)
- ![image](https://github.com/user-attachments/assets/32397fb9-5941-4bf7-a91d-c3c2dd6a9125)
- ![image](https://github.com/user-attachments/assets/7a6f404d-e375-403d-9087-d960a852b10b)
- ![image](https://github.com/user-attachments/assets/fcd24fff-8f87-416b-8a3a-8514ff6d9d6d)




- **Logging & Monitoring**: Integrated with **Serilog** for comprehensive logging and monitoring.
- ![image](https://github.com/user-attachments/assets/f461dcd7-3cef-459c-a339-574213012c5c)
- ![image](https://github.com/user-attachments/assets/3de3c0f3-059e-4fc8-81fb-6b91b0972e4c)



- **Azure Integration**: Deployed on **Azure**, leveraging **Azure App Services** and **Azure SQL** for high availability and scalability.
![image](https://github.com/user-attachments/assets/943bea4a-f76a-4cfa-9011-3c8985b09109)
![image](https://github.com/user-attachments/assets/7cff5eaf-d08c-4124-af63-79d59948a1df)
![image](https://github.com/user-attachments/assets/aa6a5653-9fa5-4ee1-a7ae-b3ba60e10c86)
![image](https://github.com/user-attachments/assets/8bb0bc3f-dee1-47b4-9a24-f0bdc5a82c67)
![image](https://github.com/user-attachments/assets/71a33cfe-78dc-4570-b0e2-6a75cbb8e570)
![image](https://github.com/user-attachments/assets/94f3a82b-460b-4553-a34d-fa7b324da158)
![image](https://github.com/user-attachments/assets/52bf5032-a88b-4d19-ba6f-4b979a901724)
![image](https://github.com/user-attachments/assets/f83ca2e4-095a-41dc-ab42-150dd85f2e92)
![image](https://github.com/user-attachments/assets/dcbcac1a-359b-49f8-9b3e-5715a4c0a086)
![image](https://github.com/user-attachments/assets/9540f050-8442-4eae-a7d6-aa9c270ef088)

---

## **Technical Highlights**

- **DTO Mapping & Validation**: Employs Data Transfer Objects (DTOs) and **FluentValidation** to ensure data integrity.
- **CQRS with MediatR**: Implements Command Query Responsibility Segregation (CQRS) using **MediatR** for enhanced scalability and separation of concerns.
- **Sub-Entity Management**: Efficiently manages nested resources within main entities, adhering to RESTful principles.
- **Paging & Sorting**: Incorporates paging and sorting mechanisms for handling large datasets effectively.
- ![image](https://github.com/user-attachments/assets/cdd763c8-70bd-45cf-bf40-7af5a8906e35)


---

## **Design Patterns Used**

- **Factory Pattern**: Used for creating service instances, promoting extensibility and maintaining a single responsibility for object creation.
- **Singleton Pattern**: Ensures a single instance of critical services, such as the database context, for consistency and reduced overhead.
- **Observer Pattern**: Manages event-driven actions within the application, such as notifications and logging.

---

## **Project Structure**

The project is organized according to **Clean Architecture** principles:

- **Core**: Contains business logic and domain entities, independent of external dependencies.
- **Infrastructure**: Manages data access, external services, and infrastructure concerns.
- **API**: Handles HTTP requests, routing, and user interface interactions.

---

## **Deployment & CI/CD**

- **Azure Deployment**: The application is deployed on **Azure** using **Azure App Services** and **Azure SQL** to ensure high availability and scalability.
- **CI/CD**: **GitHub Actions** is utilized for automating build, test, and deployment processes, ensuring efficient and reliable updates.

---

## **Documentation & Testing**

- **API Documentation**: Detailed API documentation is generated with **Swagger and Postman**, providing clear instructions on API usage.
- ![image](https://github.com/user-attachments/assets/cb29e017-6991-40e8-8f46-4388730db2b0)
![image](https://github.com/user-attachments/assets/e562ef2e-34f7-45fc-bd75-51f546b9cc75)
![image](https://github.com/user-attachments/assets/5c5390a9-dde6-4130-b60a-99210b717098)
![image](https://github.com/user-attachments/assets/35bb3191-5b34-411e-8489-35f7b7cfdd3c)



- **Testing Coverage**: Includes unit and integration tests to ensure reliability and correctness, with automated pipelines for high code quality.
- ![image](https://github.com/user-attachments/assets/b6f31a81-3785-4ee3-b0b9-9b9318fe36e3)


---

## **Final Presentation**

This project exemplifies advanced software engineering principles by integrating modern frameworks, clean architecture, and cloud services into a professional-grade API solution. The application of design patterns, clean code practices, and cloud integration highlights a high level of expertise in cross-platform application development.

---

## **Additional Resources**

- [API Documentation](https://restaurants-apis-prod-gtf8bxcffwh5ajdd.eastasia-01.azurewebsites.net/swagger) - Explore the API endpoints and functionality.


