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

1	. You may need to type "thisisunsafe" in Chrome if there are any certificate issues. It will be required just once.
Installed an ASP.NET Core HTTPS development certificate. To trust the certificate, run 'dotnet dev-certs https --trust'
2. If you can't connect to SQL Server on your local, follow  steps here https://learn.microsoft.com/en-us/answers/questions/1188831/cannot-connect-to-sql-server-from-a-docker-contain. 
First 2 steps should be enough.
3. On Windows 11 you might need to find SQL server process, right-click it, click Properties, select Log On tab and make sure that "Local System account" is selected with "Allow service to interact with desktop".
4. To run all containers at once select "docker-compose" in Visual Studio drop down (right beside "Any CPU") and click Docker Compose

Repository

1. To work with migrations install/update EntityFramework tools:
    dotnet tool install --global dotnet-ef --version 8.*

2. To add migrations run in the project folder (cd MoltenCore.Boilerplate)
	dotnet ef migrations add {migration name} --context BoilerplateDbContext

3. To generate migrations file run in project folder:
	dotnet ef migrations script --idempotent --context BoilerplateDbContext --output .\Migrations\all-migrations.sql


To create and update DB structure:

1. Create moltenCore database, if not done already
2. Create users

-- Login: boilerplate_reader
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'boilerplate_reader')
                  BEGIN
CREATE LOGIN [boilerplate_reader] WITH PASSWORD = 0x02008E12118460FC74A2FF242241FC5C29E004C82C20878F3910A3D465823F895B5969DB5858EF38ED71037B028591DDFD55FC478745275AFA5D07C9CD1A2D05670E05B5DB35 HASHED, SID = 0xDEA95A7E3572B2499C65B899EBB39274, DEFAULT_DATABASE = [MoltenCore], DEFAULT_LANGUAGE = [us_english], CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF
 
END
 
-- Login: boilerplate_reader_writer
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'boilerplate_reader_writer')
                  BEGIN
CREATE LOGIN [boilerplate_reader_writer] WITH PASSWORD = 0x0200E9E032734CC7B1120E095790F458274AD01DABA99A54604FD17BDFEF5B10DE355275D89F807F8893705DB8B9E563462A9E5381F13E448806D62E4DA860B82E19C3AA2160 HASHED, SID = 0x085C131BE9BB1147B59531807013C7A7, DEFAULT_DATABASE = [MoltenCore], DEFAULT_LANGUAGE = [us_english], CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF
 
END

2. To apply migrations run .\Migrations\all-migrations.sql under accont that have sufficient priviledges. On dev it could be db owner