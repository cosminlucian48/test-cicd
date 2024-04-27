# Use the base Windows Server Core image
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019

# Set working directory
WORKDIR /app

# Copy the .NET 4.8 console application executable
COPY bin/Debug .

# Set entrypoint to run the executable
CMD ["dissertation_prosumer.exe"]