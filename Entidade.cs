using CsvHelper.Configuration;
using System.Globalization;

public class Contrato
{
    public int Id { get; set; }               // Chave primária
    public string Nome { get; set; }          // Nome  
    public string CPF { get; set; }            // CPF  
    public string NumeroContrato { get; set; }   //   contrato
    public string Produto { get; set; }       //   produto
    public DateTime Vencimento { get; set; }  // Data de vencimento
    public decimal Valor { get; set; }        // Valor do contrato
    public int DiasAtraso { get; set; }       // Da 
    public DateTime DataImportacao { get; set; } // Data da importação
    public string Usuario { get; set; }      // usuario que adicionou os dados 
    public string NomeArquivo { get; set; }    // Nome do arquivo 


}

public class Importacao
{
    public int Id { get; set; }                   // Chave primária
    public DateTime DataImportacao { get; set; } // Data da importação
    public string NomeArquivo { get; set; }    // Nome do arquivo 
    public string Usuario { get; set; }       // uusuario que adicionou os dados 

}

// Mapeamento personalizado para o CsvHelper
public class ContratoMap : ClassMap<Contrato>
{
    public ContratoMap()
    {
        Map(m => m.Id).Ignore(); // Ignora o campo Id
        Map(m => m.Nome);
        Map(m => m.CPF);
        Map(m => m.NumeroContrato).Name("Contrato"); // Mapeia a coluna "Contrato" do CSV para o campo NumeroContrato
        Map(m => m.Produto);
        Map(m => m.Vencimento)
            .TypeConverterOption.Format("dd/MM/yyyy") // Especifica o formato de data
            .TypeConverterOption.CultureInfo(new CultureInfo("pt-BR")); // Garante a cultura correta
        Map(m => m.Valor).TypeConverterOption.CultureInfo(new CultureInfo("pt-BR")); // Define o formato numérico correto
    }
}
