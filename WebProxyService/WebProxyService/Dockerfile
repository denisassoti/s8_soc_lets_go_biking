FROM mono:6.12

MAINTAINER "Lidaou Denis ASSOTI (denisassoti2000@gmail.com)"

# Loading the executable server inside the image
COPY ./bin/Debug/WebProxyService.exe ./server.exe

EXPOSE 8732

# Running the .Net server as standalone
ENTRYPOINT ["mono", "./server.exe"]
