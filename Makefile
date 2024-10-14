create-database:
	docker-compose up -d
drop-database:
	docker-compose down
database-logs:
	docker-compose logs -f
migrate-database:
	dotnet ef database update