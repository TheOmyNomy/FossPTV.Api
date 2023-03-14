dotnet remove FossPTV.Api/FossPTV.Api.csproj reference PtvSharp/PtvSharp/PtvSharp.csproj
dotnet sln FossPTV.Api.sln remove PtvSharp/PtvSharp/PtvSharp.csproj

dotnet sln FossPTV.Api.sln add ../PtvSharp/PtvSharp/PtvSharp.csproj
dotnet add FossPTV.Api/FossPTV.Api.csproj reference ../PtvSharp/PtvSharp/PtvSharp.csproj
