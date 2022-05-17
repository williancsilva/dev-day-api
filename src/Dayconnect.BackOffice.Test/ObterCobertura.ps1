Set-Location $PSScriptRoot

dotnet clean
dotnet build
dotnet test

coverlet `
.\bin\Debug\net6.0\Dayconnect.Backoffice.Test.dll `
--target "dotnet" `
--targetargs "test --no-build" `
--exclude "[*]Dayconnect.backoffice.Repository.*" `
--exclude "[*]Dayconnect.backoffice.ExternalService.*" `
--exclude "[*]Dayconnect.backoffice.App.Dto.Result.*" `
--exclude "[*]Dayconnect.backoffice.Domain.Models.Result.*" `
--exclude "[*]Dayconnect.backoffice.App.Validators.CustomValidator.*" `
--include "[*]Dayconnect.backoffice.App*" `
--include "[*]Dayconnect.backoffice.Domain*" `
-f cobertura

reportgenerator -reports:"coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

Start-Process .\coveragereport\index.htm