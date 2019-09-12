FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["DictoWeb/DictoWeb.csproj", "DictoWeb/"]
COPY ["DictoData/DictoData.csproj", "DictoData/"]
COPY ["DictoDtos/DictoInfrasctructure.csproj", "DictoDtos/"]
COPY ["DictoServices/DictoServices.csproj", "DictoServices/"]
RUN dotnet restore "DictoWeb/DictoWeb.csproj"
COPY . .
WORKDIR "/src/DictoWeb"
RUN dotnet build "DictoWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DictoWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DictoWeb.dll"]