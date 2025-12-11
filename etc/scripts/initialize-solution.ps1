abp install-libs

cd src/SampleTesting1.DbMigrator && dotnet run && cd -



cd src/SampleTesting1.Web && dotnet dev-certs https -v -ep openiddict.pfx -p config.auth_server_default_pass_phrase 

./etc/helm/create-tls-secrets.ps1

exit 0