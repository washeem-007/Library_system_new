# Use ASP.NET Core runtime image (for final stage)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LIBRARY_SYSTEM.csproj", "./"]
RUN dotnet restore "./LIBRARY_SYSTEM.csproj"

COPY . .
WORKDIR "/src/"
RUN dotnet build "LIBRARY_SYSTEM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LIBRARY_SYSTEM.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ls -la /app      
COPY ./library.db ./

ENV ASPNETCORE_URLS=http://0.0.0.0:80
ENTRYPOINT ["dotnet", "LIBRARY_SYSTEM.dll"]

