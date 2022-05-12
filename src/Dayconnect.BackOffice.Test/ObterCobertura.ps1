Set-Location $PSScriptRoot

dotnet clean
dotnet build
dotnet test

coverlet `
.\bin\Debug\net6.0\Dayconnect.Backoffice.Test.dll `
--target "dotnet" `
--targetargs "test --no-build" `
--exclude "[*]Dayconnect.Backoffice.Repository.*" `
--exclude "[*]Dayconnect.Backoffice.ExternalService.*" `
--exclude "[*]Dayconnect.Backoffice.App.Dto.Result.*" `
--exclude "[*]Dayconnect.Backoffice.Domain.Models.Result.*" `
--exclude "[*]Dayconnect.Backoffice.App.Validators.CustomValidator.*" `
--include "[*]Dayconnect.Backoffice.App*" `
--include "[*]Dayconnect.Backoffice.Domain*" `
-f cobertura

reportgenerator -reports:"coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

Start-Process .\coveragereport\index.htm