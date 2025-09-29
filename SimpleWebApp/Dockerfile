# ====== Build stage ======
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy project files first for better layer caching
COPY SimpleWebApp/*.csproj SimpleWebApp/
# (add more COPY lines here if you reference other projects)
RUN dotnet restore SimpleWebApp/SimpleWebApp.csproj

# now copy everything and publish
COPY . .
RUN dotnet publish SimpleWebApp/SimpleWebApp.csproj -c Release -o /out --no-restore

# ====== Runtime stage ======
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# run as non-root (optional but recommended)
RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

COPY --from=build /out ./

# Bind Kestrel to all interfaces on 5020
ENV ASPNETCORE_URLS=http://+:5020
EXPOSE 5020

ENTRYPOINT ["dotnet", "SimpleWebApp.dll"]  