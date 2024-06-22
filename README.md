## Descrição

Este projeto é uma API de produtos para teste da empresa Rtx Tech, que utiliza Swagger para documentação e teste de endpoints. O projeto é composto por duas partes principais: `ProductApi` e `ProductApp`.

### Funcionalidades

- **Lista de Produtos**: Exibe uma lista de produtos mostrando foto, nome, uma breve descrição e um botão para exibir detalhes.
- **Exibição de Detalhes**: Ao clicar no botão, um modal é exibido com os detalhes do produto: foto, descrição, preço.
- **Filtro de Produtos**: Uma caixa de texto para realizar o filtro de produtos pelo nome ou descrição.
  
## Como Rodar

### 1. Clonar o Repositório

Primeiro, clone o repositório para sua máquina local.

```bash
git clone git@github.com:DevMontovam/ProductAppTest.git
cd seu-repositorio
```

###2. Rodar a API de Produtos (ProductApi)

Segundo, rode os seguintes comandos para iniciar o Back.

```bash
cd /ProductApi
dotnet run
```
(O Swagger abrirá na porta 5001)

###3. Rodar o Aplicativo de Produtos (ProductApp)

Terceiro, rode os seguintes comandos para iniciar o Front.

```bash
cd /ProductApp
dotnet run
```

###4. Acessar o front (localhost)

Quarto, acesso o localhost na porta 5002.

```bash
https://localhost:5002
