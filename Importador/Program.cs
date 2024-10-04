partial class Importador
{
    public static void Main(string[] args)
    {
        Executar();
    }

    static void Executar()
    {
        while (true)
        {
            Console.WriteLine("\tSelecione as opções do importador");
            Console.WriteLine("\t1 - Importar arquivos");
            Console.WriteLine("\t2 - Buscar arquivos na base");
            Console.WriteLine("\t3 - Deletar arquivos antigos");
            Console.WriteLine("\t4 - Mover arquivo para backup");
            Console.WriteLine("\t0 - Sair do importador");

            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    ImportarArquivos();
                    break;
                case "2":
                    Banco.GetContratos();
                    break;
                case "3":
                    DeletarArquivosDaPastaBackup();
                    break;
                case "4":
                    
                    MoverParaBackup();
                    break;
                case "0":
                    Console.WriteLine("Saindo do importador...");
                    return;
                default:
                    Console.WriteLine("Opção não disponível. Tente novamente...");
                    break;
            }
        }
    }
}
