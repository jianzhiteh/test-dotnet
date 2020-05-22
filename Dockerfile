FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o published --self-contained true -r linux-x64

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=builder ./app/published .
ENTRYPOINT ["dotnet", "test-mvc.dll"]
