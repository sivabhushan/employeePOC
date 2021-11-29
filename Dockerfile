#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY *.sln /EmployeeCoreApp/
COPY EmployeeCoreApp/EmployeeCoreApp.csproj /EmployeeCoreApp/
COPY EmployeeBAL/EmployeeBAL.csproj /EmployeeBAL/
COPY EmployeeDAL/EmployeeDAL.csproj /EmployeeDAL/
#RUN dotnet restore "./EmployeeCoreApp.csproj"
RUN dotnet restore /EmployeeCoreApp/*.csproj
COPY . .
WORKDIR "/src/."
RUN dotnet build "EmployeeCoreApp/EmployeeCoreApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeCoreApp/EmployeeCoreApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeCoreApp.dll"]