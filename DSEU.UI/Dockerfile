#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV TZ=Asia/Ashgabat

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["DSEU.UI/DSEU.UI.csproj", "DSEU.UI/"]
COPY ["DSEU.Shared/DSEU.Shared.csproj", "DSEU.Shared/"]
COPY ["DSEU.Domain/DSEU.Domain.csproj", "DSEU.Domain/"]
COPY ["DSEU.Application/DSEU.Application.csproj", "DSEU.Application/"]
COPY ["DSEU.DataAccess.Interfaces/DSEU.DataAccess.Interfaces.csproj", "DSEU.DataAccess.Interfaces/"]
COPY ["DSEU.Identity.Interfaces/DSEU.Identity.Interfaces.csproj", "DSEU.Identity.Interfaces/"]
COPY ["DSEU.Infrastrucuture.Interfaces/DSEU.Infrastrucuture.Interfaces.csproj", "DSEU.Infrastrucuture.Interfaces/"]
COPY ["DSEU.Reporting.Interfaces/DSEU.Reporting.Interfaces.csproj", "DSEU.Reporting.Interfaces/"]
COPY ["DSEU.StateRegisterSearch.Interfaces/DSEU.StateRegisterSearch.Interfaces.csproj", "DSEU.StateRegisterSearch.Interfaces/"]
COPY ["DSEU.Infrastructure/DSEU.Infrastructure.csproj", "DSEU.Infrastructure/"]
COPY ["DSEU.Infrastructure.DataProtection/DSEU.Infrastructure.DataProtection.csproj", "DSEU.Infrastructure.DataProtection/"]
COPY ["DSEU.Infrastructure.Identity/DSEU.Infrastructure.Identity.csproj", "DSEU.Infrastructure.Identity/"]
COPY ["DSEU.Infrastructure.Persistence/DSEU.Infrastructure.Persistence.csproj", "DSEU.Infrastructure.Persistence/"]
COPY ["DSEU.Infrastructure.Report/DSEU.Infrastructure.Report.csproj", "DSEU.Infrastructure.Report/"]
COPY ["DSEU.Infrastructure.StateRegisterSearch/DSEU.Infrastructure.StateRegisterSearch.csproj", "DSEU.Infrastructure.StateRegisterSearch/"]
RUN dotnet restore --disable-parallel "DSEU.UI/DSEU.UI.csproj"
COPY . .
WORKDIR "/src/DSEU.UI"
RUN dotnet build "DSEU.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSEU.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
