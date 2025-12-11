docker network create sampletesting1 --label=sampletesting1
docker-compose -f containers/redis.yml up -d
exit $LASTEXITCODE