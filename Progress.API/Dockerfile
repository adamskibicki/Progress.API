﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Progress.API/Progress.API.csproj", "Progress.API/"]
COPY ["Progress.Application/Progress.Application.csproj", "Progress.Application/"]
RUN dotnet restore "Progress.API/Progress.API.csproj"
COPY . .
WORKDIR "/src/Progress.API"
RUN dotnet build "Progress.API.csproj" -c Release -o /app/build

FROM build AS testrunner
WORKDIR /src
COPY ["Progress.Application.Tests/Progress.Application.Tests.csproj", "Progress.Application.Tests/"]
RUN dotnet restore "Progress.Application.Tests/Progress.Application.Tests.csproj"
COPY "Progress.Application.Tests/" "Progress.Application.Tests/"
WORKDIR "/src/Progress.Application.Tests"
RUN dotnet build "Progress.Application.Tests.csproj" -c Release
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM build AS publish
RUN dotnet publish "Progress.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Progress.API.dll"]
