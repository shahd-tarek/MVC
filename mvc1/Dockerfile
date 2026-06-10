# 1. Base Image لتشغيل التطبيق
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# 2. Image الـ Build عشان نعمل Compile للكود
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# نسخ ملف الـ csproj وعمل Restore للـ Dependencies
COPY ["mvc1.csproj", "."]
RUN dotnet restore "mvc1.csproj"

# نسخ باقي ملفات المشروع وعمل Build
COPY . .
RUN dotnet build "mvc1.csproj" -c Release -o /app/build

# 3. مرحلة الـ Publish
FROM build AS publish
RUN dotnet publish "mvc1.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. المرحلة النهائية: نسخ الملفات الجاهزة وتشغيل التطبيق
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mvc1.dll"]# 1. Base Image لتشغيل التطبيق
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Image الـ Build عشان نعمل Compile للكود
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# نسخ ملف الـ csproj وعمل Restore للـ Dependencies
COPY ["mvc1.csproj", "."]
RUN dotnet restore "mvc1.csproj"

# نسخ باقي ملفات المشروع وعمل Build
COPY . .
RUN dotnet build "mvc1.csproj" -c Release -o /app/build

# 3. مرحلة الـ Publish
FROM build AS publish
RUN dotnet publish "mvc1.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. المرحلة النهائية: نسخ الملفات الجاهزة وتشغيل التطبيق
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mvc1.dll"]