![banner](https://github.com/noturlee/Azure-Functions-Medical-System/assets/100778149/7ca436c9-3012-4ac0-bdd4-4955e4ea64e6)

# Ghandi Hospital Azure Patient System 

This repository contains the implementation of a system that relays patient information from a local console application to Azure. The system uses HTTP and Queue triggers to process and validate patient data before storing it in Azure Database, Blob Storage, and Azure Tables.

## Table of Contents
- [Overview](#overview)
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [Azure Integration](#azure-integration)
- [Console Application](#console-application)
- [Triggers](#triggers)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)

## Overview
The Ghandi Hospital Azure Patient System is designed to manage patient information efficiently. It uses a local console application to capture patient data, which is then sent to Azure for further processing and storage. The system leverages HTTP and Queue triggers to validate and sort the data before saving it into various Azure services.

## Architecture
<img src="https://github.com/noturlee/Azure-Functions-Medical-System/assets/100778149/eff7ac88-2654-4bea-b9c3-b2f136fee19b" width="400" alt="Architecture Diagram">

The architecture consists of the following components:</br></br>


- **Local Console Application**: Captures and sends patient data to Azure.
- **HTTP Trigger**: Receives data from the console application and initiates processing.
- **Queue Trigger**: Processes the data and validates it.
- **Azure Database**: Stores validated patient information.
- **Blob Storage**: Stores any large data objects related to patients.
- **Azure Tables**: Stores structured patient data.

## Prerequisites
Before setting up the project, ensure you have the following prerequisites:
- [Azure Subscription](https://azure.microsoft.com/en-us/free/)
- [Visual Studio or Visual Studio Code](https://visualstudio.microsoft.com/)
- [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [.NET SDK](https://dotnet.microsoft.com/download)

## Setup Instructions
Follow these steps to set up the project:

1. **Clone the repository**
    
   ```bash
   git clone https://github.com/yourusername/GhandiHospitalAzurePatientSystem.git
   cd GhandiHospitalAzurePatientSystem
   
2. **Set up Azure resources**

- Create an Azure Storage Account.
- Create an Azure SQL Database.
- Create necessary Blob containers and Tables in the Azure Storage Account.

3. **Configure the local environment**

- Update the `local.settings.json` file with your Azure Storage Account and SQL Database connection strings.

4. **Run the console application**

- Navigate to the ConsolePOE directory and run the console application.
```
dotnet run
```
5. **Deploy Azure Functions**

- Deploy the functions in the `TriggerToTable` directory to Azure.

```
func azure functionapp publish <YourFunctionAppName>
```
## Azure Integration

This project integrates various Azure services to manage patient data:

- `Azure Functions`: Used to create HTTP and Queue triggers for processing data.
- `Azure SQL Database`: Stores structured and validated patient information.
- `Azure Blob Storage`: Stores large data objects related to patients.
- `Azure Tables`: Stores additional structured data for quick access.

## Console Application
Click the button below to view the console code file.

<a href="ConsolePOE">
  <img src="https://img.shields.io/badge/View%20Console%20Code-green.svg" height="40">
</a>

## Triggers
Click the button below to view the trigger code file.

<a href="TriggerToTable">
  <img src="https://img.shields.io/badge/View%20Trigger%20Code-blue.svg" height="40">
</a>

<br>
<br>
<br>
<br>

<div align="center">
  <img src="https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjzcDrVB-FL5m2H8bW92Hz37JughjIdvcQbok9aN8m2OwXGqSLDOIz3EDvq47iEejmATinHrJ0E9XrGuTxkbdPmCT7xsjDpDZjixtdSJtx7GQg8NwmdnZi5D8MkEpumO6aAZqCGnOQCRUXu/s512/SQLPoolsScaling.gif" alt="Cloud Image" width="300">
</div>


<br>
<br>
<div align="center">

<img src="https://img.shields.io/badge/Microsoft_Azure-0078D4?style=for-the-badge&logo=microsoft-azure&logoColor=white" alt="Azure Badge">

<img src="https://img.shields.io/badge/SSMS-00AEFF?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SSMS Badge">

<img src="https://img.shields.io/badge/SQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Badge">

</div>

## Roadmap

- [x] Local Console Application Integration
- [x] HTTP and Queue Trigger Setup
- [x] Azure SQL Database Integration
- [x] Blob Storage Configuration
- [x] Azure Tables Implementation
- [ ] Advanced Analytics Integration
- [ ] Mobile App Development
- [ ] AI Integration for Predictive Analysis
- [ ] Security and Compliance Enhancements


## Graphical Representation of Progress
Graph to visualize the progress of the project:


Feature                             | Progress
----------------------------------- | ---------------------------------
Local Console Application Integration | █████████████████████████ 100%
HTTP and Queue Trigger Setup        | █████████████████████████ 100%
Azure SQL Database Integration      | █████████████████████████ 100%
Blob Storage Configuration          | █████████████████████████ 100%
Azure Tables Implementation         | █████████████████████████ 100%
Advanced Analytics Integration      | ██████                   30%
Mobile App Development              | █████                    20%
AI Integration for Predictive Analysis | ████                  15%
Security and Compliance Enhancements | ██                     10%


## Contributing

I welcome contributions to improve the project. Please submit pull requests or raise issues for any improvements or bugs found.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
