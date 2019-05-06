FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BooksApi/BooksApi.csproj", "BooksApi/"]
RUN dotnet restore "BooksApi/BooksApi.csproj"
COPY . .
WORKDIR "/src/BooksApi"
RUN dotnet build "BooksApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BooksApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BooksApi.dll"]