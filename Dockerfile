# Stage 1 - build stage
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
WORKDIR /app
# COPY Api/*.csproj .
# RUN dotnet restore
COPY . .
RUN dotnet restore
# RUN dotnet publish Api/spa-cloud.csproj --output /app/bin/ --configuration Release --self-contained -r alpine-x64
RUN dotnet publish profileMicroservice.sln --output /app/bin/ --configuration Release --self-contained true /p:useapphost=true -r alpine-x64
# RUN dotnet test ./Tests/Tests.csproj # I am sorry

# Stage 2 - runtime stage
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine3.11 as runtime
WORKDIR /app
COPY --from=builder /root/.microsoft /root/.microsoft
COPY --from=builder /app/bin/ .
RUN ["apk", "add", "--no-cache", "dumb-init"]
ENV ASPNETCORE_URLS="http://0.0.0.0:5001"
ENV ASPNETCORE_ENVIRONMENT="Azure"
EXPOSE 5001
ENTRYPOINT ["/usr/bin/dumb-init", "--"]
CMD ["./spa-cloud"]
