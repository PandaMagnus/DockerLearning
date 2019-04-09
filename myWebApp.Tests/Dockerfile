## Use Windows Server Core to get all the necessary bits for Chrome to work as expected
FROM microsoft/windowsservercore

## Install Chocolatey
RUN powershell -Command iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'));

## Install Chrome and dotnet core
RUN choco install googlechrome -y
RUN choco install dotnetcore-sdk -y

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Currently working:
# .\DockerLearning\myWebApp.Tests>docker build -t mywebapptests .
# .\DockerLearning\myWebApp.Tests>docker run -it --name mytestcontainer mywebapptests