FROM mcr.microsoft.com/dotnet/aspnet:6.0
LABEL version="1.0.1" description="APP ASP NET CORE MVC"
COPY dist /app 
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "mvc1.dll"]