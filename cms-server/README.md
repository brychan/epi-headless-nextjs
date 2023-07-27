# Modified Optimizely CMS 12 empty template

This boilerplate server is based on the Optimizely CMS 12 Empty template with some additions:
- Content Delivery API v3.
- Server listens on port 5000.
- Host for routes are localhost:3000.
- A few basic Content Types are added.
- DisplayOptions are enabled in "Startup.cs", and if set for a block, the value is sent by CD API.

## How to run locally with Windows

### Prerequisities
- .NET SDK 6+
- SQL Server 2016 Express LocalDB (or later)
- Optimizely CLI Tool

### Create database
Install Optimizely CLI Tool with:

```bash
$ dotnet tool install EPiServer.Net.Cli --global --add-source https://nuget.optimizely.com/feed/packages.svc/
````
Then run the following command, which will create the database and modify the connection string:

```bash
$ dotnet-episerver create-cms-database -S . -E "{Path to csproj}" 
````

### Run project

```bash
$ dotnet run
````
