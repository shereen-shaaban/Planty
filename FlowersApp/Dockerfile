
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY FlowersApp/FlowersApp.csproj  FlowersApp/
COPY DAL/PlantsDAL.csproj          PlantsDAL/
COPY PlantsBAL/PlantsBAL.csproj    PlantsBAL/
COPY PlantsDTO/PlantsDTO.csproj    PlantsDTO/

RUN dotnet restore  FlowersApp/FlowersApp.csproj


WORKDIR /app
COPY . .
RUN dotnet publish FlowersApp/FlowersApp.csproj -c Release -o /app/out     


FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
EXPOSE 80
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "FlowersApp.dll"]   