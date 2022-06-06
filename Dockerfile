# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal as build
WORKDIR /source
COPY . .
RUN dotnet restore "Formula1.MVC/Formula1.MVC.csproj"
RUN dotnet publish "Formula1.MVC/Formula1.MVC.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Formula1.MVC.dll"]

# $ docker build . -t teste_felipe
# $ docker run -it -p 5000:5000 teste_felipe
# $ docker run -it -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 teste_felipe

# ASPNETCORE_ENVIRONMENT=Development

