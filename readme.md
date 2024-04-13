Clean Architecture
CQRS (Models tailored for CRUD operations)
Environment parameters set in .env
docker-compose


Swagger
	Exception handling
	Logging
			AppInsights
		Authenticatication/Authorization
	Automated testing
API versioning
	
DB
Code first Db/migrations
Db agnostic
Read-only and mixed contexts
All time is time-zone agnostic (UTC)
Retries for transient fault handling
	History tracking
	Automated auth in data layer


		Customization: id type, db engine, health endpoint name


**SETUP**

1. You may need to type "thisisunsafe" in Chrome if there are any certificate issues. It will be required just once.
2. If you can't connect to SQL Server on your local, follow  steps here https://learn.microsoft.com/en-us/answers/questions/1188831/cannot-connect-to-sql-server-from-a-docker-contain. 
First 2 steps should be enough.
3. On Windows 11 you might need to find SQL server process, right-click it, click Properties, select Log On tab and make sure that "Local System account" is selected with "Allow service to interact with desktop".
4. To run all containers at once select "docker-compose" in Visual Studio drop down (right beside "Any CPU") and click Docker Compose


For MoltenCore.Boilerplate:

1. Create users

-- Login: boilerplate_reader
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'boilerplate_reader')
                  BEGIN
CREATE LOGIN [boilerplate_reader] WITH PASSWORD = HASHED, SID = 0xA673E5ACF6C6064492884CD5BC9B8B28, DEFAULT_DATABASE = [master], DEFAULT_LANGUAGE = [us_english], CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF
 
END
 
-- Login: boilerplate_reader_writer
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'boilerplate_reader_writer')
                  BEGIN
CREATE LOGIN [boilerplate_reader_writer] WITH PASSWORD =  HASHED, SID = 0xD2F4D973A1972049B62B6C5A193506D9, DEFAULT_DATABASE = [master], DEFAULT_LANGUAGE = [us_english], CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF
 
END

2. To apply migrations run .\Migrations\all-migrations.sql
3. To work with migrations you may need to use
    dotnet tool install --global dotnet-ef --version 8.*

4. To add migrations run in project folder 
	dotnet ef migrations add {migration name} --context BoilerplateDbContext

5. To generate migrations file run in project folder:
	dotnet ef migrations script --idempotent --context BoilerplateDbContext --output .\Migrations\all-migrations.sql