# Gourmet
#BackEnd
Sistema de cadastro de restaurantes e seus pratos

Package utilizados:

WebAPi;
Entity Framework;
Unit;
Owin;
MSTest;
Swagger;

Técnicas e Padrões de projeto utilizados;

Repository (genérico);
Service;
TDD;
Code First.

Instruções para compilar a solução:

Restaure os Packages através do nuget package;

Abre o arquivo "Gourmet.UI\Web.config" e em "connectionStrings" modifique o "Server" e "Password" de acordo o servidor SQL Server instalado.

No visual studio, abra o arquivo "Gourmet.sln", defina o "Gourmet.UI" como projeto de inicialização, compile e execute.

A aplicação rodará na porta http://localhost:6060.


Projetos na Solução :

Gourmet.ApplicationServices : Services e escopos de validações
Gourmet.Persistence: Infraestrutura de conexão com banco
Gourmet.Domain: Aplicação em Class Library com Modelos,  e interfaces de repositorios, services e Escopo de validação;
Gourmet.Tests: Aplicação de Testes de unidade;
Gourmet.UI: Interface web (Controlers).

#FrontEnd

Angular 4
Typescript
