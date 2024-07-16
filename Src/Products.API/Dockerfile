#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Products.API/Products.API.csproj", "Src/Products.API/"]
COPY ["Src/Products.Infrastructure/Products.Infrastructure.csproj", "Src/Products.Infrastructure/"]
COPY ["Src/Products.Application/Products.Application.csproj", "Src/Products.Application/"]
COPY ["Src/Products.Domain/Products.Domain.csproj", "Src/Products.Domain/"]
RUN dotnet restore "./Src/Products.API/Products.API.csproj"
COPY . .
WORKDIR "/src/Src/Products.API"
RUN dotnet build "./Products.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Products.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.API.dll"]