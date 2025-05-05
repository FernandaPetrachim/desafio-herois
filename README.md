Desafio Front end e Back end de Heróis

🦸‍♀️ Desafio CRUD de Heróis — Backend + Frontend

✅ O que foi realizado:

Criei uma aplicação completa com backend em ASP.NET Core e frontend com Angular, permitindo o cadastro, listagem, edição e visualização de heróis com seus superpoderes.

🧠 Backend (ASP.NET Core Web API)
Estrutura baseada em controllers, DTOs e EF Core.

CRUD completo de heróis (GET, POST, PUT) com validações.

Heróis têm nome, data de nascimento, altura, peso e uma lista de superpoderes.

Utiliza AppDbContext com EF Core.

Integração com Swagger para documentação e testes de endpoints.

Para rodar o backend:

dotnet restore
dotnet build
dotnet run

Acesse a API no navegador:
📍 https://localhost:5001/swagger ou http://localhost:5000/swagger

🖥️ Frontend (Angular)
Criado com Angular standalone components.

Formulário para criar e editar heróis com binding via ngModel.

Integração com a API via chamadas HTTP (a serem configuradas).


Para rodar o frontend:

npm install       # Instala as dependências
ng serve          # Inicia o servidor Angular

Acesse no navegador:
📍 http://localhost:4200
