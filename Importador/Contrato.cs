

public class Contrato
{
    public Contrato(int cdContrato, int cdBanco, string contratoUnico, string cpfCnpj, string nome, string uf, double valorSaldoDevedor)
    {
        CdContrato = cdContrato;
        CdBanco = cdBanco;
        ContratoUnico = contratoUnico;
        CpfCnpj = cpfCnpj;
        Nome = nome;
        Uf = uf;
        ValorSaldoDevedor = valorSaldoDevedor;
    }

    public int CdContrato { get; }
    public int CdBanco { get; }
    public string ContratoUnico { get; }
    public string CpfCnpj { get; }
    public string Nome { get; }
    public string Uf { get; }
    public double ValorSaldoDevedor { get; set; }
    public DateTime DataHoraImportacao { get; } = DateTime.Now;

    public override string ToString()
    {
        return $"Contrato: {CdContrato}, CdBanco: {CdBanco}, Contrato Único: {ContratoUnico}, CPF/CNPJ: {CpfCnpj}, Nome: {Nome}, UF: {Uf}, Valor Saldo Devedor: {ValorSaldoDevedor}, Data e Hora de Importação: {DataHoraImportacao}";
    }
}
