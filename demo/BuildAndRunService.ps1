Set-PSDebug -Trace 1
Set-Location \td\cadl\packages\samples\specs\rest\petstore
npx tsp compile . --emit ../../../../service-generator-csharp/ --output-dir C:\pr\demo\svc\generated
Set-Item Env:\ASPNETCORE_URLS "https://localhost:7213;http://localhost:5240"
Set-Location \pr\demo
Start-Process dotnet -ArgumentList "run", "--project", "C:\pr\demo\svc\PetStore.csproj"