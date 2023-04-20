# Vectra | Pessoa Desenvolvedora 

Este projeto foi gerado com ASP.NET Core versão 6.0

## Servidor de desenvolvimento

No Visual Studio, ao selecionar o projeto **Vectra.Avaliacao.Backend** como `startup project` ou `projeto de inicialização` e clicar em IIS Express na parte superior após tudo estar configurado corretamente.

## Compilação

Clicar em CTRL + SHIFT + B

___
# LEMBRETES

### Após abrir a solução e baixar os pacotes, configurar a sua connection string no arquivo `appsettings.json` e executar o `update-database` no console gerenciador do nuget
### `(Ferramentas >> Gerenciador de Pacotes do NuGet >> Console do Gerenciador de Pacotes) `

___
#### Resumo & Orientações
Este é um projeto ASP.NET Core 5.0 que abastece o front-end https://github.com/ghsalazar1/avaliacao_dev_frontend. Neste projeto temos funcionando a implementação do EF Core (Entity Framework [context & interfaces]), com listagem e criação de registros da tabela "Conta". Também temos o conceito de recebimento de requisições e respostas implementado no arquivo `ContaController.cs`.

Não foi implementado nenhum conceito de arquitetura neste projeto, apenas um controller no formato REST para gerenciar as requisições feitas ao servidor.

- Crie uma branch com seu nome e boa sorte!

### Fique a vontade para implementar qualquer melhoria, inclusive conceitos diferentes na organização da solução.
### Qualquer mudança seja funcional ou estrutural será avaliada.
