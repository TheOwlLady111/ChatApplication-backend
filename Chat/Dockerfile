#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Chat/Chat.Api.csproj", "Chat/"]
COPY ["Chat.BLL/Chat.BLL.csproj", "Chat.BLL/"]
COPY ["Chat.DAL/Chat.DAL.csproj", "Chat.DAL/"]
RUN dotnet restore "Chat/Chat.Api.csproj"
COPY . .
WORKDIR "/src/Chat"
RUN dotnet build "Chat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chat.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chat.Api.dll"]