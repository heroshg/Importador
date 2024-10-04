using System;
using System.Collections.Generic;
using System.IO;

partial class Importador
{
    static void ImportarArquivos()
    {
        var enderecoDoArquivo = "contracts.txt";

        if (!File.Exists(enderecoDoArquivo))
        {
            Console.WriteLine("O arquivo não foi encontrado.");
            return;
        }

        bool importacaoBemSucedida = true;

        try
        {
            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                using (var leitor = new StreamReader(fluxoDeArquivo))
                {
                    var loteTamanho = 100; 
                    List<Contrato> contratosLote = new List<Contrato>();

                    Console.WriteLine($"Total de Contratos a serem importados: {File.ReadAllLines(enderecoDoArquivo).Length}");

                    while (!leitor.EndOfStream)
                    {
                        try
                        {
                            var linha = leitor.ReadLine();
                            var contrato = ConverterStringParaContrato(linha!);
                            contratosLote.Add(contrato);

                            if (contratosLote.Count >= loteTamanho)
                            {
                                Banco.SalvarLoteDeContratos(contratosLote);
                                contratosLote.Clear();
                            }
                        }
                        catch (Exception ex)
                        {
                            importacaoBemSucedida = false;
                            Console.WriteLine($"Erro ao importar contrato: {ex.Message}");
                            // Adicionar logging, se necessário
                        }
                    }

                    if (contratosLote.Count > 0)
                    {
                        Banco.SalvarLoteDeContratos(contratosLote);
                    }

                    Console.WriteLine("Contratos Importados!");
                }
            }

            if (!importacaoBemSucedida)
            {
                Console.WriteLine("Importação incompleta. O arquivo não será deletado.");
            }
            
            
          
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao acessar o arquivo: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante a importação: {ex.Message}");
        }
    }

    static void MoverParaBackup()
    {
        var enderecoDoArquivo = "contracts.txt";
        var pastaBackup = "backup/";

        try
        {
            if (!File.Exists(enderecoDoArquivo))
            {
                Console.WriteLine("Arquivo não encontrado, não foi possível copiar para backup.");
                return;
            }

            if (!Directory.Exists(pastaBackup))
            {
                Directory.CreateDirectory(pastaBackup);
            }

            var nomeArquivo = Path.GetFileName(enderecoDoArquivo);
            var caminhoDestino = Path.Combine(pastaBackup, nomeArquivo);

            File.Copy(enderecoDoArquivo, caminhoDestino, overwrite: true);
            Console.WriteLine("Arquivo copiado para a pasta de backup.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao copiar o arquivo: {ex.Message}");
        }
    }

    static void DeletarArquivosDaPastaBackup()
    {
        var pastaBackup = "backup/";

        if (!Directory.Exists(pastaBackup))
        {
            Console.WriteLine("A pasta de backup não possui nenhum arquivo.");
            return;
        }
        var arquivos = Directory.GetFiles(pastaBackup);

        foreach (var arquivo in arquivos)
        {
            try
            {
                File.Delete(arquivo);
                Console.WriteLine($"Arquivo {Path.GetFileName(arquivo)} deletado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o arquivo {Path.GetFileName(arquivo)}: {ex.Message}");
            }
        }

        Console.WriteLine("Todos os arquivos na pasta backup foram deletados.");
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
