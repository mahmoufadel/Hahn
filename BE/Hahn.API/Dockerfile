#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hahn.API/Hahn.ApplicatonProcess.July2021.Web.csproj", "Hahn.API/"]
COPY ["Hahn.Application/Hahn.ApplicatonProcess.July2021.Application.csproj", "Hahn.Application/"]
COPY ["Hahn.Domain/Hahn.ApplicatonProcess.July2021.Domain.csproj", "Hahn.Domain/"]
COPY ["Hahn.Identity/Hahn.ApplicatonProcess.July202.Identity.csproj", "Hahn.Identity/"]
COPY ["Hahn.Cache.Redis/Hahn.Cache.Redis.csproj", "Hahn.Cache.Redis/"]
COPY ["Hahn.Infra/Hahn.ApplicatonProcess.July2021.Data.csproj", "Hahn.Infra/"]
RUN dotnet restore "Hahn.API/Hahn.ApplicatonProcess.July2021.Web.csproj"
COPY . .
WORKDIR "/src/Hahn.API"
RUN dotnet build "Hahn.ApplicatonProcess.July2021.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hahn.ApplicatonProcess.July2021.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hahn.ApplicatonProcess.July2021.Web.dll"]