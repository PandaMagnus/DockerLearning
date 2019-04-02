FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Install Chrome
# FROM mcr.microsoft.com/powershell
#FROM microsoft/windowsservercore
FROM microsoft/powershell
RUN powershell -Command iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'));
RUN choco install googlechrome --ignore-checksums

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]