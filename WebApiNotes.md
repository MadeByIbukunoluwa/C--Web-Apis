
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
