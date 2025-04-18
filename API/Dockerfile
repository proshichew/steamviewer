FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем и восстанавливаем каждый проект по очереди
COPY ["API/API.csproj", "API/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["DAL/Domain/Domain.csproj", "DAL/Domain/"]  # <-- Добавляем Domain

RUN dotnet restore "API/API.csproj"
RUN dotnet restore "DAL/DAL.csproj"
RUN dotnet restore "DAL/Domain/Domain.csproj"  # <-- Восстанавливаем Domain

# Копируем все остальные файлы
COPY . .

WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
