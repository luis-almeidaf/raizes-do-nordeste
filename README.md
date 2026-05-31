# Raízes do Nordeste API

Esta API foi desenvolvida para o Projeto Multidisciplinar da trilha de Back-end. O objetivo é atender a uma rede de lojas em expansão, melhorando o atendimento ao cliente e fornecendo indicadores de qualidade. Além disso, a solução garante escalabilidade, segurança e qualidade no serviço prestado.

## Tecnologias Utilizadas

* Linguagem: C# (.NET 10)
* Banco de Dados: SQL Server
* Docker / Docker Compose

---

## Como Executar o Projeto

### Pré-requisitos

* Docker

Caso você não tenha o Docker instalado, ele pode ser encontrado aqui: [https://www.docker.com/](https://www.docker.com/)

Siga as instruções de instalação para o seu sistema operacional.

### Passo a Passo

1. **Clonar o repositório:** Abra o terminal/cmd na pasta onde deseja salvar o projeto.
2. **Executar o clone:** Digite o seguinte comando:
```bash
git clone https://github.com/luis-almeidaf/raizes-do-nordeste.git

```


3. **Acessar o diretório do projeto:** Entre na pasta do projeto com o comando:
```bash
cd raizes-do-nordeste

```


4. **Acessar a pasta principal:** Entre na pasta principal com o comando:
```bash
cd src

```


5. **Iniciar a aplicação:** Execute o projeto com o comando:
```bash
docker compose up

```



---

## Documentação da API

Uma vez que a aplicação esteja rodando, você pode acessar a documentação interativa do Swagger em:

http://localhost:5298/swagger/index.html

---
Se preferir é possível testar a API com o Postman.

Para facilitar os testes dos endpoints da API, seguem a coleção de rotas (Collection) e a configuração do ambiente local (Environment).

### 1. Baixar os arquivos do projeto
Os arquivos necessários estão localizados na pasta `postman` deste repositório. Você pode baixá-los diretamente através dos links abaixo:

* [Clique aqui para baixar a Collection](./postman/raizes-do-nordeste.postman_collection.json)
* [Clique aqui para baixar o Environment (Ambiente)](./postman/local.postman_environment.json)

* No canto superior clique no botão com ícone de download, chamado Download Raw File, e salvo os respectivos arquvios.
---

### 2. Importar no Postman

1. Abra o aplicativo do **Postman**.
2. No canto superior esquerdo da tela, clique no botão **Import** (ou use o atalho `Ctrl + O`).
3. Arraste e solte os dois arquivos JSON baixados para dentro da janela de importação, ou clique em **Files** para selecioná-los no seu computador.
4. Clique no botão **Import** para confirmar.

---

### 3. Selecionar e Configurar o Ambiente

1. No canto superior direito do Postman, localize um menu suspenso que por padrão exibe **No Environment**.
2. Clique nesse menu e selecione o ambiente correspondente ao projeto (ex: **Raízes do Nordeste - Local**).
3. escolha um endpoint e clique em **Send** para testar!