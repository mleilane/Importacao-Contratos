<h1> 📌 Importação de Contratos  </h1>

<p> Este projeto é uma aplicação console em C# que autentica o usuário, importa dados de contratos a partir de um arquivo CSV e salva essas informações em um banco de dados SQL Server. 
  Além disso, a aplicação registra logs de importação contendo a data, o nome do arquivo e o nome do usuário que realizou a operação. </p>

<h2> Funcionalidades </h2>

* Autenticação de usuário.
* Importação de contratos a partir de arquivos CSV com tratamento de acentuação e formatação.
* Cálculo de dias de atraso com base na data de vencimento.
* Registro da data de importação, nome do arquivo importado e nome do usuário.
* Armazenamento dos contratos e logs de importação em um banco de dados SQL Server.


<h2> Estrutura do Projeto </h2>

* Program.cs: Contém a lógica principal da aplicação, responsável por autenticar o usuário, importar os dados do arquivo CSV e salvar as informações no banco de dados.
* Entidade.cs: Define as classes Contrato e Importacao, que representam as entidades salvas no banco de dados.
* ContratoMap.cs: Mapeia as colunas do arquivo CSV para os atributos da classe Contrato.
* DataContext.cs: Configura o contexto do banco de dados, mapeando as tabelas Contratos e Importacoes.
* Autenticacao.cs: Implementa a lógica de autenticação para verificar as credenciais do usuário.


<h2> Como Executar: </h2>

<h3>  Pré-requisitos:</h3>

* .NET SDK 6.0 ou superior.
* SQL Server instalado e configurado.


<h3> Configuração do Banco de Dados:</h3>

1. Atualize a string de conexão com o SQL Server no arquivo Program.cs dentro da função Main:


   ```sh
   optionsBuilder.UseSqlServer("Data Source=SEU_SERVIDOR;Initial Catalog=ImportacaoContratosDB;Integrated Security=True;");


2. Certifique-se de que o banco de dados ImportacaoContratosDB foi criado no SQL Server.
   

<h3> Configuração do CSV: </h3>

1. O arquivo CSV deve ser separado por ponto e vírgula (;).
2. O formato da data deve seguir o padrão dd/MM/yyyy.
3. Exemplo de arquivo CSV:


   ```sh
   Nome;CPF;Contrato;Produto;Vencimento;Valor
   João da Silva;12345678900;123456;Produto A;15/08/2023;1500,00


<h3> Executando a Aplicação: </h3>

* Compile e execute a aplicação no terminal.
* Insira suas credenciais de autenticação.
* Informe o caminho completo do arquivo CSV a ser importado.
* A aplicação processará o arquivo e salvará as informações no banco de dados.

<h2> Estrutura do Banco de Dados </h2>

<P> O banco de dados possui duas tabelas:</P>

<h3> Contratos: </h3>

* Id (int): Chave primária.
* Nome (string): Nome do cliente.
* CPF (string): CPF do cliente.
* NumeroContrato (string): Número do contrato.
* Produto (string): Produto contratado.
* Vencimento (DateTime): Data de vencimento do contrato.
* Valor (decimal): Valor do contrato.
* DiasAtraso (int): Dias de atraso com base no vencimento.
* DataImportacao (DateTime): Data em que o contrato foi importado.
* Usuario (string): Usuário que realizou a importação.
* NomeArquivo (string): Nome do arquivo CSV importado.

<h3>  Importacoes: </h3>

* Id (int): Chave primária.
* DataImportacao (DateTime): Data da importação.
* NomeArquivo (string): Nome do arquivo importado.
* Usuario (string): Usuário que realizou a importação.

  
