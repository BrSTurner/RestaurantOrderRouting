DISCLAIMER: [This is an Old Project I made in 2021]

Restaurant Order Routing

- This system was developed using a distributed architecture, it's in between a Monolithic and Microservices.

- Framework: .NET Core 3.1 And ASP.NET Core 3.1 (Windows and Linux support)
- Docker Support
- Unit and Integration tests = Unfortunately I wasn't able to start it, I ran out of time because I have decided to design a good API Structure, usualy I write Unit and Integration tests

Contains the following features:

- CQRS (Command Query Responsibility Segregation) using Mediator (MediatR) (unfortunately I did not write the query section to save time)
 - Entity Framework Core for Commands
 - Dapper for Querys
 
- RabbitMQ to use the queue feature, the RabbitMQ Server is hosted in an Azure Virtual Machine.
- SQL Server Database was used to save the data of the current entitys (Customers, Orders, OrderItems and Items) (The Connection String is located at the AppSettings.json)
- SQL Server is hosted by Azure Services
- FluentValidation Framework used to validate Commands, Entitys and General Objects
- EasyNetQ Framework, it's an API to improve RabbitMQ use
- Polly Framework used to created policys to handle exceptions and actions
- MediatR Framework used to handle Commands and Events 
- Microsoft Entity Framework, ORM used to manage the database
- Dapper Micro ORM used to execute querys
- Swashbuckle Framework used to document the API endpoints by Swagger

- Dependency Injection used to apply Inversion of Control
- Repository Pattern to execute database actions
- Unit Of Work to commit changes
- Code First and Migrations
- SOLID concepts applied
- Clean Code applied
- Projects divided by layers


Projects:

- ROR.Web.API = All commom features for HTTP API
- ROR.MessageBus = RabbitMQ bus configuration
- ROR.Core = All commom classes and configurations that could be used by all projects

- ROR.Orders.API = HTTP API responsible for Orders management
- ROR.Orders.Domain = Responsible for the bussines rules  (Models, Enumerations, Interfaces abstraction)
- ROR.Orders.Infra = Responsible for Database context, Entity mapping, migrations and repository implementation

- ROR.Kitchen.API = HTTP API responsible for Kitchen management
- ROR.Kitchen.Core = Contains the commom classes and configuration to be used by kitchen bussines rules

- ROR.DesertKitchen.Application:
- ROR.DrinkKitchen.Application:
- ROR.FriesKitchen.Application:
- ROR.GrillKitchen.Application:
- ROR.SaladKitchen.Application:

All this projects are used as the kitchen areas, each one will implement the bussines rules of that kitchen, example: FriesKitchen could turn on a fridge by IoT integration.

Current Items:
Id	CreateDate					Name			Description					Price	Kitchen
1	2021-03-28 02:46:12.7962168	French Fries	Delicious French Fries		9.50	1
2	2021-03-28 02:46:12.7962168	Grilled Chicken	Delicious Grilled Chicken	7.50	2
3	2021-03-28 02:46:12.7962168	Ceaser Salad	Delicious Ceaser Salad		12.00	3
4	2021-03-28 02:46:12.7962168	Petit Gateau	Delicious Petit Gateau		10.50	4
5	2021-03-28 02:46:12.7962168	Orange Juice	Delicious Orange Juice		5.50	5

Current Customers:
Id	CreateDate					Name	PhoneNumber
1	2021-03-28 02:46:12.7809667	Bruno	(19)98719-6273

- You can add more Customers and Items connecting to the database

- Payload example to PlaceNewOrder method:

{
  "tableNumnber": 35,
  "finalPrice": 135,
  "customerId": 1,
  "orderStatus": 1,
  "orderType": 1,
  "orderItems": [
    {
      "quantity": 2,
      "itemName": "French Fries",
      "itemPrice": 9.5,
      "orderStatus": 1,
      "orderId": 0,
      "itemId": 1,
      "kitchen": 1
    },
	{
      "quantity": 2,
      "itemName": "Grilled Chicken",
      "itemPrice": 7.50,
      "orderStatus": 1,
      "orderId": 0,
      "itemId": 2,
      "kitchen": 2
    },
	{
      "quantity": 2,
      "itemName": "Ceaser Salad",
      "itemPrice": 12,
      "orderStatus": 1,
      "orderId": 0,
      "itemId": 3,
      "kitchen": 3
    },
	{
      "quantity": 2,
      "itemName": "Petit Gateau",
      "itemPrice": 10.50,
      "orderStatus": 1,
      "orderId": 0,
      "itemId": 4,
      "kitchen": 4
    },
	{
      "quantity": 2,
      "itemName": "Orange Juice",
      "itemPrice": 5.5,
      "orderStatus": 1,
      "orderId": 0,
      "itemId": 5,
      "kitchen": 5
    }
  ],
  "validationResult": {}
}