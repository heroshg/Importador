public static class Banco
{
    public static List<Contrato> listaContratos { get; } = new List<Contrato>();   

    

    public static void SalvarLoteDeContratos(List<Contrato> listaContratosEmLote)
    {
        try
        {
            foreach( var contrato in listaContratosEmLote)
            {
                listaContratos.Add(contrato);
            }
            Console.WriteLine("Arquivos em lote importados com sucesso!");

        } catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static void GetContratos()
    {
        if(listaContratos is not null)
        {
            
            foreach (var contrato in listaContratos)
            {
                Console.WriteLine(contrato);
            }
        }
        Console.WriteLine("Ainda não há contratos a serem exibidos!");
    }
}
