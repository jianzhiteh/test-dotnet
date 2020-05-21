FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY published/test-mvc.dll ./
ENTRYPOINT ["dotnet", "test-mvc.dll"]
