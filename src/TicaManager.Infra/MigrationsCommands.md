# Para criar sua migração
````cd src/TicaManager.Infra````\
```dotnet ef migrations add NomeDaMigration --startup-project ../TicaManager.Api/```
# Para atualizar a base de dados
````cd src/TicaManager.Infra````\
```dotnet ef database update --startup-project ../TicaManager.Api/```
# Para desfazer a última migração
````cd src/TicaManager.Infra````\
```dotnet ef migrations remove --startup-project ../TicaManager.Api/```
```dotnet ef database update --startup-project ../TicaManager.Api/```


