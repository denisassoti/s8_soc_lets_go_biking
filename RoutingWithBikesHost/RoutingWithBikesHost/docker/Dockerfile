# FROM mcr.microsoft.com/dotnet/framework/wcf:4.8 
# #FROM microsoft/wcf

# MAINTAINER "Lidaou Denis ASSOTI (denisassoti2000@gmail.com)"

# # Loading the executable server inside the image
# COPY ./../bin/Debug/RoutingWithBikesHost.exe ./server.exe

# EXPOSE 8733

# # Running the .Net wcf server 
# ENTRYPOINT ["./server.exe"]

FROM mono:6.12

MAINTAINER "Lidaou Denis ASSOTI (denisassoti2000@gmail.com)"

# Loading the executable server inside the image
COPY ../bin/Debug/RoutingWithBikesHost.exe ./server.exe

EXPOSE 8733

# Running the .Net server as standalone
ENTRYPOINT ["mono", "./server.exe"]
