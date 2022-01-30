# Finance.BlazorServer
## Local development setup
1. Make sure you have Docker installed.
2. Create the SQL database in Docker: 
> `docker run -d -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=My!P@ssw0rd1" -p 1433:1433 --name Finance mcr.microsoft.com/mssql/server:latest`
3. Create a new environment variable named "SqlDbPassword" with value "My!P@ssw0rd1"