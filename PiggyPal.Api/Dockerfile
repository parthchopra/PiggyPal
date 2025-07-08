FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PiggyPal.Api/PiggyPal.Api.csproj", "PiggyPal.Api/"]
RUN dotnet restore "PiggyPal.Api/PiggyPal.Api.csproj"
COPY . .
WORKDIR "/src/PiggyPal.Api"
RUN dotnet build "PiggyPal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PiggyPal.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME ["/app/Uploads"]
ENTRYPOINT ["dotnet", "PiggyPal.Api.dll"] 