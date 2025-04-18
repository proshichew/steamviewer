# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы проекта и восстанавливаем зависимости
COPY ["Steamviewer/Steamviewer.csproj", "Steamviewer/"]
COPY ["Steamviewer.Client/Steamviewer.Client.csproj", "Steamviewer.Client/"]
RUN dotnet restore "Steamviewer/Steamviewer.csproj"

# Копируем все файлы и собираем проект
COPY . .
WORKDIR "/src/Steamviewer"
RUN dotnet build "Steamviewer.csproj" -c Release -o /app/build

# Публикуем проект
FROM build AS publish
RUN dotnet publish "Steamviewer.csproj" -c Release -o /app/publish

# Используем образ .NET Runtime для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Steamviewer.dll"]