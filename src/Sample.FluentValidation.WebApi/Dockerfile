FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Sample.FluentValidation.WebApi/Sample.FluentValidation.WebApi.csproj", "src/Sample.FluentValidation.WebApi/"]
COPY ["src/Sample.FluentValidation.WebApi.Core/Sample.FluentValidation.WebApi.Core.csproj", "src/Sample.FluentValidation.WebApi.Core/"]
RUN dotnet restore "src/Sample.FluentValidation.WebApi/Sample.FluentValidation.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Sample.FluentValidation.WebApi"
RUN dotnet build "Sample.FluentValidation.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.FluentValidation.WebApi.csproj" -c Release -o /app/publish

ENV TZ=America/Sao_Paulo
ENV LANG pt-BR
ENV LANGUAGE pt-BR
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.FluentValidation.WebApi.dll"]