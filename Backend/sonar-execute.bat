dotnet tool install --global dotnet-sonarscanner
dotnet tool update --global dotnet-sonarscanner
dotnet sonarscanner begin /k:"real-manager-back" 
dotnet build RealManager.sln
dotnet sonarscanner end