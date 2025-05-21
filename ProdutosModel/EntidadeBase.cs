namespace ProdutosModel;

public abstract class EntidadeBase
{
    public int Id { get; set; }
    public abstract string ExibirResumo();
}