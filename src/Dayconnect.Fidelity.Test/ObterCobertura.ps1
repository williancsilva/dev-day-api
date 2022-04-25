Set-Location $PSScriptRoot

dotnet clean
dotnet build
dotnet test

coverlet `
.\bin\Debug\net6.0\Dayconnect.Fidelity.Test.dll `
--target "dotnet" `
--targetargs "test --no-build" `
--exclude "[*]Dayconnect.Fidelity.Repository.*" `
--exclude "[*]Dayconnect.Fidelity.ExternalService.*" `
--exclude "[*]Dayconnect.Fidelity.App.Dto.Result.*" `
--exclude "[*]Dayconnect.Fidelity.Domain.Models.Result.*" `
--exclude "[*]Dayconnect.Fidelity.App.Validators.CustomValidator.*" `
--include "[*]Dayconnect.Fidelity.App*" `
--include "[*]Dayconnect.Fidelity.Domain*" `
-f cobertura

reportgenerator -reports:"coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

Start-Process .\coveragereport\index.htm