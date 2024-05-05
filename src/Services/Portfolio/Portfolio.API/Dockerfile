ARG APP_UID=0
ARG APP_GID=0

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
USER $APP_UID:$APP_GID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Portfolio/Portfolio.API/Portfolio.API.csproj", "src/Services/Portfolio/Portfolio.API/"]
RUN dotnet restore "src/Services/Portfolio/Portfolio.API/Portfolio.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Portfolio/Portfolio.API"
RUN dotnet build "Portfolio.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Portfolio.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
# Redefine ARGs
ARG APP_UID=0
ARG APP_GID=0
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./src/Services/Portfolio/Portfolio.API/uploads /app/uploads
USER root
RUN chown -R $APP_UID:$APP_GID /app/uploads
ENTRYPOINT ["dotnet", "Portfolio.API.dll"]