# Use the official Red Hat Universal Base Image (UBI) for .NET 6
FROM registry.access.redhat.com/ubi8/dotnet-60-runtime

# Set the working directory
WORKDIR /app
EXPOSE 80
# Copy the published application files
COPY ./out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "webap.dll"]