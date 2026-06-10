# 1. Base Image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# 2. Build Image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 
COPY ["mvc1.csproj", "."]
RUN dotnet restore "mvc1.csproj"

# Build
COPY . .
RUN dotnet build "mvc1.csproj" -c Release -o /app/build

# 3.  Publish
FROM build AS publish
RUN dotnet publish "mvc1.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4.
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mvc1.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 
COPY ["mvc1.csproj", "."]
RUN dotnet restore "mvc1.csproj"

#Build
COPY . .
RUN dotnet build "mvc1.csproj" -c Release -o /app/build

# 3. Publish
FROM build AS publish
RUN dotnet publish "mvc1.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mvc1.dll"]