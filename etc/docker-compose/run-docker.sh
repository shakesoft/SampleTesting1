#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p aa0982f8-b2af-4668-ac0f-ed82a484b0bb -t
    fi
    cd ../
fi

docker-compose up -d
