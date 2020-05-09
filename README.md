#FoodAutomation
##### A project to start working with Dot Net Core 3.1
## guide line:
#####after clone project [install Dot Net Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/)
###Follow these instructions:
1. dotnet new webapi
2. rm WeatherForecast.cs 
3. rm Controllers/WeatherForecastController.cs
4. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
5. dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson

###create .gitignore file and add :
> - bin/
- obj/ 
- FoodAutomation.csproj
- appsettings.json
- appsettings.Development.json
- Properties

###for creating database :
1. dotnet tool install --global dotnet-ef
2. dotnet-ef dotnet add package Microsoft.EntityFrameworkCore.Design
3. dotnet ef migrations add InitialCreate
4. dotnet ef database update

####and customize DBstring in the ./DBContext.cs
