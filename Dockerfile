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

ENV ASPNETCORE_URLS=http://+:5000
#ENV ASPNETCORE_URLS=http://+:5000;https://+:5001
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 5000
#EXPOSE 5001

ENTRYPOINT ["dotnet", "Formula1.MVC.dll"]

# $ docker build . -t formula1:1.0
# $ docker run -d -p 5000:5000 formula1:1.0

