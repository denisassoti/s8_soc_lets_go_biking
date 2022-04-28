#!/bin/bash

docker run -p 8080:80 assotidenis/lets_go_biking_light-web-client

 http-server .\dist\LightWebClient\ 
