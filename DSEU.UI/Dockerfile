#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["DSEU.UI/DSEU.UI.csproj", "DSEU.UI/"]
COPY ["DSEU.Devexpress/DSEU.Devexpress.csproj", "DSEU.Devexpress/"]
COPY ["DSEU.Infrastructure/DSEU.Infrastructure.csproj", "DSEU.Infrastructure/"]
COPY ["DSEU.Application/DSEU.Application.csproj", "DSEU.Application/"]
COPY ["DSEU.Domain/DSEU.Domain.csproj", "DSEU.Domain/"]
COPY ["DSEU.Security/DSEU.Security.csproj", "DSEU.Security/"]
COPY ["DSEU.Infrastructure.DataProtection/DSEU.Infrastructure.DataProtection.csproj", "DSEU.Infrastructure.DataProtection/"]
COPY ["DSEU.Infrastructure.Identity/DSEU.Infrastructure.Identity.csproj", "DSEU.Infrastructure.Identity/"]
COPY ["DSEU.Infrastructure.Persistence/DSEU.Infrastructure.Persistence.csproj", "DSEU.Infrastructure.Persistence/"]
COPY ["DSEU.Infrastructure.Permissions/DSEU.Infrastructure.Permissions.csproj", "DSEU.Infrastructure.Permissions/"]
RUN dotnet restore "DSEU.UI/DSEU.UI.csproj"
COPY . .
WORKDIR "/src/DSEU.UI"
RUN dotnet build "DSEU.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSEU.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSEU.UI.dll"]
