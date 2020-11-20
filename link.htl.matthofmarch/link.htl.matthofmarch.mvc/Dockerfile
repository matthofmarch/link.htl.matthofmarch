#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["link.htl.matthofmarch.mvc/link.htl.matthofmarch.mvc.csproj", "link.htl.matthofmarch.mvc/"]
RUN dotnet restore "link.htl.matthofmarch.mvc/link.htl.matthofmarch.mvc.csproj"
COPY . .
WORKDIR "/src/link.htl.matthofmarch.mvc"
RUN dotnet build "link.htl.matthofmarch.mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "link.htl.matthofmarch.mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "link.htl.matthofmarch.mvc.dll"]