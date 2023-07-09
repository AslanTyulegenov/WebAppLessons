FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAppLessonsApi/WebAppLessonsApi.csproj", "WebAppLessonsApi/"]
RUN dotnet restore "WebAppLessonsApi/WebAppLessonsApi.csproj"
COPY . .
WORKDIR "/src/WebAppLessonsApi"
RUN dotnet build "WebAppLessonsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppLessonsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppLessonsApi.dll"]
