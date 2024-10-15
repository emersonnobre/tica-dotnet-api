create-database:
	docker-compose up -d
drop-database:
	docker-compose down
database-logs:
	docker-compose logs -f
migrate-database:
	dotnet ef database update

start-dev:
	docker-compose -f docker-compose.dev.yml up --build

upload-to-aws:
	sudo scp -i ticakey.pem -r . ubuntu@ec2-18-231-125-218.sa-east-1.compute.amazonaws.com:/home/ubuntu
