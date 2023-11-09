# Preparation 

```shell
dotnet new webapi -n roadmapMicroservice
```

```shell
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Serilog.AspNetCore --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0-rc.2.23480.1


# for postgressql server
dotnet add package Pomelo.EntityFrameworkCore.PostgresSQL

# for mysql server
dotnet add package Pomelo.EntityFrameworkCore.mysql
dotnet add package Microsoft.EntityFrameworkCore.SqlServer


dotnet new sln -n profileMicroservice
dotnet sln profileMicroservice.sln add profileMicroservice
dotnet publish profileMicroservice.sln --output /app/bin/ --configuration Release --self-contained true /p:useapphost=true -r alpine-x64
dotnet build
```