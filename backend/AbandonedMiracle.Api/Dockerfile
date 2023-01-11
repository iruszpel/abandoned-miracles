FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AbandonedMiracle.Api/AbandonedMiracle.Api.csproj", "AbandonedMiracle.Api/"]
RUN dotnet restore "AbandonedMiracle.Api/AbandonedMiracle.Api.csproj"
COPY . .
WORKDIR "/src/AbandonedMiracle.Api"
RUN dotnet build "AbandonedMiracle.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AbandonedMiracle.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AbandonedMiracle.Api.dll"]
