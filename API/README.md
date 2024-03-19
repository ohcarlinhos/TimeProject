# Configurações
## Postgres
```
docker run --name pomodoro_pg -e POSTGRES_PASSWORD=1234 -p 5432:5432 -d postgres
```
## Migrations
```
dotnet ef database update --project PomodoroAPI
```