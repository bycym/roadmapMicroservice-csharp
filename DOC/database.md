```shell
dotnet add package Pomelo.EntityFrameworkCore.PostgresSQL
```

### doing it first time

```shell
dotnet restore
```

migrate database
```shell
dotnet ef migrations add cloudSqlMigration --context InstitutionContext
```

update database
```shell
dotnet ef database update --context InstitutionContext
```