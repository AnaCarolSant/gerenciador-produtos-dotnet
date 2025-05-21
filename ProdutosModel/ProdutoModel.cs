namespace ProdutosModel;

public class ProdutoModel : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }

    private string CodigoInterno { get; set; } = "ABC123";
    protected string Observacao { get; set; } = string.Empty;

    public override string ExibirResumo()
    {
        return $"{Nome} - R$ {Preco}";
    }
}
