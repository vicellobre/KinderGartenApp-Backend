# Etapa 1: Restaurar dependencias (restore)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src

# Copiar los archivos necesarios para restaurar dependencias
COPY *.sln .
COPY KinderGartenApp.API/*.csproj ./KinderGartenApp.API/
COPY KinderGartenApp.Core/*.csproj ./KinderGartenApp.Core/
COPY KinderGartenApp.Tests/*.csproj ./KinderGartenApp.Tests/

# Restaurar dependencias
RUN dotnet restore ./KinderGartenApp.API/KinderGartenApp.API.csproj

# Etapa 2: Compilar y publicar la aplicación (build y publish)
FROM restore AS build
WORKDIR /src

# Copiar el resto del código fuente una vez que las dependencias han sido restauradas
COPY . .

# Construir y publicar la aplicación en una única capa
RUN dotnet publish ./KinderGartenApp.API/KinderGartenApp.API.csproj -c Release -o /app/publish --no-restore

# Etapa 3: Ejecutar la aplicación (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar los archivos publicados desde la etapa de build
COPY --from=build /app/publish .

# Exponer los puertos que usará la aplicación
EXPOSE 8080
EXPOSE 8081

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "KinderGartenApp.API.dll"]
