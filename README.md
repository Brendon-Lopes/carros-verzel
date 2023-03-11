# Carros Verzel

# Descrição

Sistema de catálogo de carros a venda. Com o login administrativo é possível cadastrar, editar e excluir carros do sistema.

# Principais tecnologias utilizadas

<strong>Backend:</strong> C#, ASP.NET Core 6.0, Entity Framework Core 6.0, BCrypt, Fluent Validation, Docker.

<strong>Frontend:</strong> React + Vite + TypeScript, Tailwind CSS, Axios, React-cookie, React-router-dom, Yup, Docker.

<strong>Banco de dados:</strong> SQL Server. (Dockerizado para facilitar a execução do projeto).

# Como executar o projeto

## Pré-requisitos: Docker, Docker Compose.

## Passo a passo

Clonar o repositório:

```bash
git clone git@github.com:Brendon-Lopes/carros-verzel.git
```

Entrar na pasta do projeto:

```bash
cd carros-verzel
```

Rodar com docker compose (Pode demorar um pouco pra iniciar):

```bash
docker-compose up -d
```

O projeto estará disponível em http://localhost:3000

A API estará disponível em http://localhost:5000

A documentação da API estará disponível em http://localhost:5000/swagger

## Login administrativo:

### Email:

```bash
admin@mail.com
```

### Senha:

```bash
123456
```
