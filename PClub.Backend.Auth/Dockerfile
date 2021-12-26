#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PClub.Backend.Auth/PClub.Backend.Auth.csproj", "PClub.Backend.Auth/"]
RUN dotnet restore "PClub.Backend.Auth/PClub.Backend.Auth.csproj"
COPY . .
WORKDIR "/src/PClub.Backend.Auth"
RUN dotnet build "PClub.Backend.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PClub.Backend.Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PClub.Backend.Auth.dll"]