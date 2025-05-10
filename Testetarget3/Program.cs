using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

class Faturamento
{
    public int dia { get; set; }
    public double valor { get; set; }
}

class Program
{
    static void Main()
    {
        // Lê o conteúdo do arquivo JSON
        string json = File.ReadAllText("faturamento.json");

        // Converte o JSON para uma lista de objetos
        List<Faturamento> dados = JsonSerializer.Deserialize<List<Faturamento>>(json);

        // Filtra dias com faturamento > 0
        var diasUteis = dados.Where(d => d.valor > 0).ToList();

        double menor = diasUteis.Min(d => d.valor);
        double maior = diasUteis.Max(d => d.valor);
        double media = diasUteis.Average(d => d.valor);
        int diasAcimaDaMedia = diasUteis.Count(d => d.valor > media);

        Console.WriteLine($"Menor faturamento: R$ {menor:F2}");
        Console.WriteLine($"Maior faturamento: R$ {maior:F2}");
        Console.WriteLine($"Dias com faturamento acima da média mensal ({media:F2}): {diasAcimaDaMedia}");
    }
}
