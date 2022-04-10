#!/bin/bash

# Building the docker image.
docker build -t assotidenis/lets_go_biking_routing-with-bikes-service:latest .

#deploying the docker image to the docker hub.
docker push assotidenis/lets_go_biking_routing-with-bikes-service