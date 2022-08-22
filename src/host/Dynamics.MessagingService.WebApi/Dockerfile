FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

#EXPOSE 80
#EXPOSE 16666 

# Copy everything
COPY . ./
# Restore as distinct layers
#RUN dotnet restore ...project
# Build and publish a release
WORKDIR /app/host/Dynamics.MessagingService.WebApi
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/host/Dynamics.MessagingService.WebApi/out .
ENTRYPOINT ["dotnet", "Dynamics.MessagingService.WebApi.dll"]