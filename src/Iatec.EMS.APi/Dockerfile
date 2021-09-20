#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Iatec.EMS.APi/Iatec.EMS.APi.csproj", "src/Iatec.EMS.APi/"]
RUN dotnet restore "src/Iatec.EMS.APi/Iatec.EMS.APi.csproj"
COPY . .
WORKDIR "/src/src/Iatec.EMS.APi"
RUN dotnet build "Iatec.EMS.APi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Iatec.EMS.APi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Iatec.EMS.APi.dll"]