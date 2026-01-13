# Configurações

## Postgres

```
docker run --name TimeProject -e POSTGRES_PASSWORD=1234 -p 5432:5432 -d postgres
```

## Migrations

```
dotnet ef database update --project TimeProject.APIs
```