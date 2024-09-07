using System.Globalization;
using Microsoft.EntityFrameworkCore;

using CsvHelper;

class Program
{
    static void Main(string[] args)
    {

     

        // Solicita ao usuário o caminho do arquivo CSV
        Console.WriteLine("Digite o caminho do arquivo CSV:");

        string caminhoArquivo = Console.ReadLine();

        if (string.IsNullOrEmpty(caminhoArquivo) || !File.Exists(caminhoArquivo))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        try
        {
            // Configura o contexto do banco de dados
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BOQ9G78\\SQLEXPRESS;Initial Catalog=ImportacaoContratosDB;Integrated Security=True;");

            using (var context = new DataContext(optionsBuilder.Options))
            {
                // Lê o arquivo CSV e importa os dados
                var contratos = new List<Contrato>();
                using (var reader = new StreamReader(caminhoArquivo))
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(new CultureInfo("pt-BR")) // Definindo pt-BR aqui
                {
                    Delimiter = ";", // Define o delimitador como ponto e vírgula
                    HeaderValidated = null, // Desabilita a validação de cabeçalhos
                    MissingFieldFound = null // Ignora campos ausentes
                }))
                {
                    // Registra o mapeamento personalizado
                    csv.Context.RegisterClassMap<ContratoMap>();

                    try
                    {
                        contratos = csv.GetRecords<Contrato>().ToList();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro durante a importação: {ex.Message}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine("Detalhes adicionais: " + ex.InnerException.Message);
                            Console.WriteLine("Detalhes da InnerException: " + ex.InnerException.StackTrace);
                        }
                    }


                    // Adiciona os contratos ao banco de dados
                    context.Contratos.AddRange(contratos);
                    context.SaveChanges();

                    // Adiciona um log de importação
                    var importacao = new Importacao
                    {
                        DataImportacao = DateTime.Now,
                        NomeArquivo = Path.GetFileName(caminhoArquivo), // Nome do arquivo importado
                        
                    };
                    context.Importacoes.Add(importacao);
                    context.SaveChanges();

                    Console.WriteLine("Importação concluída com sucesso.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante a importação: {ex.Message}");
        }
    }
}
