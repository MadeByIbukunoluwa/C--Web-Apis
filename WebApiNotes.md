
# Web APIs in C sharp

* Controllers: This folder typically contains classes that define the API endpoints for the Web API. These classes are responsible for handling incoming requests, performing any necessary processing, and returning a response to the client.
* Models/Entities: This folder contains the domain objects or entities that the Web API works with. These classes often represent database tables or other persistent data structures.
* Services: This folder contains classes that implement the business logic for the Web API. These classes often encapsulate data access and other operations that manipulate the data models/entities.
* Repositories: This folder typically contains classes that provide data access functionality to the Web API. These classes may implement the data access logic directly, or they may provide a layer of abstraction between the API and a database or other data source.
* Data: This folder contains classes that are related to data access, such as data contexts or database connection classes.
* Helpers: This folder contains classes that provide utility functions or helper methods that are used throughout the Web API.
* Migrations: This folder contains database migration files that are used to apply changes to the database schema.
* Tests: This folder contains unit tests and integration tests for the Web API. These tests help ensure that the API functions correctly and that changes to the API don't introduce unintended side effects.

Rest Api stands for representational state transfer - it is an architectural style for building web services

They use verbs such as GET, POST , PATCH , PUT , DELETE

They are defined through -
A base URI
HTTP Methods
A media type for the data e.g JSON / XML

Controllers - contains classes with public methods exposed as endpoints

.csproj - contains configuration metadata for the project

Error
When I wanted to use dotnet run for a project it threw an error - Failed to create CoreCLR, HRESULT: 0x80004005
Upon doing research, I figured out that it was because of the nature of Macs having read only file systems , when I ran it with sudo , that is sudo dotnet run it worked perfectly fine

ERROR

Add it as an environment variable

<https://stackoverflow.com/questions/68705418/microsoft-dotnet-httprepl-is-already-installed-but-httprepl-command-not-found-in>

What of we have pages that changes frequently , theen we have to rebuild and redeploy your code

<https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio>

In order to change the api route form http to https , I just simply renamed the route from http:localhost:5102 to https:localhost:5102 in the launchSettings.json file

# Controller  

A controller is a public class with one or more public methods known as actions

By convention , a controller is placed in the project roots Controllers directory . The actions are exposed as HTTP endpoints via routing

We can add a [ApiController] attribute that enables opinionated behaviours that make it easier to build web apis

The names for the directories comes from the model view architecture that the web apis follow

<https://stackoverflow.com/questions/70952271/startup-cs-class-is-missing-in-net-6>

<https://khalidabuhakmeh.com/dotnet-watch-launchsetting-for-aspnet-core>

## Entity

The core entity used to represent the items in our catalog

## Repository

Repository responsible for whole item storage operations

How to model an entity via C# record types
How to implement an in-memory repository of resources
How to implement a controller with GET routes to retrieve resources

# Record

Record - cases used for immutable objects , one you get an instance of the types it can’t be modified

# IEnumerable

IEnumerable - the basic interface you can use to return a collection of items

# Action Results

When creating api endpoints , action result allows us to return more than one type from a method




How to register and implement dependencies in.NET

## How to implement Data Transfer Objects - DTOs  

How to map entities to DTOs

## Dependency Inversion Principle  

When we have a class that depends on another class we refer to that other class as a dependency

Instead of making the class that receives another class (dependency) exclusively dependent on the class it receives (the dependency) , it is going to use an interface which is where we bring in the dependency inversion principle
So the class no longer depends on the dependency , it depends on the interface that the dependency implements

By having our code depend on abstractions we are decoupling implementations from each other ti gives more freedom to move around our dependencies without ever having to touch our class this makes it easier clearer and much smoother to use

We can simply go to the left of the line that we have our controller class , then click on the screwdriver icon , then when the dropdown appears we select ‘Extract interface’

// Still have to do research on whether it is outdated
<https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences>

<https://learn.microsoft.com/en-gb/dotnet/core/extensions/dependency-injection-usage>

## DTO(Data transfer Objects)

The rate that we have created are exposing our items entity directly , we are exposing the items that we are using when dealing with persistence in the repository anytime we want to modify or remove any field in the storage , we can potentially break the contract we establish with our clients , we will introduce a DTO which is imply the contract which will be enabled between the client and our services

Instead of manually converting all the endpoints to Dto type, we can create an extension method that can extend the type of the route

How to Create resources with POST
How to validate the values of DTO properties
How to update resources with PUT
How to delete resources with DELETE

Record is a data type pretty convenient for DTOs

In this scenario because the itemDto contains more properties than we need we are going to create a new DTO for the CreateItem() function that is going to be used to POST requests

We can add data annotations to our DTOs to make sure that a field is required and getting the right range of values

With record type method , we are creating a copy of it , but eight the two properties modified

## Non nullable property must contain a non null value when exiting the constructor

<https://stackoverflow.com/questions/67505347/non-nullable-property-must-contain-a-non-null-value-when-exiting-constructor-co>

## Dependency Injection in C# ASP.Net

<https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0>

## if you come across an issue like this

    - Unable to resolve service for type 'Catalog.Repositories.IInMemItemsRepository' while attempting to activate 'Catalog.Controllers.ItemsController'....

You should register your dependency using the AddScoped method , here we registered the IInMemItemsRepository dependency using the AddScoped method.
