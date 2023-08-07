# To Do - Case Neogrid

## Descrição

Sistema de gestão de tarefas (To do), com funcionalidades para adicionar uma nova tarefa, edição, exclução e marcar/desmarcar como concluída.

O sistema foi desenvolvido como uma aplicação Web e separada em estrura de camadas.

#### Principais Tecnologias

- C#
- .Net Framework 4.8
- Dapper
- MySQL

---

## Como utilizar

### Requisitos

Para realizar a execução do projeto, verifique antes se você possui os requisitos abaixo instalados seu sistema operacional.

- Framework 4.8 ou versão superior compatível
- Visual Studio
- MySQL

### Clonando o repositório

Primeiramente, realize o download do repositório para o seu computador.

```bash
git clone https://github.com/fernandosmace/TodoNeogrid.git
```

### Configurações

- Altere o campo a ConnectionString no arquivo **Web.Config** localizado na raíz do projeto Web para a do seu banco de dados MySql.

```xml
  <connectionStrings>
    <add name="ConnectionString" connectionString="Server={server},3306;User Id={usuario};Password={senha}" />
  </connectionStrings>
```

### Executando o projeto

Após o apontamento da connection string para o banco de dados MySQL, é necessário apenas executar a aplicação no Visual Studio, ou realizar a publicação.

Ao ser iniciada a aplicação criará o banco de dados automaticamente. E então, será carregada no navegador.

---
## Informações do Desenvolvedor

- LinkedIn - [Fernando Macedo](https://www.linkedin.com/in/fsoaresmacedo/)
