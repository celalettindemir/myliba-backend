FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["presentation/Case.API/Case.API.csproj", "Case.API/"]
RUN dotnet restore "presentation/Case.API/Case.API.csproj"
COPY . .
WORKDIR "/src/Case.API"
RUN dotnet build "Case.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Case.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Case.API.dll"]
