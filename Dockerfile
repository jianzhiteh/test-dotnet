FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
ARG BUILD_VERSION=0.0.0.0
WORKDIR /app
COPY . ./
RUN dotnet publish /p:Version=$BUILD_VERSION --self-contained -c Release -o published -r linux-x64

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=builder ./app/published .
COPY ./logs ./logs
ENTRYPOINT ["dotnet", "test-mvc.dll"]
