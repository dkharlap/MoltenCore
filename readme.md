Clean Architecture
CQRS (Models tailored for CRUD operations)

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


set MoltenCoreBoilerplate__Repository__ConnectionString "true"
set MoltenCoreBoilerplate__Repository__Schema "boilerplate"