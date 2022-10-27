
dotnet new sln -o Auto
PS C:\Users\Window\Desktop\Auto\Auto> dotnet new webapi -o Auto.Api
The template "ASP.NET Core Web API" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on C:\Users\Window\Desktop\Auto\Auto\Auto.Api\Auto.Api.csproj...
  Determining projects to restore...
  Restored C:\Users\Window\Desktop\Auto\Auto\Auto.Api\Auto.Api.csproj (in 306 ms).
Restore succeeded.


PS C:\Users\Window\Desktop\Auto\Auto> dotnet new classlib -o Auto.Contracts
The template "Class Library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on C:\Users\Window\Desktop\Auto\Auto\Auto.Contracts\Auto.Contracts.csproj...
  Determining projects to restore...
  Restored C:\Users\Window\Desktop\Auto\Auto\Auto.Contracts\Auto.Contracts.csproj (in 97 ms).
Restore succeeded.


PS C:\Users\Window\Desktop\Auto\Auto> dotnet new classlib -o Auto.Infrastructure
The template "Class Library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on C:\Users\Window\Desktop\Auto\Auto\Auto.Infrastructure\Auto.Infrastructure.csproj...
  Determining projects to restore...
  Restored C:\Users\Window\Desktop\Auto\Auto\Auto.Infrastructure\Auto.Infrastructure.csproj (in 98 ms).
Restore succeeded.


PS C:\Users\Window\Desktop\Auto\Auto> dotnet new classlib -o Auto.Application
The template "Class Library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on C:\Users\Window\Desktop\Auto\Auto\Auto.Application\Auto.Application.csproj...
  Determining projects to restore...
  Restored C:\Users\Window\Desktop\Auto\Auto\Auto.Application\Auto.Application.csproj (in 90 ms).
Restore succeeded.


PS C:\Users\Window\Desktop\Auto\Auto> dotnet new classlib -o Auto.Domain
The template "Class Library" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on C:\Users\Window\Desktop\Auto\Auto\Auto.Domain\Auto.Domain.csproj...
  Determining projects to restore...
  Restored C:\Users\Window\Desktop\Auto\Auto\Auto.Domain\Auto.Domain.csproj (in 97 ms).
Restore succeeded.


PS C:\Users\Window\Desktop\Auto\Auto> dotnet build
MSBuild version 17.3.0+92e077650 for .NET
  Determining projects to restore...
C:\Program Files\dotnet\sdk\6.0.400\NuGet.targets(132,5): warning : Unable to find a project to restore! [C:\Users\Window\Desktop\Auto\Auto\Auto.s
ln]

Build succeeded.

C:\Program Files\dotnet\sdk\6.0.400\NuGet.targets(132,5): warning : Unable to find a project to restore! [C:\Users\Window\Desktop\Auto\Auto\Auto.s
ln]
    1 Warning(s)
    0 Error(s)

Time Elapsed 00:00:00.26
PS C:\Users\Window\Desktop\Auto\Auto> more .\Auto.sln

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.30114.105
MinimumVisualStudioVersion = 10.0.40219.1
Global
        GlobalSection(SolutionConfigurationPlatforms) = preSolution
                Debug|Any CPU = Debug|Any CPU
                Release|Any CPU = Release|Any CPU
        EndGlobalSection
        GlobalSection(SolutionProperties) = preSolution
                HideSolutionNode = FALSE
        EndGlobalSection
EndGlobal

PS C:\Users\Window\Desktop\Auto\Auto> dotnet sln add (ls -r **\*.csproj)
Project `Auto.Api\Auto.Api.csproj` added to the solution.
Project `Auto.Application\Auto.Application.csproj` added to the solution.
Project `Auto.Contracts\Auto.Contracts.csproj` added to the solution.
Project `Auto.Domain\Auto.Domain.csproj` added to the solution.
Project `Auto.Infrastructure\Auto.Infrastructure.csproj` added to the solution.


Reference project => PS C:\Users\Window\Desktop\Auto\Auto> dotnet add .\Auto.Api\ reference .\Auto.Contracts\ .\Auto.Application\
`dotnet add .\Auto.Infrastructure\ reference .\Auto.Application\`
`dotnet add .\Auto.Application\ reference .\Auto.Domain\` 
`dotnet add .\Auto.Api\ reference .\Auto.Infrastructure\`


Run => `dotnet run --project .\Auto.Api\`

How to add user-secrets => `dotnet user-secrets init --project .\Auto.Api\` 
Add key => `dotnet user-secrets set --project .\Auto.Api\ "JwtSettings:Secret" "super-secret-key"`
Check value => `dotnet user-secrets list --project .\Auto.Api\`