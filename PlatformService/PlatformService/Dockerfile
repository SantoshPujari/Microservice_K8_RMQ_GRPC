FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "PlatformService.dll" ]

# docker build . -t santoshrpujari/platformservice
# docker run -p 8080:80 -e ASPNETCORE_URLS=http://+:80 santoshrpujari/platformservice
# docker push santoshrpujari/platformservice