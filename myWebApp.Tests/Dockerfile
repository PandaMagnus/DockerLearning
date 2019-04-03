# Install Powershell
FROM microsoft/powershell

# Install Chocolatey
RUN powershell -Command iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'));

# Install Chrome
RUN choco install googlechrome --ignore-checksums -y

# This probably won't work. Need to copy Chrome from prior build stage to this one.
FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "mywebapp.tests.dll"]

# D:\Projects\DockerLearning\myWebApp.Tests>docker build -t mywebapptests .
# ???