# Define a imagem base do SDK do .NET 8.0 para a fase de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos de projeto
COPY *.csproj ./
RUN dotnet restore

# Copia o código-fonte
COPY . ./
RUN dotnet publish -c Release -o out

# Define a imagem de tempo de execução do ASP.NET 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

# Expõe a porta 80 (porta HTTP padrão)
EXPOSE 80

# Define o comando para iniciar a API
ENTRYPOINT ["./entrypoint.sh"]