Set-PSDebug -Trace 1
Set-Location C:\td\petstore
Copy-Item C:\td\cadl\packages\samples\specs\rest\petstore\petstore.tsp
npx tsp compile . --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir=C:\pr\demo\client\
Set-Location C:\pr\demo
Start-Process dotnet -ArgumentList "run", "--project", "C:\pr\demo\PetStoreDemo\PetStoreDemo.csproj"