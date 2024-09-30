
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



partial class Importador
{
    static void ImportarArquivos()
    {
        var enderecoDoArquivo = "contracts.txt";
        Console.WriteLine($"Total de Contratos a serem importados: {File.ReadAllLines(enderecoDoArquivo).Length}");
        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            while(!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contrato = ConverterStringParaContrato(linha!);
                
                Banco.SalvarContrato(contrato);
            }
            Console.WriteLine("Contratos Importados!");
        }
    }

    static Contrato ConverterStringParaContrato(string linha)
    {
        var campos = linha.Split(',');

        var cdContrato = campos[0];
        var cdBanco = campos[1];
        var contratoUnico = campos[2];
        var cpfCnpj = campos[3];
        var nome = campos[4];
        var uf = campos[5];
        var valorSaldoDevedor = campos[6].Replace('.', ',');

        var contrato = new Contrato(int.Parse(cdContrato), int.Parse(cdBanco), contratoUnico, cpfCnpj, nome, uf, double.Parse(valorSaldoDevedor));

        return contrato;
    }
}
