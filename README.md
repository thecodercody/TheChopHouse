# The Chop House

![TCH-logo](https://user-images.githubusercontent.com/8681966/164029883-c116a420-8624-4ef4-bb1c-7aec02a68601.png)

# Technologies Used

- Visual Studio for Mac
- C#
- .NET Core 5.0
- ADO.NET
- Swagger
- Serilog
- SQL Server
- Azure Data Studio
- Docker (for SQL Server)

# Features

- Create a new customer
- Get list of all customers
- Retrieve a specific customer
- Place an order
- Retrieve an order
- View order history by customer
- View customer invoice (total from all his or her orders)

# To-Do List:

- Create views for a nice UI
- Improve Serilog to show only information directly related to user actions in the API

# Getting Started

1 - Clone the reposisotry (git clone https://github.com/thecodercody/TheChopHouse.git)

2 - Create a docker container running an SQL server if on Mac or just a local SQL Server if on Windows

3 - Restore the database locally using the .bak file

4 - Change the connection string for the correct server destination and username/password, if needed

5 - Run the file in RELEASE mode from within Visual Studio.  You should see the following:
<img width="1422" alt="screenshot" src="https://user-images.githubusercontent.com/8681966/164037749-309b0d22-bf07-43c6-be34-65daa8655651.png">

6 - Adding a customer requires adding a first name and a last name into the JSON input.  The id will be automatically assigned, and the balance due will take care of itself, as well.

7 - Add items from the menu, which is found in the drop-create-insert.sql file in TheChopHouse/TheChopHouse/Models/ directory.  Do this by copying the entire line for each item into the JSON input given when clicking "add order" in the Swagger UI.

8 - The other features will work as expected and are self-explanatory.

# License

This project uses the following license: MIT
