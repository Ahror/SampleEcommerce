#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/ProductPricing/ProductPricing.Api/ProductPricing.Api.csproj", "src/Services/ProductPricing/ProductPricing.Api/"]
RUN dotnet restore "src/Services/ProductPricing/ProductPricing.Api/ProductPricing.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/ProductPricing/ProductPricing.Api"
RUN dotnet build "ProductPricing.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductPricing.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductPricing.Api.dll"]