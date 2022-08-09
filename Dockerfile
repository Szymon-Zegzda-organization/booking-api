FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Booking.Server
COPY . .
# Restore as distinct layers

RUN dotnet restore "./Booking.Server/Booking.Server.API/Booking.Server.API.csproj" --disable-parallel
RUN dotnet restore "./Booking.Server/Booking.Server.DB/Booking.Server.DB.csproj" --disable-parallel
RUN dotnet restore "./Booking.Server/Booking.Server.Test/Booking.Server.Test.csproj" --disable-parallel

RUN dotnet publish "./Booking.Server/Booking.Server.API/Booking.Server.API.csproj" -c release -o /app --no-restore
RUN dotnet publish "./Booking.Server/Booking.Server.DB/Booking.Server.DB.csproj" -c release -o /app --no-restore
RUN dotnet publish "./Booking.Server/Booking.Server.Test/Booking.Server.Test.csproj" -c release -o /app --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/ ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Booking.Server.API.dll"]