public static class Banco
{
    public static List<Contrato> listaContratos { get; } = new List<Contrato>();   

    public static void SalvarContrato(Contrato contrato)
    {
        listaContratos.Add(contrato);
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
