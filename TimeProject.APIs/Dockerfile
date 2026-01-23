FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TimeProject.APIs/TimeProject.APIs.csproj", "TimeProject.APIs/"]
COPY ["TimeProject.Application/TimeProject.Application.csproj", "TimeProject.Application/"]
COPY ["TimeProject.Domain/TimeProject.Domain.csproj", "TimeProject.Domain/"]
COPY ["TimeProject.Infrastructure/TimeProject.Infrastructure.csproj", "TimeProject.Infrastructure/"]
RUN dotnet restore "TimeProject.APIs/TimeProject.APIs.csproj"
COPY . .
WORKDIR "/src/TimeProject.APIs"
RUN dotnet build "./TimeProject.APIs.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TimeProject.APIs.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeProject.APIs.dll"]
