# Blog Simples

## Descrição
Este é um projeto de um **blog simples**, onde usuários podem **visualizar, criar, editar e excluir postagens**. O projeto foi desenvolvido utilizando **.NET** e **Entity Framework Core** para a parte de backend, com uma interface web responsiva utilizando **Bootstrap 5.2.3**.

A aplicação possui autenticação de usuário, permitindo que usuários registrados possam gerenciar suas postagens. Apenas usuários autenticados podem criar, editar ou excluir postagens. Visitantes do site podem visualizar todas as postagens, mas não podem editá-las ou excluí-las.

## Tecnologias Usadas
- **.NET 7+**: Framework para o desenvolvimento da aplicação.
- **Entity Framework Core**: ORM utilizado para comunicação com o banco de dados.
- **SQL Server**: Banco de dados utilizado para armazenar informações sobre os posts e usuários.
- **Bootstrap 5.2.3**: Framework CSS para a criação de uma interface web moderna e responsiva.
- **JavaScript (jQuery)**: Usado para algumas interações dinâmicas na interface.

## Funcionalidades

- **Autenticação de Usuários**:
  - Usuários podem **se registrar** e **fazer login**.
  - Após o login, o usuário pode acessar e gerenciar suas postagens.
  
- **Gerenciamento de Postagens**:
  - Usuários autenticados podem **criar**, **editar** e **excluir** suas próprias postagens.
  - O sistema oferece uma interface simples para adicionar um título e conteúdo à postagem.
  - As postagens são armazenadas no banco de dados com a data de criação e o autor (usuário logado).

- **Visualização de Postagens**:
  - Qualquer visitante pode **visualizar as postagens** existentes.
  - As postagens são exibidas com título, conteúdo inicial (primeiros 100 caracteres) e data de criação.
  
- **Interface Web Simples**:
  - A interface foi projetada para ser simples e fácil de usar.
  - Os posts recentes são exibidos na página principal.
  - Há um modal para adicionar novas postagens, acessível através de um botão fixo na tela.

## Estrutura do Banco de Dados

O sistema utiliza um banco de dados **SQL Server** para armazenar as informações sobre os posts e usuários. A tabela `Posts` contém os seguintes campos:

- **Id** (int): Identificador único do post (auto-incremento).
- **Title** (nvarchar(255)): Título do post.
- **Content** (text): Conteúdo do post.
- **CreatedAt** (datetime): Data de criação do post.
- **AuthorId** (int): ID do autor, que é um relacionamento com a tabela de usuários.

A tabela de usuários não está explicitamente definida neste README, mas assume-se que os usuários são gerenciados com o sistema de autenticação integrado ao .NET.

## Como Rodar o Projeto

### Pré-Requisitos
- **.NET SDK 7+** instalado na sua máquina.
- **SQL Server** ou **SQL Server Express** para o banco de dados.

### Passos
1. Clone este repositório:
   ```bash
   git clone <https://github.com/WebDev5231/coding-test-blog.git>
